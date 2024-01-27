import CreateProjectCommand from '@/models/commands/project/CreateProjectCommand';
import ProjectViewModel from '@/models/viewModels/project/ProjectViewModel';

const apiGatewayUrl = import.meta.env.PH_API_GATEWAY_URL

export function useProjectRequest() {
  const createProject = async (request: CreateProjectCommand) => {
    const response = await fetch(`${apiGatewayUrl}/projects`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(request)
    })

    var data = await response.json() as ProjectViewModel
    return data.id
  }

  return {
    createProject,
  }
}
