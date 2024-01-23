using MediatR;

namespace ProjectHarbor.Projects.Application.Contracts.Commands;

public record DeleteProjectCommand(int ProjectId) : IRequest<bool>;
