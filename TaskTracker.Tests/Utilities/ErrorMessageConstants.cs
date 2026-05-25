namespace TaskTracker.Tests.Utilities;

public class ErrorMessageConstants
{
    public const string TitleMessage = "Title is required";
    public const string TitleMaxLengthMessage = "Title field cannot be more than 100 characters";
    public const string InvalidStatusMessage = "Invalid task status (Todo, InProgress or Done)";
    public const string CannotMarkDoneMessage = "Cannot mark task as done without a valid title";
    public const string TaskNotFound = "Task not found";
}