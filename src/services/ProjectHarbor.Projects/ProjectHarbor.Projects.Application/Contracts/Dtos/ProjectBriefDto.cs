namespace ProjectHarbor.Projects.Application.Contracts.Dtos;

public class ProjectBriefDto
{
    public int Id { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime? ModifiedAt { get; init; }

    public string Name { get; init; } = string.Empty;

    public string? CodeRepositoryUrl { get; init; }

    public decimal? Price { get; init; }

    public string BriefDescription { get; init; } = string.Empty;
}
