using AutoMapper;
using Project.Core.Entities.Project;
using Project.WebApi.Models;

namespace Project.WebApi.MapperProfile
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ProjectModel, ProjectViewModel>();
            CreateMap<ProjectViewModel, ProjectModel>();
        }
    }
}