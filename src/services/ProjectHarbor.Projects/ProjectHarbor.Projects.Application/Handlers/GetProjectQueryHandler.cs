using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectHarbor.Projects.Application.Contracts.Queries;
using ProjectHarbor.Projects.Application.Contracts.ViewModels;
using ProjectHarbor.Projects.Persistence;

namespace ProjectHarbor.Projects.Application.Handlers;

internal class GetProjectQueryHandler(DatabaseContext databaseContext, IMapper mapper) : IRequestHandler<GetProjectQuery, ProjectViewModel?>
{
    public async Task<ProjectViewModel?> Handle(GetProjectQuery query, CancellationToken cancellationToken)
    {
        var entity = await databaseContext.Projects
            .AsNoTracking()
            .FirstOrDefaultAsync(project => project.Id == query.ProjectId, cancellationToken);

        var viewModel = mapper.Map<ProjectViewModel>(entity);
        return viewModel;
    }
}
