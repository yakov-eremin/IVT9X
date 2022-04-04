import * as WebBrowser from 'expo-web-browser';
import React from 'react';
import {
  StyleSheet,
  StatusBar,
  Platform,
  Dimensions,
  View,
  SafeAreaView,
  ScrollView,
  Image,
  Text,
  TouchableOpacity,
  BackHandler,
  Alert
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import Colors, {themes} from '../constants/Colors.js';

import UiButtonBlue from '../components/ui/button/ButtonBlue.js';
import UiCheckBox from '../components/ui/form/CheckBox.js';
import UiRadioBtnBox from '../components/ui/form/RadioBtnBox.js';
import UiAlert from '../components/ui/modal/Alert.js';

import logo from '../assets/images/logo-full.png';
import langIcon from '../assets/images/ui/globe-blue.png';
import langLightIcon from '../assets/images/ui/globe-light.png';

import {getLastRun, setLastRun } from '../services/Storage.js';
import {Locale, getFirstRun, setFirstRun, getLang, setLang, getTheme} from '../i18n/locale.js';

export default class WelcomeScreen extends React.Component  {

  state = {
    fontsLoaded: false,
    lang: "kz",
    langSelected: 0,
    selectedTheme: 'normal',
    modalLoadVisible: false,
    lenghtSelect: [
      {
        title:"ҚАЗ",
        value:0
      },
      {
        title:"РУС",
        value:1
      }
    ]
  }

  static navigationOptions = {
    header: null,
  };

  componentDidMount = async() => { 
    await Font.loadAsync({
      'Roboto-Regular': require('../assets/fonts/Roboto-Regular.ttf'),
      'Roboto-Medium': require('../assets/fonts/Roboto-Medium.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
    
    BackHandler.addEventListener('hardwareBackPress', ()=> {this.props.navigation.navigate('Main'); return true;});

  
    this.changeTheme();
    this.props.navigation.addListener('willFocus', this.load);
 
    //setFirstRun('true');
    getFirstRun().then((res)=>  {
      console.log("FR", res);
      if(res == undefined || res == null || res == 'true'){
        this.lang("kz");
        setFirstRun('false');
      } else {
        getLang().then((res)=> {
          
          global.lang = res;
          if(res == "kz") {
            this.setState({lang: res, langSelected: 0});
          } else {
            this.setState({lang: res, langSelected: 1});
          }
        });
      }
    });

    getLastRun().then((res)=>{
      if(res != null){
        this.setState({selelectedNews: res, modalLoadVisible: true})
        
      } else {

      }
      //console.log(res);
    })
  }
  
  load = () => { 
    //getLang().then((res)=>  this.setState({lang: res}) );
    this.changeTheme();
    //RSS
  }

  lang(lang){
    setLang(lang);
  
    getLang().then((res)=> {
      global.lang = res;
      this.setState({lang: res})
    });
  }


  changeTheme(){
    getTheme().then((res)=>  {
      //console.log("theme", res);
      global.theme =  res;
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
        this.state.selectedTheme == 'night' ? {backgroundColor: themes.night.uiBlue} : {backgroundColor: themes.normal.uiBlue},
      ]}>
        <StatusBar barStyle="light-content"  />
        <SafeAreaView style={styles.safeArea}>
          <View style={[
            styles.content,
            this.state.selectedTheme == 'night' ? {backgroundColor: themes.night.uiBlue} : {backgroundColor: themes.normal.uiBlue},
          ]}>

            <View style={styles.logo}>
              <View style={styles.logoInner}>
                <Image source={logo} style={styles.logoImage} />
              </View>
            </View>
            <View style={[
              styles.form,
              this.state.selectedTheme == 'night' ? {backgroundColor: themes.night.uiBg} : {backgroundColor: themes.normal.uiBg},
            ]}>

              <View style={styles.lang}>
                {this.state.selectedTheme == 'night' ?
                  <Image source={langLightIcon} style={styles.langIcon} /> :
                  <Image source={langIcon} style={styles.langIcon} />
                }
                <Text style={[
                  styles.langText,
                  this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText},
                ]}>
                  {Locale(global.lang, "language_app")}
                </Text>
              </View>
              <View style={styles.langRadio}>
                <UiRadioBtnBox 
                  defaultValue={this.state.langSelected}
                  selectedTheme={this.state.selectedTheme}
                  itemList={this.state.lenghtSelect}  
                  callBack={(res)=>{
                    //console.log("rr", res);
                    if(res == 1) this.lang("ru"); else this.lang("kz");
                  }}
                />
              </View>
              
              <View style={styles.push}>
                <UiCheckBox 
                  selectedTheme={this.state.selectedTheme}
                  labelText={Locale(global.lang, "push_uppercase")}
                  callBack={(res)=>{
                    //console.log(res)
                
                  }}
                />
              </View>
              
              <UiButtonBlue 
                selectedTheme={this.state.selectedTheme}
                buttonText={Locale(global.lang, "login")}
                onPress={()=> navigate('Main')}
              />

            </View>
          </View>

          <UiAlert 
            modalVisible={this.state.modalLoadVisible} 
            alertTitle={Locale(global.lang, "reset_news")}
            alertText={Locale(global.lang, "reset_news_mode")}
            okText={Locale(global.lang, "yes")}
            cancelText={Locale(global.lang, "cancel")}
            cancelPress ={() => {
              setLastRun(null);
              this.setState({modalLoadVisible: !this.state.modalLoadVisible});
            }}       
            okPress={() => {
              setLastRun(null);
              this.props.navigation.navigate("News", {info: this.state.selelectedNews});
              this.setState({modalLoadVisible: !this.state.modalLoadVisible});
            }}
          />
          
        </SafeAreaView>
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
    justifyContent: 'space-between',
  },
  /* Logo Top Elements */
  logo: {
    flex: 1,
    justifyContent:"center",
    alignItems: "center",
    backgroundColor: Colors.uiBlue,
  },
  logoInner: {
    width: 150,
    height: 150,
    overflow: 'hidden',
  },
  logoImage: {
    width: '100%',
    height: '100%',
    resizeMode: 'cover',
  },
  /* Form Elements */
  form: {
    flex: 1,
    paddingHorizontal: 16,
    alignItems: "center",
    justifyContent: "center",
  },
  lang: {
    width: '100%',
    height: 48,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'center',
  },
  langIcon: {
    width: 24,
    height: 24,
    resizeMode: 'contain',
  },
  langText: {
    fontFamily: 'Roboto-Medium',
    fontSize: 16,
    lineHeight: 22,
    color: Colors.uiDark,
    marginLeft: 12,
    textTransform: 'uppercase',
  },
  langRadio: {
    marginBottom: 16,
  },
  push: {
    marginBottom: 16,
  },
  
});
