using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectHarbor.Projects.Application.Contracts.Commands;
using ProjectHarbor.Projects.Persistence;

namespace ProjectHarbor.Projects.Application.Handlers;

public class DeleteProjectCommandHandler(DatabaseContext databaseContext)
    : IRequestHandler<DeleteProjectCommand, bool>
{
    public async Task<bool> Handle(DeleteProjectCommand command, CancellationToken cancellationToken)
    {
        var rowsDeleted = await databaseContext.Projects
            .Where(project => project.Id == command.ProjectId)
            .ExecuteDeleteAsync(cancellationToken);

        return rowsDeleted > 0;
    }
}
