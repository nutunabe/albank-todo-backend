using AlbankTodo.Application.Common;
using AlbankTodo.Application.Tasks.Commands.CreateTask;
using AlbankTodo.Application.Tasks.Commands.UpdateTask;
using AlbankTodo.Core.Entities;
using AutoMapper;

namespace AlbankTodo.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateTaskRequest, AlbankTask>();
            CreateMap<UpdateTaskRequest, AlbankTask>();
            CreateMap<AlbankTask, TaskDto>();
        }
    }
}
