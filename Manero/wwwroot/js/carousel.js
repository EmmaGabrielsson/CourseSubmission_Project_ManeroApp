const track = document.querySelector('.carousel_track');

const slides = Array.from(track.children);

const nextButton = document.querySelector('.carousel_button-right');
const prevButton = document.querySelector('.carousel_button-left');

const dotsNav = document.querySelector('.carousel_nav');

const dots = Array.from(dotsNav.children);

const slideWidth = slides[0].getBoundingClientRect().width;

const slideCount = slides.length;

let currentSlideIndex = 0;

let touchStartX = 0;
let touchEndX = 0;

slides.forEach((slide, index) => {
    slide.style.left = slideWidth * index + 'px';
});

const moveToSlide = (targetIndex) => {
    track.style.transform = 'translateX(-' + (targetIndex * slideWidth) + 'px';

    slides[currentSlideIndex].classList.remove('current-slide');

    slides[targetIndex].classList.add('current-slide');

    currentSlideIndex = targetIndex;
};

const updateDots = () => {
    const currentDot = dotsNav.querySelector('.current-slide');
    currentDot.classList.remove('current-slide');

    dots[currentSlideIndex].classList.add('current-slide');
};

nextButton.addEventListener('click', () => {
    let nextSlideIndex = currentSlideIndex + 1;

    if (nextSlideIndex >= slideCount) {
        nextSlideIndex = 0;
    }

    moveToSlide(nextSlideIndex);
    updateDots();
});

prevButton.addEventListener('click', () => {
    let prevSlideIndex = currentSlideIndex - 1;

    if (prevSlideIndex < 0) {
        prevSlideIndex = slideCount - 1;
    }

    moveToSlide(prevSlideIndex);
    updateDots();
});

dotsNav.addEventListener('click', (e) => {
    const targetDot = e.target.closest('button');

    if (!targetDot) return;

    const targetIndex = dots.indexOf(targetDot);
    moveToSlide(targetIndex);
    updateDots();
});

track.addEventListener('touchstart', (e) => {
    touchStartX = e.touches[0].clientX;
});

track.addEventListener('touchend', (e) => {
    touchEndX = e.changedTouches[0].clientX;
    handleSwipe();
});

const handleSwipe = () => {
    const swipeDistance = touchEndX - touchStartX;
    if (swipeDistance > 50) {
        let prevSlideIndex = currentSlideIndex - 1;
        if (prevSlideIndex < 0) {
            prevSlideIndex = slideCount - 1;
        }
        moveToSlide(prevSlideIndex);
        updateDots();
    } else if (swipeDistance < -50) {
        let nextSlideIndex = currentSlideIndex + 1;
        if (nextSlideIndex >= slideCount) {
            nextSlideIndex = 0;
        }
        moveToSlide(nextSlideIndex);
        updateDots();
    }
};

const moveToNextSlide = () => {
    let nextSlideIndex = currentSlideIndex - 1;
    if (nextSlideIndex < 0) {
        nextSlideIndex = slideCount - 1;
    }
    moveToSlide(nextSlideIndex);
    updateDots();
};

const slideInterval = setInterval(moveToNextSlide, 7000);

const autoSlideInterval = setInterval(() => {
    moveToNextSlide();
    updateDots();
}, 7000);

nextButton.addEventListener('click', () => {
    clearInterval(slideInterval);
    clearInterval(autoSlideInterval);
});
prevButton.addEventListener('click', () => {
    clearInterval(slideInterval);
    clearInterval(autoSlideInterval);
});
dotsNav.addEventListener('click', () => {
    clearInterval(slideInterval);
    clearInterval(autoSlideInterval);
});

moveToSlide();
updateDots();
moveToNextSlide();