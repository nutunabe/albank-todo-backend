using AlbankTodo.Application.Tasks.Queries;
using AlbankTodo.Core.Entities;
using AutoMapper;

namespace AlbankTodo.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AlbankTask, TaskDto>();
        }
    }
}
