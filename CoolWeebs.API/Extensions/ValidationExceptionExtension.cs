﻿using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoolWeebs.API.Extensions
{
    public static class ValidationExceptionExtension
    {
        public static ValidationProblemDetails ToProblemDetails(this ValidationException modelState)
        {
            var validationProblemDetails = new ValidationProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "One or more validation errors occurred.",
                Status = (int)HttpStatusCode.BadRequest,
            };

            foreach (var error in modelState.Errors)
            {
                validationProblemDetails.Errors.TryAdd(error.PropertyName, new[] { error.ErrorMessage });
            }

            return validationProblemDetails;
        }
    }
}
