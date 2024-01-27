import { Outlet } from 'react-router-dom';

export default function MainLayout() {
  return (
    <div className="flex w-screen h-screen justify-center items-center">
      <div className="flex flex-col justify-center items-center w-full max-w-md h-full max-h-[704px] border rounded p-16 space-y-4">
        <Outlet />
      </div>
    </div>
  )
}
