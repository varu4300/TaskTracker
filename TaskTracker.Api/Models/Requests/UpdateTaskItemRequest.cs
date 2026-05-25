namespace TaskTracker.Api.Models.Requests
{
    public class UpdateTaskItemRequest : CreateTaskItemRequest
    {
        public long Id { get; set; }
    }
}