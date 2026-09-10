//window.scrollToAndHighlight = function (elementId) {
//    const el = document.getElementById(elementId);
//    if (!el) return;

//    el.scrollIntoView({ behavior: "smooth", block: "center" });

//    el.classList.add("highlight-error");

//    setTimeout(() => {
//        el.classList.remove("highlight-error");
//    }, 2000);
//};

/*JS: apply shake + highlight*/
window.scrollToAndHighlight = function (elementId) {
    const el = document.getElementById(elementId);
    if (!el) return;

    el.scrollIntoView({ behavior: "smooth", block: "center" });
    el.focus({ preventScroll: true });

    el.classList.add("highlight-error", "shake-error");

    setTimeout(() => {
        el.classList.remove("highlight-error", "shake-error");
    }, 1200);
};