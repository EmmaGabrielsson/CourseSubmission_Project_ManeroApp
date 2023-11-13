document.addEventListener("DOMContentLoaded", function () {
   
    const popup = document.querySelector(".logout-popup");
    const logoutButton = document.getElementById("logout-button");
    const confirmButton = document.getElementById("confirm-logout-btn");
    const cancelButton = document.getElementById("cancel-logout-btn");


    // Show the pop-up when the logout button is clicked
    logoutButton.addEventListener("click", function (e) {
        e.preventDefault();
        popup.style.display = "block";
    });

    // Close the pop-up when the cancel button is clicked
    cancelButton.addEventListener("click", function () {
        popup.style.display = "none";
    });

    // Handle the logout action when the confirm button is clicked
    confirmButton.addEventListener("click", function () {
 
        const logoutLink = document.createElement("a");
        logoutLink.href = "/Logout?area=";
        logoutLink.setAttribute("asp-action", "Index");
        logoutLink.setAttribute("asp-controller", "Logout");
        logoutLink.style.display = "none";
        document.body.appendChild(logoutLink);

        logoutLink.click();

        popup.style.display = "none";
    });
});
