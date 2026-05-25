using AutoMapper;
using TaskTracker.Application.DTOs;
using TaskTracker.Api.Models.Requests;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Api.Configs
{
    public class TaskItemProfile : Profile
    {
        public TaskItemProfile()
        {
            CreateMap<TaskItem, TaskItemDTO>();
            CreateMap<CreateTaskItemRequest, TaskItemDTO>();
            CreateMap<UpdateTaskItemRequest, TaskItemDTO>();
        }
    }
}