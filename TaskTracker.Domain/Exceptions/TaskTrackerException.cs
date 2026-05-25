namespace TaskTracker.Domain.Exceptions
{

    public class TaskTrackerException : Exception
    {
        public TaskTrackerException(string message) : base(message) { }
    }
}