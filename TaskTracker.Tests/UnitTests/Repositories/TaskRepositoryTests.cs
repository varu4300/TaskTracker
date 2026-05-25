using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain.Entities;
using TaskTracker.Infrastructure.Data;
using TaskTracker.Infrastructure.Repositories;

namespace TaskTracker.Tests.UnitTests.Repositories
{
   
    public class TaskRepositoryTests
    {
        
        private AppDbContext GetDbContext()
        {
            // Using in-memory db for unit tests
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }
       
        [Fact]
        public async Task CreateTaskItemAsync_Should_Create_Task()
        {
            // Arrange
            var context = GetDbContext();

            var repository = new TaskRepository(context);

            var task = new TaskItem
            {
                Title = "Test Task",
                Description = "Test Description",
                Status = "Todo",
                DueDate = DateTime.Today
            };

            // Act
            var result = await repository.CreateTaskItemAsync(task);

            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public async Task UpdateTaskItemAsync_Should_Update_Task()
        {
            // Arrange
            var context = GetDbContext();

            var taskItem = new TaskItem
            {
                Id = 1,
                Title = "Old Title",
                Description = "Old Description",
                Status = "Todo",
                DueDate = DateTime.Today
            };

            context.TaskItem.Add(taskItem);

            await context.SaveChangesAsync();

            var repository = new TaskRepository(context);

            // Act
            var result = await repository.UpdateTaskItemAsync(taskItem);

            // Assert
            Assert.True(result);
        }
    }
}