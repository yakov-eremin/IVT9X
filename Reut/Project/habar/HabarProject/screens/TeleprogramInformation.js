import * as WebBrowser from 'expo-web-browser';
import React from 'react';
import {
  StyleSheet,
  Dimensions,
  View,
  Image, 
  Text, 
  TouchableOpacity, 
  SafeAreaView,
  ScrollView,
  Alert
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import timeIcon from '../../assets/images/cards/clock.png';
import lookIcon from '../../assets/images/cards/eye.png';
import videoIcon from '../../assets/images/cards/youtube.png';
import markIcon from '../../assets/images/ui/bookmark-blue.png';
import markOutlineIcon from '../../assets/images/ui/bookmark-outline.png';
import linkIcon from '../../assets/images/ui/link-2x.png';
import likeIcon from '../../assets/images/ui/like-blue-2x.png';
import likeOutlineIcon from '../../assets/images/ui/like-outline-2x.png';

import Loader from '../../components/ui/Loader.js';
import UiHeader from '../../components/ui/header/Header.js';

import Carousel from 'react-native-snap-carousel';

import Colors from '../../constants/Colors.js';

import {Locale, getLang} from '../i18n/locale.js';


const { width: viewportWidth } = Dimensions.get('window');
function wp (percentage) {
  const value = (percentage * viewportWidth) / 100;
  return Math.round(value);
}
const imageWidth = wp(100) - 34;
const imageHeight = imageWidth*0.56;

const topItemWidth = wp(90);
const topItemHeight = topItemWidth*0.5;
const sliderWidth = viewportWidth;

export default class NewsScreen extends React.Component  {

  state = {
    fontsLoaded: false,
    loginProgress: false,
    markActive: false,
    likeActive: false,
    lang: "kz",
  }

  static navigationOptions = {
    header: null,
  };

  topSlider = [
    {
      topIllustration: require('../../assets/images/photo.jpg'),
    },
    {
      topIllustration: require('../../assets/images/photo.jpg'),
    },
    {
      topIllustration: require('../../assets/images/photo.jpg'),
    },
    {
      topIllustration: require('../../assets/images/photo.jpg'),
    }
  ];

  componentDidMount = async() => { 
    await Font.loadAsync({
      'Roboto-Regular': require('../../assets/fonts/Roboto-Regular.ttf'),
      'Roboto-Medium': require('../../assets/fonts/Roboto-Medium.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
  
    getLang().then((res)=>  this.setState({lang: res}) );
    this.props.navigation.addListener('willFocus', this.load);
  
  //this.getRSS();
  }
  
  load = () => { 
    getLang().then((res)=>  this.setState({lang: res}) );
  
    //RSS
    
  }

  carouselContent ({item, index}) {
    return (
      <TouchableOpacity style={styles.topSlide}>
        <Image style={styles.topSlideillustration} source={ item.topIllustration } />
      </TouchableOpacity>
    );
  }

  render() {
    const {navigate} = this.props.navigation;
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }

    return (
      <View style={styles.container}>
        <Loader show={this.state.loginProgress} />
        <UiHeader
          btnLeft='back'
          pressLeft={()=> navigate('TVProgram')}
          pressSave={()=> Alert.alert('Save')}
          pressRight={()=> navigate('Live')}
        />
        <SafeAreaView style={styles.safeArea} forceInset={{top:'never'}}>

          <ScrollView style={styles.content}>
            <View style={styles.cardImage}>
              <Carousel
                data={this.topSlider}
                ref={(c) => { this._carousel = c; }}
                renderItem={this.carouselContent}
                sliderWidth={sliderWidth}
                itemWidth={topItemWidth}
                itemHeight={topItemHeight}
                activeSlideAlignment="start"
                inactiveSlideScale={1}
                inactiveSlideOpacity={1}
                useScrollView={true}
                onSnapToItem={(index) => this.setState({ sliderActiveSlide: index })}
              />
            </View>
            <View style={styles.cardContent}>
              <View style={styles.cardTitle}>
                <Text style={styles.title}>{Locale(this.state.lang, "title")}</Text>
              </View>
{/*           <View style={styles.tags}>
                <Text style={styles.tagsText}>#промышленность</Text>
                <Text style={styles.tagsText}>#хабар24</Text>
                <Text style={styles.tagsText}>#новости</Text>
                <Text style={styles.tagsText}>#экономика</Text>
              </View> */}
              <View style={styles.status}>
                <View style={styles.statusInner}>
                  <Image style={styles.statusIcon} source={timeIcon} />
                  <Text style={styles.statusInnerText}>10 {Locale(this.state.lang, "hours_late")}</Text>
                </View>
{/*             <View style={styles.statusInner}>
                  <Image style={[styles.statusIcon, styles.statusIconBig]} source={lookIcon} />
                  <Text style={styles.statusInnerText}>108</Text>
                </View>
                <View style={styles.statusInner}>
                  <Image style={[styles.statusIcon, styles.statusIconBig]} source={videoIcon} />
                </View>*/}
              </View>
{/*             <View style={styles.buttonsBar}>
                 <TouchableOpacity style={styles.bookmark}>
                  <Image style={styles.icon} source={linkIcon} />
                </TouchableOpacity>
             <TouchableOpacity style={styles.bookmark} onPress={()=> this.setState({likeActive:!this.state.likeActive})}>
                  {this.state.likeActive ? 
                    <Image style={styles.icon} source={likeIcon} /> : 
                    <Image style={styles.icon} source={likeOutlineIcon} />
                  }
                </TouchableOpacity>
                <TouchableOpacity style={styles.bookmark} onPress={()=> this.setState({markActive:!this.state.markActive})}>
                  {this.state.markActive ? 
                    <Image style={styles.icon} source={markIcon} /> : 
                    <Image style={styles.icon} source={markOutlineIcon} />
                  }
                </TouchableOpacity>
              </View>*/}
              <View style={styles.newsText}>
                <Text style={styles.text}>{Locale(this.state.lang, "comment") + "."}</Text>
              </View>
            </View>
          </ScrollView>
        </SafeAreaView>
      </View>
    );
  }
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
  safeArea: {
    flex: 1,
    backgroundColor: '#fff',
  },
  content: {
    flex: 1,
    backgroundColor: '#fff',
    padding: 16,
  },
  cardImage: {
    width: '100%',
    height: imageHeight,
  },
  topSlide: {
    marginRight: 16,
    borderWidth: 1,
    borderColor: Colors.uiLine,
    borderRadius: 3,
    overflow: 'hidden',
  },
  topSlideillustration: {
    height: '100%',
    width: '100%',
    resizeMode: 'cover',
  },
/*tags: {
    flexDirection: 'row',
    flexWrap: 'wrap',
    marginBottom: 4,
  },
  tagsText: {
    fontFamily: 'Roboto-Medium',
    color: Colors.uiBlue,
    marginRight: 6,
    borderRadius: 3,
  },*/
  cardContent: {
    paddingVertical: 8,
  },
  cardTitle: {
    marginVertical: 4,
    flexDirection: 'row',
  },
  title: {
    fontFamily: 'Roboto-Medium',
    fontSize: 18,
    lineHeight: 20,
    color: Colors.uiBlue,
    flexGrow: 1,
    flexShrink: 1,
  },
  buttonsBar: {
    flexDirection: 'row',
    justifyContent: 'flex-start',
    alignItems: 'center',
  },
  bookmark: {
    width: 42,
    height: 32,
    paddingTop: 4,
    flexGrow: 0,
    flexShrink: 0,
    alignItems: 'center',
    justifyContent: 'center',
  },
  icon: {
    width: 24,
    height: 24,
    resizeMode: 'contain',
  },
  status: {
    flexDirection: 'row',
    marginVertical: 8,
    paddingBottom: 8,
    borderBottomWidth: 1,
    borderBottomColor: Colors.uiLine,
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
    color: Colors.uiLightGray,
    fontFamily: 'Roboto-Regular',
    fontSize: 12,
    lineHeight: 16,
    letterSpacing: 1.25,
  },
  newsText: {
    marginVertical: 8,
  },
  text: {
    marginVertical: 4,
    fontFamily: 'Roboto-Regular',
    fontSize: 14,
    lineHeight: 16,
    color: Colors.uiDark,
  },

});
