const wishlistData = JSON.parse(localStorage.getItem('wishlist')) || [];

//add or remove an item to or from wishlist based on if it already exists in the wishlist
function toggleWishlist(productId, button) {

    const index = wishlistData.findIndex(x => x.productId === productId);

    if (index > -1) {
        wishlistData.splice(index, 1);
        button.classList.remove('fa-solid', 'red-heart-icon');
        button.classList.add('fa-regular');
    } else {
        const productItem = button.closest('.product-item');
        const productName = productItem.querySelector('.product-name').innerHTML;
        const productPriceElement = productItem.querySelector('.price')
        const productPrice = productPriceElement ? productPriceElement.innerHTML : null;
        const oldPriceElement = productItem.querySelector('.old-price');
        const productOldPrice = oldPriceElement ? oldPriceElement.innerHTML : null;
        const newPriceElement = productItem.querySelector('.new-price');
        const productNewPrice = newPriceElement ? newPriceElement.innerHTML : null;
        const productReview = productItem.querySelector('.star-review').innerHTML;
        const productImage = productItem.querySelector('img').getAttribute('src');
        const hasSale = productItem.querySelector('.sale');


        wishlistData.push({
            productId,
            productName,
            productOldPrice,
            productNewPrice,
            productPrice,
            productReview,
            productImage,
            hasSale,
        });

        button.classList.remove('fa-regular');
        button.classList.add('fa-solid', 'red-heart-icon');
    }
    localStorage.setItem('wishlist', JSON.stringify(wishlistData));
}

// check if a product is in the wishlist
function isProductInWishlist(productId) {
    return wishlistData.some(x => x.productId === productId);
}

// add click event listeners to all heart icons
document.querySelectorAll(".heart-icon").forEach(button => {
    const productId = button.closest('.product-item').getAttribute('id');

    button.addEventListener("click", function () {
        toggleWishlist(productId, button);
    });
});

// initialize heart icons based on localStorage
document.querySelectorAll(".heart-icon").forEach(button => {
    const productId = button.closest('.product-item').getAttribute('id');
    const isInWishlist = isProductInWishlist(productId);

    if (isInWishlist) {
        button.classList.remove('fa-regular');
        button.classList.add('fa-solid', 'red-heart-icon');
    }
});