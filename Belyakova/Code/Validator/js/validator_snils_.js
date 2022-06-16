/*validator_snils_.js*/
function validateSnils(snils, error) {//валидатор снилса
    var result = false;
    var message = error;
    if (typeof snils === 'number') {
        snils = snils.toString();
    } else if (typeof snils !== 'string') {
        snils = '';
    }
    if (!snils.length) {
        message = 'Ошибка, код: ' + 1 + ' - СНИЛС пустой';
    } else if (/[^0-9]/.test(snils)) {
        message = 'Ошибка, код: ' + 2 + ' - СНИЛС состоит только из цифр';
    } else if (snils.length !== 11) {
        message = 'Ошибка, код: ' + 3 + ' - СНИЛС состоит только из 11 цифр';
    } else {
        var sum = 0;
        for (var i = 0; i < 9; i++) {
            sum += parseInt(snils[i]) * (9 - i);
        }
        var checkDigit = 0;
        if (sum < 100) {
            checkDigit = sum;
        } else if (sum > 101) {
            checkDigit = parseInt(sum % 101);
            if (checkDigit === 100) {
                checkDigit = 0;
            }
        }
        if (checkDigit === parseInt(snils.slice(-2))) {
            result = true;
            message = 'Код: ' + 0 + ' - Верный №СНИЛСа';
        } else {
            message = 'Ошибка, код: ' + 4 + ' - Неправильное контрольное число';
        }
    }
    document.getElementById("err").innerHTML = message;
    return result;
}

function validateSnilsdop(snils, error) {//валидатор снилса
    var result = false;
    var message = error;
    if (typeof snils === 'number') {
        snils = snils.toString();
    } else if (typeof snils !== 'string') {
        snils = '';
    }
    if (!snils.length) {
        message = 'Ошибка, код: ' + 1 + ' - СНИЛС пустой';
    } else if (/[^0-9]/.test(snils)) {
        message = 'Ошибка, код: ' + 2 + ' - СНИЛС может состоять только из цифр';
    } else if (snils.length !== 11) {
        message = 'Ошибка, код: ' + 3 + ' - СНИЛС может состоять только из 11 цифр';
    } else {
        var sum = 0;
        for (var i = 0; i < 9; i++) {
            sum += parseInt(snils[i]) * (9 - i);
        }
        var checkDigit = 0;
        if (sum < 100) {
            checkDigit = sum;
        } else if (sum > 101) {
            checkDigit = parseInt(sum % 101);
            if (checkDigit === 100) {
                checkDigit = 0;
            }
        }
        if (checkDigit === parseInt(snils.slice(-2))) {
            result = true;
            message = '№, код: ' + 0 + ' - Верный №СНИЛСа';
        } else {
            message = 'Ошибка, код: ' + 4 + ' - Неправильное контрольное число';
        }
    }
    document.getElementById("err1").innerHTML = message;
    return result;
}
