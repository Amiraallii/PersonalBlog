import { useState, useEffect } from 'react'

const slidesData = [
    { title: "بلاگ و مطالب جذاب", description: "از فیلم و بازی تا کتاب و تکنولوژی", buttonText: "مطالعه بلاگ" },
    { title: "به وبسایت شخصی من خوش آمدید", description: "جایی برای به اشتراک گذاری پروژه‌ها و ایده‌ها", buttonText: "بیشتر بدانید" },
]
const HeroSlider = () => {
    const [currentSlide, setCurrentSlide] = useState(0);

    const nextSlide = () => {
        setCurrentSlide((prev) => (prev + 1) % slidesData.length);
    };

    useEffect(() => {
        const slideInterval = setInterval(nextSlide, 5000);
        return () => clearInterval(slideInterval);
    }, []);

    return (
        <div className="slider-container relative h-96 md:h-[500px] overflow-hidden bg-primary">
            {slidesData.map((slide, index) => (
                <div key={index} className={`absolute inset-0 flex items-center justify-center transition-opacity duration-1000 ${index === currentSlide ? 'opacity-100' : 'opacity-0'}`}>
                    <div className="text-center text-white">
                        <h2 className="text-3xl md:text-5xl font-bold mb-4">{slide.title}</h2>
                        <p className="text-lg md:text-xl mb-8">{slide.description}</p>
                        <button className="bg-light text-primary px-8 py-3 rounded-lg font-medium">{slide.buttonText}</button>
                    </div>
                </div>
            ))}
        </div>
    );

};
export const HomePage = () => {
    return (
        <>
            <HeroSlider />
            <main className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
                <section className="text-center mb-16">
                    <h2 className="text-3xl md:text-4xl font-bold text-dark dark:text-dark-text mb-6">خوش آمدید</h2>
                    <p className="text-lg text-gray-600 dark:text-gray-300 max-w-3xl mx-auto leading-relaxed">
                        این وبسایت جایی است برای به اشتراک گذاری پروژه‌های شخصی، تجربیات و علایق من.
                        از آخرین پروژه‌های تکنولوژی گرفته تا نقد فیلم‌ها، بازی‌ها و کتاب‌های مورد علاقه.
                    </p>
                </section>

                <div className="grid md:grid-cols-3 gap-8 mb-16">
                    <div className="bg-light dark:bg-dark-card rounded-xl p-6 shadow-lg hover:shadow-xl dark:shadow-gray-900/20 transition-all duration-300">
                        <div className="w-12 h-12 bg-primary rounded-lg flex items-center justify-center mb-4">
                            <svg className="w-6 h-6 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 11H5m14 0a2 2 0 012 2v6a2 2 0 01-2 2H5a2 2 0 01-2-2v-6a2 2 0 012-2m14 0V9a2 2 0 00-2-2M5 11V9a2 2 0 012-2m0 0V5a2 2 0 012-2h6a2 2 0 012 2v2M7 7h10"></path>
                            </svg>
                        </div>
                        <h3 className="text-xl font-semibold text-dark dark:text-dark-text mb-3">پروژه‌ها</h3>
                        <p className="text-gray-600 dark:text-gray-300 mb-4">مجموعه‌ای از پروژه‌های شخصی و حرفه‌ای که روی آن‌ها کار کرده‌ام</p>
                        <a href="#" className="text-primary dark:text-accent font-medium hover:text-accent dark:hover:text-primary transition-colors duration-200">مشاهده همه →</a>
                    </div>

                    <div className="bg-light dark:bg-dark-card rounded-xl p-6 shadow-lg hover:shadow-xl dark:shadow-gray-900/20 transition-all duration-300">
                        <div className="w-12 h-12 bg-primary rounded-lg flex items-center justify-center mb-4">
                            <svg className="w-6 h-6 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 6.253v13m0-13C10.832 5.477 9.246 5 7.5 5S4.168 5.477 3 6.253v13C4.168 18.477 5.754 18 7.5 18s3.332.477 4.5 1.253m0-13C13.168 5.477 14.754 5 16.5 5c1.746 0 3.332.477 4.5 1.253v13C19.832 18.477 18.246 18 16.5 18c-1.746 0-3.332.477-4.5 1.253"></path>
                            </svg>
                        </div>
                        <h3 className="text-xl font-semibold text-dark dark:text-dark-text mb-3">بلاگ</h3>
                        <p className="text-gray-600 dark:text-gray-300 mb-4">مطالب و نقدهایی درباره فیلم، بازی، کتاب و تکنولوژی</p>
                        <a href="#" className="text-primary dark:text-accent font-medium hover:text-accent dark:hover:text-primary transition-colors duration-200">خواندن مطالب →</a>
                    </div>

                    <div className="bg-light dark:bg-dark-card rounded-xl p-6 shadow-lg hover:shadow-xl dark:shadow-gray-900/20 transition-all duration-300">
                        <div className="w-12 h-12 bg-primary rounded-lg flex items-center justify-center mb-4">
                            <svg className="w-6 h-6 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z"></path>
                            </svg>
                        </div>
                        <h3 className="text-xl font-semibold text-dark dark:text-dark-text mb-3">درباره من</h3>
                        <p className="text-gray-600 dark:text-gray-300 mb-4">بیشتر درباره من، تجربیاتم و علایقم بدانید</p>
                        <a href="#" className="text-primary dark:text-accent font-medium hover:text-accent dark:hover:text-primary transition-colors duration-200">آشنایی بیشتر →</a>
                    </div>
                </div>
            </main>
        </>
    );
};