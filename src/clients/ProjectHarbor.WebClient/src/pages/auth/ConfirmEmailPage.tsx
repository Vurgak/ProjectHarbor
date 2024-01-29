import { useSearchParams } from 'react-router-dom';

export default function ConfirmEmailPage() {
  const [searchParams, _] = useSearchParams()
  const email = searchParams.get('email')
  console.log(email)
  return (
    <>
      <h1 className="font-bold font text-center text-4xl tracking-tight mb-8">Confirm your account</h1>
    </>
  )
}
