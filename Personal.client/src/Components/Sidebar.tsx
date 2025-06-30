//import './Sidebar.css'; // فایل استایل مخصوص سایدبار

export default function Sidebar() {
    return (
        <aside className="social-sidebar">
            <a href="#"><i className="fab fa-youtube"></i></a>
            <a href="#"><i className="fab fa-instagram"></i></a>
            <a href="#"><i className="fab fa-facebook-f"></i></a>
            {/* ... بقیه آیکون‌ها */}
        </aside>
    );
}