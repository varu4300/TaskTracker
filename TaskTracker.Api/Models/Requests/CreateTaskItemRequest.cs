using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Api.Models.Requests
{

    public class CreateTaskItemRequest
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }
    }
}