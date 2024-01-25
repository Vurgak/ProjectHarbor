using ProjectHarbor.Projects.Shared.Constraints;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHarbor.Projects.Persistence.Entities;

public class ProjectEntity
{
    public int Id { get; set; }

    public DateTimeOffset CreatedAt {  get; set; }

    public DateTimeOffset? ModifiedAt {  get; set; }

    [MaxLength(ProjectConstraints.MaxNameLength)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(ProjectConstraints.MaxCodeRepositoryUrlLength)]
    public string? CodeRepositoryUrl { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal? Price { get; set; }

    [MaxLength(ProjectConstraints.MaxBriefDescriptionLength)]
    public string BriefDescription { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
