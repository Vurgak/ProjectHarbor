import { useEffect, useState } from 'react'
import { Drawer, DrawerContent, DrawerHeader, DrawerTitle, DrawerTrigger } from '@/components/ui/drawer'
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from '@/components/ui/select'
import { Label } from '@/components/ui/label'
import SearchBar from '../SearchBar'

type ProjectFiltersProps = {
  onChange: (filters: ProjectSearchFilters) => void
}

const availablePageSizes = [10, 20, 50, 100] as const;

export default function ProjectFilters({ onChange }: ProjectFiltersProps) {
  var [filters, setFilters] = useState<ProjectSearchFilters>({
    pageSize: 10,
    sortOrder: 'newest',
  })

  const handleValueChange = (filterName: string, filterValue: string) => {
    setFilters({ ...filters, [filterName]: filterValue })
  }

  useEffect(() => onChange(filters), [filters])

  return (
    <>
      <SearchBar onSearch={_ => { }} disabled />

      <Drawer>
        <DrawerTrigger className="button-muted">Filters</DrawerTrigger>
        <DrawerContent className="w-full max-w-sm mx-auto">
          <DrawerHeader>
            <DrawerTitle>Filters</DrawerTitle>
          </DrawerHeader>
          <div className="m-3 mt-0">
            <Label>Sort by</Label>
            <Select value={filters.pageSize.toString()} onValueChange={value => handleValueChange('pageSize', value)}>
              <SelectTrigger>
                <SelectValue />
              </SelectTrigger>
              <SelectContent>
                {availablePageSizes.map(pageSize => <SelectItem key={pageSize} value={pageSize.toString()}>{pageSize}</SelectItem>)}
              </SelectContent>
            </Select>

            <Label>Sort by</Label>
            <Select value={filters.sortOrder} onValueChange={value => handleValueChange('sortOrder', value)}>
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
    </>
  )
}
