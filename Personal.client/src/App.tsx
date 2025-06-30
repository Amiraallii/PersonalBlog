import { BrowserRouter, Routes, Route } from "react-router-dom";
import Register from './Pages/Account/Register';
import Login from './Pages/Account/Login';
import Layout from './Components/Layout';      // این همون قالب اصلیه

export default function App() {
    return (
        <BrowserRouter>
            <Routes>
                {/* ===== صفحاتی که Layout ندارند (تمام صفحه هستن) ===== */}
                {/*<Route path="/login" element={<Login />} />*/}
                {/*<Route path="/register" element={<Register />} />*/}


                {/* ===== صفحاتی که داخل Layout نمایش داده می‌شن ===== */}
                {/* این روت اصلی، قالب Layout رو نشون می‌ده */}
                <Route path="/" element={<Layout />}>

                    {/* این روت‌های تو در تو، محتواشون داخل اون قالب نمایش داده می‌شه */}
                    <Route index element={<Login />} />
                    <Route path="/register" element={<Register />} />
                    {/* بقیه صفحه‌هایی که هدر و سایدبار دارن رو اینجا اضافه کن */}

                </Route>
            </Routes>
        </BrowserRouter>
    );
}

