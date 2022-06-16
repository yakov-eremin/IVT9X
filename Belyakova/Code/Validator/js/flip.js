/*flip.js*/
const menunav = document.querySelector(".unvisib");
const menunavnext = document.querySelector(".visib");
const logclass = document.querySelector(".log");
const menunavb = document.querySelector("#button__2");
let menunavOpen = true;
menunavb.addEventListener("click", () => {
    if (menunavOpen) {
        menunav.classList.add("vis");
        menunavnext.classList.add("unvis");
        menunavnext.remove();
        logclass.style.height = 'auto';
        menunavOpen = false;

    } else {
        window.location.reload();
        menunavOpen = true;
    }
});

const snilz = document.querySelector("#num");
const snilz1 = document.querySelector("#num1");
const valid = document.querySelector("#button11");
const valid1 = document.querySelector("#button134");

valid.addEventListener("click", () => {
    validateSnils(snilz.value,"");
});
valid1.addEventListener("click", () => {
    validateSnilsdop(snilz1.value,"");
});