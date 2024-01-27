import { cn } from '@/utils';
import { Link, useLocation } from "react-router-dom";

const navLinks = [
  {
    label: 'Home',
    route: '/',
  },
  {
    label: 'Browse',
    route: '/browse',
  }
]

export default function SiteHeader() {
  const { pathname: currentRoute } = useLocation()

  return (
    <header className="sticky top-0 flex items-center h-16 px-6 gap-4 border-b">
      <section className="font-bold">Project Harbor</section>

      <nav>
        {navLinks.map(link => (
          <Link
            key={link.route}
            to={link.route}
            className={cn(
              `px-4 py-1 rounded-full hover:text-primary`,
              link.route == currentRoute
                ? 'bg-muted font-medium text-primary'
                : 'text-muted-foreground'
            )}
          >
            {link.label}
          </Link>
        ))}
      </nav>

      <section className="flex gap-4 ml-auto">
        <Link to="/auth/sign-in" className="button-muted">Sign in</Link>
        <Link to="/auth/sign-up" className="button-primary">Sign up</Link>
      </section>
    </header >
  )
}
