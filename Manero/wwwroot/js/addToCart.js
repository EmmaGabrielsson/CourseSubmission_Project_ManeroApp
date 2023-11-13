// Lagra selektorer i variabler
const cartItems = document.querySelectorAll(".cart-item");
const cartCountElement = document.querySelector(".cart-count");
const quantityElement = document.querySelector(".quantity");

// h�mta antal sparade produkter fr�n localstorage
let updateElementContent = (element, data) => {
    element.textContent = data
        .map((x) => x.produkt)
        .reduce((x, y) => x + y, 0);
};

updateElementContent(quantityElement, korg);
updateElementContent(cartCountElement, korg);


let basket = JSON.parse(localStorage.getItem("data")) || [];

// H�ndelsehanterare f�r att �ka produkters antal
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
// Hitta produktobjekt baserat p� en klickad element
function findProductItem(element) {
    console.log(element.parentElement.parentElement)
    return element.parentElement.parentElement;
}

// H�ndelselyssnare f�r att hantera klickh�ndelser
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
