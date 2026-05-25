namespace TaskTracker.Application.Utilities;

public class ErrorConstants
{
    public const string CreateTaskFailed = "CREATE_TASK_FAILED";
    public const string UpdateTaskFailed = "UPDATE_TASK_FAILED";
    public const string DeleteTaskFailed = "DELETE_TASK_FAILED";
    public const string TaskNotFound = "TASK_NOT_FOUND";
    public const string GetAllTaskFailed = "GET_ALL_TASK_FAILED";
    public const string ServerError = "SERVER_ERROR";
    public const string TitleRequired = "TITLE_REQUIRED";
    public const string TitleMaxLength = "TITLE_MAX_LENGTH_100";
    public const string InvalidStatus = "INVALID_STATUS";
    public const string CannotMarkDone = "CANNOT_MARK_DONE";
}