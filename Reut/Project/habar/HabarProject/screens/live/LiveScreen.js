import * as WebBrowser from 'expo-web-browser';
import React from 'react';
import {
  StyleSheet,
  Dimensions,
  View,
  SafeAreaView,
  Image,
  Alert,
  StatusBar, 
  Platform,
} from 'react-native';
import { Video } from 'expo-av';
 
import VideoPlayer from 'expo-video-player';

import { AppLoading, ScreenOrientation } from 'expo';
import * as Font from 'expo-font';

import Loader from '../../components/ui/Loader.js';
import UiHeader from '../../components/ui/header/Header.js';
import UiTabs from '../../components/ui/tabs/Tabs.js';

import Colors, {themes} from '../../constants/Colors.js';
import { getSettingsUF } from '../../services/Feed.js';
import { isIphoneX } from '../../components/isIphoneX';

const { width: viewportWidth, height: viewportHeight } = Dimensions.get('window');
function wp (percentage) {
  const value = (percentage * viewportWidth) / 100;
  return Math.round(value);
}
function hp (percentage) {
  const value = (percentage * viewportHeight) / 100;
  return Math.round(value);
}
const videoWidth = wp(100);
const statusHeight = Platform.OS === 'ios' ? 20 : StatusBar.currentHeight;
const statusX = isIphoneX() ? 24 : 0;
const headerTop = statusHeight + statusX;
const videoHeight = hp(100) - 56 - headerTop;

export default class LiveScreen extends React.Component  {

  state = {
    fontsLoaded: false,
    loginProgress: false,
    markActive: false,
    videoPaused: true,
    videoHeight : hp(100) - 100,
    videoWidth : wp(100),
    videoHeightOld : hp(100) - 100,
    videoWidthOld : wp(100),

    liveUrl: '',
  }

  static navigationOptions = {
    header: null,
  };

  componentDidMount = async() => { 
    await Font.loadAsync({
      'Roboto-Regular': require('../../assets/fonts/Roboto-Regular.ttf'),
      'Roboto-Medium': require('../../assets/fonts/Roboto-Medium.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );

    
    ScreenOrientation.addOrientationChangeListener((ref)=>{
      //console.log(ref.orientationInfo.orientation)
      if(ref.orientationInfo.orientation == "LANDSCAPE" || ref.orientationInfo.orientation == "LANDSCAPE_RIGHT" || ref.orientationInfo.orientation == "LANDSCAPE_LEFT"){
        this.setState({
          videoHeight : Dimensions.get('window').height ,
          videoWidth : Dimensions.get('window').width,
        })
      } else {
        //console.log("PORTRAIT_UP11")
        this.setState({
          videoHeight : hp(100) - 100,
          videoWidth : wp(100),
        })
      }
      
    })

    getSettingsUF().then((res)=>{
      res = JSON.parse(res);
      //console.log(res.settings)
      if(res.settings.live != ""){
        this.setState({liveUrl:res.settings.live })
        this.setState({videoPaused: false })
      }
    })

    this.props.navigation.addListener('willFocus', () => {
      //console.log("willFocus")
      this.setState({videoPaused: false })
    });

    this.props.navigation.addListener('willBlur', () => {
      //console.log("willBlur")
      this.setState({videoPaused: true })
    });
  }




  render() {
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }

    return (
      <View style={styles.container}>
        <SafeAreaView style={styles.safeArea} forceInset={{top:'never'}}>
          <View style={styles.content}>
            {!this.state.videoPaused ?
              <VideoPlayer
                 
                videoProps={{
                  shouldPlay: true,
                  resizeMode: Video.RESIZE_MODE_CONTAIN, 
                  
                  source: {
                    uri: this.state.liveUrl , type: 'm3u8'
                  },
                }}
           
                useNativeControls={false}
                showControlsOnLoad={false}
                 
                width={this.state.videoWidth}
                height={this.state.videoHeight}
              />
            
            : null}
          </View> 
        </SafeAreaView>
        <UiTabs 
          selectedTheme={this.state.selectedTheme}
          navigation={this.props.navigation}
        />
        <Loader selectedTheme={this.state.selectedTheme} show={this.state.loginProgress} />
      </View>
    );
  }
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#000',
  },
  safeArea: {
    flexGrow: 1,
  },
  content: {
    alignItems: 'center',
    justifyContent: 'center',
  },
  
});
