﻿using System;
using FluentValidation;

namespace DDDSample.Application.Customers.Update
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(r => r.Id)
               .NotEmpty();

            RuleFor(r => r.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(r => r.LastName)
                 .NotEmpty()
                 .MaximumLength(50)
                 .WithName("Last Name");

            RuleFor(r => r.Email)
                 .NotEmpty()
                 .EmailAddress()
                 .MaximumLength(255);

            RuleFor(r => r.PhoneNumber)
                 .NotEmpty()
                 .MaximumLength(9)
                 .WithName("Phone Number");

            RuleFor(r => r.Country)
                .NotEmpty()
                .MaximumLength(3);

            RuleFor(r => r.Line1)
                .NotEmpty()
                .MaximumLength(20)
                .WithName("Addres Line 1");

            RuleFor(r => r.Line2)
                .MaximumLength(20)
                .WithName("Addres Line 2");

            RuleFor(r => r.City)
                .NotEmpty()
                .MaximumLength(40);

            RuleFor(r => r.State)
                .NotEmpty()
                .MaximumLength(40);

            RuleFor(r => r.ZipCode)
                .NotEmpty()
                .MaximumLength(10)
                .WithName("Zip Code");

            RuleFor(r => r.Active)
                .NotNull();
        }
    }
}

