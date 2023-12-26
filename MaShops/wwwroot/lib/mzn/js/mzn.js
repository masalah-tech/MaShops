
// Entry Point
async function mznMain() {
    await mznIntialize().then(value => {
        mznApplyEvents();
    })
}


// mznIntialize() applies some initial settings such as
//      local storage items and layout preferences
async function mznIntialize() {
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


// mznApplyEvents() is the only function that applies events
//      in this file
function mznApplyEvents() {
    const liElements = document.querySelectorAll("li");
    const inputElements = document.querySelectorAll("input");
    const iElements = document.querySelectorAll("i");
    const aElements = document.querySelectorAll("a");
    const buttons = document.querySelectorAll("button");
    const divElements = document.querySelectorAll("div");

    window.addEventListener("click", windowClickEvent => {
        const selectBoxes = document.querySelectorAll(".c-select-box");

        selectBoxes.forEach(selectBox => {
            const openSelectBtn = selectBox.querySelector(".c-select-option");
            const selectContent = selectBox.querySelector(".c-select-items-container");

            if (selectBox.classList.contains("active")) {
                if (!selectContent.contains(windowClickEvent.target)) {
                    mznCloseSelectContent(selectBox);
                }
            }
            else if (openSelectBtn.contains(windowClickEvent.target)) {
                mznOpenSelectContent(selectBox);
            }
        })
    });

    window.addEventListener("scroll", windowScrollEvent => {
        document.querySelectorAll(".c-select-box").forEach(selectBox => {
            mznCloseSelectContent(selectBox);
        });
    });

    liElements.forEach(liElement => {
        liElement.addEventListener("click", liElementClickEvent => {
            if (liElement.classList.contains("c-select-item")) {
                const outerBox = liElement.parentElement.parentElement.parentElement;
                outerBox.querySelector(".c-selected-item").value = liElement.innerHTML;
                mznCloseSelectContent(outerBox)

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

                mznShowPassText(outerBox);
            }
            else if (iElement.classList.contains("hide-pass-btn")) {
                const outerBox = iElement.parentElement.parentElement;

                mznHidePassText(outerBox);
            }
        });
    });

    aElements.forEach(aElement => {
        aElement.addEventListener("click", aElementClickEvent => {
            //if (aElement.classList.contains("mzn-expand-img-btn")) {
            //    mznExpandImg(aElement);
            //}
        });
    });

    buttons.forEach(button => {
        button.addEventListener("click", buttonClickEvent => {
        });
    })

    divElements.forEach(divElement => {
        //divElement.addEventListener("click", divElementClickEvent => {
        //    if (divElement.classList.contains("c-expanded-img-overlay")) {

                
        //    }
        //});
    });
}

// mznOpenSelectContent() shows the custom select items container
function mznOpenSelectContent(outerBox) {
    outerBox.classList.add("active");
    outerBox.querySelector(".c-search-select-items-input").focus();
}

// mznCloseSelectContent() hides the custom select items container
function mznCloseSelectContent(outerBox) {
    outerBox.classList.remove("active");
    outerBox.querySelector(".c-search-select-items-input").value = "";

    outerBox.querySelectorAll(".c-select-item").forEach(selectItem => {
        selectItem.classList.remove("hide");
    })

}

// mznShowPassText(outerBox) replaces the dots in the password
//      input field with the actual text
function mznShowPassText(outerBox) {
    const input = outerBox.querySelector("input")

    input.setAttribute("type", "text");
    outerBox.querySelector(".show-pass-btn").classList.remove("active");
    outerBox.querySelector(".hide-pass-btn").classList.add("active");

    input.focus();
}

// mznHidePassText(outerBox) replaces the text in the password
//      input field with dots
function mznHidePassText(outerBox) {
    const input = outerBox.querySelector("input");

    input.setAttribute("type", "password");
    outerBox.querySelector(".hide-pass-btn").classList.remove("active");
    outerBox.querySelector(".show-pass-btn").classList.add("active");

    input.focus();
}


// mznExpandImg(aSenderElem) expands an image in the mzn image gallery
//      module. the parameter senderElem is supposed to be the clicked
//      element before invoking this function
function mznExpandImg(senderElem) {
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

// mznCloseImgOverlay(overlayElem) closes the image overlay.
//      the parameter overlayElem is supposed to be the
//      html dom element of the overaly
function mznCloseImgOverlay(overlayElem, clickEvent) {
    const contentWrapper =
        overlayElem.querySelector(".c-wrapper");

    if (!contentWrapper.contains(clickEvent.target)) {
        overlayElem.classList.remove("active");
    }
}