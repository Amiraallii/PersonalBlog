import React from 'react';

interface AuthLayoutProps {
    children: React.ReactNode;
    title: string;
}

export const AuthLayout: React.FC<AuthLayoutProps> = ({ children, title }) => {
    return (
        
        <div className="flex min-h-screen items-center justify-center bg-gray-50 p-4">

            <div className="w-full max-w-md space-y-8">

                <div className="text-center">
                    <h2 className="mt-6 text-3xl font-bold tracking-tight text-gray-900">
                        {title} 
                    </h2>
                </div>

                
                <div className="rounded-xl bg-white p-8 shadow-lg">
                    {children} 
                </div>

            </div>
        </div>
    );
};