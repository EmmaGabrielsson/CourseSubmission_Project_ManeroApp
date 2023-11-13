document.addEventListener("DOMContentLoaded", function () {

    const form = document.querySelector(".add-address-form");
    let cityValid = false;
    let streetNameValid = false;
    let postalCodeValid = false;

    let validationElements = document.querySelectorAll('[data-val="true"]');
    for (let element of validationElements) {
        element.addEventListener("keyup", function (e) {
            switch (e.target.id) {
                case 'StreetName':
                    streetNameValid = textValidator(e.target, 2);
                    break;
                case 'PostalCode':
                    postalCodeValid = postalCodeValidator(e.target, 5); 
                    break;
                case 'City':
                    cityValid = textValidator(e.target, 2);
                    break;
            }
        });
    }

     if (form != null) {
        form.addEventListener("submit", function (event) {
            event.preventDefault();
            // If validation passes, submit the form
            if (streetNameValid && postalCodeValid && cityValid) {
                form.submit();
            }
        });
     }

    function textValidator(target, minLength) {
        if (target.value.length < minLength) {
            document.getElementById(`${target.id}`).nextElementSibling.innerHTML = "Too short, invalid input";
            document.getElementById(`${target.id}`).nextElementSibling.style.color = "red";
            document.getElementById(`${target.id}`).previousElementSibling.previousElementSibling.innerHTML = "";
            return false;
        } else {
            document.getElementById(`${target.id}`).nextElementSibling.innerHTML = "";
            document.getElementById(`${target.id}`).previousElementSibling.previousElementSibling.innerHTML = "✓";
            return true;
        }
    }

    function postalCodeValidator(target, length) {
        const regex = /^[1-9]+$/;
        if (target.value.length === length && regex.test(target.value)) {
            document.getElementById(`${target.id}`).nextElementSibling.innerHTML = "";
            document.getElementById(`${target.id}`).previousElementSibling.previousElementSibling.innerHTML = "✓";
            return true;
        } else if (target.value.length < length) {
            document.getElementById(`${target.id}`).previousElementSibling.previousElementSibling.innerHTML = "";
            document.getElementById(`${target.id}`).nextElementSibling.style.color = "red";
            document.getElementById(`${target.id}`).nextElementSibling.innerHTML = "Too short, invalid input";
            return false;
        } else if (target.value.length > length) {
            document.getElementById(`${target.id}`).previousElementSibling.previousElementSibling.innerHTML = "";
            document.getElementById(`${target.id}`).nextElementSibling.style.color = "red";
            document.getElementById(`${target.id}`).nextElementSibling.innerHTML = "Too long, only 5 characters is a valid postalcode";
            return false;
        } else {
            document.getElementById(`${target.id}`).previousElementSibling.previousElementSibling.innerHTML = "";
            document.getElementById(`${target.id}`).nextElementSibling.style.color = "red";
            document.getElementById(`${target.id}`).nextElementSibling.innerHTML = "You need to enter valid characters of 1-9";
            return false;
        }
    }

});