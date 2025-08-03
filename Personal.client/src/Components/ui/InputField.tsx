import React from 'react';

interface InputFieldProps extends React.InputHTMLAttributes<HTMLInputElement> {
    label: string;
    error?: string; 
}

export const InputField: React.FC<InputFieldProps> = ({ label, id, error, ...props }) => {
    return (
        <div>
            <label htmlFor={id} className="block text-sm font-medium text-gray-700">
                {label}
            </label>
            <div className="mt-1">
                <input
                    id={id}
                    {...props}
                    className={`block w-full text-white appearance-none rounded-lg border border-gray-300 px-3 py-2 placeholder-gray-400 shadow-sm focus:outline-none sm:text-sm 
            ${error
                            ? 'border-red-500 focus:border-red-500 focus:ring-red-500'
                            : 'focus:border-blue-500 focus:ring-blue-500'
                        }
          `}
                />
                {error && <p className="mt-1 text-xs text-red-600">{error}</p>}
            </div>
        </div>
    );
};