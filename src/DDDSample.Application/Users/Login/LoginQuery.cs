using DDDSample.Application.Users.Common;
using ErrorOr;
using MediatR;

namespace DDDSample.Application.Users.Login
{
	public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<UserResponse>>;
}

