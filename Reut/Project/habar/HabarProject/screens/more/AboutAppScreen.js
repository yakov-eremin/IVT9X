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
  Alert,
  Share
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import Colors, {themes} from '../../constants/Colors.js';

import Loader from '../../components/ui/Loader.js';
import UiHeader from '../../components/ui/header/Header.js';

import chevronRight from '../../assets/images/ui/chevronRight-2x.png';
import bulbIcon from '../../assets/images/about/bulb-blue-2x.png';
import mobileIcon from '../../assets/images/about/mobile-blue-2x.png';
import commentIcon from '../../assets/images/about/comment-blue-2x.png';
import starIcon from '../../assets/images/about/star-blue-2x.png';
import shareIcon from '../../assets/images/about/share-blue-2x.png';
import unlockIcon from '../../assets/images/about/unlock-blue-2x.png';
import bulbLightIcon from '../../assets/images/about/bulb-light-2x.png';
import mobileLightIcon from '../../assets/images/about/mobile-light-2x.png';
import commentLightIcon from '../../assets/images/about/comment-light-2x.png';
import starLightIcon from '../../assets/images/about/star-light-2x.png';
import shareLightIcon from '../../assets/images/about/share-light-2x.png';
import unlockLightIcon from '../../assets/images/about/unlock-light-2x.png';

import {Locale, getLang, getTheme} from '../../i18n/locale.js';

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
    
    getLang().then((res)=>  this.setState({lang: res}) );
    this.changeTheme();
    this.props.navigation.addListener('willFocus', this.load);
    //this.getRSS();
  }
  
  load = () => { 
    getLang().then((res)=>  this.setState({lang: res}) );
    this.changeTheme();
    //RSS
  }

  changeTheme(){
    getTheme().then((res)=>  {
      //console.log("theme", res);
      this.setState({selectedTheme: res});
    });
  }

  onShare = async (title) => {
    try {
      const result = await Share.share({
        message: title,
      });
      if (result.action === Share.sharedAction) {
        if (result.activityType) {
          // shared with activity type of result.activityType
        } else {
          // shared
        }
      } else if (result.action === Share.dismissedAction) {
        // dismissed
      }
    } catch (error) {
      alert(error.message);
    }
  };

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
            
            <TouchableOpacity 
              style={[
                styles.link,
                this.state.selectedTheme == 'night' ? {borderColor: themes.night.uiLine} : {borderColor: themes.normal.uiLine},
              ]}
              onPress={()=> navigate('OnBoard')}
            >
              {this.state.selectedTheme == 'night' ?
                <Image style={styles.linkIcon} source={bulbLightIcon} /> :
                <Image style={styles.linkIcon} source={bulbIcon} />
              }
              <Text style={[
                styles.linkSetting,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText},
              ]}>
                {Locale(global.lang, "bulb")}
              </Text>
              <Image style={styles.chevronLink} source={chevronRight} />
            </TouchableOpacity>



            <TouchableOpacity 
              style={[
                styles.link,
                this.state.selectedTheme == 'night' ? {borderColor: themes.night.uiLine} : {borderColor: themes.normal.uiLine},
              ]}
              onPress={()=> navigate('Support')}
            >
              {this.state.selectedTheme == 'night' ?
                <Image style={styles.linkIcon} source={commentLightIcon} /> : 
                <Image style={styles.linkIcon} source={commentIcon} />
              }
              <Text style={[
                styles.linkSetting,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText},
              ]}>
                {Locale(global.lang, "link_with_moderate")}
              </Text>
              <Image style={styles.chevronLink} source={chevronRight} />
            </TouchableOpacity>

            
            <TouchableOpacity 
              style={[
                styles.link,
                this.state.selectedTheme == 'night' ? {borderColor: themes.night.uiLine} : {borderColor: themes.normal.uiLine},
              ]}
              onPress={()=> navigate('ContactUs')}
            >
              {this.state.selectedTheme == 'night' ?
                <Image style={styles.linkIcon} source={mobileLightIcon} /> :
                <Image style={styles.linkIcon} source={mobileIcon} />
              }
              <Text style={[
                styles.linkSetting,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText},
              ]}>
                {Locale(global.lang, "mobile")}
              </Text>
              <Image style={styles.chevronLink} source={chevronRight} />
            </TouchableOpacity>

            <TouchableOpacity 
              style={[
                styles.link,
                this.state.selectedTheme == 'night' ? {borderColor: themes.night.uiLine} : {borderColor: themes.normal.uiLine},
              ]}
              onPress={()=> Alert.alert('Оценка будет доступна после публикации')}
            >
              {this.state.selectedTheme == 'night' ?
                <Image style={styles.linkIcon} source={starLightIcon} /> : 
                <Image style={styles.linkIcon} source={starIcon} />
              }
              <Text style={[
                styles.linkSetting,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText},
              ]}>
                {Locale(global.lang, "rating")}
              </Text>
              <Image style={styles.chevronLink} source={chevronRight} />
            </TouchableOpacity>

            <TouchableOpacity style={[
              styles.link,
              this.state.selectedTheme == 'night' ? {borderColor: themes.night.uiLine} : {borderColor: themes.normal.uiLine},
            ]}
              onPress={() => this.onShare("Приложение Хабар24 для телефона")}
            >
              {this.state.selectedTheme == 'night' ?
                <Image style={styles.linkIcon} source={shareLightIcon} /> :
                <Image style={styles.linkIcon} source={shareIcon} />
              }
              <Text style={[
                styles.linkSetting,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText},
              ]}>
                {Locale(global.lang, "share")}
              </Text>
              <Image style={styles.chevronLink} source={chevronRight} />
            </TouchableOpacity>

            <TouchableOpacity 
              style={[
                styles.link,
                this.state.selectedTheme == 'night' ? {borderColor: themes.night.uiLine} : {borderColor: themes.normal.uiLine},
              ]} 
              onPress={()=> navigate('Politics')}
            >
              {this.state.selectedTheme == 'night' ?
                <Image style={styles.linkIcon} source={unlockLightIcon} /> :
                <Image style={styles.linkIcon} source={unlockIcon} /> 
              }
              <Text style={[
                styles.linkSetting,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText},
              ]}>
                {Locale(global.lang, "politics")}
              </Text>
              <Image style={styles.chevronLink} source={chevronRight} />
            </TouchableOpacity>
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
    fontWeight:"800",
    flexGrow:1,
    flexShrink:1,
  },
  linkDownSetting:{
    fontSize:14,
    margin:10,
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
