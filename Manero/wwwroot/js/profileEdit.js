document.addEventListener('DOMContentLoaded', function () {
    // Originalvärden för fälten sparas för att kontrollera om ändringar har gjorts
    window.originalValues = {
        name: document.getElementById('name').value,
        email: document.getElementById('email').value,
        phoneNumber: document.getElementById('phoneNumber').value,
        location: document.getElementById('location').value
    };

    // Sätt upp eventlyssnare för formuläret
    var editProfileForm = document.getElementById('editProfileForm');
    if (editProfileForm) {
        editProfileForm.addEventListener('submit', function (event) {
            var errors = [];

            // Kontrollera om inga ändringar har gjorts
            var currentValues = {
                name: document.getElementById('name').value,
                email: document.getElementById('email').value,
                phoneNumber: document.getElementById('phoneNumber').value,
                location: document.getElementById('location').value
            };

            if (JSON.stringify(window.originalValues) === JSON.stringify(currentValues) && document.getElementById('profileImageUpload').files.length === 0) {
                errors.push('Inga ändringar har gjorts.');
            }

            // Validera bilduppladdning
            var profileImage = document.getElementById('profileImageUpload');
            if (profileImage.files.length === 1) {
                var file = profileImage.files[0];
                var allowedTypes = ['image/jpeg', 'image/png', 'image/gif', 'image/webp'];
                if (!allowedTypes.includes(file.type)) {
                    errors.push("Invalid file type. Only JPG, PNG, GIF, and WebP files are allowed.");
                }
            }

            // Validera namn
            var name = document.getElementById('name').value;
            if (name.split(' ').length < 2) {
                errors.push("Please enter both first and last name.");
            }

            // Validera e-post
            var email = document.getElementById('email').value;
            var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
            if (!emailPattern.test(email)) {
                errors.push("Please enter a valid email address.");
            }

            // Validera telefonnummer
            var phoneNumber = document.getElementById('phoneNumber').value;
            if (!phoneNumber.match(/^[0-9]{10,16}$/)) {
                errors.push("Please enter a valid phone number with 10 to 16 digits.");
            }

            // Visa fel om det finns
            if (errors.length > 0) {
                event.preventDefault(); // Förhindrar att formuläret skickas
                var errorHtml = errors.map(function (error) {
                    return "<p>" + error + "</p>";
                }).join('');
                document.getElementById('formErrors').innerHTML = errorHtml;
            }
        });
    }

    // Lägg till fokus-händelsehanterare för varje fält
    var inputs = document.querySelectorAll('#editProfileForm input');
    inputs.forEach(function (input) {
        input.addEventListener('focus', function () {
            // Dölj eller rensa felmeddelandet när fältet får fokus
            document.getElementById('formErrors').innerHTML = '';
        });
    });

    // Hantera visning av profilredigeringssektion
    var profileEditButton = document.querySelector('.profile-edit');
    if (profileEditButton) {
        profileEditButton.addEventListener('click', function (e) {
            e.preventDefault();
            document.querySelector('.profile-section').style.display = 'none';
            document.querySelector('.profile-edit-container').style.display = 'grid';
        });
    }

    // Hantera återgång till föregående profilvy
    var profilePreviousPageIcon = document.querySelector('.profile-privus-page-icon');
    if (profilePreviousPageIcon) {
        profilePreviousPageIcon.addEventListener('click', function (e) {
            e.preventDefault();
            document.querySelector('.profile-section').style.display = 'grid';
            document.querySelector('.profile-edit-container').style.display = 'none';
        });
    }
});

    //document.getElementById('editProfileForm').addEventListener('submit', function (event) {
    //    var errors = [];

    //    // Kontrollera om inga ändringar har gjorts
    //    var currentValues = {
    //        name: document.getElementById('name').value,
    //        email: document.getElementById('email').value,
    //        phoneNumber: document.getElementById('phoneNumber').value,
    //        location: document.getElementById('location').value
    //    }

    //    if (JSON.stringify(window.originalValues) === JSON.stringify(currentValues)) {
    //        errors.push('Inga ändringar har gjorts.');
    //    }

    //    // Validera bilduppladdning
    //    var profileImage = document.getElementById('profileImageUpload');
    //    if (profileImage.files.length === 1) {
    //        var file = profileImage.files[0];
    //        var allowedTypes = ['image/jpeg', 'image/png', 'image/gif', 'image/webp'];
    //        if (!allowedTypes.includes(file.type)) {
    //            errors.push("Invalid file type. Only JPG, PNG, GIF, and WebP files are allowed.");
    //        }
    //    }

    //    // Validera namn
    //    var name = document.getElementById('name').value;
    //    if (name.split(' ').length < 2) {
    //        errors.push("Please enter both first and last name.");
    //    }

    //    // Validera e-post
    //    var email = document.getElementById('email').value;
    //    var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    //    if (!emailPattern.test(email)) {
    //        errors.push("Please enter a valid email address.");
    //    }

    //    // Validera telefonnummer
    //    var phoneNumber = document.getElementById('phoneNumber').value;
    //    if (!phoneNumber.match(/^[0-9]{10,16}$/)) {
    //        errors.push("Please enter a valid phone number with 10 to 16 digits.");
    //    }

    //    // Visa fel om det finns
    //    if (errors.length > 0) {
    //        event.preventDefault(); // Förhindrar att formuläret skickas
    //        var errorHtml = errors.map(function (error) {
    //            return "<p>" + error + "</p>";
    //        }).join('');
    //        document.getElementById('formErrors').innerHTML = errorHtml;
    //    }
    //});

    //document.addEventListener('DOMContentLoaded', function () {
    //    // Lägg till fokus-händelsehanterare för varje fält
    //    var inputs = document.querySelectorAll('#editProfileForm input');
    //    inputs.forEach(function (input) {
    //        input.addEventListener('focus', function () {
    //            // Dölj eller rensa felmeddelandet när fältet får fokus
    //            document.getElementById('formErrors').innerHTML = '';
    //        });
    //    });
    //});

    //// I din JavaScript-kod
    //document.addEventListener('DOMContentLoaded', (event) => {
    //    document.querySelector('.profile-edit').addEventListener('click', function (e) {
    //        e.preventDefault(); // Förhindra standardåtgärden för en <a>-tagg
    //        document.querySelector('.profile-section').style.display = 'none';
    //        document.querySelector('.profile-edit-container').style.display = 'grid';
    //    });
    //});
    //document.addEventListener('DOMContentLoaded', (event) => {
    //    document.querySelector('.profile-privus-page-icon').addEventListener('click', function (e) {
    //        e.preventDefault(); // Förhindra standardåtgärden för en <a>-tagg
    //        document.querySelector('.profile-section').style.display = 'grid';
    //        document.querySelector('.profile-edit-container').style.display = 'none';
    //    });
    //});