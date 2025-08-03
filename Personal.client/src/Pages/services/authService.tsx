/* eslint-disable @typescript-eslint/no-explicit-any */
import axios from 'axios';

// آدرس پایه API شما. بهتره این رو در یک فایل کانفیگ یا متغیرهای محیطی (.env) قرار بدی
const API_URL = "http://localhost:5240/api/auth";

// تعریف یک تایپ برای داده‌های ورودی تابع register
// این تایپ باید با RegisterDto در بک‌اند شما مطابقت داشته باشه
interface RegisterData {
    userName: string;
    email: string;
    password: string;
}

// این تابع مسئول ارسال درخواست ثبت‌نام به سرور است
export const registerUser = async (userData: RegisterData) => {
    try {
        // یک درخواست POST به آدرس '.../register' با داده‌های کاربر ارسال می‌کنیم
        const response = await axios.post(`${API_URL}/register`, userData);

        // اگر درخواست موفق بود، داده‌های پاسخ (شامل توکن) رو برمی‌گردونیم
        return response.data;
    } catch (error: any) {
        // اگر سرور با خطا پاسخ داد (مثل خطای 400 برای ایمیل تکراری)
        if (error.response && error.response.data) {
            // خطاهایی که از بک‌اند میان رو پرتاب می‌کنیم تا کامپوننت بتونه اونها رو بگیره
            throw error.response.data;
        } else {
            // برای خطاهای پیش‌بینی نشده (مثل قطع بودن اینترنت)
            throw new Error('یک خطای پیش‌بینی نشده رخ داد.');
        }
    }
};

// می‌تونی تابع loginUser رو هم به همین شکل اینجا اضافه کنی