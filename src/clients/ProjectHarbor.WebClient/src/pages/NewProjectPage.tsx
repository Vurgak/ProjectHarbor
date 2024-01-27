import { useForm } from 'react-hook-form';
import * as z from "zod"
import { Button } from '@/components/ui/button';
import { Form, FormControl, FormField, FormItem, FormLabel } from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import { TextArea } from '@/components/ui/textarea';
import CreateProjectCommand from '@/models/commands/project/CreateProjectCommand';
import { useProjectRequest } from '@/hooks/project/useProjectRequest';
import { useNavigate } from 'react-router-dom';

export default function NewProjectPage() {
  const navigate = useNavigate()
  const { createProject } = useProjectRequest()

  const form = useForm<CreateProjectCommand>({
    defaultValues: {
      name: '',
      briefDescription: '',
      codeRepositoryUrl: '',
      price: 0.0,
      description: '',
    },
  })

  const handleSubmit = async (data: CreateProjectCommand) => {
    if (data.codeRepositoryUrl!.trim() == '')
      data.codeRepositoryUrl = null

    const projectId = await createProject(data);
    navigate(`/project/${projectId}`)
    console.log(data)
  }

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(handleSubmit)} className="w-full max-w-lg mx-auto space-y-4">
        <FormField
          name="name"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Project name</FormLabel>
              <FormControl>
                <Input {...field} />
              </FormControl>
            </FormItem>
          )}
        />

        <FormField
          name="briefDescription"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Brief description</FormLabel>
              <FormControl>
                <Input {...field} />
              </FormControl>
            </FormItem>
          )}
        />

        <FormField
          name="codeRepositoryUrl"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Code repository</FormLabel>
              <FormControl>
                <Input {...field} />
              </FormControl>
            </FormItem>
          )}
        />

        <FormField
          name="price"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Price</FormLabel>
              <FormControl>
                <Input {...field} />
              </FormControl>
            </FormItem>
          )}
        />

        <FormField
          name="description"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Description</FormLabel>
              <FormControl>
                <TextArea {...field} />
              </FormControl>
            </FormItem>
          )}
        />

        <div className="flex justify-end">
          <Button type="submit">Create project</Button>
        </div>
      </form>
    </Form>
  )
}
