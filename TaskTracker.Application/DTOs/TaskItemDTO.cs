using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Application.DTOs;

public class TaskItemDTO
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public string Status { get; set; } = string.Empty;
    
    public DateTime DueDate { get; set; }
}