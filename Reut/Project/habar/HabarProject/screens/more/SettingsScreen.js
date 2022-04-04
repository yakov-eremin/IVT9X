import * as WebBrowser from 'expo-web-browser';
import React from 'react';
import {
  Alert,
  Dimensions,
  Image,
  Linking,
  Platform,
  SafeAreaView,
  ScrollView,
  StyleSheet,
  Switch,
  Text,
  TouchableOpacity,
  View,
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import bookmarkBlue from '../../assets/images/ui/bookmark-blue.png';
import chevronRight from '../../assets/images/ui/chevronRight-2x.png';
import settings from '../../assets/images/ui/cogs.png';
import worldWeb from '../../assets/images/ui/globe.png';

import Loader from '../../components/ui/Loader.js';
import UiHeader from '../../components/ui/header/Header.js';
import UiTabs from '../../components/ui/tabs/Tabs.js';

import Colors, {themes} from '../../constants/Colors.js';

import {Locale, getLang, getTheme, setTheme} from '../../i18n/locale.js';

export default class SettingsScreen extends React.Component  {

  state = {
    fontsLoaded: false,
    loginProgress: false,
    nightEnabled: false,
    lang: "kz",
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
      //console.log("lang", res);
      this.setState({lang: res}) 
    });
    this.changeTheme();
    this.props.navigation.addListener('willFocus', this.load);
    //this.getRSS();
  }

  load = () => { 
    getLang().then((res)=>  this.setState({lang: res}) );
    this.changeTheme();
  }

  changeTheme(){
    getTheme().then((res)=>  {
      //console.log("theme", res);
      if(res == 'night') {
        this.setState({nightEnabled: true});
      }else {
        this.setState({nightEnabled: false});
      } 
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
        />
        <SafeAreaView style={styles.safeArea} forceInset={{top:'never'}}>
          <ScrollView style={styles.content}>
            
            <TouchableOpacity 
              style={[
                styles.link,
                this.state.selectedTheme == 'night' ? {borderColor: themes.night.uiLine} : {borderColor: themes.normal.uiLine}
              ]} 
              onPress={()=> navigate('Read')}
            >
              <Image style={styles.linkIcon} source={bookmarkBlue} />
              <Text style={[
                styles.linkSetting,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText}
              ]}>
                {Locale(global.lang, "read_later_uppercase")}
              </Text>
              <Image style={styles.chevronLink} source={chevronRight} />
            </TouchableOpacity>

            <TouchableOpacity 
              style={[
                styles.link,
                this.state.selectedTheme == 'night' ? {borderColor: themes.night.uiLine} : {borderColor: themes.normal.uiLine}
              ]} 
              onPress={()=> navigate('SettingsMore')}
            >
              <Image style={styles.linkIcon} source={settings} />
              <Text style={[
                styles.linkSetting,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText}
              ]}>
                {Locale(global.lang, "settings_uppercase")}
              </Text>
              <Image style={styles.chevronLink} source={chevronRight} />
            </TouchableOpacity>

            <TouchableOpacity 
              style={[
                styles.link,
                this.state.selectedTheme == 'night' ? {borderColor: themes.night.uiLine} : {borderColor: themes.normal.uiLine}
              ]} 
              onPress={()=> navigate('Language')}
            >
              <Image style={styles.linkIcon} source={worldWeb} />
              <Text style={[
                styles.linkSetting,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText}
              ]}>
                {Locale(global.lang, "change_language_uppercase")}
              </Text>
              <Image style={styles.chevronLink} source={chevronRight} />
            </TouchableOpacity>

            <TouchableOpacity 
              style={[
                styles.link,
                this.state.selectedTheme == 'night' ? {borderColor: themes.night.uiLine} : {borderColor: themes.normal.uiLine}
              ]}
              onPress={()=> Linking.openURL('https://24.kz/kz/')}
            >
              <Text style={[
                styles.linkDownSetting,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText}
              ]}>
                {Locale(global.lang, "about_kz24_uppercase")}
              </Text>
              <Image style={styles.chevronLink} source={chevronRight} />
            </TouchableOpacity>

            <TouchableOpacity 
              style={[
                styles.link,
                this.state.selectedTheme == 'night' ? {borderColor: themes.night.uiLine} : {borderColor: themes.normal.uiLine}
              ]} 
              onPress={()=> navigate('AboutApp')}
            >
              <Text style={[
                styles.linkDownSetting,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText}
              ]}>
                {Locale(global.lang, "about_app_uppercase")}
              </Text>
              <Image style={styles.chevronLink} source={chevronRight} />
            </TouchableOpacity>

            <View style={[
              styles.link,
              this.state.selectedTheme == 'night' ? {borderColor: themes.night.uiLine} : {borderColor: themes.normal.uiLine}
            ]}>
              <Text style={[
                styles.linkDownSetting,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText}
              ]}>
                {Locale(global.lang, "night_mode")}
              </Text>
              {Platform.OS == 'ios' ?
                <Switch
                  trackColor={{false:'', true: themes.night.uiLine}}
                  value={this.state.nightEnabled}
                  onValueChange={()=> { 
                    let fl = !this.state.nightEnabled;
                    //console.log(fl)
                    if(fl) {
                      setTheme('night'); 
                      this.setState({selectedTheme: 'night'});
                    }else {
                      setTheme('normal');   
                      this.setState({selectedTheme: 'normal'});
                    } 
                    this.setState({nightEnabled: fl});
                  }}
                /> : 
                <Switch
                  trackColor={{false: '', true: themes.night.uiLine}}
                  thumbColor={[this.state.nightEnabled ? '#fff' : '#fff']}
                  value={this.state.nightEnabled}
                  onValueChange={()=>{
                    let fl = !this.state.nightEnabled;
                    //console.log(fl)
                    if(fl) {
                      setTheme('night'); 
                      this.setState({selectedTheme: 'night'});
                    }else {
                      setTheme('normal');   
                      this.setState({selectedTheme: 'normal'});
                    } 
                    this.setState({nightEnabled: fl});
                  }}
                />
               }
            </View>
            
          </ScrollView>
        </SafeAreaView>

        <UiTabs 
          selectedTheme={this.state.selectedTheme}
          navigation={this.props.navigation}
          activeTabs={5}
        />

        <Loader 
          selectedTheme={this.state.selectedTheme}
          show={this.state.loginProgress} 
        />

      </View>
    );
  }
}


var styles = StyleSheet.create({
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
  link:{
    marginLeft: 16,
    paddingRight: 16,
    fontFamily: 'Roboto-Regular',
    flexDirection: "row",
    alignItems:"center",
    borderBottomWidth: 1,
    justifyContent: "space-between",
    paddingVertical:5,
  },
  linkIcon:{
    width:24,
    height:24,
    margin:10,
    flexGrow:0,
    flexShrink:0,
  },
  linkSetting:{
    fontSize:14,
    fontFamily: 'Roboto-Medium',
    color: Colors.uiNightText,
    flexGrow:1,
    flexShrink:1,
  },
  linkDownSetting:{
    fontSize:14,
    margin:10,
    color: Colors.uiNightText,
    flexGrow:1,
    flexShrink:1,
  },
  chevronLink:{
    height:20,
    width:20,
    flexGrow:0,
    flexShrink:0,
  },
});
