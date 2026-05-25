using FluentValidation.TestHelper;
using Microsoft.Extensions.Localization;
using Moq;
using TaskTracker.Api;
using TaskTracker.Api.Models.Requests;
using TaskTracker.Api.Validators;
using TaskTracker.Application.Utilities;
using TaskTracker.Tests.Setup;
using TaskTracker.Tests.Utilities;

namespace TaskTracker.Tests.UnitTests.Validators
{

    public class CreateTaskItemValidatorTests
    {
        
        private readonly CreateTaskItemRequestValidator _validator;
        
        
        public CreateTaskItemValidatorTests()
        {
            var localizerMock = new Mock<IStringLocalizer<GlobalResource>>();
            
            LocalizerSetup.Configure(localizerMock);
            
            _validator = new CreateTaskItemRequestValidator(localizerMock.Object);
        }


        [Fact]
        public void Title_Field_Should_Fail_With_Title_Required_Error()
        {
            // Arrange
            var model = new CreateTaskItemRequest
            {
                Title = "",
                Status = Constants.Todo,
                Description = "Description",
                DueDate = DateTime.Today
            };

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Title)
                .WithErrorMessage(ErrorMessageConstants.TitleMessage);
        }
        
        [Fact]
        public void Status_Should_Fail_With_Invalid_Status_Error()
        {
            // Arrange
            var model = new CreateTaskItemRequest
            {
                Title = "Test title",
                Status = "Something",
                Description = "Description",
                DueDate = DateTime.Today
            };

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Status)
                .WithErrorMessage(ErrorMessageConstants.InvalidStatusMessage);

        }
        
        [Fact]
        public void Title_Should_Fail_With_Max_Length_Error()
        {
            // Arrange
            var model = new CreateTaskItemRequest
            {
                Title = "Test fwejfiowejfoiwejfiowijfoiwfjiowfjowejfwoeijfwoejfoiwejfoweijfoiwejfoiwejfiowejfiojweoifjweiofjweiojfiowejfiowejfiowejfiojweiofjweiofjiowejfiowejfiowejofijweiofjweiojfiowejfowiejfoiwejoifjweiofhsekjcbvywgqw7dgqwukbfiuwehfqwuhjfjklnxuqghidfughqwiuhgiuqhfuiqwhfuihqiufhqiufhuiehft78qyf78qwhrbcg8aqcgkqwbfduqwghrughqw7fbcifgwegf",
                Status = Constants.InProgress,
                Description = "Description",
                DueDate = DateTime.Today
            };

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Title)
                .WithErrorMessage(ErrorMessageConstants.TitleMaxLengthMessage);

        }
        
        [Fact]
        public void Business_Transition_Rule_Should_Return_False()
        {
            // Arrange
            var model = new CreateTaskItemRequest
            {
                Title = "",
                Status = Constants.Done,
                Description = "Description",
                DueDate = DateTime.Today
            };

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Title)
                .WithErrorMessage(ErrorMessageConstants.TitleMessage);
            
            result.ShouldHaveValidationErrorFor(x => x.Title)
                .WithErrorMessage(ErrorMessageConstants.CannotMarkDoneMessage);
        }
        
        [Fact]
        public void All_Validations_Pass()
        {
            // Arrange
            var model = new CreateTaskItemRequest
            {
                Title = "This is a test",
                Status = Constants.Done,
                Description = "Description",
                DueDate = DateTime.Today
            };

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

    }
}