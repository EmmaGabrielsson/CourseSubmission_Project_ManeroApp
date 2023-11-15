document.addEventListener('DOMContentLoaded', function () {
    const searchButtonTop = document.getElementById('search-field-navigate-to-shop-top');
    const searchButtonBottom = document.getElementById("search-field-navigate-to-shop-bottom");

    searchButtonTop.addEventListener('click', function () {
        moveToShop();
    });
    searchButtonBottom.addEventListener('click', function () {
        moveToShop();
    });

    function moveToShop() {
        // Send an AJAX request to move to shop if not already there
        if (window.location.pathname.toLowerCase() === "/home/shop") {
            console.log("Already on the shop page. No need to navigate.");
            return;
        }

        fetch(`/Home/Shop`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            },
        })
            .then(response => {
                if (response.ok) {
                    window.location.href = '/home/shop';
                    console.log('Successfully navigated to the shop');
                } else {
                    console.error('Failed to move');
                }
            })
            .catch(error => {
                console.error('An error occurred:', error);
            });
    }

});