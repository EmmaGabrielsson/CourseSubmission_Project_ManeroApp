// Lagra selektorer i variabler
const cartItems = document.querySelectorAll(".cart-item");
const cartCountElement = document.querySelector(".cart-count");
const quantityElement = document.querySelector(".quantity");

// hämta antal sparade produkter från localstorage
let updateElementContent = (element, data) => {
    element.textContent = data
        .map((x) => x.produkt)
        .reduce((x, y) => x + y, 0);
};

updateElementContent(quantityElement, korg);
updateElementContent(cartCountElement, korg);


let basket = JSON.parse(localStorage.getItem("data")) || [];

// Händelsehanterare för att öka produkters antal
function handleAddToCart(event) {
    const itemInStorage = localStorage.getItem(basket);
    if (itemInStorage === null) {
        const productItem = findProductItem(event.target);
        if (productItem) {
            addTocart(productItem.id);
            updateElementContent(quantityElement, korg);
            updateElementContent(cartCountElement, korg);
        }
    }
}
// Hitta produktobjekt baserat på en klickad element
function findProductItem(element) {
    console.log(element.parentElement.parentElement)
    return element.parentElement.parentElement;
}

// Händelselyssnare för att hantera klickhändelser
cartItems.forEach((item) => {
    item.addEventListener("click", handleAddToCart);
});

let addTocart = (id) => {
    let selectedItem = id;
    let search = basket.find((x) => x.id === selectedItem);
    if (search === undefined) {
        basket.push({
            id: selectedItem,
            item: 1,
        });
    }
    localStorage.setItem("data", JSON.stringify(basket));
};
