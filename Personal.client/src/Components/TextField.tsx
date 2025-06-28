interface TextFieldProps {
    label: string;
    type?: string;
    value: string;
    onChange: (val: string) => void;
    placeholder?: string;
    required?: boolean;
    id: string;
}

export default function TextField({
    label,
    type = "text",
    value,
    onChange,
    placeholder,
    required,
    id,
}: TextFieldProps) {
    return (
        <div className="space-y-2">
            <label htmlFor={id} className="block text-sm font-medium text-gray-700">{label}</label>
            <input
                type={type}
                id={id}
                value={value}
                onChange={(e) => onChange(e.target.value)}
                placeholder={placeholder}
                required={required}
                className="w-full px-4 py-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-primary focus:border-primary outline-none"
            />
        </div>
    );
}
