import React from 'react';
import { 
  StyleSheet, 
  Dimensions, 
  View, 
  Text, 
  Image, 
  TouchableOpacity, 
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import alertIcon from '../../../assets/images/cards/bell-outline.png';
import alertActiveIcon from '../../../assets/images/cards/bell-blue.png';
import playIcon from '../../../assets/images/cards/play-red.png';

import Colors, { themes } from '../../../constants/Colors';
import {Locale, getLang} from '../../../i18n/locale.js';

componentDidMount = async() => { 
  await Font.loadAsync({
    'Roboto-Regular': require('../../../assets/fonts/Roboto-Regular.ttf'),
    'Roboto-Medium': require('../../../assets/fonts/Roboto-Medium.ttf'),
  }).then( () => this.setState( { fontsLoaded: true } ) );

  getLang().then((res)=>  this.setState({lang: res}) );
  this.props.navigation.addListener('willFocus', this.load);

//this.getRSS();
}

load = () => { 
  getLang().then((res)=>  this.setState({lang: res}) );

  //RSS
  
}

const { width: viewportWidth } = Dimensions.get('window');
function wp (percentage) {
  const value = (percentage * viewportWidth) / 100;
  return Math.round(value);
}
const imageWidth = wp(100) - 94;
const imageHeight = imageWidth*0.56;
const cardHeight = imageHeight + 68;

export default class UiProgramCard extends React.Component {

  state = {
    fontsLoaded: false,
    loginProgress: false,
    activeTime: false,
    lang: "ru",
  }

  constructor(props){
    super(props);
  }

  render() {
    return (
      <TouchableOpacity 
        onPress={()=> this.props.onPress() }
        style={[
          styles.programCard, 
          this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiLine} : {borderBottomColor: themes.normal.uiLine},
          this.props.live ? styles.programCardLive : null
        ]}
      >
        <View style={[
          styles.time, 
          this.props.selectedTheme == 'night' ? {borderRightColor: themes.night.uiLine} : {borderRightColor: themes.normal.uiLine},
          this.props.live && this.props.selectedTheme == 'night' ? {borderRightColor: themes.night.uiBlue} : null,
          this.props.live && this.props.selectedTheme != 'night' ? {borderRightColor: themes.normal.uiBlue} : null,
        ]}>
          <Text style={[
            styles.timeText, 
            this.props.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText},
            this.props.live ? styles.timeTextLive : null,
          ]}>
            {this.props.date}
          </Text>
          {this.props.live ?
            <Text style={styles.liveText}>LIVE</Text>
          :null}
          <View style={[
            styles.timeSpot, 
            this.props.selectedTheme == 'night' ? {borderColor: themes.night.uiLine, backgroundColor: themes.night.uiBg} : {borderColor: themes.normal.uiLine, backgroundColor: themes.normal.uiBg},
            this.props.live && this.props.selectedTheme == 'night' ? {borderColor: themes.night.uiBlue, backgroundColor: themes.night.uiBlue} : null,
            this.props.live && this.props.selectedTheme != 'night' ? {borderColor: themes.normal.uiBlue, backgroundColor: themes.normal.uiBlue} : null,
          ]}></View>
        </View>
        <View style={[styles.cardInfo, this.props.live ? styles.cardInfoLive : null]}>
          <View style={[styles.image, this.props.live ? styles.imageLive : null]}>
            {this.props.image ? <Image source={{uri: this.props.image}} style={styles.imageCover} /> : <Image style={styles.imageCover} source={require('../../../assets/images/screen.jpg')} />}
          </View>
          <View style={[styles.content, this.props.live ? styles.contentLive : null]}>
            <Text style={[
              styles.contentTitle,
              this.props.selectedTheme == 'night' ? {color: themes.night.uiCardTitle} : {color: themes.normal.uiCardTitle},
            ]}>
             {this.props.title}
            </Text>
            <Text style={styles.contentText}>{this.props.category}</Text>
          </View>
        </View>
        {this.props.pastProgram ? null :
          <View style={[styles.control, this.props.live ? styles.controlLive : null]}>
            {this.props.live ? 
              null
              :
              <TouchableOpacity style={styles.controlBtn} onPress={()=> {
                  this.setState({activeTime: !this.activeTime});
                  this.props.bookMarkPress();
                }}>
                {this.props.bookMarkActiv ? 
                  <Image source={alertActiveIcon} style={styles.icon} /> :
                  <Image source={alertIcon} style={styles.icon} />
                }
              </TouchableOpacity>
              }
          </View>
        }
        
      </TouchableOpacity>
    );
  }
}

const styles = StyleSheet.create({
  programCard: {
    width: '100%',
    height: 64,
    flexDirection: 'row',
    marginLeft: 16,
    paddingRight: 16,
    borderBottomWidth: 1,
  },
  programCardLive: {
    height: cardHeight,
  },
  time: {
    width: 52,
    flexGrow: 0,
    flexShrink: 0,
    alignItems: 'center',
    justifyContent: 'center',
    marginRight: 10,
    paddingRight: 8,
    alignItems: 'flex-end',
    borderRightWidth: 3,
  },
  timeText: {
    fontFamily: 'Roboto-Regular',
    fontSize: 14,
    lineHeight: 16,
  },
  timeTextLive: {
    fontFamily: 'Roboto-Medium',
  },
  liveText: {
    color: Colors.colRed,
    fontFamily: 'Roboto-Medium',
    fontSize: 12,
    lineHeight: 16,
    letterSpacing: 1,
  },
  timeSpot: {
    position: 'absolute',
    width: 12,
    height: 12,
    borderRadius: 12,
    borderWidth: 3,
    right: -7.5,
  },
  cardInfo: {
    flexDirection: 'row',
    flexGrow: 1,
    flexShrink: 1,
  },
  cardInfoLive: {
    flexDirection: 'column',
  },
  image: {
    width: 48,
    height: 48,
    marginVertical: 8,
    flexGrow: 0,
    flexShrink: 0,
    borderRadius: 60,
    overflow: 'hidden',
  },
  imageLive: {
    width: imageWidth,
    height: imageHeight,
    borderRadius: 8,
    marginBottom: 0,
  },
  imageCover: {
    width: '100%',
    height: '100%',
    resizeMode: 'cover',
  },
  content: {
    height: '100%',
    flexGrow: 1,
    flexShrink: 1,
    justifyContent: 'center',
    paddingHorizontal: 12,
  },
  contentLive: {
    paddingLeft: 0,
  },
  contentTitle: {
    fontFamily: 'Roboto-Medium',
    fontSize: 16,
    lineHeight: 18,
  },
  contentText: {
    color: Colors.colGray,
    fontSize: 14,
    lineHeight: 16,
    fontFamily: 'Roboto-Regular',
  },
  control: {
    width: 48,
    height: 64,
  },
  controlLive: {
    position: 'absolute',
    bottom: 0,
    left: 52,
    height: 50,
  },
  controlBtn: {
    width: '100%',
    height: '100%',
    alignItems: 'center',
    justifyContent: 'center',
  },
  icon: {
    width: 20,
    height: 20,
    resizeMode: 'contain',
  },
  
});