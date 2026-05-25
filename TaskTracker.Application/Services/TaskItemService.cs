using AutoMapper;
using Microsoft.Extensions.Logging;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Utilities;
using TaskTracker.Domain.Entities;
using TaskTracker.Domain.Exceptions;
using TaskTracker.Domain.Interfaces;

namespace TaskTracker.Application.Services
{

    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TaskItemService> _logger;
        
        public TaskItemService(ILogger<TaskItemService> logger,ITaskRepository taskRepository,  IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _logger = logger;
        }
        
        public async Task<bool> CreateTaskItemAsync(TaskItemDTO dto)
        {
            try
            {
                var taskItem = _mapper.Map<TaskItem>(dto);

                taskItem.CreatedAt = DateTime.Now;
                taskItem.UpdatedAt = DateTime.Now;

                var created = await _taskRepository.CreateTaskItemAsync(taskItem);

                return !created ? throw new TaskTrackerException(ErrorConstants.CreateTaskFailed) : created;
            }
            catch (TaskTrackerException ex)
            {
                throw new TaskTrackerException(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("[Error]: {Exception}", ex);
                throw new Exception(ErrorConstants.ServerError);
            }
        }

        public async Task<bool> DeleteTaskItemAsync(long taskItemId)
        {
            try
            {
                // Check if task item exists 
                var taskItem = await _taskRepository.GetTaskItemByIdAsync(taskItemId);

                // Throw an error with appropriate message if the item doesn't exist.
                if (taskItem == null) throw new TaskTrackerException(ErrorConstants.TaskNotFound);

                var deleted = await _taskRepository.DeleteTaskItemAsync(taskItem); // remove task item

                return !deleted ? throw new TaskTrackerException(ErrorConstants.DeleteTaskFailed) : deleted;
            }
            catch (TaskTrackerException ex)
            {
                throw new TaskTrackerException(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception(ErrorConstants.ServerError);
            }
        }

        public async Task<bool> UpdateTaskItemAsync(TaskItemDTO dto)
        {
            try
            {
                // Check if task item exists 
                var taskItem = await _taskRepository.GetTaskItemByIdAsync(dto.Id);

                // Throw an error with appropriate message if the item doesn't exist.
                if (taskItem == null) throw new TaskTrackerException(ErrorConstants.TaskNotFound);

                taskItem = _mapper.Map<TaskItem>(dto);
                taskItem.UpdatedAt = DateTime.Now;
                
                var updated = await _taskRepository.UpdateTaskItemAsync(taskItem); // remove task item

                return !updated ? throw new TaskTrackerException(ErrorConstants.DeleteTaskFailed) : updated;
            }
            catch (TaskTrackerException ex)
            {
                throw new TaskTrackerException(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception(ErrorConstants.ServerError);
            }
        }

        public async Task<TaskItemDTO> GetTaskItemByIdAsync(long taskItemId)
        {
            try
            {
                // Check if task item exists 
                var taskItem = await _taskRepository.GetTaskItemByIdAsync(taskItemId);

                // Throw an error with appropriate message if the item doesn't exist.
                if (taskItem == null) throw new TaskTrackerException(ErrorConstants.TaskNotFound);

                var dto = _mapper.Map<TaskItemDTO>(taskItem);
                return dto;

            }
            catch (TaskTrackerException ex)
            {
                throw new TaskTrackerException(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception(ErrorConstants.CreateTaskFailed);
            }
        }

        public async Task<List<TaskItemDTO>> GetTaskItemsAsync()
        {
            try
            {
                var  taskItems = await _taskRepository.GetTaskItemsAsync();
                
                var taskItemDtOs = _mapper.Map<List<TaskItemDTO>>(taskItems);
                return taskItemDtOs;

            }
            catch (TaskTrackerException ex)
            {
                throw new TaskTrackerException(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception(ErrorConstants.ServerError);
            }
        }
    }
}