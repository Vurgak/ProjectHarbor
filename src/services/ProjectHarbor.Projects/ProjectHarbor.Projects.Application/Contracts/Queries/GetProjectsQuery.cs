using MediatR;
using ProjectHarbor.Projects.Application.Contracts.Enums;
using ProjectHarbor.Projects.Application.Contracts.ViewModels;

namespace ProjectHarbor.Projects.Application.Contracts.Queries;

public record GetProjectsQuery(SortOrder SortOrder = SortOrder.Newest, int PageOffset = 0, int PageSize = 10) : IRequest<ProjectsViewModel>;
