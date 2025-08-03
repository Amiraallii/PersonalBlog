/* eslint-disable @typescript-eslint/no-explicit-any */
import { useState } from 'react';
import axios from 'axios';
import { AuthLayout } from '../../Components/layouts/AuthLayout';
import { InputField } from '../../Components/ui/InputField';
import { AuthButton } from '../../Components/ui/AuthButton';

export const RegisterPage = () => {
    const [userName, setUserName] = useState('');
    const [fullName, setFullName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const [isLoading, setIsLoading] = useState(false);
    const [errors, setErrors] = useState<any>({}); 

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        setIsLoading(true);
        setErrors({}); 

        try {
            const response = await axios.post('http://localhost:5240/api/auth/Register', {
                fullName: fullName,
                userName: userName,
                email: email,
                password: password,
            });

            console.log('ثبت نام موفق بود!', response.data);
            alert('ثبت نام با موفقیت انجام شد! حالا به صفحه ورود منتقل می‌شوید.');

        } catch (error: any) {
            console.error('خطایی در ثبت نام رخ داد!', error);
            if (error.response && error.response.data) {
                setErrors(error.response.data.errors || { general: 'مشکلی پیش آمده است.' });
            } else {
                setErrors({ general: 'ارتباط با سرور برقرار نشد.' });
            }

        } finally {
            setIsLoading(false);
        }
    };

    return (
        <AuthLayout title="ایجاد حساب کاربری">
            <form onSubmit={handleSubmit} className="space-y-6">
                <InputField
                    id="fullName"
                    label="نام کامل"
                    type="text"
                    value={fullName}
                    onChange={(e) => setFullName(e.target.value)}
                    error={errors.FullName}
                    required
                />
                <InputField
                    id="username"
                    label="نام کاربری"
                    type="text"
                    value={userName}
                    onChange={(e) => setUserName(e.target.value)}
                    error={errors.UserName}
                    required
                />
                <InputField
                    id="email"
                    label="آدرس ایمیل"
                    type="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    error={errors.Email}
                    required
                />
                <InputField
                    id="password"
                    label="رمز عبور"
                    type="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    error={errors.Password}
                    required
                />
                <div>
                    <AuthButton type="submit" isLoading={isLoading}>
                        ثبت نام
                    </AuthButton>
                </div>
            </form>
            <p className="mt-4 text-center text-sm text-gray-600">
                قبلاً ثبت‌نام کرده‌اید؟{' '}
                <a href="/login" className="font-medium text-blue-600 hover:text-blue-500">
                    وارد شوید
                </a>
            </p>
        </AuthLayout>
    );
};