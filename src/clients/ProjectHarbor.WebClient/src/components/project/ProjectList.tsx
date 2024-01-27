import { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import SearchBar from '@/components/SearchBar'
import ProjectCard from '@/components/project/ProjectCard'
import { Drawer, DrawerContent, DrawerHeader, DrawerTitle, DrawerTrigger } from '@/components/ui/drawer'
import { Label } from '@/components/ui/label'
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from '@/components/ui/select'
import ProjectBriefDto from '@/models/viewModels/project/ProjectBriefDto'
import ProjectsViewModel from '@/models/viewModels/project/ProjectsViewModel'

const apiGatewayUrl = import.meta.env.PH_API_GATEWAY_URL

const availablePageSizes = [10, 20, 50, 100] as const;

export default function ProjectList() {
  const [filters, setFilters] = useState<ProjectSearchFilters>({
    pageSize: availablePageSizes[0],
    sortOrder: 'newest',
  })
  const [projects, setProjects] = useState<ProjectBriefDto[]>([])

  useEffect(() => {
    const fetchProjects = async () => {
      console.log('fetching projects')
      const url = `${apiGatewayUrl}/projects?pageSize=${filters.pageSize}&sortOrder=${filters.sortOrder}`
      const response = await fetch(url)
      const data = await response.json() as ProjectsViewModel
      setProjects(data.projects)
    }

    fetchProjects()
  }, [filters])

  const handleSearch = (text: string) => console.log(text)

  const handleFiltersChange = (filterName: string, filterValue: string) => {
    setFilters({ ...filters, [filterName]: filterValue })
  }

  return (
    <div className="w-full">
      <div className="flex gap-4 items-center mb-4">
        <SearchBar onSearch={handleSearch} disabled />

        <Drawer>
          <DrawerTrigger className="button-muted">Filters</DrawerTrigger>
          <DrawerContent className="w-full max-w-sm mx-auto">
            <DrawerHeader>
              <DrawerTitle>Filters</DrawerTitle>
            </DrawerHeader>
            <div className="m-3 mt-0">
              <Label>Sort by</Label>
              <Select value={filters.pageSize.toString()} onValueChange={value => handleFiltersChange('pageSize', value)}>
                <SelectTrigger>
                  <SelectValue />
                </SelectTrigger>
                <SelectContent>
                  {availablePageSizes.map(pageSize => <SelectItem value={pageSize.toString()}>{pageSize}</SelectItem>)}
                </SelectContent>
              </Select>

              <Label>Sort by</Label>
              <Select value={filters.sortOrder} onValueChange={value => handleFiltersChange('sortOrder', value)}>
                <SelectTrigger>
                  <SelectValue />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="newest">Newest</SelectItem>
                  <SelectItem value="updated">Updated</SelectItem>
                </SelectContent>
              </Select>
            </div>
          </DrawerContent>
        </Drawer>

        <Link to="/project/new" className="button-solid">New</Link>
      </div>

      <div className="grid grid-cols-1 grid-cols-1 lg:grid-cols-2 gap-4 mx-auto hover:text-muted-background">
        {projects.map(project => <ProjectCard key={project.id} project={project} />)}
      </div>
    </div>
  )
}
