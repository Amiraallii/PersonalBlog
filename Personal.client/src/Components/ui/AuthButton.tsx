import React from 'react';

interface AuthButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
    isLoading?: boolean; 
}

export const AuthButton: React.FC<AuthButtonProps> = ({ children, isLoading, ...props }) => {
    return (
        <button
            {...props}
            disabled={isLoading || props.disabled}
            className="flex w-full justify-center rounded-lg bg-blue-600 px-4 py-3 text-sm font-semibold text-white shadow-sm hover:bg-blue-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-blue-600 disabled:opacity-50"
        >
            {isLoading ? 'در حال پردازش...' : children}
        </button>
    );
};