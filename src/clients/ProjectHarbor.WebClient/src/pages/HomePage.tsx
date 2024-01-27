import { Link } from 'react-router-dom';

export default function HomePage() {
  return (
    <div className="flex flex-col gap-8 items-center justify-center w-full mb-16">
      <h2 className="text-center text-6xl font-bold tracking-tight">
        Show your creativity and coding skill
      </h2>

      <h3 className="text-center text-2xl text-muted-foreground">
        Discover and share your projects with the world
      </h3>

      <div className="flex gap-4">
        <Link to="/browse" className="button-solid">Browse projects</Link>
        <Link to="/auth/sign-up" className="button-primary">Sign up</Link>
      </div>
    </div>
  )
}
