import { useEffect, useState } from 'react'
import ProjectsViewModel from '@/models/viewModels/project/ProjectsViewModel'

const apiGatewayUrl = import.meta.env.PH_API_GATEWAY_URL

export function useProjectsRequest(filters: ProjectSearchFilters) {
  const [projects, setProjects] = useState<ProjectsViewModel | null>(null)

  const getProjects = async (filters: ProjectSearchFilters) => {
    const url = filters == null ? (
      `${apiGatewayUrl}/projects`
    ) : (
      `${apiGatewayUrl}/projects?pageSize=${filters.pageSize}&sortOrder=${filters.sortOrder}`
    )
    const response = await fetch(url)
    const data = await response.json() as ProjectsViewModel
    setProjects(data)
  }

  useEffect(() => { getProjects(filters) }, [filters])

  return {
    isLoading: projects == null,
    projects,
  }
}
