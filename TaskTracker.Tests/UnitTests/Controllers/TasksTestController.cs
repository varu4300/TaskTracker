using System.Net;
using AutoMapper;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Moq;
using TaskTracker.Api;
using TaskTracker.Api.Controllers;
using TaskTracker.Api.Models.Requests;
using TaskTracker.Api.Models.Responses;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Utilities;
using TaskTracker.Tests.Setup;
using Microsoft.Extensions.Logging;
using TaskTracker.Domain.Exceptions;
using TaskTracker.Tests.Utilities;

namespace TaskTracker.Tests.UnitTests.Controllers
{

    public class TasksTestController
    {
        private readonly TasksController _controller;
        private readonly Mock<ITaskItemService> _taskItemServiceMock;

        public TasksTestController()
        {
            _taskItemServiceMock = new Mock<ITaskItemService>();
            var mapperMock = new Mock<IMapper>();
            var localizerMock = new Mock<IStringLocalizer<GlobalResource>>();
            var loggerMock = new Mock<ILogger<TasksController>>();
            LocalizerSetup.Configure(localizerMock);
            
            _controller = new TasksController(
                _taskItemServiceMock.Object,
                localizerMock.Object,
                mapperMock.Object,
                loggerMock.Object
            );
        }
        
        
        [Fact]
        public async Task CreateTaskItem_Should_Return_Success()
        {
            // Arrange
            var request = new CreateTaskItemRequest
            {
                Title = "Task1",
                Description = "Task1",
                Status = Constants.Todo,
                DueDate = DateTime.Today
            };

            _taskItemServiceMock
                .Setup(x => x.CreateTaskItemAsync(It.IsAny<TaskItemDTO>()))
                .ReturnsAsync(true);

            var response = new BaseApiResponse<bool>
            {
                StatusCode = HttpStatusCode.OK,
                Result = true,
                Message = ""
            };

            // Act
            var responseObj = await _controller.CreateTaskItemAsync(request);
            var result = responseObj as ObjectResult;
            
            // Assert
            Assert.IsType<BaseApiResponse<bool>>(result.Value);
            Assert.Equivalent(response, result.Value);
        }
        
        [Fact]
        public async Task UpdateTaskItem_Should_Return_Success()
        {
            // Arrange
            var request = new UpdateTaskItemRequest()
            {
                Id = 1,
                Title = "Task1",
                Description = "Task1",
                Status = Constants.Todo,
                DueDate = DateTime.Today
            };

            _taskItemServiceMock
                .Setup(x => x.UpdateTaskItemAsync(It.IsAny<TaskItemDTO>()))
                .ReturnsAsync(true);

            var response = new BaseApiResponse<bool>
            {
                StatusCode = HttpStatusCode.OK,
                Result = true,
                Message = ""
            };

            // Act
            var responseObj = await _controller.UpdateTaskItemByIdAsync(request);
            var result = responseObj as ObjectResult;
            
            // Assert
            Assert.IsType<BaseApiResponse<bool>>(result.Value);
            Assert.Equivalent(response, result.Value);
        }
        
        [Fact]
        public async Task Get_All_Tasks_Should_Return_Empty()
        {
            // Arrange
            _taskItemServiceMock
                .Setup(x => x.GetTaskItemsAsync())
                .ReturnsAsync([]);
            
            var response = new BaseApiResponse<List<TaskItemDTO>>
            {
                StatusCode = HttpStatusCode.OK,
                Result = [],
                Message = ""
            };

            // Act
            var responseObj = await _controller.GetAllTasksAsync();
            var result = responseObj as ObjectResult;
            
            // Assert
            Assert.IsType<BaseApiResponse<List<TaskItemDTO>>>(result.Value);
            Assert.Equivalent(response, result.Value);
        }
        
        [Fact]
        public async Task Get_All_Tasks_Should_Return_SERVER_ERROR()
        {
            // Arrange
            var response = new BaseApiResponse<List<TaskItemDTO>>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Result = null,
                Message = ErrorMessageConstants.ServerError
            };

            _taskItemServiceMock
                .Setup(x => x.GetTaskItemsAsync())
                .ThrowsAsync(new Exception(ErrorConstants.ServerError));

            // Act
            var responseObj = await _controller.GetAllTasksAsync();
            var result = responseObj as ObjectResult;
            
            // Assert
            Assert.IsType<BaseApiResponse<List<TaskItemDTO>>>(result.Value);
            Assert.Equivalent(response, result.Value);
        }
    }
}