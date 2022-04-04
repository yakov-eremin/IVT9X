import {Locale, getLang} from '../../i18n/locale.js';

state = {
  lang: "ru",
}
componentDidMount = async() => { 
  await Font.loadAsync({
    'Roboto-Regular': require('../../assets/fonts/Roboto-Regular.ttf'),
    'Roboto-Medium': require('../../assets/fonts/Roboto-Medium.ttf'),
  }).then( () => this.setState( { fontsLoaded: true } ) );

  getLang().then((res)=>  this.setState({lang: res}) );
  this.props.navigation.addListener('willFocus', this.load);

//this.getRSS();
}

load = () => { 
  getLang().then((res)=>  this.setState({lang: res}) );

  //RSS
  
}


export const formatDate = (date) => {
    var d = new Date(date),
    month = '' + (d.getMonth() + 1),
    day = '' + d.getDate(),
    year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [month, day, year].join('-');
  }
  
  export const formatDateDotsCurr = () => {
    var d = new Date(),
    month = '' + (d.getMonth() + 1),
    day = '' + d.getDate(),
    year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;
   
    return [day, month, year].join('.');
  }

  export const formatDateDots = (date) => {
    var d = new Date(date),
    month = '' + (d.getMonth() + 1),
    day = '' + d.getDate(),
    year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [day, month, year].join('.');
  }

  export const formatDateTimeDots = (date) => {
    var d = new Date(date),
    month = '' + (d.getMonth() + 1),
    day = '' + d.getDate(),
    year = d.getFullYear(),
    hours = d.getHours(),
    minutes = d.getMinutes();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;
    if (hours < 10) hours = '0' + hours;
    if (minutes < 10) minutes = '0' + minutes;

    return [day, month, year].join('.') + ", "+[hours, minutes].join(':');;
  }


  export const formatDateString = (date) => {
    var d = new Date(date),
    month = '' + (d.getMonth() ),
    day = '' + d.getDate(),
    year = d.getFullYear();


    
    var months = [Locale(this.state.lang, "date_january_s"), Locale(this.state.lang, "date_february_s"), Locale(this.state.lang, "date_march_s"), Locale(this.state.lang, "date_april_s"), Locale(this.state.lang, "date_may_s"), Locale(this.state.lang, "date_june_s"), Locale(this.state.lang, "date_july_s"), Locale(this.state.lang, "date_august_s"), Locale(this.state.lang, "date_september_s"), Locale(this.state.lang, "date_october_s"), Locale(this.state.lang, "date_november_s"), Locale(this.state.lang, "date_december_s")];
    var week = [Locale(this.state.lang, "monday_short"),Locale(this.state.lang, "tuesday_short") ,Locale(this.state.lang, "wednesday_short") ,Locale(this.state.lang, "thursday_short") ,Locale(this.state.lang, "friday_short"),Locale(this.state.lang, "saturday_short"),Locale(this.state.lang, "sunday_short")];

    return day+' '+months[month]+', '+week[d.getDay()];
  }


  export const getAge = (dateString) => {
    var today = new Date();
    var birthDate = new Date(dateString);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
  }

  export const formatTimeSlice = (line) => {
    if(line != undefined){
      time = line.split(":");
      return time[0]+":"+time[1]
    }
  }

  export const getDaysInMonth = (month,year) =>  {     
      if( typeof year == "undefined") year = 1999; // any non-leap-year works as default     
      var currmon = new Date(year,month),     
          nextmon = new Date(year,month+1);
      return Math.floor((nextmon.getTime()-currmon.getTime())/(24*3600*1000));
  } 

  export const getDateTimeSince = (target, ht, mt) =>  { // target should be a Date object
      now = new Date(target);
      var dateStrArr = target.split(" ");
      var HM = dateStrArr[4];
      HM = HM.split(":");

      now.setHours(HM[0]);
      now.setMinutes(HM[1]);
      //console.log(HM, now)

      var target = new Date(), diff, yd, md, dd, hd, nd, sd, out = [];
      diff = Math.floor(now.getTime()-target.getTime()/1000);
      yd = target.getFullYear()-now.getFullYear();
      md = target.getMonth()-now.getMonth();
      dd = target.getDate()-now.getDate();
      hd = target.getHours()-now.getHours();
      nd = target.getMinutes()-now.getMinutes();
      sd = target.getSeconds()-now.getSeconds();

      if( md < 0) {yd--; md += 12;}
      if( dd < 0) {
          md--;
          dd += getDaysInMonth(now.getMonth()-1,now.getFullYear());
      }
      if( hd < 0) {dd--; hd += 24;}
      if( md < 0) {hd--; md += 60;}
      if( sd < 0) {md--; sd += 60;}


      //if( dd > 0) out.push( dd+" day"+(dd == 1 ? "" : "s"));
      if( hd > 0) out.push( hd+" "+ht+(hd == 1 ? "" : ""));
        out.push( Math.abs(nd)+" "+mt+(nd == 1 ? "" : ""));
      //console.log( out )

      return out.join(" ");
  }
 
  
  export const getCurrentDateDots = () => {
    var d = new Date(),
    month = '' + (d.getMonth() + 1),
    day = '' + d.getDate(),
    year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [day, month, year].join('.');
  }

  
  export const formatDateArr = (date) => {
    var d = new Date(date),
    month = '' + (d.getMonth() ),
    day = '' + d.getDate(),
    year = d.getFullYear();

    var months = [Locale(this.state.lang, "date_january"), Locale(this.state.lang, "date_february"), Locale(this.state.lang, "date_march"), Locale(this.state.lang, "date_april"), Locale(this.state.lang, "date_may"), Locale(this.state.lang, "date_june"), Locale(this.state.lang, "date_july"), Locale(this.state.lang, "date_august"), Locale(this.state.lang, "date_september"), Locale(this.state.lang, "date_october"), Locale(this.state.lang, "date_november"), Locale(this.state.lang, "date_december")];

    return [day, months[month], month, year];
  }

  export const formatDateTimeArr = (date) => {
    var d = new Date(date),
    month = '' + (d.getMonth() ),
    day = '' + d.getDate(),
    year = d.getFullYear();
    hour = d.getHours();
    min = d.getMinutes();

    var months = [Locale(this.state.lang, "date_january"), Locale(this.state.lang, "date_february"), Locale(this.state.lang, "date_march"), Locale(this.state.lang, "date_april"), Locale(this.state.lang, "date_may"), Locale(this.state.lang, "date_june"), Locale(this.state.lang, "date_july"), Locale(this.state.lang, "date_august"), Locale(this.state.lang, "date_september"), Locale(this.state.lang, "date_october"), Locale(this.state.lang, "date_november"), Locale(this.state.lang, "date_december")];

    return [day, months[month], month, year, hour, min];
  }

  export const formatDateTimeString = (date) => {
    var d = new Date(date),
    month =  (d.getMonth() +1 ),
    day = '' + d.getDate(),
    year = d.getFullYear();
    var dateStrArr = date.split(" ");
    //console.log(date, dateStrArr[4])
    hour = d.getHours();
    min = d.getMinutes();

    var months = [Locale(this.state.lang, "date_january"), Locale(this.state.lang, "date_february"), Locale(this.state.lang, "date_march"), Locale(this.state.lang, "date_april"), Locale(this.state.lang, "date_may"), Locale(this.state.lang, "date_june"), Locale(this.state.lang, "date_july"), Locale(this.state.lang, "date_august"), Locale(this.state.lang, "date_september"), Locale(this.state.lang, "date_october"), Locale(this.state.lang, "date_november"), Locale(this.state.lang, "date_december")];
    if(month < 10) month = "0"+month; 
    return [day, month, year].join('.') +" "+ dateStrArr[4];
  }

  export const formatTimeString = (date) => {
    let std = date.slice(0, 25)
    var d = new Date(std),
    month =  (d.getMonth() ),
    day = '' + d.getDate(),
    year = d.getFullYear();

    

    hour = d.getHours();
    min = d.getMinutes();

    
    if(min < 10) min = "0"+min;
    if(hour < 10) hour = "0"+hour;

    return   [hour, min].join(':');
  }

  export const formatDateToLocal = (date) => {
    var d = new Date(date);
    var millis = (d.getTime() - ( Math.abs( d.getTimezoneOffset() ) * 60000));
    
    d.setTime( millis );
    
    return d;
  }

  export const formatDateLocalTimeArr = (date) => {
    var d = new Date(date);
    var millis = (d.getTime() - ( Math.abs( d.getTimezoneOffset() ) * 60000));
    
    d.setTime( millis );
    //console.log(millis,  d.getHours())

    month = '' + (d.getMonth() ),
    day = '' + d.getDate(),
    year = d.getFullYear();
    hour = d.getHours();
    min = d.getMinutes();

    var months = [Locale(this.state.lang, "date_january"), Locale(this.state.lang, "date_february"), Locale(this.state.lang, "date_march"), Locale(this.state.lang, "date_april"), Locale(this.state.lang, "date_may"), Locale(this.state.lang, "date_june"), Locale(this.state.lang, "date_july"), Locale(this.state.lang, "date_august"), Locale(this.state.lang, "date_september"), Locale(this.state.lang, "date_october"), Locale(this.state.lang, "date_november"), Locale(this.state.lang, "date_december")];

    return [day, months[month], month, year, hour, min];
  }

  export const getMonthNumber = (month) => {
    var months = [Locale(this.state.lang, "date_january"), Locale(this.state.lang, "date_february"), Locale(this.state.lang, "date_march"), Locale(this.state.lang, "date_april"), Locale(this.state.lang, "date_may"), Locale(this.state.lang, "date_june"), Locale(this.state.lang, "date_july"), Locale(this.state.lang, "date_august"), Locale(this.state.lang, "date_september"), Locale(this.state.lang, "date_october"), Locale(this.state.lang, "date_november"), Locale(this.state.lang, "date_december")];
    var _index = 0;
    months.map((item,index)=>{
      if(item == month) _index = index;
    });
    return _index;
  }
  

  export const sortDateArrByYear = (arr) => {
    var d = new Date(date),
    month = '' + (d.getMonth() ),
    day = '' + d.getDate(),
    year = d.getFullYear();

    var months = [Locale(this.state.lang, "date_january"), Locale(this.state.lang, "date_february"), Locale(this.state.lang, "date_march"), Locale(this.state.lang, "date_april"), Locale(this.state.lang, "date_may"), Locale(this.state.lang, "date_june"), Locale(this.state.lang, "date_july"), Locale(this.state.lang, "date_august"), Locale(this.state.lang, "date_september"), Locale(this.state.lang, "date_october"), Locale(this.state.lang, "date_november"), Locale(this.state.lang, "date_december")];

    return [day, months[month], month, year];
  }

  