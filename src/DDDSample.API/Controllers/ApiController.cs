﻿using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using DDDSample.API.Common.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DDDSample.API.Controllers;

public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0)
        {
            return Problem();
        }

        if (errors.All(e => e.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);
        }

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;
        return Problem(errors[0]);
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };

        return Problem(statusCode: statusCode, title: error.Description);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(error.Code, error.Description);
        }

        return ValidationProblem(modelStateDictionary);
    }
}

