import ProjectCard from '@/components/project/ProjectCard'
import ProjectsViewModel from '@/models/viewModels/project/ProjectsViewModel';

type ProjectListProps = {
  projects: ProjectsViewModel,
}

export default function ProjectList({ projects }: ProjectListProps) {
  return (
    <div className="w-full grid grid-cols-1 grid-cols-1 lg:grid-cols-2 gap-4 mx-auto hover:text-muted-background">
      {projects.projects.map(project => <ProjectCard key={project.id} project={project} />)}
    </div>
  )
}
