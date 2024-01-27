import { FieldValues, useForm } from 'react-hook-form'
import { Form, FormControl, FormField, FormItem, FormLabel } from '@/components/ui/form'
import { Input } from '@/components/ui/input'
import { Button } from '@/components/ui/button'
import { useAuthRequest } from '@/hooks/auth/useAuthRequest'
import { useNavigate } from 'react-router-dom'

type SignUpFormProps = {
  onSubmit: () => void
}

export default function SignUpForm({ onSubmit }: SignUpFormProps) {
  const { loading, result, signUp } = useAuthRequest()

  const form = useForm()

  const handleSubmit = (fields: FieldValues) => signUp(fields.email, fields.password)

  if (!loading && result.signedUp)
    onSubmit()

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(handleSubmit)} className="space-y-4 w-full">
        <FormField
          name="email"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Email</FormLabel>
              <FormControl>
                <Input type="email" {...field} />
              </FormControl>
            </FormItem>
          )}
        />

        <FormField
          name="password"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Password</FormLabel>
              <FormControl>
                <Input type="password" {...field} />
              </FormControl>
            </FormItem>
          )}
        />

        <FormField
          name="repeatPassword"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Repeat password</FormLabel>
              <FormControl>
                <Input type="password" {...field} />
              </FormControl>
            </FormItem>
          )}
        />

        <Button type="submit" disabled={loading} className="w-full">Sign up</Button>
      </form>
    </Form>
  )
}
