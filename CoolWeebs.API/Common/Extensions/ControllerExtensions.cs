using FluentValidation;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoolWeebs.API.Common.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ToResponse<TResult>(this Result<TResult> result, HttpStatusCode statusType)
        {
            return result.Match<IActionResult>(
                success =>
                {
                    if (statusType == HttpStatusCode.Created)
                    {
                        return new CreatedAtActionResult("", "", "", success);
                    } else if (statusType == HttpStatusCode.OK)
                    {
                        return new OkObjectResult(success);
                    }
                    else
                    {
                        return new StatusCodeResult(500);
                    }
                },
                failure =>
                {
                    if (failure is ValidationException validationException)
                    {
                        return new BadRequestObjectResult(validationException.ToProblemDetails());
                    }
                    else
                    {
                        return new StatusCodeResult(500);
                    }
                });
        }
    }
}
