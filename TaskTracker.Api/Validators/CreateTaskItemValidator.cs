using FluentValidation;
using Microsoft.Extensions.Localization;
using TaskTracker.Api.Models.Requests;
using TaskTracker.Application.Utilities;

namespace TaskTracker.Api.Validators
{

    public class CreateTaskItemRequestValidator : AbstractValidator<CreateTaskItemRequest>
    {
        public CreateTaskItemRequestValidator(IStringLocalizer<GlobalResource> localizer)
        {
            // Checking for null only will check for empty string in business logic
            RuleFor(t => t.Title)
                .NotEmpty()
                .WithMessage(localizer.GetString(ErrorConstants.TitleRequired));
                
            RuleFor(t => t.Title)
                .MaximumLength(100)
                .WithMessage(localizer.GetString(ErrorConstants.TitleMaxLength));

            RuleFor(t => t.Status)
                .Must(status => status is Constants.Todo or Constants.InProgress or Constants.Done)
                .WithMessage(localizer.GetString(ErrorConstants.InvalidStatus));
            
            RuleFor(t => t.Title)
                .NotEmpty()
                .When( g => g.Status.Equals(Constants.Done))
                .WithMessage(localizer.GetString(ErrorConstants.CannotMarkDone));
        }
   
    }
}