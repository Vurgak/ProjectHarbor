import ProjectBriefDto from './ProjectBriefDto'

type ProjectsViewModel = {
  projects: ProjectBriefDto[],
  pageOffset: number,
  pageSize: number,
  totalCount: number,
}

export default ProjectsViewModel
