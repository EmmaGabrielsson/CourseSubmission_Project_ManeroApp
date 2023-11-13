const stars = document.querySelectorAll('.review-rating i');

stars.forEach((star, rating) => {
    star.addEventListener('click', () => {
        stars.forEach((star, selected) => {
            rating >= selected ? star.classList.add('select') : star.classList.remove('select');
        });
    });
});