using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoolWeebs.API.Common.Extensions
{
    public static class BadRequestExtension
    {
        public static ValidationProblemDetails ToProblemDetails(this ValidationException modelState)
        {
            var validationProblemDetails = new ValidationProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "One or more validation errors occurred.",
                Status = (int)HttpStatusCode.BadRequest,
            };

            if (modelState.Errors.Count() == 0)
            {
                validationProblemDetails.Errors.Add("Error", new[] { modelState.Message });
                return validationProblemDetails;
            }

            foreach (var error in modelState.Errors)
            {
                validationProblemDetails.Errors.Add(error.PropertyName, new[] { error.ErrorMessage });
            }

            return validationProblemDetails;
        }
    }
}
