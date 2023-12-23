window.addEventListener("load", windowLoadEvent => {
    main();
});

// Entry Point
async function main() {
    await intialize().then(value => {
        mznMain();
        applyEvents();
        applyUtilities();
    })
}

// intialize() applies some initial settings such as
//      local storage items and layout preferences
async function intialize() {

}


// applyEvents() is the only function that applies events
//      on various HTML elements
function applyEvents() {
    const buttonElements = document.querySelectorAll("button");
    const fileInputs = document.querySelectorAll("input[type=file]");

    window.addEventListener("scroll", bodyScrollEvent => {
        const header = document.querySelector("#header");
        if (header != null) {
            if (window.scrollY > 20)
                header.classList.add("shadow");
            else
                header.classList.remove("shadow");
        }
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
                outerBox.querySelector("img").setAttribute("src", URL.createObjectURL(fileInput.files[0]));
            }

            if (fileInput.classList.contains("new-banner")) {
                const outerBox = fileInput.parentElement.parentElement.parentElement
                const cardsContainer = outerBox.querySelector(".mzn-img-gallery");
                const imgUrl = URL.createObjectURL(fileInput.files[0]);
                const randomId = Math.floor((Math.random() * 1000) + 1);

                cardsContainer.innerHTML +=
                    `<div class="col-sm-6 col-xl-4 col-xxl-3 mx-0 p-2">
                    <div class="mzn-img-card">
                        <div class="mzn-btns-container">
                            <div class="mzn-btn">
                                <input type="checkbox" id="banner-${randomId}" checked="false" onchange="validateBannerSelects(this)" />
                            </div>
                            <a href="javascript:void(0)" onclick="mznExpandImg(this);" class="mzn-btn link-dark text-decoration-none mzn-expand-img-btn" mzn-img-target="#banner-img-${randomId}">
                                <i class="fa-solid fa-expand"></i>
                            </a>
                            <a class="mzn-btn link-secondary text-decoration-none" asp-area="ControlPanel" asp-controller="Banner" asp-action="">
                                <i class="fa-solid fa-trash"></i>
                            </a>
                        </div>
                        <label for="banner-${randomId}">
                            <img id="banner-img-${randomId}" src="${imgUrl}" alt="Banner with ID of @banner.Id" />
                        </label>
                    </div>
                </div>`;
            }
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
    const validateAlert = outerBox.querySelector(".mzn-gallery-validate-alert");

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