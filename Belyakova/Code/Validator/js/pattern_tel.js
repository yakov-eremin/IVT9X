/*pattern_tel.js*/
function handlet() {
    var tel = document.getElementById('tele');
    tel.value = tel.value.replace(/[^0-9]/g, "");
}
var input2 = document.getElementById('tele');
input2.onkeydown = input2.onkeyup = input2.onkeypress = handlet;
