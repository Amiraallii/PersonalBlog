import { useState } from 'react';
import { Outlet, Link } from 'react-router-dom';

const Navbar = () => {
    const [isMenuOpen, setIsMenuOpen] = useState(false);

    const handleThemeToggle = () => {
        // این منطق فعلاً برای سادگی همینجا می‌مونه
        // در آینده این رو به یک Context منتقل می‌کنیم تا حرفه‌ای‌تر بشه
        document.documentElement.classList.toggle('dark');
    };

    return (
        <nav className="bg-light dark:bg-dark-card shadow-md sticky top-0 z-50">
            <div className="max-w-7xl mx-auto px-4">
                <div className="flex justify-between items-center h-16">
                    <h1 className="text-xl font-bold text-primary dark:text-accent">وبسایت شخصی</h1>

                    {/* Desktop Menu */}
                    <div className="hidden md:flex items-center space-x-8 space-x-reverse">
                        <Link to="/news" className="text-dark dark:text-dark-text hover:text-primary">اخبار</Link>
                        <Link to="/projects" className="text-dark dark:text-dark-text hover:text-primary">پروژه‌ها</Link>
                        <Link to="/blog" className="text-dark dark:text-dark-text hover:text-primary">بلاگ</Link>
                        <button onClick={handleThemeToggle} className="p-2 rounded-lg bg-gray-100 dark:bg-gray-700">🌙</button>
                        <Link to="/login" className="bg-primary hover:bg-accent text-white px-6 py-2 rounded-lg font-medium">ورود / ثبت نام</Link>
                    </div>

                    {/* Mobile Menu Button */}
                    <div className="md:hidden">
                        <button onClick={() => setIsMenuOpen(!isMenuOpen)}>
                            <svg className="h-6 w-6 text-dark dark:text-dark-text" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M4 6h16M4 12h16M4 18h16" />
                            </svg>
                        </button>
                    </div>
                </div>
            </div>

            {/* Mobile Menu Content */}
            <div className={`md:hidden ${isMenuOpen ? 'block' : 'hidden'}`}>
                <div className="px-2 pt-2 pb-3 space-y-1">
                    <Link to="/news" className="block px-3 py-2 text-dark dark:text-dark-text">اخبار</Link>
                    <Link to="/projects" className="block px-3 py-2 text-dark dark:text-dark-text">پروژه‌ها</Link>
                    {/* ... other mobile links */}
                </div>
            </div>
        </nav>
    );
};

const Footer = () => {
    return (
        <footer className="bg-primary dark:bg-dark-card text-white dark:text-dark-text py-8">
            <div className="max-w-7xl mx-auto px-4 text-center">
                <p>© ۲۰۲۴ وبسایت شخصی. تمامی حقوق محفوظ است.</p>
            </div>
        </footer>
    );
}

export const MainLayout = () => {
    return (
        <div className="bg-secondary dark:bg-dark-bg min-h-screen">
            <Navbar />
            <main>
                <Outlet />
            </main>
            <Footer />
        </div>
    )
}