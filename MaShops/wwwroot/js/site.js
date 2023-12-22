window.addEventListener("load", windowLoadEvent => {
    main();
});

// Entry Point
async function main() {
    await intialize().then(value => {
        mznMain();
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
    
}

// applyUtilities() is the only function that applies scripts
//      required for external utilities such as bootstrap 
//      carosal.
function applyUtilities() {

}
