import { Link } from 'react-router-dom';
import { Card, CardDescription, CardFooter, CardHeader, CardTitle } from '@/components/ui/card';
import ProjectBriefDto from '@/models/viewModels/project/ProjectBriefDto';
import { fromNow } from '@/utils/dateUtils';

export interface ProjectCardProps {
  project: ProjectBriefDto,
}

export default function ProjectCard({ project }: ProjectCardProps) {
  const updatedSpan = project.modifiedAt != null ? (
    <span>Updated {fromNow(project.modifiedAt)} ago</span>
  ) : (
    <span>Created {fromNow(project.createdAt)} ago</span>
  )

  return (
    <Card>
      <CardHeader>
        <Link to={`/project/${project.id}`}>
          <CardTitle>{project.name}</CardTitle>
        </Link>
        <CardDescription>{project.briefDescription}</CardDescription>
      </CardHeader>

      <CardFooter>
        <span>{updatedSpan}</span>
      </CardFooter>
    </Card>
  )
}
