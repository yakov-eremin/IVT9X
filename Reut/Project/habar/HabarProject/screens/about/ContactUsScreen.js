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
import UiTextInput from '../../components/ui/form/TextInput.js';
import UiTextInputLines from '../../components/ui/form/TextInputLines.js';
import UiTextInputMasked from '../../components/ui/form/TextInputMasked.js';
import UiCheckBox from '../../components/ui/form/CheckBox.js';
import UiButtonBlue from '../../components/ui/button/ButtonBlue.js';
import UiButtonSmBlue from '../../components/ui/button/ButtonSmBlue.js';

import iconDelete from '../../assets/images/ui/delete-2x.png';
import {Locale, getLang, getTheme} from '../../i18n/locale.js';

 
export default class ContactUsScreen extends React.Component  {

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

    getLang().then((res)=>  this.setState({lang: res}) );
    this.changeTheme();
    this.props.navigation.addListener('willFocus', this.load);
  }

  load = () => { 
    getLang().then((res)=>  this.setState({lang: res}) );
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
        this.state.selectedTheme == 'night' ? {borderColor: themes.night.uiLine} : {borderColor: themes.normal.uiLine},
      ]}>
        <Loader selectedTheme={this.state.selectedTheme} show={this.state.loginProgress} />
        <UiHeader 
          pressLeft={()=> navigate('AboutApp')}
          pressBtnRight={()=> {
            if (this.state.lang == 'ru') {
              Alert.alert("Внимание", "Сообщение отправлено");
            } else {
              Alert.alert("Назар аудар", "Хабарлама жіберілді");
            }
            navigate("Main")
          }}
          btnBtnRightText={Locale(this.state.lang, "send")}
          btnLeft='back'
          selectedTheme={this.state.selectedTheme}
        />

        <SafeAreaView style={styles.safeArea} forceInset={{top:'never'}}>
          <ScrollView style={styles.content}>
            <Text style={styles.text}>
              {Locale(this.state.lang, "contact_us_text")}
            </Text>
            <Text style={[styles.title, this.state.selectedTheme == 'night' ? {color: themes.night.uiBlue} : {borderColor: themes.normal.uiBlue},]}>{Locale(this.state.lang, "theme")}</Text>
            <UiTextInput 
              selectedTheme={this.state.selectedTheme}
              placeholder={Locale(this.state.lang, "theme") + ":"}
              maxLength={200}
            />
            <Text style={[styles.title, this.state.selectedTheme == 'night' ? {color: themes.night.uiBlue} : {borderColor: themes.normal.uiBlue},]}>{Locale(this.state.lang, "message")}</Text>
            <UiTextInputLines 
              selectedTheme={this.state.selectedTheme}
              placeholder= {Locale(this.state.lang, "message") + ":"}
              multiline={true}
              numberOfLines={3}
            />
            
          </ScrollView>
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
    marginVertical: 8,
    marginHorizontal: 16,
  },
  title: {
    fontFamily: 'Roboto-Medium',
    fontSize: 16,
    lineHeight: 20,
    marginTop: 8,
    marginBottom: 4,
  },
  text: {
    fontFamily: 'Roboto-Regular',
    fontSize: 16,
    lineHeight: 20,
    marginTop: 8,
    marginBottom: 4,
  },
  
});
