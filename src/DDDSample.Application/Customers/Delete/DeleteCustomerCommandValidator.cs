using System;
using FluentValidation;

namespace DDDSample.Application.Customers.Delete
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();
        }
    }
}

