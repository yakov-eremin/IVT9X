import {AsyncStorage} from 'react-native';

const tintColor = '#2f95dc';

export default {
  colWhite: '#fff',
  colRed: '#f00',
  colBlue: '#003865',
  colBlueGrey: '#8a959d',
  colDark: '#363636',
  colGray: '#666',
  colLightGray: '#999',
  colTitanWhite: '#e2e0e5',
};

const normal = {
  uiBg: '#fff',
  uiBgGray: '#dbdbdb',
  uiTabLine: '#fff',
  uiBlue: '#003865',
  uiTabsBg: '#fff',
  uiTabsLine: '#e0e0e0',
  uiCardBg: '#fff',
  uiCardTitle: '#003865',
  uiLine: '#dbdbdb',
  uiText: '#363636',
};

const night = {
  uiBg: '#323639',
  uiBgGray: '#323639',
  uiTabLine: '#17181a',
  uiBlue: '#00223e',
  uiTabsBg: '#323639',
  uiTabsLine: '#17181a',
  uiCardBg: '#202224',
  uiCardTitle: '#eff0f1',
  uiLine: '#17181a',
  uiText: '#f8f9f9',
};

export function getThemesColor  (key)  {
    //console.log("global.theme", global.theme)
    if(global.theme == 'night') return  night[key]; else  return  normal[key]; 
}

export const themes = {
  normal,
  night,
};