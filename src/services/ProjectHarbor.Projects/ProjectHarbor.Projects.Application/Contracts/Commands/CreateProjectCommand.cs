using MediatR;
using ProjectHarbor.Projects.Application.Contracts.ViewModels;

namespace ProjectHarbor.Projects.Application.Contracts.Commands;

public class CreateProjectCommand : IRequest<ProjectViewModel>
{
    public string Name { get; init; } = string.Empty;

    public string? CodeRepositoryUrl { get; init; }

    public decimal? Price { get; init; }

    public string BriefDescription { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;
}
