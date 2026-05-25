using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain.Entities;
using TaskTracker.Domain.Interfaces;
using TaskTracker.Infrastructure.Data;

namespace TaskTracker.Infrastructure.Repositories
{

    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;
        
        public TaskRepository(AppDbContext context)
        {
            _context = context;
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
                throw new Exception(ex.Message);
            }
        }
    }
}