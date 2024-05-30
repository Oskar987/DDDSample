using DDDSample.Application.Users.Common;
using DDDSample.Application.Users.Login;
using DDDSample.Infrastructure.Auth.Abstractions;
using DDDSample.Infrastructure.Models;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DDDSample.Infrastructure.Auth.Login
{
    public class LoginHandler : IRequestHandler<LoginQuery, ErrorOr<UserResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJWTGenerator _jwtGenerator;

        public LoginHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJWTGenerator jWTGenerator)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _jwtGenerator = jWTGenerator ?? throw new ArgumentNullException(nameof(jWTGenerator));
        }

        public async Task<ErrorOr<UserResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return Domain.DomainErrors.Errors.User.UserUnauthorized;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                return new UserResponse(user.DisplayName, _jwtGenerator.CreateToken(user), user.UserName);
            }

            return Domain.DomainErrors.Errors.User.UserUnauthorized;
        }
    }
}

