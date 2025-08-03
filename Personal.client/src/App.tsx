import { BrowserRouter, Routes, Route } from "react-router-dom";
import { RegisterPage } from './Pages/Account/Register';
import { LoginPage } from './Pages/Account/Login';
import { MainLayout } from './Components/layouts/MainLayout';
import { HomePage } from './Pages/Home/HomePage';

export default function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/login" element={<LoginPage />} />
                <Route path="/register" element={<RegisterPage />} />

                <Route element={<MainLayout />}>
                    <Route path="/" element={<HomePage />} />
                    {/* بقیه صفحات مثل /news, /about و... اینجا قرار می‌گیرن */}
                </Route>
            </Routes>
        </BrowserRouter>
    );
}