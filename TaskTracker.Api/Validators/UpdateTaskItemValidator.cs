
using FluentValidation;
using Microsoft.Extensions.Localization;
using TaskTracker.Api.Models.Requests;
using TaskTracker.Application.Utilities;

namespace TaskTracker.Api.Validators
{
    
    public class UpdateTaskItemRequestValidator : AbstractValidator<UpdateTaskItemRequest>
    {
        public UpdateTaskItemRequestValidator(IStringLocalizer<GlobalResource> localizer)
        {
            RuleFor(t => t.Title)
                .Empty()
                .WithMessage(localizer.GetString("TITLE_REQUIRED"));
                
            RuleFor(t => t.Title)
                .MaximumLength(100)
                .WithMessage(localizer.GetString("TITLE_MAX_LENGTH_100"));

            RuleFor(t => t.Status)
                .Must(status => status is Constants.Todo or Constants.InProgress or Constants.Done)
                .WithMessage(localizer.GetString("INVALID_STATUS"));
            
                
            RuleFor(t => t.Title)
                .NotEmpty()
                .When( g => g.Status.Equals(Constants.Done))
                .WithMessage(localizer.GetString("CANNOT_MARK_DONE"));
            
        }
   
    }
}


