using System.Net;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TaskTracker.Api.Models;
using TaskTracker.Application.DTOs;
using TaskTracker.Api.Models.Requests;
using TaskTracker.Api.Models.Responses;
using TaskTracker.Api.Utilities.Filters;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Utilities;
using TaskTracker.Domain.Exceptions;
using TaskTracker.Domain.Logging;

namespace TaskTracker.Api.Controllers
{
    public class TasksController : BaseController
    {
        private readonly ITaskItemService _taskItemService;
        private readonly IStringLocalizer<GlobalResource> _localizer;
        private readonly IMapper _mapper;
        private readonly ILogger<TasksController> _logger;
        public TasksController(
            ITaskItemService taskItemService,
            IStringLocalizer<GlobalResource> localizer,
            IMapper mapper,
            ILogger <TasksController> logger)
        {
            _taskItemService = taskItemService;
            _localizer = localizer;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasksAsync()
        {
            var response = new BaseApiResponse<List<TaskItemDTO>>();
            try
            {
                var items = await _taskItemService.GetTaskItemsAsync();
                response.Result = items;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (TaskTrackerException ex)
            {
                TaskTrackerLogger.Log(_logger, LogLevel.Error, ex);
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = _localizer.GetString(ex.Message);
            }
            catch (Exception ex)
            {
                TaskTrackerLogger.Log(_logger, LogLevel.Error, ex);
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = _localizer.GetString(ErrorConstants.ServerError);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetTaskItemByIdAsync(long id)
        {
            var response = new BaseApiResponse<TaskItemDTO>();
            try
            {
                var item = await _taskItemService.GetTaskItemByIdAsync(id);
                response.Result = item;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (TaskTrackerException ex)
            {
                TaskTrackerLogger.Log(_logger, LogLevel.Error, ex);
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = _localizer.GetString(ex.Message);
            }
            catch (Exception ex)
            {
                TaskTrackerLogger.Log(_logger, LogLevel.Error, ex);
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = _localizer.GetString(ErrorConstants.ServerError);
            }
            return StatusCode((int)response.StatusCode, response);
        }
        
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteTaskItemByIdAsync(long id)
        {
            var response = new BaseApiResponse<bool>();
            try
            {
                var deleted = await _taskItemService.DeleteTaskItemAsync(id);
                response.Result = deleted;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (TaskTrackerException ex)
            {
                TaskTrackerLogger.Log(_logger, LogLevel.Error, ex);
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = _localizer.GetString(ex.Message);
            }
            catch (Exception ex)
            {
                TaskTrackerLogger.Log(_logger, LogLevel.Error, ex);
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = _localizer.GetString(ErrorConstants.ServerError);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        
        [ServiceFilter(typeof(CustomValidation<CreateTaskItemRequest>))]
        [HttpPost]
        public async Task<IActionResult> CreateTaskItemAsync(CreateTaskItemRequest request)
        {
            var response = new BaseApiResponse<bool>();
            try
            {
                var dto = _mapper.Map<TaskItemDTO>(request);
                var created = await _taskItemService.CreateTaskItemAsync(dto);
                response.Result = created;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (TaskTrackerException ex)
            {
                TaskTrackerLogger.Log(_logger, LogLevel.Error, ex);
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = _localizer.GetString(ex.Message);
            }
            catch (Exception ex)
            {
                TaskTrackerLogger.Log(_logger, LogLevel.Error, ex);
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = _localizer.GetString(ErrorConstants.ServerError);
            }

            return StatusCode((int)response.StatusCode, response);
        }
        
        
        [ServiceFilter(typeof(CustomValidation<UpdateTaskItemRequest>))]
        [HttpPut]
        public async Task<IActionResult> UpdateTaskItemByIdAsync(UpdateTaskItemRequest request)
        {
            var response = new BaseApiResponse<bool>();
            try
            {
                var dto = _mapper.Map<TaskItemDTO>(request);
                var updated = await _taskItemService.UpdateTaskItemAsync(dto);
                response.Result = updated;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (TaskTrackerException ex)
            {
                TaskTrackerLogger.Log(_logger, LogLevel.Error, ex);
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = _localizer.GetString(ex.Message);
            }
            catch (Exception ex)
            {
                TaskTrackerLogger.Log(_logger, LogLevel.Error, ex);
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = _localizer.GetString(ErrorConstants.ServerError);
            }

            return StatusCode((int)response.StatusCode, response);
        }
    
    }
}