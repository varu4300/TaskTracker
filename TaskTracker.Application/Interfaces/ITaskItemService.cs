using TaskTracker.Application.DTOs;

namespace TaskTracker.Application.Interfaces
{

    public interface ITaskItemService
    {
        /// <summary>
        /// Create a task from  the Task item data transfer object and utilize repository to save to DB
        /// </summary>
        /// <param name="dto">Data transfer object</param>
        /// <returns>Whether the task item has been created</returns>
        Task<bool> CreateTaskItemAsync(TaskItemDTO dto);
        
        /// <summary>
        /// Deletes the given task item by id from the database
        /// </summary>
        /// <param name="taskItemId">Data transfer object</param>
        /// <returns>Whether the task item has been deleted</returns>
        Task<bool> DeleteTaskItemAsync(long taskItemId);
        
        /// <summary>
        /// Updates the given task item in db, first will convert the data transfer object to appropriate entity and
        /// update db entry
        /// </summary>
        /// <param name="dto">Data transfer object</param>
        /// <returns>Whether the task item has been updated</returns>
        Task<bool> UpdateTaskItemAsync(TaskItemDTO dto);
        
        /// <summary>
        /// Get the task item by id if it exists. Otherwise, throws an exception with appropriate message
        /// </summary>
        /// <param name="taskItemId">Unique identifier of task</param>
        /// <returns></returns>
        Task<TaskItemDTO> GetTaskItemByIdAsync(long taskItemId);
        
        /// <summary>
        /// Returns all the task items to client
        /// </summary>
        /// <returns>List of task items</returns>
        Task<List<TaskItemDTO>> GetTaskItemsAsync();
    }
}