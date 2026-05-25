using System.Net;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Microsoft.Extensions.Localization;
using TaskTracker.Api.Models.Requests;
using TaskTracker.Api.Models.Responses;

namespace TaskTracker.Api.Validators
{
    
    public class TaskItemRequestValidator : AbstractValidator<CreateTaskItemRequest>
    {
        public TaskItemRequestValidator(IStringLocalizer<GlobalResource> localizer)
        {
            RuleFor(t => t.Title)
                .NotEmpty()
                .WithMessage(localizer.GetString("TITLE_REQUIRED"));
                
            RuleFor(t => t.Title)
                .MaximumLength(100)
                .WithMessage(localizer.GetString("TITLE_MAX_LENGTH_100"));
            
        }
   
    }
}


