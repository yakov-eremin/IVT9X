import React from 'react';
import { 
  StyleSheet, 
  Dimensions, 
  View, 
  Image, 
  Text, 
  TouchableOpacity 
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';
import { LinearGradient } from 'expo-linear-gradient';

import timeIcon from '../../../assets/images/cards/clock.png';
import lookIcon from '../../../assets/images/cards/eye.png';
import videoIcon from '../../../assets/images/cards/youtube.png';
import markIcon from '../../../assets/images/ui/bookmark-blue.png';
import markOutlineIcon from '../../../assets/images/ui/bookmark-outline.png';

import Colors, {themes} from '../../../constants/Colors.js';

const { width: viewportWidth } = Dimensions.get('window');
function wp (percentage) {
  const value = (percentage * viewportWidth) / 100;
  return Math.round(value);
}
const imageWidth = wp(100) - 34;
const imageHeight = imageWidth*0.56;

export default class UiTopNewsCard extends React.Component {

  state = { 
    fontsLoaded: false, 
    markActive: false,
  }

  constructor(props){
    super(props);
  }

  componentDidMount() {
    Font.loadAsync({
      'Roboto-Medium': require('../../../assets/fonts/Roboto-Medium.ttf'),
      'Roboto-Regular': require('../../../assets/fonts/Roboto-Regular.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
  }

  render() {
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }

    return (
      <TouchableOpacity 
        style={[
          styles.topNewsCard,
          this.props.selectedTheme == 'night' ? {
            backgroundColor: themes.night.uiCardBg, 
            borderColor: themes.night.uiLine
          } : {
            backgroundColor: themes.normal.uiCardBg, 
            borderColor: themes.normal.uiLine
          } 
        ]} 
        onPress={this.props.cardPress}
      >
        <View style={styles.cardImage}>
          {this.props.image ? <Image source={{uri: this.props.image}} style={styles.image} /> : <Image source={require('../../../assets/images/photo.jpg')} style={styles.image} />}
          
          <View style={styles.gradient}>
            <LinearGradient
              colors={['rgba(0,0,0,0)', 'rgba(0,0,0,0)',  'rgba(0,0,0,0.8)']}
              style={{ width: '100%', height: '100%' }}>
            </LinearGradient>
          </View>
        </View>
        <View style={styles.cardContent}>
          <View style={styles.cardTitle}>
            <Text style={[styles.title, this.props.selectedTheme == 'night' ? {color: themes.night.uiCardTitle} : {color: themes.normal.uiCardTitle}]}>{this.props.title} | {this.props.category}</Text>
            <TouchableOpacity style={styles.bookmark} onPress={()=> {
                this.props.bookMarkPress(); 
                this.setState({markActive:!this.state.markActive});
              }}>

              {this.props.markActive ? 
                <Image style={styles.icon} source={markIcon} /> : 
                <Image style={styles.icon} source={markOutlineIcon} />
              }
            </TouchableOpacity>
          </View>
          <View style={styles.status}>
            <View style={styles.statusInner}>
              <Image style={styles.statusIcon} source={timeIcon} />
              <Text style={styles.statusInnerText}>{this.props.date}</Text>
            </View>
            {this.props.video != null ?
              <View style={styles.statusInner}>
                <Image style={[styles.statusIcon, styles.statusIconBig]} source={videoIcon} />
              </View>
            : null}
          </View>
        </View>
      </TouchableOpacity>
    );
  }
}

const styles = StyleSheet.create({
  topNewsCard: {
    marginHorizontal: 16,
    marginBottom: 16,
    borderWidth: 1,
    borderRadius: 2,
  },
  cardImage: {
    width: '100%',
    height: imageHeight,
  },
  image: {
    height: '100%',
    width: '100%',
    resizeMode: 'cover',
  },
  gradient: {
    position: 'absolute',
    top: 0,
    left: 0,
    width: '100%',
    height: '100%',
  },
  cardContent: {
    paddingLeft: 16,
    paddingRight: 10,
    paddingVertical: 8,
  },
  cardTitle: {
    marginVertical: 4,
    flexDirection: 'row',
  },
  title: {
    fontFamily: 'Roboto-Medium',
    fontSize: 16,
    lineHeight: 18,
    flexGrow: 1,
    flexShrink: 1,
  },
  bookmark: {
    width: 28,
    height: 42,
    paddingTop: 4,
    flexGrow: 0,
    flexShrink: 0,
    alignItems: 'flex-end',
    justifyContent: 'flex-start',
  },
  icon: {
    width: 18,
    height: 18,
    resizeMode: 'contain',
  },
  status: {
    flexDirection: 'row',
    marginBottom: 8,
  },
  statusInner: {
    flexDirection: 'row',
    marginRight: 16,
    alignItems: 'center',
  },
  statusIcon: {
    width: 12,
    height: 12,
    resizeMode: 'contain',
    marginRight: 5,
  },
  statusIconBig: {
    width: 16,
  },
  statusInnerText: {
    color: Colors.colLightGray,
    fontFamily: 'Roboto-Regular',
    fontSize: 12,
    lineHeight: 16,
    letterSpacing: 1.25,
  },

});