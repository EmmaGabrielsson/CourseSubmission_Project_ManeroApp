document.addEventListener("DOMContentLoaded", function () {
    const addressMap = document.getElementById("address-map");
    const updateMapCheckbox = document.getElementById("update-map-checkbox");
    let map = null; 

    // Initialize the map with a default location when the page loads
    const defaultLatitude = 62.89073;
    const defaultLongitude = 18.39824; 
    map = L.map(addressMap).setView([defaultLatitude, defaultLongitude], 4); // Set zoom level and default location
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png').addTo(map);
    updateMapCheckbox.addEventListener("change", function () {
        if (this.checked) {
            if ("geolocation" in window.navigator) {
                // Use the Geolocation API to get the user's current location
                navigator.geolocation.getCurrentPosition(function (position) {
                    // Remove the existing map before initializing a new one
                    if (map) {
                        map.remove();
                    }

                    // Initialize a new Leaflet map with the current location
                    let latitude = position.coords.latitude;
                    let longitude = position.coords.longitude;
                    map = L.map(addressMap).setView([latitude, longitude], 13); // Set zoom level to 13
                    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png').addTo(map);
                });
            } else {
                alert("Geolocation is not supported in your browser.");
            }
        } else {
            // If the checkbox is unchecked, remove the existing map and add the init map
            if (map) {
                map.remove();
                map = L.map(addressMap).setView([defaultLatitude, defaultLongitude], 4); 
                L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png').addTo(map);
            }
        }
    });
});
