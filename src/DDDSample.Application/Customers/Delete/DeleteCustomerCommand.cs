using System;
using ErrorOr;
using MediatR;

namespace DDDSample.Application.Customers.Delete
{
    public record DeleteCustomerCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}

