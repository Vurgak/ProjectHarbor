import { useForm } from 'react-hook-form';
import { Button } from '@/components/ui/button';
import { Form, FormControl, FormField, FormItem, FormLabel } from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import { Textarea } from '@/components/ui/textarea';
import CreateProjectCommand from '@/models/commands/project/CreateProjectCommand';
import { useProjectRequest } from '@/hooks/project/useProjectRequest';
import { useNavigate } from 'react-router-dom';
import { useState } from 'react';

export default function NewProjectPage() {
  const navigate = useNavigate()
  const { createProject } = useProjectRequest()

  const [errorMessage, setErrorMessage] = useState<string | null>(null)

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
    if (projectId != null)
      navigate(`/project/${projectId}`)
    else
      setErrorMessage('Form is not filled correctly')
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
                <Textarea {...field} />
              </FormControl>
            </FormItem>
          )}
        />

        {errorMessage && (
          <div className="border rounded border-rose-500 p-4 text-balance text-rose-500">
            {errorMessage}
          </div>
        )}

        <div className="flex justify-end">
          <Button type="submit">Create project</Button>
        </div>
      </form>
    </Form>
  )
}
