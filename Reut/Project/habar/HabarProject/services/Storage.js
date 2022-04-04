
import {AsyncStorage} from 'react-native';


export const getLastRun   = () => {
    return  AsyncStorage.getItem('lr').then((response) =>  JSON.parse(response) );
}
  
export const setLastRun  = (value) => {
    return  AsyncStorage.setItem('lr', JSON.stringify(value));
}

export const getOffline   = () => {
    return  AsyncStorage.getItem('Offline').then((response) =>  JSON.parse(response) );
}
  
export const setOffline   = (value) => {
    return  AsyncStorage.setItem('Offline', JSON.stringify(value));
}

export const setOfflineNews   = () => {
    return  AsyncStorage.getItem('Offline').then((response) =>  JSON.parse(response) );
}
  
export const getOfflineNew   = (value) => {
    return  AsyncStorage.setItem('Offline', JSON.stringify(value));
}




export const getNews   = () => {
    return  AsyncStorage.getItem('news').then((response) =>  JSON.parse(response)  );
}

export const checkInNews   = ( ) => {
    return  AsyncStorage.getItem('news').then((response) =>  {
        var arr = JSON.parse(response);
        if (arr == null) arr = [];
        return arr;
    });
}

export const remNews   = (value) => {
    return AsyncStorage.getItem('news').then((response) => JSON.parse(response)).then((res)=>{
        if(res == null){
            
        } else {
            let f = true;
            let i = 0;
            res.map((item,index)=>{
                if(item.title == value.title) {
                    f = false;
                    i = index;
                }
            });
            if(!f){
                res.splice(i,1);
            } 


            AsyncStorage.setItem('news', JSON.stringify(res) );
        }
        
    });
 
}
  
export const setNews  = (value) => {
   return AsyncStorage.getItem('news').then((response) => JSON.parse(response)).then((res)=>{
        if(res == null){
            res = [];
            res.push(value);
            AsyncStorage.setItem('news', JSON.stringify(res)) ;
        } else {
            let f = true;
            res.map((item)=>{
                if(item.title == value.title) f = false;
            });
            if(f) res.push(value);
            AsyncStorage.setItem('news', JSON.stringify(res) );
        }
        
    });
 
}


export const clearCategory   = () => {
    AsyncStorage.setItem('category', JSON.stringify([])) ;
}
  

export const getCategory   = () => {
    return  AsyncStorage.getItem('category').then((response) =>  JSON.parse(response)  );
}

export const remCategory  = (value) => {
    return AsyncStorage.getItem('category').then((response) => JSON.parse(response)).then((res)=>{
        if(res == null){
            
        } else {
            let f = true;
            let i = 0;
            res.map((item,index)=>{
                if(item.title == value.title) {
                    f = false;
                    i = index;
                }
            });
            if(!f){
                res.splice(i,1);
            } 


            AsyncStorage.setItem('category', JSON.stringify(res) );
        }
        
    });
 
}

export const setCategory  = (value) => {
    return  AsyncStorage.getItem('category').then((response) => JSON.parse(response)).then((res)=>{
        if(res == null){
            res = [];
            res.push(value);
            AsyncStorage.setItem('category', JSON.stringify(res)) ;
        } else {
            let f = true;
            res.map((item)=>{
                if(item.title == value.title) f = false;
            });
            if(f) res.push(value);
            AsyncStorage.setItem('category', JSON.stringify(res) );
        }
        
    });
 
}