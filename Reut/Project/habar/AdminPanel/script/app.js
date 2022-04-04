'use strict';
var app = angular.module('kotApp',  []);

app.controller('LoginController', function MainController($scope, $http) {

  $scope.signin = function(login, pass){
    if(login == "admin" && pass == "admin428" ){
      localStorage.setItem("habaUser","true");
      window.location.href = "main.html"
    } else {
      alert("Логин или пароль не верен");
    }
   }

});
 
app.controller('MainController', function MainController($scope, $http) {

    var user = localStorage.getItem("habaUser");
    if(user == undefined || user == "null" || user == null ){
        window.location.href = "index.html"
    }
    
    $scope.mail = "test@mail.ru";
    $scope.live = "";
    $scope.banner = "";
    $scope.logo = "";
    $scope.deadlist =  [ 
        {title: "Главные новости", value: 0 , disabled: 0},
        {title: "Выпуски новостей", value: 1 , disabled: 0},
        {title: "В мире", value: 2 , disabled: 0},
        {title: "Деловые новости", value: 3 , disabled: 0},
        {title: "Культура", value: 4 , disabled: 0},
        {title: "Новости Казахстана", value: 5 , disabled: 0},
        {title: "Народный репортер", value: 6 , disabled: 0},
        {title: "Общество", value: 7 , disabled: 0},
        {title: "Образование и наука", value: 8 , disabled: 0},
        {title: "Обзор прессы", value: 9 , disabled: 0},
        {title: "Политика", value: 10 , disabled: 0},
        {title: "Происшествия", value: 11 , disabled: 0},
        {title: "Полезно знать", value: 12 , disabled: 0},
        {title: "Спорт", value: 13 , disabled: 0},
        {title: "Экономика", value: 14 , disabled: 0},
    ];

    console.log("init")
    var getAll = function(){
      $http({
        url: 'get_state.php',
        method: "GET",
      }).then(function(response) {
          $scope.settings = JSON.parse(  JSON.parse(response.data) );
          console.log(response,  $scope.settings);
          if($scope.settings){
            if($scope.settings.settings.mail != undefined) $scope.mail = $scope.settings.settings.mail;
            if($scope.settings.settings.live != undefined) $scope.live = $scope.settings.settings.live;
            if($scope.settings.settings.deadlist != undefined) $scope.deadlist = $scope.settings.settings.deadlist;
            if($scope.settings.settings.banner != undefined) $scope.banner = $scope.settings.settings.banner;
          }
          

      },function(response) { // optional
          console.log(response)
      });

      $http({
        url: 'push.txt',
        method: "GET",
      }).then(function(response) {
        console.log(response)

      },function(response) { // optional
          console.log(response)
      });

    }

    $scope.sendPush = function(){
      var _data = {                 
        to: token,                        
        title: $scope.msgTitle,                  
        body: $scope.msgText,           
        priority: "high",            
        sound:"default",              
        channelId:"default",   
      }

      console.log("data",_data);
      $http({
          url: 'https://exp.host/--/api/v2/push/send',
          method: "POST",
          headers: {
            Accept: 'application/json',  
           'Content-Type': 'application/json', 
           'accept-encoding': 'gzip, deflate',   
           'host': 'exp.host'      
          }, 
          body: JSON.stringify( _data )
      }).then(function(response) {
        //alert("Данные обновленны");
 
        console.log(response)
      },function(response) { // optional
        alert("Ошибка =( ");
        console.log(response)
      });
    }

    $scope.updateList = function(id, val){

      $scope.deadlist.map((item)=>{
        if(item.value == id) item.disabled = val;
      });

      var _data = { 
        settings : {
          live: $scope.live,
          mail:  $scope.mail,
          deadlist: $scope.deadlist,
          banner: $scope.banner,
          logo: $scope.logo
        } 
      }
      console.log("data",_data);
      $http({
          url: 'set_state.php',
          method: "POST",
          data: _data
      }).then(function(response) {
        //alert("Данные обновленны");
        getAll();
        console.log(response)
      },function(response) { // optional
        alert("Ошибка =( ");
        console.log(response)
      });

    }

    $scope.update = function(){
      var _data = { 
        settings : {
          live: $scope.live,
          mail:  $scope.mail,
          deadlist: $scope.deadlist,
          banner: $scope.banner,
          logo: $scope.logo
        } 
      }
      console.log("data",_data);
      $http({
          url: 'set_state.php',
          method: "POST",
          data: _data
      }).then(function(response) {
        //alert("Данные обновленны");
        getAll();
        console.log(response)
      },function(response) { // optional
        alert("Ошибка =( ");
        console.log(response)
      });
    }
      
    getAll();
});

 