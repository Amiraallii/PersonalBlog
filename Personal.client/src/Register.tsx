import { useState } from "react";
import axios from "axios";

interface RegisterResponse {
    token: string;
}

export default function Register() {
    const [form, setForm] = useState({
        fullName: "",
        email: "",
        password: ""
    });

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await axios.post<RegisterResponse>(
                "http://localhost:5240/api/auth/register",
                form
            );

            alert("ثبت نام موفق! توکن: " + response.data.token);
            localStorage.setItem("token", response.data.token);
        } catch (error) {
            if (
                typeof error === "object" &&
                error !== null &&
                "response" in error
            ) {
                const err = error as { response?: { data?: string[] } };
                alert("خطا: " + (err.response?.data?.[0] || "مشکلی پیش آمده است"));
            } else {
                alert("خطای ناشناخته");
            }
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                placeholder="نام کامل"
                value={form.fullName}
                onChange={(e) => setForm({ ...form, fullName: e.target.value })}
            />
            <input
                type="text"
                placeholder="ایمیل"
                value={form.email}
                onChange={(e) => setForm({ ...form, email: e.target.value })}
            />
            <input
                type="password"
                placeholder="رمز عبور"
                value={form.password}
                onChange={(e) => setForm({ ...form, password: e.target.value })}
            />
            <button type="submit">ثبت نام</button>
        </form>
    );
}
