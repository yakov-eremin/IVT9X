//data_validation_snils.js

function getTests(errorCodeForZero) {
    return [
        [null, false, 1],
        [' ', false, 2],
        [0, false, errorCodeForZero],
        [0.0, false, errorCodeForZero],
        ['0', false, errorCodeForZero],
        ['0.0', false, 2],
        [1, false, errorCodeForZero],
        [[], false, 1],
        ['a123', false, 2],
        ['123-', false, 2]
    ];//0-9 первоначальные тесты с ошибками
}

QUnit.test('Snils', function (assert) {
    var data = [].concat(getTests(3), [
        //10
        ['dfghjghfiuy', false, 2],
        ['0000000000', false, 3],
        ['0123456789', false, 3],
        ['1234567890', false, 3],
        ['00000000000', true, null],//верный
        ['01234567890', false, 4],
        ['12345678901', false, 4],
        ['000000000000', false, 3],
        ['123456789012', false, 3],
        ['08765430300', true, null],//верный
        ['18765430300', false, 4],
        ['08865430300', false, 4],
        ['08766430300', false, 4],
        ['08765440300', false, 4],
        ['08765430400', false, 4],
        ['08765430301', false, 4]//25
    ]);

    for (var i in data) {
        var error = {
            code: null,
            message: null
        };
        assert.ok(validateSnils(data[i][0], error) === data[i][1], ['1)', i, data[i][0]].join(' '));
        assert.ok(error.code === data[i][2], ['2)', i, data[i][2]].join(' '));
    }

});