using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectHarbor.Projects.Application.Contracts.Commands;
using ProjectHarbor.Projects.Application.Contracts.Queries;
using ProjectHarbor.Projects.Application.Contracts.ViewModels;
using ProjectHarbor.Projects.WebApi.ViewModels;

namespace ProjectHarbor.Projects.WebApi.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectsController(ISender sender) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType<ProjectViewModel>(200)]
        [ProducesResponseType<ValidationResult>(400)]
        [ProducesResponseType<ErrorViewModel>(500)]
        public async Task<ActionResult<ProjectViewModel>> CreateAsync([FromBody] CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var result = await sender.Send(request, cancellationToken);
            return result is not null ? CreatedAtAction(nameof(GetAsync), new { projectId = result.Id }, result) : BadRequest();
        }

        [HttpPut("{projectId:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType<ValidationResult>(400)]
        [ProducesResponseType<ErrorViewModel>(500)]
        public async Task<ActionResult> UpdateAsync([FromRoute] int projectId, [FromBody] UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            request.ProjectId = projectId;
            var result = await sender.Send(request, cancellationToken);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{projectId:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType<ValidationResult>(404)]
        [ProducesResponseType<ErrorViewModel>(500)]
        public async Task<ActionResult> DeleteAsync([FromRoute] int projectId, CancellationToken cancellationToken)
        {
            var command = new DeleteProjectCommand(projectId);
            var result = await sender.Send(command, cancellationToken);
            return result ? NoContent() : NotFound();
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType<ValidationResult>(404)]
        [ProducesResponseType<ErrorViewModel>(500)]
        public async Task<ActionResult<ProjectsViewModel>> GetAsync([FromQuery] GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var result = await sender.Send(request, cancellationToken);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpGet("{projectId:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType<ErrorViewModel>(500)]
        public async Task<ActionResult<ProjectViewModel>> GetAsync([FromRoute] int projectId, CancellationToken cancellationToken)
        {
            var query = new GetProjectQuery(projectId);
            var result = await sender.Send(query, cancellationToken);
            return result is not null ? Ok(result) : NotFound();
        }
    }
}
