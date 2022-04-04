pic = new Image();
pic.scr = "../assets/twitchprime-hover.jpg";
pic.src="../assets/first-tank-hover.png";
pic.src="../assets/second-tank-hover.png";
pic.src="../assets/first-gift-hover.png";
pic.src="../assets/second-gift-hover.png";
pic.src="../assets/third-gift-hover.png";
pic.src="../assets/four-gift-hover.png";
// Создаем экземпляр класса XMLHttpRequest
const request = new XMLHttpRequest();

// Указываем путь до файла на сервере, который будет обрабатывать наш запрос 
const url = "/ajax.php";

// Так же как и в GET составляем строку с данными, но уже без пути к файлу 
const params = "action=" + "click";

function clickCounter() {
    request.open("POST", url, true);
    request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    request.send(params);
}


$("#overlay").height( $(document).height() );

if((document.location.href=="https://www.joves-modpack.ru/")||(document.location.href=="https://joves-modpack.ru/")){
    $(".close").css("display","block");
    $(".ads-window").css("display","block");
    $("#overlay").css("display","block");
}

$('#click-close').on('click', function(){
    $(".close").css("display","none");
    $(".ads-window").css("display","none");
    $("#overlay").css("display","none");
    console.log('закрыл');
});

$('#overlay').on('click', function(){
    $(".close").css("display","none");
    $(".ads-window").css("display","none");
    $("#overlay").css("display","none");
    console.log('закрыл');
});