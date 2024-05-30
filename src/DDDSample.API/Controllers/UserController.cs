using DDDSample.Application.Users.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDDSample.API.Controllers
{
    [Route("users")]
    public class Users : ApiController
    {
        private readonly ISender _mediator;

        public Users(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginQuery query)
        {
            var result = await _mediator.Send(query);

            return result.Match(
                user => Ok(user),
                errors => Problem(errors));
        }
    }
}

