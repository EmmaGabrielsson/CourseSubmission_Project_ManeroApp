
try {
    // visa och dölja filter sidebar
    const filterElement = document.querySelector('.filter-element');
    const filterSidebar = document.querySelector('.filter-sidebar');
    const filterIcon = document.querySelector('.filter-icon');
    filterElement.addEventListener('click', function () {
        filterSidebar.style.display = 'block';
    })
    filterIcon.addEventListener('click', function () {
        filterSidebar.style.display = 'none';
    })

    // visa och dölja size och color elements
    document.addEventListener("DOMContentLoaded", function () {
        const sizeElements = document.querySelector(".size-elements");
        const colorElements = document.querySelector(".color-elements");
        const viewMoreSizeBtn = document.getElementById("viewMoreSizeBtn");
        const viewMoreColorBtn = document.getElementById("viewMoreColorBtn");

        // Dölj alla utom de första "size elements"
        hideAllElementsExceptFirst();

        // Lägg till klickhanterare för knappen "Visa alla"
        viewMoreSizeBtn.addEventListener("click", function () {
            const sizeElementChildren = sizeElements.children;
            viewMoreSizeBtn.style.display = 'none';
            for (let i = 0; i < sizeElementChildren.length; i++) {
                sizeElementChildren[i].style.display = "grid";
            }
        });
        viewMoreColorBtn.addEventListener("click", function () {
            const colorElementChildren = colorElements.children;
            viewMoreColorBtn.style.display = 'none';
            for (let i = 0; i < colorElementChildren.length; i++) {
                colorElementChildren[i].style.display = "grid";
            }
        });

        function hideAllElementsExceptFirst() {
            const sizeElementChildren = sizeElements.children;
            const numberOfRowsToShowSize = Math.ceil(sizeElementChildren.length / 3);
            const colorElementChildren = colorElements.children;
            const numberOfRowsToShowColor = Math.ceil(colorElementChildren.length / 1.7);

            for (let i = numberOfRowsToShowSize; i < sizeElementChildren.length; i++) {
                sizeElementChildren[i].style.display = "none";
            }
            for (let i = numberOfRowsToShowColor; i < colorElementChildren.length; i++) {
                colorElementChildren[i].style.display = "none";
            }
        }
    });

    // Lägg till en klickhändelsehanterare på checkboxarna
    var checkboxes = document.querySelectorAll('.custom-checkbox');
    checkboxes.forEach(function (checkbox) {
        checkbox.addEventListener('change', function () {
            var label = this.closest('.checked-label');
            if (this.checked) {
                label.classList.add('checked');
            } else {
                label.classList.remove('checked');
            }
        });
    });

    //pris
    var maxInput = document.querySelector('.max-input');
    let rangeInput = document.querySelectorAll('.range-input input');
    let rangeText = document.querySelectorAll('.range-text div');
    let rangeTextInput = document.querySelectorAll('.range-text input');
    let progress = document.querySelector('.progress');
    let priceMax = rangeInput[0].max;
    let priceGap = 120;

    rangeInput.forEach(input => {
        input.addEventListener('input', (event) => {
            let minVal = parseInt(rangeInput[0].value);
            let maxVal = parseInt(rangeInput[1].value);

            if (maxVal - minVal < priceGap) {
                if (event.target.className === 'range-min') {
                    minVal = rangeInput[0].value = maxVal - priceGap;
                } else {
                    maxVal = rangeInput[1].value = minVal + priceGap;
                }
            }

            let positionMin = (minVal / priceMax) * 100;
            let positionMax = 100 - ((maxVal / priceMax) * 100);
            progress.style.left = positionMin + '%';
            progress.style.right = positionMax + '%';
            rangeTextInput[0].style.left = positionMin + '%';
            rangeTextInput[1].style.right = positionMax + '%';
            rangeTextInput[0].value = '$' + minVal;
            rangeTextInput[1].value = '$' + maxVal;
        })
    })
}
catch { }

