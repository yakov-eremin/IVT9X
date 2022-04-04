import * as rssParser from '../components/common/rss-parser';

export const parseTags = (str) => {
    var rx =/<img[^>]+src="([^">]+)/g;
    var _rx = rx.exec(str);
    //console.log("rx", _rx)
    
    var _text = str.replace(/<li>/ig, ' ');
    _text = _text.replace(/<\/li>/ig, ' ');
  
    _text = _text.replace(/<[^>]*>?/gm, '');
    _text = _text.replace(/[\r|\n|\r\n]$/gm, '');
   
    return {
        text: _text,
        images: _rx != null ? _rx[1] : ""
    }
}

export const parseVideoTag = (str) => {
    var rx =/<iframe src="([^">]+)/g;
    var _rx = rx.exec(str);
     if(_rx != null)   return _rx[1]; else return null;
 
    
}

export const parseFeddTag = (str) => {
   var rx =/<div class="K2FeedTags/g;
    _rx = str.match("<div class=\"K2FeedTags\">(.*?)</div>")[1];
    _rx = _rx.replace(/<[^>]*>?/gm, '#');
    _rx = _rx.replace(/##/gm, ' #');
   //console.log(_rx);

   return _rx;
    
}


export const setUserPushToken = (token) => {
    return fetch('http://test.interkot.ru/habar24/set_push.php' , {
        method: 'POST',
        body: token,
      }).then((response) => response.json())
}



export const getSettingsUF = (lang) => {
    return fetch('http://test.interkot.ru/habar24/settings.txt')
    .then((response) => response.json()) 
}


export const getCategorysTV = (lang) => {
    //console.log("cat", lang)
    if(lang == "ru"){
        return fetch('https://24.kz/tvproject.xml')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    } else {
        return fetch('https://24.kz/tvproject_kz.xml')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }

}


export const getCategorys = (lang) => {
    //console.log("cat", lang)
    if(lang == "ru"){
        return fetch('https://24.kz/rubriki.xml')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    } else {
        return fetch('https://24.kz/rubriki_kz.xml')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }

}

export const getPopularNews = (lang) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/component/k2/itemlist?format=feed&moduleID=242')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    } else {
        return fetch('https://24.kz/kz/component/k2/itemlist?format=feed&moduleID=244')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }

}


export const getCatNews = (lang, id) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/news?format=feed&catid='+id)
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    } else {
        return fetch('https://24.kz/kz/news?format=feed&catid='+id)
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }

}

export const getNews = (lang) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/news?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    } else {
        return fetch('https://24.kz/kz/zha-aly-tar?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }

}
export const getMainNews = (lang) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/news/top-news?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }else{
        return fetch('https://24.kz/kz/zha-aly-tar/zha-aly-tar-toptamasy?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }
    
}
export const getIssuesNews = (lang) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/news/vypuski-novostej?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )  
    }else{
        return fetch('https://24.kz/kz/zha-aly-tar/basty-zha-aly-tar?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )  
    }
    
}
export const getWorldNews = (lang) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/news/in-the-world?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }else{
        return fetch('https://24.kz/kz/zha-aly-tar/bilim-zh-ne-ylym?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }
    
}
export const getBusinessNews = (lang) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/news/delovye-novosti?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }else{
        return fetch('https://24.kz/kz/zha-aly-tar/bylu-manyzdy?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }
    
}
export const getCulturalNews = (lang) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/news/culture?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }else{
        return fetch('https://24.kz/kz/zha-aly-tar/sayasat?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }
    
}
export const getNewsKZ = (lang) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/news/novosti-kazakhstana?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } ) 
    }else{
        return fetch('https://24.kz/kz/zha-aly-tar/ekonomika?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } ) 
    }
   
}
export const getPeopleNews = (lang) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/news/people-report?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }else{
        return fetch('https://24.kz/kz/zha-aly-tar/lemde?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }
    
}
export const getSocietyNews = (lang) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/news/social?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } ) 
    }else{
        return fetch('https://24.kz/kz/zha-aly-tar/o-am?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } ) 
    }
    
}
export const getCulturalAndScienceNews = (lang) => {
    if(lang == "ru"){
       return fetch('https://24.kz/ru/news/obrazovanie-i-nauka?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } ) 
    }else{
        return fetch('https://24.kz/kz/zha-aly-tar/sport?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } ) 
    }
    
}
export const getViewPressNews = (lang) => {
    if(lang == "ru"){
      return fetch('https://24.kz/ru/news/obzor-pressy?format=feed')
      .then((response) => response.text())
      .then((responseData) =>{
            //console.log(responseData)
        return rssParser.parse(responseData);
      } )  
    }else{
        return fetch('https://24.kz/kz/zha-aly-tar/o-i-a?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } ) 
    }
    
}
export const getPolicyNews = (lang) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/news/policy?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )   
    }else{
        return fetch('https://24.kz/kz/zha-aly-tar/m-denie?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )   
    }
    
}
export const getAccidentsNews = (lang) => {
    if(lang == "ru"){
       return fetch('https://24.kz/ru/news/incidents?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } ) 
    }else{
        return fetch('https://24.kz/kz/zha-aly-tar/o-i-a-ku-geri?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } ) 
    }
    
}
export const getGoodToKnowNews = (lang) => {
    if(lang == "ru"){
       return fetch('https://24.kz/ru/news/polezno-znat?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } ) 
    }else{
        return fetch('https://24.kz/kz/zha-aly-tar/baspasozge-sholu?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } ) 
    }
    
}
export const getSportNews = (lang) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/news/sport?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }else{
        return fetch('https://24.kz/kz/zha-aly-tar/ekonomika-zhnalyktary?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )
    }
    
}
export const getEconomyNews = (lang) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/news/economyc?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )    
    }else{
        return fetch('https://24.kz/kz/zha-aly-tar/aza-stan-zha-aly-tary?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )   
    }
    
}


export const getTv = (url) => {
    console.log(url)
    return fetch(url)
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )    
}


export const getTv_Projects = (lang) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/tv-projects?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )    
    }else{
        return fetch('https://24.kz/kz/telepoject?format=feed')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )   
    }
    
}
export const getTv_Programm = (lang) => {
    if(lang == "ru"){
        return fetch('https://24.kz/ru/tvschedule')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )    
    }else{
        return fetch('https://24.kz/ru/tvschedule')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )   
    }
    
}
export const getLive = (lang) => {
    if(lang == "ru"){
        return fetch('http://24.kz/mobtv')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )    
    }else{
        return fetch('http://24.kz/mobtv')
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )   
    }
    
}

export const getFedCategory = (lang, id) => {
    let link = "";
    switch (id) {
        case 0:
            if(lang == "ru"){
                link = "https://24.kz/ru/news/top-news?format=feed";
            } else {
                link = "https://24.kz/kz/zha-aly-tar/basty-zha-aly-tar?format=feed";
            }  
        break;
        case 1:
            if(lang == "ru"){
                link = "https://24.kz/ru/news/vypuski-novostej?format=feed";
            } else {
                link = "https://24.kz/kz/zha-aly-tar/zha-aly-tar-toptamasy?format=feed";
            }  
        break;
        case 2:
            if(lang == "ru"){
                link = "https://24.kz/ru/news/in-the-world?format=feed";
            } else {
                link = "https://24.kz/kz/zha-aly-tar/lemde?format=feed";
            }  
        break;
        case 3:
            if(lang == "ru"){
                link = "https://24.kz/ru/news/delovye-novosti?format=feed";
            } else {
                link = "https://24.kz/kz/zha-aly-tar/ekonomika-zhnalyktary?format=feed";
            }  
        break;
        case 4:
            if(lang == "ru"){
                link = "https://24.kz/ru/news/culture?format=feed";
            } else {
                link = "https://24.kz/kz/zha-aly-tar/m-denie?format=feed";
            }  
        break;
        case 5:
            if(lang == "ru"){
                link = "https://24.kz/ru/news/novosti-kazakhstana?format=feed";
            } else {
                link = "https://24.kz/kz/zha-aly-tar/aza-stan-zha-aly-tary?format=feed";
            }  
        break;
        case 6:
            if(lang == "ru"){
                link = "https://24.kz/ru/news/people-report?format=feed";
            } else {
                link = "https://24.kz/kz/zha-aly-tar/o-i-a-ku-geri?format=feed";
            }  
        break;
        case 7:
            if(lang == "ru"){
                link = "https://24.kz/ru/news/social?format=feed";
            } else {
                link = "https://24.kz/kz/zha-aly-tar/o-am?format=fee";
            }  
        break;
        case 8:
            if(lang == "ru"){
                link = "https://24.kz/ru/news/obrazovanie-i-nauka?format=feed";
            } else {
                link = "https://24.kz/kz/zha-aly-tar/bilim-zh-ne-ylym?format=feed";
            }  
        break;
        case 9:
            if(lang == "ru"){
                link = "https://24.kz/ru/news/obzor-pressy?format=feed";
            } else {
                link = "https://24.kz/kz/zha-aly-tar/baspasozge-sholu?format=feed";
            }  
        break;
        case 10:
            if(lang == "ru"){
                link = "https://24.kz/ru/news/policy?format=feed";
            } else {
                link = "https://24.kz/kz/zha-aly-tar/sayasat?format=feed";
            }  
        break;
        case 11:
            if(lang == "ru"){
                link = "https://24.kz/ru/news/incidents?format=feed";
            } else {
                link = "https://24.kz/kz/zha-aly-tar/o-i-a?format=feed";
            }  
        break;
        case 12:
            if(lang == "ru"){
                link = "https://24.kz/ru/news/polezno-znat?format=feed";
            } else {
                link = "https://24.kz/kz/zha-aly-tar/bylu-manyzdy?format=feed";
            }  
        break;
        case 13:
            if(lang == "ru"){
                link = "https://24.kz/ru/news/sport?format=feed";
            } else {
                link = "https://24.kz/kz/zha-aly-tar/sport?format=feed";
            }  
        break;
        case 14:
            if(lang == "ru"){
                link = "https://24.kz/ru/news/economyc?format=feed";
            } else {
                link = "https://24.kz/kz/zha-aly-tar/ekonomika?format=feed";
            }  
        break;    

        default:
            link = "https://24.kz/ru/news/top-news?format=feed";
    }

   
        return fetch(link)
        .then((response) => response.text())
        .then((responseData) =>{
            //console.log(responseData)
            return rssParser.parse(responseData);
        } )    
   
    
}
