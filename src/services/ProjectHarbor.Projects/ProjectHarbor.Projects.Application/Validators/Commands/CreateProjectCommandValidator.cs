using FluentValidation;
using ProjectHarbor.Projects.Application.Contracts.Commands;
using ProjectHarbor.Projects.Shared.Constraints;

namespace ProjectHarbor.Projects.Application.Validators.Commands;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(ProjectConstraints.MinNameLength, ProjectConstraints.MaxNameLength);

        RuleFor(x => x.CodeRepositoryUrl)
            .NotEmpty()
        .Must(x => Uri.TryCreate(x, UriKind.Absolute, out _))
            .WithMessage(x => "'{PropertyName}' must be a valid URL")
            .MaximumLength(ProjectConstraints.MaxCodeRepositoryUrlLength)
            .When(x => x.CodeRepositoryUrl is not null);

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0.0m);

        RuleFor(x => x.BriefDescription)
            .MaximumLength(ProjectConstraints.MaxBriefDescriptionLength);
    }
}
