using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectHarbor.Projects.Application.Contracts.Commands;
using ProjectHarbor.Projects.Persistence;

namespace ProjectHarbor.Projects.Application.Handlers;

internal class UpdateProjectCommandHandler(DatabaseContext databaseContext, IMapper mapper)
    : IRequestHandler<UpdateProjectCommand, bool>
{
    public async Task<bool> Handle(UpdateProjectCommand command, CancellationToken cancellationToken)
    {
        var entity = await databaseContext.Projects
            .FirstOrDefaultAsync(project => project.Id == command.ProjectId, cancellationToken);

        if (entity is null)
            return false;

        mapper.Map(command, entity);
        await databaseContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
