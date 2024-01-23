using AutoMapper;
using ProjectHarbor.Projects.Application.Contracts.Commands;
using ProjectHarbor.Projects.Application.Contracts.Dtos;
using ProjectHarbor.Projects.Application.Contracts.ViewModels;
using ProjectHarbor.Projects.Persistence.Entities;

namespace ProjectHarbor.Projects.Application.Mappers;

internal class ProjectMapper : Profile
{
    public ProjectMapper()
    {
        CreateMap<CreateProjectCommand, ProjectEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedAt, opt => opt.Ignore());

        CreateMap<UpdateProjectCommand, ProjectEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedAt, opt => opt.Ignore());

        CreateMap<ProjectEntity, ProjectBriefDto>();

        CreateMap<ProjectEntity, ProjectViewModel>();
    }
}
