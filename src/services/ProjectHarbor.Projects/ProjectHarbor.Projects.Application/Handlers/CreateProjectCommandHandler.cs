using AutoMapper;
using MediatR;
using ProjectHarbor.Projects.Application.Contracts.Commands;
using ProjectHarbor.Projects.Application.Contracts.ViewModels;
using ProjectHarbor.Projects.Persistence;
using ProjectHarbor.Projects.Persistence.Entities;

namespace ProjectHarbor.Projects.Application.Handlers;

internal class CreateProjectCommandHandler(DatabaseContext databaseContext, IMapper mapper)
    : IRequestHandler<CreateProjectCommand, ProjectViewModel>
{
    public async Task<ProjectViewModel> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<ProjectEntity>(command);
        await databaseContext.AddAsync(entity, cancellationToken);
        await databaseContext.SaveChangesAsync(cancellationToken);

        var viewModel = mapper.Map<ProjectViewModel>(entity);
        return viewModel;
    }
}
