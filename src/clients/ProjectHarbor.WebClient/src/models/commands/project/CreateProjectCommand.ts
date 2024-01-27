type CreateProjectCommand = {
  name: string
  briefDescription: string
  codeRepositoryUrl: string | null
  price: number | null
  description: string
}

export default CreateProjectCommand
