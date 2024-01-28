import { useState } from 'react'

const identityApiUrl = import.meta.env.PH_IDENTITY_API_URL

export function useAuthRequest() {
  const [loading, setLoading] = useState(false)
  const [result, setResult] = useState({ signedUp: false })

  const signUp = async (email: string, password: string) => {
    setLoading(true)

    try {
      const response = await fetch(`${identityApiUrl}/register`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ email, password })
      })

      setResult({ signedUp: response.ok })
    } catch (error) {
      console.error(error)
      setResult({ signedUp: false })
    } finally {
      setLoading(false)
    }
  }

  return {
    loading,
    result,
    signUp,
  }
}
