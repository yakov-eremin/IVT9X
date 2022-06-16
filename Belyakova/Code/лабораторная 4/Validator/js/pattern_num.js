/*pattern_num.js*/
function handlen() {
    var num = document.getElementById('num');
    num.value = num.value.replace(/[[0-9]{1,19}]/g, "");
}
var input1 = document.getElementById('num');
input1.onkeydown = input1.onkeyup = input1.onkeypress = handlen;


function handlenv() {
    var num3 = document.getElementById('num1');
    num3.value = num3.value.replace(/[[0-9]{1,19}]/g, "");
}
var input3 = document.getElementById('num1');
input3.onkeydown = input3.onkeyup = input3.onkeypress = handlenv;