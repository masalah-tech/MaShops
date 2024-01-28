window.addEventListener("load", windowLoadEvent => {
    main();
});

// Entry Point
async function main() {
    await intialize().then(value => {
        applyEvents();
        applyUtilities();
    })
}

// intialize() applies some initial settings such as
//      local storage items and layout preferences
async function intialize() {
    const response = await fetch("/json/countries.json");
    const countries = await response.json();
    let counter = 0;

    document.querySelectorAll(".c-select-box .load-countries").forEach(ulCountries => {

        const outerBox = ulCountries.parentElement.parentElement;
        const defaultSelectedCountry
            = outerBox.querySelector(".c-select-option input").value;

        for (let country of countries) {
            if (country['name'] == defaultSelectedCountry) {
                ulCountries.innerHTML += `<li class='c-select-item active'>${country['name']}</li>`;
                counter++;
            }
            else {
                ulCountries.innerHTML += `<li class='c-select-item'>${country['name']}</li>`;
            }
        }

        if (counter > 0) {
            outerBox.querySelector("li:first-child").classList.remove("active");
        }

    });
}


// applyEvents() is the only function that applies events
//      on various HTML elements
function applyEvents() {
    const buttonElements = document.querySelectorAll("button");
    const fileInputs = document.querySelectorAll("input[type=file]");
    const liElements = document.querySelectorAll("li");
    const inputElements = document.querySelectorAll("input");
    const iElements = document.querySelectorAll("i");
    const aElements = document.querySelectorAll("a");

    window.addEventListener("click", windowClickEvent => {
        const selectBoxes = document.querySelectorAll(".c-select-box");

        selectBoxes.forEach(selectBox => {
            const openSelectBtn = selectBox.querySelector(".c-select-option");
            const selectContent = selectBox.querySelector(".c-select-items-container");

            if (selectBox.classList.contains("active")) {
                if (!selectContent.contains(windowClickEvent.target)) {
                    closeSelectContent(selectBox);
                }
            }
            else if (openSelectBtn.contains(windowClickEvent.target)) {
                openSelectContent(selectBox);
            }
        })
    });

    window.addEventListener("scroll", windowScrollEvent => {

        const header = document.querySelector("#header");
        if (header != null) {
            if (window.scrollY > 20)
                header.classList.add("shadow");
            else
                header.classList.remove("shadow");
        }

        document.querySelectorAll(".c-select-box").forEach(selectBox => {
            closeSelectContent(selectBox);
        });
    });

    buttonElements.forEach(buttonElement => {
        buttonElement.addEventListener("click", buttonElementClickEvent => {
            if (buttonElement.classList.contains("open-sidenav-btn")) {
                document.querySelector("#sidenav").classList.add("active");
            }
            if (buttonElement.classList.contains("close-sidenav-btn")) {
                document.querySelector("#sidenav").classList.remove("active");
            }
        });
    });

    fileInputs.forEach(fileInput => {

        fileInput.addEventListener("change", fileInputsChangeEvent => {
            if (fileInput.classList.contains("photo-immediate-change")) {
                const outerBox = fileInput.parentElement.parentElement;
                const imgWrapper = outerBox.querySelector(".img-wrapper");
                const targetImg = imgWrapper.querySelector("img");

                if (targetImg != null) {
                    targetImg.setAttribute("src", URL.createObjectURL(fileInput.files[0]));
                }
                else {
                    imgWrapper.innerHTML =
                        `<img src="${URL.createObjectURL(fileInput.files[0])}" alt="Product Poster"
                            class="product-poster-in-wide-card"/>`;
                }

            }

            if (fileInput.classList.contains("new-banner")) {
                const outerBox = fileInput.parentElement.parentElement.parentElement
                const cardsContainer = outerBox.querySelector(".c-img-gallery");
                const imgUrl = URL.createObjectURL(fileInput.files[0]);
                const randomId = Math.floor((Math.random() * 1000) + 1);

                cardsContainer.innerHTML +=
                    `<div class="col-sm-6 col-xl-4 col-xxl-3 mx-0 p-2">
                    <div class="c-img-card">
                        <div class="btns-container">
                            <div class="c-btn">
                                <input type="checkbox" id="banner-${randomId}" checked="false" onchange="validateBannerSelects(this)" />
                            </div>
                            <a href="javascript:void(0)" onclick="expandImg(this);" class="c-btn link-dark text-decoration-none mzn-expand-img-btn" mzn-img-target="#banner-img-${randomId}">
                                <i class="fa-solid fa-expand"></i>
                            </a>
                            <a class="c-btn link-secondary text-decoration-none" asp-area="Admin" asp-controller="Banner" asp-action="">
                                <i class="fa-solid fa-trash"></i>
                            </a>
                        </div>
                        <label for="banner-${randomId}">
                            <img id="banner-img-${randomId}" src="${imgUrl}" alt="Banner with ID of @banner.Id" />
                        </label>
                    </div>
                </div>`;
            }

            if (fileInput.classList.contains("new-prod-img")) {
                const outerBox = fileInput.parentElement.parentElement.parentElement
                const cardsContainer = outerBox.querySelector(".c-img-gallery");
                const imgUrl = URL.createObjectURL(fileInput.files[0]);
                const randomId = Math.floor((Math.random() * 1000) + 1);

                cardsContainer.innerHTML +=
                    `<div class="prod-photo-card">
                    <div class="btns-container">
                        <a href="javascript:void(0)" onclick="expandImg(this)" class="c-btn link-dark text-decoration-none expand-img-btn" mzn-img-target="#prod2-photo${randomId}">
                            <i class="fa-solid fa-expand"></i>
                        </a>
                        <a class="c-btn link-secondary text-decoration-none delete-img-btn"
                           asp-area="Seller" asp-controller="ProductPhoto" asp-action="Delete" asp-route-id="1">
                            <i class="fa-solid fa-trash"></i>
                        </a>
                    </div>
                    <img id="prod2-photo${randomId}"
                         src="${imgUrl}" alt="Banner with ID of ${randomId}" />
                </div>`;
            }
        });

    });

    liElements.forEach(liElement => {
        liElement.addEventListener("click", liElementClickEvent => {
            if (liElement.classList.contains("c-select-item")) {
                const outerBox = liElement.parentElement.parentElement.parentElement;
                outerBox.querySelector(".c-selected-item").value = liElement.innerHTML;
                closeSelectContent(outerBox)

                liElements.forEach(innerLiElement => {
                    innerLiElement.classList.remove("active");
                });

                liElement.classList.add("active");
            }
        });
    });

    inputElements.forEach(inputElement => {
        let counter = 0;
        inputElement.addEventListener("keyup", inputElementKeyDownEvent => {
            if (inputElement.classList.contains("c-search-select-items-input")) {

                const outerBox = inputElement.parentElement.parentElement.parentElement;
                const filter = inputElement.value.toLowerCase();
                const selectItems = outerBox.querySelectorAll(".c-select-item");

                selectItems.forEach(selectItem => {
                    const itemText = selectItem.innerHTML;

                    if (itemText.toLowerCase().startsWith(filter)) {
                        selectItem.classList.remove("hide");
                        counter++;
                    }
                    else {
                        selectItem.classList.add("hide");
                    }
                });

                if (counter == 0) {
                    outerBox.querySelector(".c-no-match-msg").classList.add("active");
                }
                else {
                    outerBox.querySelector(".c-no-match-msg").classList.remove("active");
                }

                counter = 0;
            }
        });
    });

    iElements.forEach(iElement => {
        iElement.addEventListener("click", iElementClickEvent => {
            if (iElement.classList.contains("show-pass-btn")) {
                const outerBox = iElement.parentElement.parentElement;

                showPassText(outerBox);
            }
            else if (iElement.classList.contains("hide-pass-btn")) {
                const outerBox = iElement.parentElement.parentElement;

                hidePassText(outerBox);
            }
        });
    });

    aElements.forEach(aElement => {
        aElement.addEventListener("click", aElementClickEvent => {

            // --
        });
    });
}

// applyUtilities() is the only function that applies scripts
//      required for external utilities such as bootstrap 
//      carosal.
function applyUtilities() {

}

// validateBannerSelects() makes sure the user doesn't select
//      less than 1 banner or more than 5 banners
function validateBannerSelects(senderInput) {

    if (senderInput.getAttribute("checked") == "false") {
        senderInput.setAttribute("checked", "true");
    }
    else if (senderInput.getAttribute("checked") == "true") {
        senderInput.setAttribute("checked", "false");
    }

    const outerBox =
        senderInput.parentElement.parentElement.parentElement.parentElement.parentElement;
    const checkedInputs = outerBox.querySelectorAll("input[type=checkbox][checked=true]");
    const validateAlert = outerBox.querySelector(".c-gallery-validate-alert");

    if (checkedInputs.length < 1) {
        validateAlert.classList.add("show");
        setTimeout(() => {
            validateAlert.classList.remove("show");

        }, 5000)
        senderInput.setAttribute("checked", "true");
    }
    else if (checkedInputs.length > 5) {
        validateAlert.classList.add("show");
        setTimeout(() => {
            validateAlert.classList.remove("show");

        }, 5000)
        senderInput.setAttribute("checked", "false");
    }
}

// openSelectContent() shows the custom select items container
function openSelectContent(outerBox) {
    outerBox.classList.add("active");
    outerBox.querySelector(".c-search-select-items-input").focus();
}

// closeSelectContent() hides the custom select items container
function closeSelectContent(outerBox) {
    const searchField =
        outerBox.querySelector(".c-search-select-items-input");
    const selectItems =
        outerBox.querySelectorAll(".c-select-item");
    const selectedItemInput =
        outerBox.querySelector(".c-selected-item");

    outerBox.classList.remove("active");
    searchField.value = "";

    selectItems.forEach(selectItem => {
        selectItem.classList.remove("hide");
    })

    // This to solve the problem of jQuery validation
    selectedItemInput.focus();
    selectedItemInput.blur();
}

// showPassText(outerBox) replaces the dots in the password
//      input field with the actual text
function showPassText(outerBox) {
    const input = outerBox.querySelector("input")

    input.setAttribute("type", "text");
    outerBox.querySelector(".show-pass-btn").classList.remove("active");
    outerBox.querySelector(".hide-pass-btn").classList.add("active");

    input.focus();
}

// hidePassText(outerBox) replaces the text in the password
//      input field with dots
function hidePassText(outerBox) {
    const input = outerBox.querySelector("input");

    input.setAttribute("type", "password");
    outerBox.querySelector(".hide-pass-btn").classList.remove("active");
    outerBox.querySelector(".show-pass-btn").classList.add("active");

    input.focus();
}

// expandImg(aSenderElem) expands an image in the mzn image gallery
//      module. the parameter senderElem is supposed to be the clicked
//      element before invoking this function
function expandImg(senderElem) {
    const outerBox =
        senderElem.parentElement.parentElement.parentElement.parentElement;

    const src =
        outerBox.querySelector(
            senderElem.getAttribute("mzn-img-target")
        ).src;
    const imgOverlay = outerBox.querySelector(".c-expanded-img-overlay");
    const targetImg = imgOverlay.querySelector("img");

    targetImg.src = src;

    imgOverlay.classList.add("active");
}

// closeImgOverlay(overlayElem) closes the image overlay.
//      the parameter overlayElem is supposed to be the
//      html dom element of the overaly
function closeImgOverlay(overlayElem, clickEvent) {
    const contentWrapper =
        overlayElem.querySelector(".c-wrapper");

    if (!contentWrapper.contains(clickEvent.target)) {
        overlayElem.classList.remove("active");
    }
}