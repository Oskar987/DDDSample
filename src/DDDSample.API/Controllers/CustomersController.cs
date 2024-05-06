using DDDSample.Application.Customers.Create;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDDSample.API.Controllers;

[Route("customers")]
public class Customers : ApiController
{
    private readonly ISender _mediator;

    public Customers(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            customerId => Ok(customerId),
            errors => Problem(errors)
        );
    }
}

