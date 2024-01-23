using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectHarbor.Projects.Application.Contracts.Dtos;
using ProjectHarbor.Projects.Application.Contracts.Enums;
using ProjectHarbor.Projects.Application.Contracts.Queries;
using ProjectHarbor.Projects.Application.Contracts.ViewModels;
using ProjectHarbor.Projects.Persistence;

namespace ProjectHarbor.Projects.Application.Handlers;

internal class GetProjectsQueryHandler(DatabaseContext databaseContext, IMapper mapper)
    : IRequestHandler<GetProjectsQuery, ProjectsViewModel>
{
    public async Task<ProjectsViewModel> Handle(GetProjectsQuery query, CancellationToken cancellationToken)
    {
        var entitiesQuery = databaseContext.Projects
            .AsNoTracking();

        entitiesQuery = query.SortOrder switch
        {
            SortOrder.Newest => entitiesQuery
                .OrderByDescending(entity => entity.CreatedAt),
            SortOrder.Updated => entitiesQuery
                .Where(entity => entity.ModifiedAt != null)
                .OrderByDescending(entity => entity.ModifiedAt),
            _ => throw new NotImplementedException($"Sorting by '{query.SortOrder}' is not implemented"),
        };

        var entities = await entitiesQuery
            .Skip(query.PageOffset)
            .Take(query.PageSize)
            .ToListAsync(cancellationToken);

        var dtos = mapper.Map<IEnumerable<ProjectBriefDto>>(entities);
        return new ProjectsViewModel()
        {
            Projects = dtos,
            PageOffset = query.PageOffset,
            PageSize = query.PageSize,
        };
    }
}
