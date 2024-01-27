import { Link, useNavigate } from 'react-router-dom';
import SignUpForm from '@/components/auth/SignUpForm';
import { buttonVariants } from '@/components/ui/button';

export default function SignUpPage() {
  const navigate = useNavigate()

  const handleSubmit = () => navigate('/auth/sign-in')

  return (
    <>
      <h1 className="font-bold font text-center text-4xl tracking-tight mb-8">Sign up</h1>

      <SignUpForm onSubmit={handleSubmit} />

      <div className="uppercase text-sm text-muted-foreground">Or if you have an account</div>

      <Link
        to="/auth/sign-in"
        className={`${buttonVariants({ variant: 'outline' })} w-full`}
      >
        Sign in
      </Link>
    </>
  )
}
