import { Outlet } from 'react-router-dom';
import SiteHeader from '@/components/header/SiteHeader';

export default function MainLayout() {
  return (
    <div className="flex flex-col min-h-screen">
      <SiteHeader />

      <div className="flex flex-1 max-w-screen-xl w-full mx-auto p-4">
        <Outlet />
      </div>
    </div>
  )
}
