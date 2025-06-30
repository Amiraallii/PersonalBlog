import { Link } from 'react-router-dom'; // از Link به جای تگ a استفاده کنید
//import './Header.css'; // فایل استایل مخصوص هدر

export default function Header() {
    return (
        <header className="main-header">
            <div className="logo">AmirAli.</div>
            <nav>
                <Link to="/">Home</Link>
                <Link to="/my-vlog">My Vlog</Link>
                <Link to="/my-story">My Story</Link>
                {/* ... بقیه لینک‌ها */}
            </nav>
        </header>
    );
}