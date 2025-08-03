/** @type {import('tailwindcss').Config} */
export default {
    content: [
        "./index.html",
        "./src/**/*.{js,ts,jsx,tsx}", 
    ],
    darkMode: 'class', 
    theme: {
        extend: {
            fontFamily: {
                sans: ['Vazirmatn', 'sans-serif'],
            },
            colors: {
                primary: '#4A637D',
                secondary: '#F8F9FA',
                accent: '#7D94AB',
                light: '#FFFFFF',
                dark: '#2C3E50',
                'dark-bg': '#1a202c',
                'dark-card': '#2d3748',
                'dark-text': '#e2e8f0',
            }
        },
    },
    plugins: [],
}