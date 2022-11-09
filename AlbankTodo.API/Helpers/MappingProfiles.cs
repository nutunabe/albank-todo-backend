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
            CreateMap<UpdateTaskRequest, AlbankTask>()
                .ForMember(m => m.Title, x => x.MapFrom((s, m) => s.Title == null ? m.Title : s.Title))
                .ForMember(m => m.Description, x => x.MapFrom((s, m) => s.Description == null ? m.Description : s.Description))
                .ForMember(m => m.DueDate, x => x.MapFrom((s, m) => s.DueDate.HasValue ? s.DueDate.Value : m.DueDate))
                .ForMember(m => m.Status, x => x.MapFrom((s, m) => s.Status.HasValue ? s.Status.Value : m.Status));
            CreateMap<AlbankTask, TaskDto>();
        }
    }
}
