import { Outlet } from 'react-router-dom'; // Outlet برای نمایش محتوای متغیر است
import Header from './Header';
import Sidebar from './Sidebar';
//import './Layout.css'; // برای استایل‌دهی به چیدمان کلی

export default function Layout() {
    return (
        <div className="app-container">
            <Header />
            <Sidebar />
            <main className="content">
                {/* هر صفحه‌ای که کاربر باز کند، محتوای آن اینجا نمایش داده می‌شود */}
                <Outlet />
            </main>
        </div>
    );
}