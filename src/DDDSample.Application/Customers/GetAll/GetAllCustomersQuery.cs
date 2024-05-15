using System;
using DDDSample.Application.Customers.Common;
using ErrorOr;
using MediatR;

namespace DDDSample.Application.Customers.GetAll
{
    public record GetAllCustomersQuery() : IRequest<ErrorOr<IReadOnlyList<CustomerResponse>>>;
}

