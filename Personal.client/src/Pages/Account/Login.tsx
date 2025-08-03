/* eslint-disable @typescript-eslint/no-explicit-any */
import { useState } from 'react';
import axios from 'axios';
import { AuthLayout } from '../../Components/layouts/AuthLayout';
import { InputField } from '../../Components/ui/InputField';
import { AuthButton } from '../../Components/ui/AuthButton';

export const LoginPage = () => {
    const [LoginIdentifier, setULoginIdentifier] = useState('');
    const [password, setPassword] = useState('');

    const [isLoading, setIsLoading] = useState(false);
    const [errors, setErrors] = useState<any>({});

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        setIsLoading(true);
        setErrors({});

        try {
            const response = await axios.post('http://localhost:5240/api/auth/Login', {
                LoginIdentifier: LoginIdentifier,
                password: password,
            });

            console.log('ورود موفق بود!', response.data);
            alert('خوش آمدید.');

        } catch (error: any) {
            console.error('خطایی در ورود رخ داد!', error);
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
        <AuthLayout title="ورود کاربر">
            <form onSubmit={handleSubmit} className="space-y-6">
                <InputField
                    id="LoginIdentifier"
                    label="نام کاربری یا ایمیل"
                    type="text"
                    value={LoginIdentifier}
                    onChange={(e) => setULoginIdentifier(e.target.value)}
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
                        ورود
                    </AuthButton>
                </div>
            </form>
            <p className="mt-4 text-center text-sm text-gray-600">
                کاربر نیستید؟{' '}
                <a href="/register" className="font-medium text-blue-600 hover:text-blue-500">
                    ثبت نام کنید
                </a>
            </p>
        </AuthLayout>
    );
};