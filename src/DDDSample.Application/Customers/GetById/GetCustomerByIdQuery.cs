using DDDSample.Application.Customers.Common;
using ErrorOr;
using MediatR;

namespace DDDSample.Application.Customers.GetById
{
    public record GetCustomerByIdQuery(Guid Id) : IRequest<ErrorOr<CustomerResponse>>;
}

