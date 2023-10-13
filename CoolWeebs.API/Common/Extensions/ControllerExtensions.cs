﻿using CoolWeebs.API.Common.Exceptions;
using FluentValidation;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoolWeebs.API.Common.Extensions
{
    public static class ControllerExtensions
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
                    _ => controller.StatusCode(500)
                },
                failure => failure switch
                {
                    ValidationException validationException => controller.BadRequest(validationException.ToProblemDetails()),
                    ConflictException conflictException => controller.Conflict(conflictException.ToProblemDetails()),
                    _ => controller.StatusCode(500)
                });
        }
    }
}
