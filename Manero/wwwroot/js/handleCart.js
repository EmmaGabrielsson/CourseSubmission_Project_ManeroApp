document.addEventListener('DOMContentLoaded', function () {
    let decrementButtons = document.querySelectorAll('.quantity-button-decrement');
    let incrementButtons = document.querySelectorAll('.quantity-button-increment');
    const addPromocodeButton = document.getElementById("add-promocode-button");

    adjustProductNames();
    window.addEventListener('resize', function () {
        adjustProductNames();
    });
    decrementButtons.forEach(function (decrementButton) {
        decrementButton.addEventListener('click', function () {
            handleQuantityChange(decrementButton, -1);
        });
    });

    incrementButtons.forEach(function (incrementButton) {
        incrementButton.addEventListener('click', function () {
            handleQuantityChange(incrementButton, 1);
        });
    });

    addPromocodeButton.addEventListener('click', function () {
        let promocodeId = document.getElementById("promocode-input-cart").value;
        let orderId = document.getElementById("promocode-input-cart").dataset.orderId;
        addPromocodeToCart(promocodeId, orderId);
    });

    function handleQuantityChange(button, change) {
        let quantityInput = button.closest('.product-quantity-cart-item').querySelector('.quantity-input');
        let currentQuantity = parseInt(quantityInput.value, 10);

        if (change > 0) {
            // Increment action
            let maxQuantity = parseInt(button.getAttribute('max'), 10);

            if ((currentQuantity + change) <= maxQuantity) {
                quantityInput.value = currentQuantity + change;

                // Delay added before sending the update request
                setTimeout(() => {
                    updateQuantityInputOnProduct(quantityInput.dataset.variantId, quantityInput.dataset.orderId, quantityInput.value);
                }, 1000);
            } else {
                // Handle reaching maximum quantity
                alert(`Products stock is no more then ${maxQuantity}.`);
            }
        } else if (change < 0) {
            // Decrement action
            if ((currentQuantity + change) > 0) {
                quantityInput.value = currentQuantity + change;

                // Delay added before sending the update request
                setTimeout(() => {
                    updateQuantityInputOnProduct(quantityInput.dataset.variantId, quantityInput.dataset.orderId, quantityInput.value);
                }, 1000);
            } else {
                if (confirm("Do you want to remove the product from the cart?")) {
                    let productVariantId = quantityInput.dataset.variantId;
                    let orderId = quantityInput.dataset.orderId;

                    removeProductFromCart(productVariantId, orderId);
                }
            }
        }
    }
});


function updateQuantityInputOnProduct(productVariantId, orderId, qty) {
    // Send an AJAX request to the server to update quantity of the product in order
    fetch(`/Product/UpdateQuantity?productVariantId=${productVariantId}&orderId=${orderId}&qty=${qty}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({})
    })
        .then(response => {
            if (response.ok) {
                location.reload();
            } else {
                console.error('Failed to update quantity. Server returned:', response);
            }
        })
        .catch(error => {
            console.error('An error occurred:', error);
        });
}

function removeProductFromCart(productVariantId, orderId) {
    // Send an AJAX request to the server to remove the product
    fetch(`/Product/RemoveProduct?productVariantId=${productVariantId}&orderId=${orderId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({})
    })
        .then(response => {
            if (response.ok) {
                location.reload();
            } else {
                console.error('Failed to remove product from the cart. Server returned:', response);
            }
        })
        .catch(error => {
            console.error('An error occurred while removing the product from the cart:', error);
        });
}

function addPromocodeToCart(promocodeId, orderId) {
    // Send an AJAX request to the server to add promocode
    fetch(`/Product/AddPromocode?promocodeId=${promocodeId}&orderId=${orderId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({})
    })
        .then(response => {
            if (response.ok) {
                location.reload();
            } else {
                console.error('Failed to add promocode to cart. Server returned:', response);
            }
        })
        .catch(error => {
            console.error('An error occurred while adding promocode to cart:', error);
        });
}

function adjustProductNames() {
    var windowWidth = window.innerWidth;
    var productParagraphs = document.querySelectorAll('.product-name-paragraph');

    productParagraphs.forEach(function (paragraph) {
        var productName = paragraph.dataset.fullname;

        if (windowWidth > 800) {
            paragraph.textContent = productName;
        } else {

            if (productName.length > 30) {
                paragraph.textContent = productName.substring(0, 30) + "..";
            }
        }
    });
}
