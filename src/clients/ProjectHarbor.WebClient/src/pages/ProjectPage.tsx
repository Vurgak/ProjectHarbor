import { useParams } from "react-router-dom"

export default function ProjectPage() {
  const params = useParams()

  return (
    <>
      Project ID: {params.projectId}
    </>
  )
}