using MediatR;
using ProjectHarbor.Projects.Application.Contracts.ViewModels;

namespace ProjectHarbor.Projects.Application.Contracts.Queries;

public record GetProjectQuery(int ProjectId) : IRequest<ProjectViewModel?>;
