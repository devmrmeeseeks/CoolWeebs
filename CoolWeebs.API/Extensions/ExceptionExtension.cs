using CoolWeebs.API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoolWeebs.API.Extensions
{
    public static class ExceptionExtension
    {
        public static ProblemDetails ToProblemDetails(this Exception modelState)
        {
            var validationProblemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = modelState switch
                {
                    ConflictException => "Conflict",
                    NotFoundException => "Not Found",
                    _ => "Server error"
                },
                Status = modelState switch
                {
                    ConflictException => (int)HttpStatusCode.Conflict,
                    NotFoundException =>  (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError
                },
                Detail = modelState.Message
            };

            return validationProblemDetails;
        }
    }
}
