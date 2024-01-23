using MediatR;
using System.Text.Json.Serialization;

namespace ProjectHarbor.Projects.Application.Contracts.Commands;

public class UpdateProjectCommand : IRequest<bool>
{
    [JsonIgnore]
    public int ProjectId { get; set; }

    public string Name { get; init; } = string.Empty;

    public string? CodeRepositoryUrl { get; init; }

    public decimal? Price { get; init; }

    public string BriefDescription { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;
}
