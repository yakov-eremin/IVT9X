
import {AsyncStorage} from 'react-native';
import {ru} from '../i18n/ru.js';
import {kz} from '../i18n/kz.js';

export const Locale = (lang, word) => {
            if(lang == "ru"){
                return ru[word];
            } else if(lang == "kz"){
                return kz[word];
            } else {
               return kz[word];
            }
}

export const getFirstRun   = () => {
    return  AsyncStorage.getItem('fr').then((response) =>  response );
}
  
export const setFirstRun  = (value) => {
    return  AsyncStorage.setItem('fr', value);
}


export const getTheme   = () => {
    return  AsyncStorage.getItem('theme').then((response) =>  response );
}
  
export const setTheme = (value) => {
    return  AsyncStorage.setItem('theme', value);
}

export const getLang   = () => {
    return  AsyncStorage.getItem('lang').then((response) =>  response );
}
  
export const setLang  = (value) => {
    return  AsyncStorage.setItem('lang', value);
}