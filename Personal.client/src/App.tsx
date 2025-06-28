import { BrowserRouter, Routes, Route } from "react-router-dom";
import Register from './Pages/Account/Register';
import Login from './Pages/Account/Login';


export default function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Register />} />
                <Route path="/login" element={<Login />} />
            </Routes>
        </BrowserRouter>
    );
}

