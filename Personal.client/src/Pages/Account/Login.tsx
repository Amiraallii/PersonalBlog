import { useState } from "react";
import axios from "axios";

interface LoginResponse {
    token: string;
}

export default function Login() {
    const [form, setForm] = useState({
        fullName: "",
        email: "",
        password: ""
    });

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await axios.post<LoginResponse>(
                "http://localhost:5240/api/auth/login",
                form
            );

            alert("ورود موفق! توکن: " + response.data.token);
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
        <div className="bg-gradient-to-br from-secondary to-light min-h-screen flex items-center justify-center p-4" data-new-gr-c-s-check-loaded="14.1241.0" data-gr-ext-installed="">
            <div className="bg-white rounded-lg shadow-xl overflow-hidden w-full max-w-md">
                <div className="bg-primary p-6 text-center">
                    <h1 className="text-2xl font-bold text-white">ورود</h1>
                    <p className="text-secondary/80 mt-1">لطفا اطلاعات خود را وارد کنید</p>
                </div>
                <form
                    onSubmit={handleSubmit}
                    className="max-w-md mx-auto mt-10 p-6 bg-white rounded-xl shadow space-y-4"
                >   

                    <div className="space-y-2">
                        <label htmlFor="email" className="block text-sm font-medium text-gray-700">ایمیل</label>
                        <input type="email" id="email" name="email" required
                            placeholder="ایمیل"
                            value={form.email}
                            onChange={(e) => setForm({ ...form, email: e.target.value })}
                            className="w-full px-4 py-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-primary focus:border-primary transition-all duration-200 outline-none" />
                    </div>



                    <div className="space-y-2">
                        <label htmlFor="password" className="block text-sm font-medium text-gray-700">رمز عبور</label>
                        <input type="password" id="password" name="password" placeholder="رمز عبور"
                            value={form.password}
                            onChange={(e) => setForm({ ...form, password: e.target.value })}
                            required className="w-full px-4 py-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-primary focus:border-primary transition-all duration-200 outline-none" />
                    </div>

                    {/*<div className="space-y-2">*/}
                    {/*    <label htmlFor="confirmPassword" className="block text-sm font-medium text-gray-700">تکرار رمز عبور</label>*/}
                    {/*    <input type="password" id="confirmPassword" name="confirmPassword" required className="w-full px-4 py-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-primary focus:border-primary transition-all duration-200 outline-none" placeholder="رمز عبور را مجدداً وارد کنید"/>*/}
                    {/*</div>*/}



                    <div className="pt-2">
                        <button type="submit"
                            className="w-full bg-primary hover:bg-accent text-white font-medium py-2.5 px-4 rounded-md transition-all duration-200 transform hover:scale-[1.02] focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-primary">
                             ورود
                        </button>
                    </div>

                    <div className="text-center text-sm text-gray-600 mt-4">
                        قبلاً ثبت نام نکرده‌اید؟ <a href="#" className="text-primary font-medium hover:underline">ثبت نام</a>
                    </div>
                </form>
            </div>

        </div>
    );
}
