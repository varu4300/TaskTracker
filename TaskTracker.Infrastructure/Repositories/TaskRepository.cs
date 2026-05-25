using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskTracker.Domain.Entities;
using TaskTracker.Domain.Interfaces;
using TaskTracker.Domain.Logging;
using TaskTracker.Infrastructure.Data;

namespace TaskTracker.Infrastructure.Repositories
{

    public class TaskRepository : ITaskRepository
    {
        private readonly ILogger<TaskRepository> _logger;
        private readonly AppDbContext _context;
        
        public TaskRepository(AppDbContext context, ILogger<TaskRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        public async Task<bool> CreateTaskItemAsync(TaskItem taskItem)
        {
            try
            {
                _context.TaskItem.Add(taskItem);
                return (await _context.SaveChangesAsync()) > 0;
            }
            catch (Exception ex)
            {
                TaskTrackerLogger.Log(_logger, LogLevel.Error, ex);
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteTaskItemAsync(TaskItem taskItem)
        {
            try
            {
                _context.TaskItem.Remove(taskItem);
                return (await _context.SaveChangesAsync()) > 0;
            }
            catch (Exception ex)
            {
                TaskTrackerLogger.Log(_logger, LogLevel.Error, ex);
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateTaskItemAsync(TaskItem taskItem)
        {
            try
            {
                _context.TaskItem.Update(taskItem);
                return (await _context.SaveChangesAsync()) > 0;
            }
            catch (Exception ex)
            {
                TaskTrackerLogger.Log(_logger, LogLevel.Error, ex);
                throw new Exception(ex.Message);
            }
        }

        public async Task<TaskItem?> GetTaskItemByIdAsync(long taskItemId)
        {
            try
            {
              return (await _context.TaskItem
                    .AsNoTracking()
                    .FirstOrDefaultAsync(g => g.Id == taskItemId)
                  );
                
            }
            catch (Exception ex)
            {
                TaskTrackerLogger.Log(_logger, LogLevel.Error, ex);
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TaskItem>> GetTaskItemsAsync()
        {
            try
            {
                return (await _context.TaskItem
                    .AsNoTracking()
                    .ToListAsync());
                
            }
            catch (Exception ex)
            {
                TaskTrackerLogger.Log(_logger, LogLevel.Error, ex);
                throw new Exception(ex.Message);
            }
        }
    }
}