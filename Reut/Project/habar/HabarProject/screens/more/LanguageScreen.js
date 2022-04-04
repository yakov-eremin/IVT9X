import * as WebBrowser from 'expo-web-browser';
import React from 'react';
import {
  StyleSheet,
  Switch,
  Platform,
  Dimensions,
  View,
  SafeAreaView,
  ScrollView,
  Image,
  Text,
  TouchableOpacity,
  Alert
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import Colors, {themes} from '../../constants/Colors.js';

import Loader from '../../components/ui/Loader.js';
import UiHeader from '../../components/ui/header/Header.js';
import UiRadioBox from '../../components/ui/form/RadioBox.js';

import {Locale, getLang, setLang, getTheme} from '../../i18n/locale.js';

export default class LanguageScreen extends React.Component  {

  state = {
    fontsLoaded: false,
    loginProgress: false,
    nightEnabled: false,
    lang: 'kz',
    langSelect: [
      {
        title:"Русский язык",
        value:0
      },
      {
        title:"Қазақ тілі",
        value:1
      }
    ]
  }

  static navigationOptions = {
    header: null,
  };

  componentDidMount = async() => { 
    await Font.loadAsync({
      'Roboto-Regular': require('../../assets/fonts/Roboto-Regular.ttf'),
      'Roboto-Medium': require('../../assets/fonts/Roboto-Medium.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
  
    getLang().then((res)=>  {
      this.setState({lang: res});
      //console.log(res)
    });
    this.changeTheme();
    this.props.navigation.addListener('willFocus', this.load);
  }

  load = () => { 
    getLang().then((res)=> this.setState({lang: res}));
    this.changeTheme();
    //RSS
  }

  lang(lang){
    global.lang = lang;
    setLang(lang);
  }

  changeTheme(){
    getTheme().then((res)=>  {
      //console.log("theme", res);
      this.setState({selectedTheme: res});
    });
  }

  render() {
    const {navigate} = this.props.navigation;
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }

    return (
      <View style={[
        styles.container,
        this.state.selectedTheme == 'night' ? {backgroundColor: themes.night.uiBg} : {backgroundColor: themes.normal.uiBg} 
      ]}>
        
        <UiHeader 
          selectedTheme={this.state.selectedTheme}
          pressRight={()=> navigate('Live')}
          btnLeft='back'
          pressLeft={()=> navigate('Settings')}
        />
        <SafeAreaView style={styles.safeArea} forceInset={{top:'never'}}>
          <ScrollView style={styles.content}>
            <UiRadioBox 
              defaultValue={global.lang == 'ru'? 0 : 1}
              selectedTheme={this.state.selectedTheme}
              itemList={this.state.langSelect}  
              callBack={(res)=>{
                if(res == 0) this.lang("ru"); else this.lang("kz");
                //console.log(res)
              }}
            />
          </ScrollView>
        </SafeAreaView>

        <Loader 
          selectedTheme={this.state.selectedTheme} 
          show={this.state.loginProgress} 
        />
      </View>
    );
  }
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  safeArea: {
    flex: 1,
  },
  content: {
    flex: 1,
    marginVertical: 8,
  },
});
