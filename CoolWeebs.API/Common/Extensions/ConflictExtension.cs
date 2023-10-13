using CoolWeebs.API.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoolWeebs.API.Common.Extensions
{
    public static class ConflictExtension
    {
        public static ValidationProblemDetails ToProblemDetails(this ConflictException modelState)
        {
            var validationProblemDetails = new ValidationProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "One or more validation errors occurred.",
                Status = (int)HttpStatusCode.Conflict,
                Errors = { { "conflict", new[] { modelState.Message } } }
            };

            return validationProblemDetails;
        }
    }
}
