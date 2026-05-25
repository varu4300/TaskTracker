using Microsoft.Extensions.Localization;
using Moq;
using TaskTracker.Api;
using TaskTracker.Api.Validators;
using TaskTracker.Tests.Utilities;

namespace TaskTracker.Tests.Setup
{

    public static class LocalizerSetup
    {
        public static void Configure(Mock<IStringLocalizer<GlobalResource>> localizerMock)
        {
            localizerMock
                .Setup(x => x["TITLE_REQUIRED"])
                .Returns(new LocalizedString("TITLE_REQUIRED", ErrorMessageConstants.TitleMessage));
            
            localizerMock
                .Setup(x => x["TITLE_MAX_LENGTH_100"])
                .Returns(new LocalizedString("TITLE_MAX_LENGTH_100", ErrorMessageConstants.TitleMaxLengthMessage));
            
            localizerMock
                .Setup(x => x["INVALID_STATUS"])
                .Returns(new LocalizedString("INVALID_STATUS", ErrorMessageConstants.InvalidStatusMessage));
            
            localizerMock
                .Setup(x => x["CANNOT_MARK_DONE"])
                .Returns(new LocalizedString("CANNOT_MARK_DONE", ErrorMessageConstants.CannotMarkDoneMessage));
            
            localizerMock
                .Setup(x => x["TASK_NOT_FOUND"])
                .Returns(new LocalizedString("TASK_NOT_FOUND", ErrorMessageConstants.CannotMarkDoneMessage));
            
           
        }
    }
}