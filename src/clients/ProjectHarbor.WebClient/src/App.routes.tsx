import { RouteObject } from 'react-router-dom';
import MainLayout from '@/layouts/MainLayout'
import HomePage from '@/pages/HomePage';
import BrowsePage from '@/pages/BrowsePage';
import ProjectPage from '@/pages/ProjectPage';
import NewProjectPage from '@/pages/NewProjectPage';
import SignUpPage from './pages/auth/SignUpPage';
import SignInPage from './pages/auth/SignInPage';
import AuthLayout from './layouts/AuthLayout';

export const appRoutes: RouteObject[] = [
  {
    path: '/',
    element: <MainLayout />,
    children: [
      {
        path: '/',
        element: <HomePage />
      },
      {
        path: 'browse',
        element: <BrowsePage />
      },
      {
        path: 'project/new',
        element: <NewProjectPage />
      },
      {
        path: 'project/:projectId',
        element: <ProjectPage />
      }
    ]
  },
  {
    path: '/auth',
    element: <AuthLayout />,
    children: [
      {
        path: 'sign-in',
        element: <SignInPage />
      },
      {
        path: 'sign-up',
        element: <SignUpPage />
      }
    ]
  }
]
