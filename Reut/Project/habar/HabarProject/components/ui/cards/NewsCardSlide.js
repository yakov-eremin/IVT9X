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

import timeIcon from '../../../assets/images/cards/clock.png';
import lookIcon from '../../../assets/images/cards/eye.png';
import videoIcon from '../../../assets/images/cards/youtube.png';
import markIcon from '../../../assets/images/ui/bookmark-blue.png';
import markOutlineIcon from '../../../assets/images/ui/bookmark-outline.png';
import { parseTags, parseVideoTag } from '../../../services/Feed.js';

import Colors, {themes} from '../../../constants/Colors.js';

export default class UiNewsCardSlide extends React.Component {

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
          styles.newsCard,
          this.props.selectedTheme == 'night' ? {
            backgroundColor: themes.night.uiCardBg,
            borderColor: themes.night.uiLine,
          } : {
            backgroundColor: themes.normal.uiCardBg,
            borderColor: themes.normal.uiLine,
          }
        ]} 
        onPress={this.props.cardPress}
      >

        <View style={styles.cardImage}>
          {this.props.image ? <Image source={{uri: this.props.image}} style={styles.image} /> : <Image source={require('../../../assets/images/photo1.jpg')} style={styles.image} />}
        </View>

        <View style={styles.cardContent}>
          <Text 
            style={[
              styles.title,
              this.props.selectedTheme == 'night' ? {color: themes.night.uiCardTitle} : {color: themes.normal.uiCardTitle},
            ]} 
            numberOfLines={3} 
            ellipsizeMode="tail"
          >
            {this.props.title} | {this.props.category}
          </Text>
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
        { this.props.bookMarkPress ? 
          <TouchableOpacity style={styles.bookmark} onPress={()=> {
            this.props.bookMarkPress();   
            this.setState({markActive:!this.state.markActive});
          }}>
            {this.state.markActive ? 
              <Image style={styles.icon} source={markIcon} /> : 
              <Image style={styles.icon} source={markOutlineIcon} />
            }
          </TouchableOpacity>
          
          : null}      
        
      </TouchableOpacity>
    );
  }
}

const styles = StyleSheet.create({
  newsCard: {
    flexDirection: 'row',
    marginHorizontal: 16,
    marginBottom: 0,
    borderWidth: 1,
    borderRadius: 2,
  },
  cardImage: {
    width: 120,
    height: 80,
    flexGrow: 0,
    flexShrink: 0,
  },
  image: {
    width: '100%',
    height: '100%',
    resizeMode: 'cover',
  },
  cardContent: {
    flexGrow: 1,
    flexShrink: 1,
    paddingHorizontal: 8,
    paddingVertical: 4,
    justifyContent: 'space-between',
  },
  title: {
    fontFamily: 'Roboto-Medium',
    fontSize: 14,
    lineHeight: 15,
    marginTop: 4,
  },
  status: {
    flexDirection: 'row',
    marginBottom: 2,
  },
  statusInner: {
    flexDirection: 'row',
    marginRight: 10,
    alignItems: 'center',
  },
  statusIcon: {
    width: 10,
    height: 10,
    resizeMode: 'contain',
    marginRight: 2,
  },
  statusIconBig: {
    width: 14,
  },
  statusInnerText: {
    color: Colors.colLightGray,
    fontFamily: 'Roboto-Regular',
    fontSize: 10,
    lineHeight: 12,
    letterSpacing: 1.25,
  },
  bookmark: {
    width: 28,
    height: 42,
    flexGrow: 0,
    flexShrink: 0,
    alignItems: 'flex-start',
    justifyContent: 'center',
  },
  icon: {
    width: 18,
    height: 18,
    resizeMode: 'contain',
  },
});