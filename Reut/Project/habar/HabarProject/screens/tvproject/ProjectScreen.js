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
  Alert,
  WebView,
  Linking,
  Share
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import Carousel from 'react-native-snap-carousel';

import timeIcon from '../../assets/images/cards/clock.png';
import lookIcon from '../../assets/images/cards/eye.png';
import videoIcon from '../../assets/images/ui/youtube.png';
import markIcon from '../../assets/images/ui/bookmark-blue.png';
import markOutlineIcon from '../../assets/images/ui/bookmark-outline.png';
import linkIcon from '../../assets/images/ui/link-2x.png';
import likeIcon from '../../assets/images/ui/like-blue-2x.png';
import likeOutlineIcon from '../../assets/images/ui/like-outline-2x.png';

import Loader from '../../components/ui/Loader.js';
import UiHeader from '../../components/ui/header/Header.js';
import { formatDateTimeString } from '../../components/common/Date.js';

import Colors, { themes } from '../../constants/Colors.js';
import { Locale, getLang, getTheme } from '../../i18n/locale.js';
import { parseTags, parseVideoTag } from '../../services/Feed.js';
import { setNews, setLastRun } from '../../services/Storage.js';

const { width: viewportWidth } = Dimensions.get('window');
function wp(percentage) {
  const value = (percentage * viewportWidth) / 100;
  return Math.round(value);
}
const imageWidth = wp(100) - 32;
const imageHeight = imageWidth * 0.56;

const topItemWidth = wp(100) - 32;
const topItemHeight = topItemWidth * 0.56;
const sliderWidth = viewportWidth - 32;

export default class NewsScreen extends React.Component {

  state = {
    fontsLoaded: false,
    loginProgress: false,
    markActive: false,
    likeActive: false,
    lang: "kz",

    topSlider: [
      {
        topIllustration: parseTags(this.props.navigation.state.params.info.description).images,
        description: (this.props.navigation.state.params.info.description),
      }
    ]
  }

  static navigationOptions = {
    header: null,
  };


  componentDidMount = async () => {
    await Font.loadAsync({
      'Roboto-Regular': require('../../assets/fonts/Roboto-Regular.ttf'),
      'Roboto-Medium': require('../../assets/fonts/Roboto-Medium.ttf'),
    }).then(() => this.setState({ fontsLoaded: true }));

    getLang().then((res) => this.setState({ lang: res }));
    this.changeTheme();
    setLastRun(this.props.navigation.state.params.info);
    this.props.navigation.addListener('willFocus', this.load);
    this.setState({
      showVideo: false, topSlider: [
        {
          topIllustration: parseTags(this.props.navigation.state.params.info.description).images,
          description: (this.props.navigation.state.params.info.description),
        }
      ]
    });

    //this.getRSS();
  }

  load = () => {
    setLastRun(this.props.navigation.state.params.info);
    getLang().then((res) => this.setState({ lang: res }));
    this.changeTheme();
    this.setState({
      showVideo: false, 
      topSlider: [
        {
          topIllustration: parseTags(this.props.navigation.state.params.info.description).images,
          description: (this.props.navigation.state.params.info.description),
        }
      ]
    });
  }

  changeTheme() {
    getTheme().then((res) => {
      //console.log("theme", res);
      this.setState({ selectedTheme: res });
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

  carouselContent({ item, index }) {
    return (
      <TouchableOpacity
        style={[
          styles.topSlide,
          this.state.selectedTheme == 'night' ? { borderColor: themes.night.uiLine } : { borderColor: themes.normal.uiLine },
          item.length == 1 ? { marginRight: 0 } : { marginRight: 0 }
        ]}
        onPress={() => {
          if (parseVideoTag(item.description) != null) {
            this.setState({ youtube: parseVideoTag(item.description) });
            this.setState({ showVideo: true })
          }
        }}
      >
        <Image style={[styles.topSlideillustration, this.state.selectedTheme == 'night' ? { borderColor: themes.night.uiLine } : { borderColor: themes.normal.uiLine }]} source={{ uri: item.topIllustration }} />
        {parseVideoTag(item.description) != null
          ?
          <Image style={styles.topSlideillustrationIcon} source={videoIcon} />
          : null
        }
      </TouchableOpacity>
    );
  }

  render() {
    const { navigate } = this.props.navigation;
    if (!this.state.fontsLoaded) {
      return <AppLoading />
    }

    return (
      <View style={[
        styles.container,
        this.state.selectedTheme == 'night' ? { backgroundColor: themes.night.uiBg } : { backgroundColor: themes.normal.uiBg }
      ]}>
        <UiHeader
          btnLeft='back'
          pressLeft={() => navigate('TVProjects')}
          selectedTheme={this.state.selectedTheme}
          pressRight={() => navigate('Live')}
        />
        <SafeAreaView style={styles.safeArea} forceInset={{ top: 'never' }}>

          <ScrollView style={styles.content}>
            <View style={styles.cardImage}>

              {this.state.showVideo ?
                <WebView
                  useWebKit={true}
                  style={{ width: topItemWidth, height: topItemHeight }}
                  javaScriptEnabled={true}
                  domStorageEnabled={true}
                  source={{ uri: this.state.youtube }}
                />
                :
                <Carousel
                  data={this.state.topSlider}
                  ref={(c) => { this._carousel = c; }}
                  renderItem={this.carouselContent.bind(this)}
                  sliderWidth={sliderWidth}
                  itemWidth={topItemWidth}
                  itemHeight={topItemHeight}
                  activeSlideAlignment="start"
                  inactiveSlideScale={1}
                  inactiveSlideOpacity={1}
                  useScrollView={true}
                  onSnapToItem={(index) => this.setState({ sliderActiveSlide: index })}
                />

              }
            </View>
            <View style={styles.cardContent}>
              <View style={styles.cardTitle}>
                <Text style={[
                  styles.title,
                  this.state.selectedTheme == 'night' ? { color: themes.night.uiCardTitle } : { color: themes.normal.uiCardTitle }
                ]}>
                  {this.props.navigation.state.params.info.title}
                </Text>
              </View>

              <View style={[
                styles.status,
                this.state.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiLine } : { borderBottomColor: themes.normal.uiLine }
              ]}>
                <View style={styles.statusInner}>
                  <Image style={styles.statusIcon} source={timeIcon} />
                  <Text style={styles.statusInnerText}>{formatDateTimeString(this.props.navigation.state.params.info.published)}</Text>
                </View>

              </View>
              <View style={styles.buttonsBar}>
                <TouchableOpacity style={styles.bookmark} onPress={() => this.onShare(this.props.navigation.state.params.info.id)}>
                  <Image style={styles.icon} source={linkIcon} />
                </TouchableOpacity>

                <TouchableOpacity style={styles.bookmark} onPress={() => {
                  setNews(this.props.navigation.state.params.info);
                  this.setState({ markActive: !this.state.markActive });
                }}>
                  {this.state.markActive ?
                    <Image style={styles.icon} source={markIcon} /> :
                    <Image style={styles.icon} source={markOutlineIcon} />
                  }
                </TouchableOpacity>
              </View>
              <View style={styles.newsText}>
                <Text style={[
                  styles.text,
                  this.state.selectedTheme == 'night' ? { color: themes.night.uiText } : { color: themes.normal.uiText }
                ]}>
                  {parseTags(this.props.navigation.state.params.info.description).text}
                </Text>



              </View>
            </View>
          </ScrollView>
        </SafeAreaView>
        <Loader selectedTheme={this.state.selectedTheme} show={this.state.loginProgress} />
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
    padding: 16,
  },
  cardImage: {
    width: '100%',
    height: imageHeight,
    alignItems: 'center',
  },
  topSlide: {
    width: '100%',
    height: '100%',
  },
  topSlideillustration: {
    height: '100%',
    width: '100%',
    borderWidth: 1,
    borderRadius: 3,
    overflow: 'hidden',
    resizeMode: 'cover',
  },
  topSlideillustrationIcon: {
    position: 'absolute',
    top: '50%',
    left: '50%',
    marginTop: -32,
    marginLeft: -32,
    width: 64,
    height: 64,
    resizeMode: 'contain',
  },
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
  newsText: {
    marginVertical: 8,
  },
  text: {
    marginVertical: 4,
    fontFamily: 'Roboto-Regular',
    fontSize: 14,
    lineHeight: 16,
    textAlign: 'justify',
  },

});
