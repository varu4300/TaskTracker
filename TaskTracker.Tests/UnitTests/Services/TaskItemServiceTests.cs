using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Services;
using TaskTracker.Application.Utilities;
using TaskTracker.Domain.Entities;
using TaskTracker.Domain.Exceptions;
using TaskTracker.Domain.Interfaces;
using ILogger = Castle.Core.Logging.ILogger;

namespace TaskTracker.Tests.UnitTests.Services
{

    public class TaskItemServiceTests
    {
        private readonly Mock<ILogger<TaskItemService>> _loggerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ITaskRepository> _taskRepositoryMock;
        
        private readonly ITaskItemService _taskItemService;
        
        public TaskItemServiceTests()
        {
            _loggerMock = new Mock<ILogger<TaskItemService>>();
            _mapperMock = new Mock<IMapper>();
            _taskRepositoryMock = new Mock<ITaskRepository>();

            _taskItemService = new TaskItemService(
                _loggerMock.Object, _taskRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Create_Task_Item_Successfully()
        {
            var dto = new TaskItemDTO
            {
                Title = "Task1",
                Description = "Task1",
                Status = Constants.Todo,
                DueDate = DateTime.Today
            };
            
            _mapperMock
                .Setup(x => x.Map<TaskItem>(It.IsAny<TaskItemDTO>()))
                .Returns(new TaskItem
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    Status = dto.Status,
                    DueDate = dto.DueDate
                });

            _taskRepositoryMock
                .Setup(x => x.CreateTaskItemAsync(It.IsAny<TaskItem>()))
                .ReturnsAsync(true);
            
            var result = await _taskItemService.CreateTaskItemAsync(dto);
            
            Assert.True(result);
        }

        [Fact]
        public async Task Get_Task_Item_By_Id_Returns_Error()
        {
            var dto = new TaskItemDTO
            {
                Title = "Task1",
                Description = "Task1",
                Status = Constants.Todo,
                DueDate = DateTime.Today
            };
            
            _mapperMock
                .Setup(x => x.Map<TaskItem>(It.IsAny<TaskItemDTO>()))
                .Returns(new TaskItem
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    Status = dto.Status,
                    DueDate = dto.DueDate
                });

            _taskRepositoryMock
                .Setup(x => x.GetTaskItemByIdAsync(It.IsAny<long>()))
                .ThrowsAsync(new TaskTrackerException("TASK_NOT_FOUND"));
            
            var exception = await Assert.ThrowsAsync<TaskTrackerException>(() =>  _taskItemService.GetTaskItemByIdAsync(1));
            
            Assert.Equal(ErrorConstants.TaskNotFound, exception.Message);
        }
        
        [Fact]
        public async Task Update_Task_Item_Successfully()
        {
            var dto = new TaskItemDTO
            {
                Id = 1,
                Title = "Task1",
                Description = "Task1",
                Status = Constants.Todo,
                DueDate = DateTime.Today
            };
            
            _mapperMock
                .Setup(x => x.Map<TaskItem>(It.IsAny<TaskItemDTO>()))
                .Returns(new TaskItem
                {
                    Id = dto.Id,
                    Title = dto.Title,
                    Description = dto.Description,
                    Status = dto.Status,
                    DueDate = dto.DueDate
                });

            _taskRepositoryMock
                .Setup(x => x.GetTaskItemByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(new TaskItem
                {
                    Id = dto.Id,
                    Title = dto.Title,
                    Description = dto.Description,
                    Status = dto.Status,
                    DueDate = dto.DueDate
                });

            _taskRepositoryMock
                .Setup(x => x.UpdateTaskItemAsync(It.IsAny<TaskItem>()))
                .ReturnsAsync(true);
            
            var result = await _taskItemService.UpdateTaskItemAsync(dto);
            
            Assert.True(result);
        }
    }
}