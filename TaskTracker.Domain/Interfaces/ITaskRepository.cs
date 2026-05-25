using TaskTracker.Domain.Entities;

namespace TaskTracker.Domain.Interfaces
{

    public interface ITaskRepository
    {
        /// <summary>
        /// Creates a task item in DB 
        /// </summary>
        /// <param name="taskItem"></param>
        /// <returns>A boolean to represent that the task item has or has not been created</returns>
        Task<bool> CreateTaskItemAsync(TaskItem taskItem);
        
        /// <summary>
        /// Removes a task item from DB 
        /// </summary>
        /// <param name="taskItem"></param>
        /// <returns>A boolean to represent that the task item has or has not been deleted</returns>
        Task<bool> DeleteTaskItemAsync(TaskItem taskItem);
        
        /// <summary>
        /// Updates a existing task item in DB
        /// </summary>
        /// <param name="taskItem"></param>
        /// <returns>A boolean to represent that the task item has or has not been updated</returns>
        Task<bool> UpdateTaskItemAsync(TaskItem taskItem);
        
        /// <summary>
        /// Will retrieve a task item given a valid task item unique identifier
        /// </summary>
        /// <param name="taskItemId"></param>
        /// <returns>A boolean to represent that the task item has or has not been updated</returns>
        Task<TaskItem?> GetTaskItemByIdAsync(long taskItemId);
        
        /// <summary>
        /// Will retrieve all the task items from the DB
        /// </summary>
        /// <returns>A boolean to represent that the task item has or has not been updated</returns>
        Task<List<TaskItem>> GetTaskItemsAsync();
    }
}