/*pattern_fio.js*/
function handle() {
    var fio = document.getElementById('fio');
    fio.value = fio.value.replace(/[^А-Яа-яЁё ]/g, "");
}
var input = document.getElementById('fio');
input.onkeydown = input.onkeyup = input.onkeypress = handle;