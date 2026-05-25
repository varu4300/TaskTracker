using Microsoft.Extensions.Localization;
using Moq;
using TaskTracker.Api;
using TaskTracker.Api.Validators;
using TaskTracker.Application.Utilities;
using TaskTracker.Tests.Utilities;

namespace TaskTracker.Tests.Setup
{

    public static class LocalizerSetup
    {
        public static void Configure(Mock<IStringLocalizer<GlobalResource>> localizerMock)
        {
            localizerMock
                .Setup(x => x[ErrorConstants.TitleRequired])
                .Returns(new LocalizedString(ErrorConstants.TitleRequired, ErrorMessageConstants.TitleMessage));
            
            localizerMock
                .Setup(x => x[ErrorConstants.TitleMaxLength])
                .Returns(new LocalizedString(ErrorConstants.TitleMaxLength, ErrorMessageConstants.TitleMaxLengthMessage));
            
            localizerMock
                .Setup(x => x[ErrorConstants.InvalidStatus])
                .Returns(new LocalizedString(ErrorConstants.InvalidStatus, ErrorMessageConstants.InvalidStatusMessage));
            
            localizerMock
                .Setup(x => x[ErrorConstants.CannotMarkDone])
                .Returns(new LocalizedString(ErrorConstants.CannotMarkDone, ErrorMessageConstants.CannotMarkDoneMessage));
            
            localizerMock
                .Setup(x => x[ErrorConstants.TaskNotFound])
                .Returns(new LocalizedString(ErrorConstants.TaskNotFound, ErrorMessageConstants.TaskNotFound));
            
            localizerMock
                .Setup(x => x[ErrorConstants.ServerError])
                .Returns(new LocalizedString(ErrorConstants.ServerError, ErrorMessageConstants.ServerError));
           
        }
    }
}