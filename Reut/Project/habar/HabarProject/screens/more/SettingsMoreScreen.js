import * as WebBrowser from 'expo-web-browser';
import React from 'react';
import {
  StyleSheet,
  Switch,
  Platform,
  View,
  SafeAreaView,
  ScrollView,
  Text,
  Alert
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import Colors, {themes} from '../../constants/Colors.js';

import Loader from '../../components/ui/Loader.js';
import UiHeader from '../../components/ui/header/Header.js';
import {getOffline, setOffline } from '../../services/Storage.js';
import {Locale, getLang, getTheme} from '../../i18n/locale.js';


export default class SettingsMoreScreen extends React.Component  {

  state = {
    fontsLoaded: false,
    loginProgress: false,
    nightEnabled: false,
    offlineEnabled: false,
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
  
    getLang().then((res)=>  this.setState({lang: res}) );
    getOffline().then((res)=>  this.setState({offlineEnabled: res}) );
    this.changeTheme();
    this.props.navigation.addListener('willFocus', this.load);
  }

  load = () => { 
    getLang().then((res)=>  this.setState({lang: res}) );
    getOffline().then((res)=>  this.setState({offlineEnabled: res}) );
    this.changeTheme();
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
          pressBtnRight={()=> {}}
          btnBtnRightText= {Locale(global.lang, "save")}
          btnLeft='back'
          pressLeft={()=> navigate('Settings')}
        />

        <SafeAreaView style={styles.safeArea} forceInset={{top:'never'}}>
          <ScrollView style={styles.content}>
            <Text style={[
              styles.settTitle,
              this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText}
            ]}>
              {Locale(global.lang, "settings_push")}
            </Text>
            <View style={[
              styles.link,
              this.state.selectedTheme == 'night' ? {borderColor: themes.night.uiLine} : {borderColor: themes.normal.uiLine}
            ]}>
              <Text style={[
                styles.linkDownSetting,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText}
              ]}>
                {Locale(global.lang, "push")}
              </Text>
              {Platform.OS == 'ios' ?
                <Switch
                  trackColor={{false:'', true: themes.night.uiLine}}
                  value={this.state.nightEnabled}
                  onValueChange={()=> { 
                    this.setState({nightEnabled: !this.state.nightEnabled});
                  }}
                /> : 
                <Switch
                  trackColor={{false: '', true: themes.night.uiLine}}
                  thumbColor={[this.state.nightEnabled ? '#fff' : '#fff']}
                  value={this.state.nightEnabled}
                  onValueChange={()=>{
                    this.setState({nightEnabled: !this.state.nightEnabled});
                  }}
                />
              }
            </View>


            <Text style={[
              styles.settTitle, 
              this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText}
            ]}>
              {Locale(global.lang, "text_size")}
            </Text>
            <Text style={[
              styles.settText,
              this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText}
            ]}>
              {Locale(global.lang, "text_size_modify")}
            </Text>
            <Text style={[
              styles.settText,
              this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText}
            ]}>
              {Locale(global.lang, "text_size_bread_crumb")}
            </Text>

            <Text style={[
              styles.settTitle,
              this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText}
            ]}>
              {Locale(global.lang, "offline_mode_activ")}
            </Text>
            <View style={[
              styles.link,
              this.state.selectedTheme == 'night' ? {borderColor: themes.night.uiLine} : {borderColor: themes.normal.uiLine}
            ]}>
              <Text style={[
                styles.linkDownSetting,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText}
              ]}>
                {Locale(global.lang, "offline_mode")}
              </Text>
              {Platform.OS == 'ios' ?
                <Switch
                  trackColor={{false:'', true: themes.night.uiLine}}
                  value={this.state.offlineEnabled}
                  onValueChange={()=> { 
                    this.setState({offlineEnabled: !this.state.offlineEnabled});
                    setOffline(!this.state.offlineEnabled);
                  }}
                /> : 
                <Switch
                  trackColor={{false: '', true: themes.night.uiLine}}
                  thumbColor={[this.state.nightEnabled ? '#fff' : '#fff']}
                  value={this.state.offlineEnabled}
                  onValueChange={()=>{
                    this.setState({offlineEnabled: !this.state.offlineEnabled});
                    setOffline(!this.state.offlineEnabled);
                  }}
                />
              }
            </View>
            
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
  settTitle: {
    fontFamily: 'Roboto-Medium',
    color: Colors.uiBlue,
    fontSize: 16,
    lineHeight: 20,
    marginBottom: 4,
    marginTop: 12,
    marginHorizontal: 16,
  },
  link: {
    marginLeft: 16,
    paddingRight: 16,
    fontFamily: 'Roboto-Regular',
    flexDirection: "row",
    alignItems:"center",
    borderBottomWidth: 1,
    justifyContent: "space-between",
    paddingVertical:5,
  },
  linkDownSetting: {
    fontSize: 14,
    lineHeight: 20,
    fontFamily: 'Roboto-Regular',
    marginVertical: 10,
    flexGrow: 1,
    flexShrink: 1,
  },
  settText: {
    fontSize: 14,
    lineHeight: 20,
    fontFamily: 'Roboto-Regular',
    marginVertical: 4,
    marginHorizontal: 16,
  },

});
