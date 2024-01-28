import { RouterProvider, createBrowserRouter } from 'react-router-dom'
import { appRoutes } from '@/App.routes'
import { ThemeProvider } from '@/themes/ThemeProvider'

const router = createBrowserRouter(appRoutes)

export default function App() {
  return (
    <>
      <ThemeProvider defaultTheme="dark" storageKey="vite-ui-theme">
        <RouterProvider router={router} />
      </ThemeProvider>
    </>
  )
}
