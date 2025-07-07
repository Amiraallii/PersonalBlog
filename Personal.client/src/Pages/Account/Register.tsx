import { useState } from "react";
import axios from "axios";

interface RegisterResponse {
    token: string;
}

export default function Register() {
    const [form, setForm] = useState({
        fullName: "",
        email: "",
        phone: "",
        password: "",
        confirmPassword: "",
        acceptTerms: false
    });

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        if (form.password !== form.confirmPassword) {
            alert("رمز عبور و تکرار آن مطابقت ندارند.");
            return;
        }

        if (!form.acceptTerms) {
            alert("لطفاً قوانین را بپذیرید.");
            return;
        }

        try {
            const response = await axios.post<RegisterResponse>(
                "http://localhost:5240/api/auth/register",
                {
                    fullName: form.fullName,
                    email: form.email,
                    phone: form.phone,
                    password: form.password
                }
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
        <div className="bg-gradient-to-br from-secondary to-light min-h-screen flex items-center justify-center p-4">
            <div className="bg-white rounded-lg shadow-xl overflow-hidden w-full max-w-md">
                <div className="bg-primary p-6 text-center">
                    <h1 className="text-2xl font-bold text-black">ثبت نام</h1>
                    <p className="text-secondary/80 mt-1 text-black">لطفا اطلاعات خود را وارد کنید</p>
                </div>

                <form onSubmit={handleSubmit} className="p-6 space-y-4">
                    {/* Full Name */}
                    <div className="space-y-2">
                        <label htmlFor="fullName" className="block text-sm font-medium text-gray-700">نام و نام خانوادگی</label>
                        <input
                            type="text"
                            id="fullName"
                            value={form.fullName}
                            onChange={(e) => setForm({ ...form, fullName: e.target.value })}
                            className="w-full px-4 py-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-primary focus:border-primary transition-all duration-200 outline-none"
                            placeholder="نام و نام خانوادگی خود را وارد کنید"
                            required
                        />
                    </div>

                    {/* Email */}
                    <div className="space-y-2">
                        <label htmlFor="email" className="block text-sm font-medium text-gray-700">ایمیل</label>
                        <input
                            type="email"
                            id="email"
                            value={form.email}
                            onChange={(e) => setForm({ ...form, email: e.target.value })}
                            className="w-full px-4 py-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-primary focus:border-primary transition-all duration-200 outline-none"
                            placeholder="example@email.com"
                            required
                        />
                    </div>

                    {/* Phone */}
                    <div className="space-y-2">
                        <label htmlFor="phone" className="block text-sm font-medium text-gray-700">شماره موبایل</label>
                        <input
                            type="tel"
                            id="phone"
                            value={form.phone}
                            onChange={(e) => setForm({ ...form, phone: e.target.value })}
                            className="w-full px-4 py-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-primary focus:border-primary transition-all duration-200 outline-none"
                            placeholder="09xxxxxxxxx"
                            required
                        />
                    </div>

                    {/* Password */}
                    <div className="space-y-2">
                        <label htmlFor="password" className="block text-sm font-medium text-gray-700">رمز عبور</label>
                        <input
                            type="password"
                            id="password"
                            value={form.password}
                            onChange={(e) => setForm({ ...form, password: e.target.value })}
                            className="w-full px-4 py-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-primary focus:border-primary transition-all duration-200 outline-none"
                            placeholder="رمز عبور خود را وارد کنید"
                            required
                        />
                    </div>

                    {/* Confirm Password */}
                    <div className="space-y-2">
                        <label htmlFor="confirmPassword" className="block text-sm font-medium text-gray-700">تکرار رمز عبور</label>
                        <input
                            type="password"
                            id="confirmPassword"
                            value={form.confirmPassword}
                            onChange={(e) => setForm({ ...form, confirmPassword: e.target.value })}
                            className="w-full px-4 py-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-primary focus:border-primary transition-all duration-200 outline-none"
                            placeholder="رمز عبور را مجدداً وارد کنید"
                            required
                        />
                    </div>

                    {/* Accept Terms */}
                    <div className="flex items-center">
                        <input
                            type="checkbox"
                            id="terms"
                            checked={form.acceptTerms}
                            onChange={(e) => setForm({ ...form, acceptTerms: e.target.checked })}
                            className="w-4 h-4 text-primary focus:ring-primary border-gray-300 rounded"
                            required
                        />
                        <label htmlFor="terms" className="mr-2 block text-sm text-gray-700">
                            با <a href="#" className="text-primary hover:underline">قوانین و مقررات</a> موافقم
                        </label>
                    </div>

                    {/* Submit Button */}
                    <div className="pt-2">
                        <button
                            type="submit"
                            className="w-full bg-primary hover:bg-accent text-black font-medium py-2.5 px-4 rounded-md transition-all duration-200 transform hover:scale-[1.02] focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-primary"
                        >
                            ثبت نام
                        </button>
                    </div>

                    <div className="text-center text-sm text-gray-600 mt-4">
                        قبلاً ثبت نام کرده‌اید؟ <a href="#" className="text-primary font-medium hover:underline">ورود</a>
                    </div>
                </form>
            </div>
        </div>
    );
}
