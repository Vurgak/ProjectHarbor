using ProjectHarbor.Projects.Application.Contracts.Dtos;

namespace ProjectHarbor.Projects.Application.Contracts.ViewModels;

public class ProjectsViewModel
{
    public IEnumerable<ProjectBriefDto> Projects { get; init; } = Enumerable.Empty<ProjectBriefDto>();

    public int PageOffset { get; init; }

    public int PageSize { get; init; }
}
