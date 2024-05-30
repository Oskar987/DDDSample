using DDDSample.Application.Customers.Create;
using DDDSample.Application.Customers.Delete;
using DDDSample.Application.Customers.GetAll;
using DDDSample.Application.Customers.GetById;
using DDDSample.Application.Customers.Update;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDSample.API.Controllers;

[Route("customers")]
[Authorize]
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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customersResult = await _mediator.Send(new GetAllCustomersQuery());

        return customersResult.Match(
            customers => Ok(customers),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var customerResult = await _mediator.Send(new GetCustomerByIdQuery(id));

        return customerResult.Match(
            customer => Ok(customer),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerCommand command)
    {
        if (command.Id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("Customer.UpdateInvalid", "The request Id does not match with the url Id.")
            };
            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            customerId => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteCustomerCommand(id));

        return deleteResult.Match(
            customerId => NoContent(),
            errors => Problem(errors)
        );
    }
}

