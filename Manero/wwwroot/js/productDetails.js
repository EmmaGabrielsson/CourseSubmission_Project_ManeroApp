document.addEventListener('DOMContentLoaded', function () {
    //------------------------------------------------------------------------------------
    // Code to control the image-slider 
    //------------------------------------------------------------------------------------
    var currentImageIndex = 0;
    var images = document.querySelectorAll('.img');
    var dots = document.querySelectorAll('.dot');

    function showImage(index) {
        images.forEach(image => image.style.display = 'none');
        images[index].style.display = 'block';

        // Reset attributes
        dots.forEach(dot => {
            dot.classList.remove('active');
            dot.style.width = '';
            dot.style.height = '';
            dot.style.border = '';
            dot.style.borderRadius = '';
            dot.style.backgroundColor = '';
        });

        // Apply attributes
        dots[index].classList.add('active');
        dots[index].style.width = '25px';
        dots[index].style.height = '12px';
        dots[index].style.border = '2px solid black';
        dots[index].style.borderRadius = '10px';
        dots[index].style.backgroundColor = 'white';
    }

    function nextImage() {
        currentImageIndex = (currentImageIndex + 1) % images.length;
        showImage(currentImageIndex);
    }

    function previousImage() {
        currentImageIndex = (currentImageIndex - 1 + images.length) % images.length;
        showImage(currentImageIndex);
    }

    document.getElementById('nextBtn').addEventListener('click', nextImage);
    document.getElementById('prevBtn').addEventListener('click', previousImage);

    // Initialize the slider with the first image when screen is more then 700px
    showImage(currentImageIndex);




    //------------------------------------------------------------------------------------
    // Handle Cookie consent modal 
    //------------------------------------------------------------------------------------
    const overlay = document.getElementById("overlay-consent");
    const modal = document.getElementById("confirmation-modal");
    const confirmButton = document.getElementById("confirm-button");
    const rejectButton = document.getElementById("reject-button");
    const addToCartButton = document.getElementById("add-to-cart-detail-btn");
    const additionalInfo = document.getElementById("additional-info");
    const showDetailsButton = document.getElementById("show-details-button");

    showDetailsButton.addEventListener("click", function (event) {
        if (additionalInfo.style.display === "none" || additionalInfo.style.display === "") {
            additionalInfo.style.display = "block";
        } else {
            additionalInfo.style.display = "none";
        }
    });


    // Check the user's consent and display the modal when the "Add to Cart" button is clicked
    addToCartButton.addEventListener("click", function (event) {
        if (!checkEssentialCookieConsent()) {
            event.preventDefault(); // Prevent the default form submission
            showConfirmationModal(); // Display the confirmation modal
        }
    });
 
    function checkEssentialCookieConsent() {
        var cookies = document.cookie.split("; ");
        for (var i = 0; i < cookies.length; i++) {
            var cookie = cookies[i].split("=");
            if (cookie[0] === "EssentialCookieConsent" && cookie[1] === "true") {
                return true; // The user has confirmed essential cookies
            }
        }
        return false; // The user has not confirmed essential cookies
    }

    // Function to display the modal when the user clicks "Add to Cart"
    function showConfirmationModal() {
        modal.style.display = "block";
        overlay.style.display = "block";
    }

    // Handle user's confirmation
    confirmButton.addEventListener("click", function () {
        // User consents to essential cookies and Set a cookie to remember the user's confirmation with expiration date (14 days) from the current date
        const expirationDate = new Date();
        expirationDate.setDate(expirationDate.getDate() + 14);

        const formattedExpirationDate = expirationDate.toUTCString(); // Format the date to the required cookie format (GMT)
        document.cookie = "EssentialCookieConsent=true; expires=" + formattedExpirationDate + "; path=/"; // Set the cookie with the calculated expiration date
        modal.style.display = "none";
        overlay.style.display = "none";
    });

    // Handle user's rejection
    rejectButton.addEventListener("click", function () {
        modal.style.display = "none";
        overlay.style.display = "none";
        return false;
    });


    //------------------------------------------------------------------------------------
    // Handle layout and selection of productVariants (sizes, colors, quantity) 
    //------------------------------------------------------------------------------------
    const sizeElements = document.querySelectorAll(".size-circle");
    const colorElements = document.querySelectorAll(".color-circle");
    const productVariantInfo = document.getElementById("product-variant-info");
    const selectedVariantQunatity = document.getElementById("selectedVariantQuantity");
    let selectedColorButton = null;
    let selectedSizeButton = null;
    let selectedVariant = null;
    let quantityInput = document.getElementById("quantity");
    let stockQuantity = 0;

    const decrementButton = document.getElementById("decrement");
    const incrementButton = document.getElementById("increment");

    // Event listener for the decrement button
    decrementButton.addEventListener("click", function () {
        let currentQuantity = parseInt(quantityInput.value);
        if (currentQuantity > 1) {
            currentQuantity--;
            quantityInput.value = currentQuantity;
            selectedVariantQunatity.value = currentQuantity;
        }
    });

    // Event listener for the increment button
    incrementButton.addEventListener("click", function () {
        let currentQuantity = parseInt(quantityInput.value);
        if (currentQuantity < stockQuantity) {
            currentQuantity++;
            quantityInput.value = currentQuantity;
            selectedVariantQunatity.value = currentQuantity;
        }
    });

    sizeElements.forEach(sizeElement => {
        sizeElement.addEventListener("click", () => {
            handleVariantSelection(sizeElement, "size");
        });
    });

    colorElements.forEach(colorElement => {
        colorElement.addEventListener("click", () => {
            handleVariantSelection(colorElement, "color");
        });
    });

    function handleVariantSelection(button, type) {
        if (type === "color") {
            if (selectedColorButton === button) {
                // Deselect the variant
                selectedColorButton.classList.remove("selected-color");
                selectedColorButton = null;
            } else {
                // Remove selection from the previously selected button
                if (selectedColorButton) {
                    selectedColorButton.classList.remove("selected-color");
                }
                button.classList.add("selected-color");
                selectedColorButton = button;
            }
        } else if (type === "size") {
            if (selectedSizeButton === button) {
                // Deselect the variant
                selectedSizeButton.classList.remove("selected-size");
                selectedSizeButton = null;
            } else {
                // Remove selection from the previously selected button
                if (selectedSizeButton) {
                    selectedSizeButton.classList.remove("selected-size");
                }
                button.classList.add("selected-size");
                selectedSizeButton = button;
            }

            // Update the selected product variant
            if (selectedVariant === button.getAttribute("data-variant-id")) {
                selectedVariant = null; // Deselect the variant
            } else {
                selectedVariant = button.getAttribute("data-variant-id");
                document.getElementById("selectedVariantId").value = selectedVariant;
                document.getElementById("selectedVariantQuantity").value = quantityInput.value;
            }

            // Check if no variant is selected and disable the button
            if (selectedVariant === null) {
                addToCartButton.disabled = true;
                addToCartButton.title = "select a size";
                addToCartButton.style.cursor = "not-allowed";
            } else {
                addToCartButton.disabled = false;
                addToCartButton.title = "";
                addToCartButton.style.cursor = "pointer";
            }

            stockQuantity = parseInt(button.getAttribute("data-stock-quantity"));
            quantityInput.value = 1; // Reset quantity to 1 when a new variant is selected
            selectedVariantQunatity.value = 1;
            displayProductVariantInfo(selectedVariant, stockQuantity);
        }


        function displayProductVariantInfo(variantId, qty) {
            if (!variantId) {
                productVariantInfo.textContent = "Please select a product size.";
                productVariantInfo.classList.remove("low-stock", "out-of-stock", "in-stock");
                productVariantInfo.classList.add("select-variant");

            } else {
                let stockStatus = "";
                productVariantInfo.classList.remove("low-stock", "out-of-stock", "in-stock", "select-variant");
                if (qty > 0 && qty <= 3) {
                    stockStatus = `Low Stock (only ${qty.toString()} left)`;
                    productVariantInfo.classList.add("low-stock");
                } else if (qty > 0) {
                    stockStatus = "In Stock";
                    productVariantInfo.classList.add("in-stock");

                } else {
                    stockStatus = "Out of Stock";
                    productVariantInfo.classList.add("out-of-stock");
                }

                productVariantInfo.innerHTML = `<p>${stockStatus}</p>`;
            }
        }
    }
   
});