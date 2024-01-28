import { useState } from 'react';
import ProjectFilters from '@/components/project/ProjectFilters';
import ProjectList from '@/components/project/ProjectList';
import { useProjectsRequest } from '@/hooks/project/useProjectsRequest';
import { Link } from 'react-router-dom';

export default function BrowsePage() {
  const [filters, setFilters] = useState<ProjectSearchFilters>({
    pageSize: 10,
    sortOrder: 'newest',
  })

  const { isLoading, projects } = useProjectsRequest(filters)

  if (isLoading) {
    return <>Loading...</>
  }

  return (
    <>
      <div className="flex items-center gap-4 w-full">
        <ProjectFilters onChange={filters => setFilters(filters)} />
        <Link to="/project/new" className="button-solid">New</Link>
      </div>

      <ProjectList projects={projects!} />
    </>
  )
}
