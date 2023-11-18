using CoolWeebs.API.Exceptions;
using FluentValidation;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace CoolWeebs.API.Extensions
{
    public static class ControllerExtension
    {
        public static IActionResult ToResponse<TResult>(this ControllerBase controller, Result<TResult> result)
        {
            var actionName = controller.RouteData.Values["action"]?.ToString();
            var controllerName = controller.RouteData.Values["controller"]?.ToString();
            var uri = controller.Url.Action(actionName, controllerName);

            return result.Match<IActionResult>(
                success => actionName switch
                {
                    "Post" => controller.Created(uri!, success),        
                    "Get" or "Patch" => controller.Ok(success),
                    "Delete" => controller.NoContent(),
                    _ => controller.StatusCode(500)
                },
                failure => failure switch
                {
                    ValidationException validationException => controller.BadRequest(validationException.ToProblemDetails()),
                    ConflictException conflictException => controller.Conflict(conflictException.ToProblemDetails()),
                    NotFoundException notFoundException => controller.NotFound(notFoundException.ToProblemDetails()),
                    _ => controller.StatusCode(500, failure.ToProblemDetails())
                });
        }
    }
}
