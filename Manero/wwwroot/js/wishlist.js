const wishlistItems = document.querySelector(".wishlist-items");

//function to update wishlist
function updateWishlist() {
    const wishlistData = JSON.parse(localStorage.getItem("wishlist"));
    wishlistItems.innerHTML = "";

    if (!wishlistData || wishlistData.length === 0) {
        wishlistItems.innerHTML = "Your wishlist is empty. Click on the heart icon to save products to this list <i class='heart-icon fa-regular fa-heart'></i>";
        wishlistItems.classList.remove("wishlist-items");
        wishlistItems.classList.add("empty-wishlist");
        return;
    }

    wishlistItems.classList.remove("empty-wishlist");
    wishlistItems.classList.add("wishlist-items");

    wishlistData.forEach((item) => {
        const wishlistItem = createWishlistItem(item);
        wishlistItems.appendChild(wishlistItem);
    });
}

// function to create a new item for the wishlist
function createWishlistItem(item) {
    const wishlistItem = document.createElement("div");
    wishlistItem.classList.add("wishlist-item");
    wishlistItem.dataset.productId = item.productId;
    wishlistItem.innerHTML = `
          <img src="${item.productImage}" alt="${item.productName}" />
          <div class="product-content">
            <div class="product-info">
              <p class="product-name">${item.productName}</p>
              <div class="product-price">
                ${item.hasSale
            ? `<span class="old-price">${item.productOldPrice}</span>`
            : ""
        }
                ${item.hasSale
            ? `<span class="new-price">${item.productNewPrice}</span>`
            : `<span class="price">${item.productPrice}</span>`
        }
              </div>
              <div class="star-review">${item.productReview}</div>
            </div>
            <div class="product-icons">
              <i class="red-heart-icon fa-solid fa-heart"></i>
              <div class="cart-wrapper">
              <i class="cart-item fa-solid fa-bag-shopping"></i>
              </div>
            </div>
            ${item.hasSale ? '<div class="sale">SALE</div>' : ""}
          </div>
        `;

    //function to remove an item from the wishlist by clicking the heart icon
    const removeButton = wishlistItem.querySelector(".red-heart-icon");
    removeButton.addEventListener("click", function () {
        const productId = item.productId;

        // update local storage after removing the item
        const updatedWishlistData = JSON.parse(localStorage.getItem("wishlist")).filter(x => x.productId !== productId);
        localStorage.setItem("wishlist", JSON.stringify(updatedWishlistData));

        updateWishlist();
    });

    return wishlistItem;
}

updateWishlist();