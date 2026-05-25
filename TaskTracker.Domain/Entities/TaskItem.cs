using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Domain.Entities;

public class TaskItem
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public string Status { get; set; } = string.Empty;
    
    public DateTime DueDate { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}