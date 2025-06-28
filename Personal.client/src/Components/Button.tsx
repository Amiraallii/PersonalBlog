interface ButtonProps {
    type?: "submit" | "button";
    children: React.ReactNode;
}

export default function Button({ type = "button", children }: ButtonProps) {
    return (
        <button
            type={type}
            className="w-full bg-primary hover:bg-accent text-white font-medium py-2.5 px-4 rounded-md transition-all duration-200 transform hover:scale-[1.02] focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-primary"
        >
            {children}
        </button>
    );
}
