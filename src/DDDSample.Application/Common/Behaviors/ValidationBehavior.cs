﻿using System;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace DDDSample.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                return await next();
            }

            var validatorResult = await _validator.ValidateAsync(request, cancellationToken);


            if (validatorResult.IsValid)
            {
                return await next();
            }

            var errors = validatorResult.Errors
                .ConvertAll(validationFailure => Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));

            return (dynamic)errors;
        }
    }
}

