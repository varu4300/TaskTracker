using System.Net;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskTracker.Api.Models.Responses;

namespace TaskTracker.Api.Utilities.Filters;

public class CustomValidation<T> : IAsyncActionFilter
{
    private readonly IValidator<T> _validator;

    public CustomValidation(IValidator<T> validator)
    {
        _validator = validator;
    }

    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        var argument = context.ActionArguments
            .Values
            .OfType<T>()
            .FirstOrDefault();

        if (argument == null)
        {
            await next();
            return;
        }

        ValidationResult validationResult =
            await _validator.ValidateAsync(argument);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(e => e.ErrorMessage)
                .ToList();

            var response = new BaseApiResponse<object>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = string.Join(",  ", errors),
                Result = null
            };


            context.Result = new JsonResult(response);
            return;
        }

        await next();
    }
}