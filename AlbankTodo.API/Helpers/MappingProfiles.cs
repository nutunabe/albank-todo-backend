using AlbankTodo.API.Dtos;
using AlbankTodo.Application.Tasks.Commands.CreateTask;
using AlbankTodo.Application.Tasks.Commands.UpdateTask;
using AlbankTodo.Application.Tasks.Queries;
using AlbankTodo.Core.Entities;
using AutoMapper;

namespace AlbankTodo.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateTaskRequest, AlbankTask>();
            CreateMap<AlbankTask, TaskDto>();
            CreateMap<CreateTaskDto, CreateTaskRequest>();
            CreateMap<UpdateTaskDto, UpdateTaskRequest>();
        }
    }
}
