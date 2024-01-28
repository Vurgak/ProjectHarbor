import { Outlet } from 'react-router-dom';
import SiteHeader from '@/components/header/SiteHeader';

export default function MainLayout() {
  return (
    <div className="flex flex-col min-h-screen">
      <SiteHeader />

      <div className="flex flex-col flex-1 gap-4 max-w-screen-xl w-full mx-auto p-4">
        <Outlet />
      </div>

      <footer className="p-4 text-muted-foreground text-center">
        &copy; Damian Koski. All rights reserved.
      </footer>
    </div>
  )
}
