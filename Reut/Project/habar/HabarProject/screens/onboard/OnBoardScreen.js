import React from 'react';
import {
  Image,
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
  Dimensions,
  StatusBar,
  SafeAreaView,
} from 'react-native';

import Carousel, { Pagination } from 'react-native-snap-carousel';

import { NavigationEvents } from 'react-navigation';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import Colors, { themes } from '../../constants/Colors.js';

import { Locale, getLang, getTheme } from '../../i18n/locale.js';
import { ScrollView } from 'react-native-gesture-handler';

const { width: viewportWidth, height: viewportHeight } = Dimensions.get('window');
function wp(percentage) {
  const value = (percentage * viewportWidth) / 100;
  return Math.round(value);
}
const slideWidth = wp(100);
const imageWidth = wp(65);
const imageHeight = imageWidth * 1.1;

const phoneHeight = viewportHeight;
const fontSize = phoneHeight < 613 ? 24 : 30;

export const sliderWidth = viewportWidth;
export const itemWidth = slideWidth - 32;

export default class OnBoardScreen extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      sliderActiveSlide: 0,
      
    };
  }
  state = {
    fontsLoaded: false,
    loading: true,
    selectedTheme:'night',
    lang: 'kz',
    Entries: []
  };
  static navigationOptions = {
    header: null,
  };

  componentDidMount() {
    Font.loadAsync({
      'Roboto-Medium': require('../../assets/fonts/Roboto-Medium.ttf'),
      'Roboto-Regular': require('../../assets/fonts/Roboto-Regular.ttf'),
    }).then(() => this.setState({ fontsLoaded: true }));
    getLang().then((res) => {
      this.setState({ lang: res });
    });
    this.changeTheme();
    this.props.navigation.addListener('willFocus', this.load);
    this.setState({ loading: true });
  }

  load = () => {
    getLang().then((res) => {
      this.setState({ lang: res });
      //RSS
    })
    this.changeTheme();
  }

  changeTheme(){
    getTheme().then((res)=>  {
      //console.log("theme", res);
      this.setState({selectedTheme: res});
    });
  }

  render() {
    const { navigate } = this.props.navigation;
    if (!this.state.fontsLoaded) {
      return <AppLoading />
    }
    return (
      <View style={[
        styles.container,
        this.state.selectedTheme == 'night' ? { backgroundColor: themes.night.uiBg } : { backgroundColor: themes.normal.uiBg },
      ]}>
        <StatusBar barStyle="dark-content" />

        <SafeAreaView style={styles.safeArea} forceInset={{ top: 'never' }}>
          <View style={styles.content}>
            <TouchableOpacity
              style={styles.close}
              onPress={() => navigate('AboutApp')}
            >
              <Image style={styles.closeIcon} source={require('../../assets/images/ui/cancel-2x.png')} />
            </TouchableOpacity>

            <View style={styles.sliderWrap}>
              <ScrollView
                disableIntervalMomentum={true}
                showsHorizontalScrollIndicator={false}
                scrollEventThrottle={1}
                decelerationRate={0}
                snapToInterval={viewportWidth}
                horizontal={true}
                pagingEnabled={true}
                ref={(ref) => this.myScroll = ref}>
                <View style={[styles.slide, { width: viewportWidth}]}>
                  <TouchableOpacity
                    style={[
                      styles.tabButton,
                      this.state.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiBlue } : { borderBottomColor: themes.normal.uiBlue },
                      this.state.selectedIndex == 0 ? styles.activeTab : null,
                      this.state.selectedIndex == 0 && this.state.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiTabLine } : null,
                      this.state.selectedIndex == 0 && this.state.selectedTheme == 'normal' ? { borderBottomColor: themes.normal.uiTabLine } : null,
                    ]}
                  >
                    <View style={styles.illustrationView}>
                      <Image style={styles.illustration} source={require('../../assets/images/onboard/slide1-2x.png')} />
                    </View>
                    <View style={styles.title}>
                      <Text
                        style={[
                          styles.titleText,
                          this.state.selectedTheme == 'night' ? { color: themes.night.uiCardTitle } : { color: themes.normal.uiCardTitle },
                        ]}>
                        {Locale(global.lang, "stay_informed")}
                      </Text>
                    </View>
                    <View style={styles.subtitle}>
                      <Text style={styles.subtitleText}>{Locale(global.lang, "stay_informed_subtitle")}</Text>
                    </View>
                  </TouchableOpacity>
                </View>


                <View style={[styles.slide, { width: viewportWidth}]}>
                  <TouchableOpacity
                    style={[
                      styles.tabButton,
                      this.state.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiBlue } : { borderBottomColor: themes.normal.uiBlue },
                      this.state.selectedIndex == 1 ? styles.activeTab : null,
                      this.state.selectedIndex == 1 && this.state.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiTabLine } : null,
                      this.state.selectedIndex == 1 && this.state.selectedTheme == 'normal' ? { borderBottomColor: themes.normal.uiTabLine } : null,
                    ]}
                  >
                    <View style={styles.illustrationView}>
                      <Image style={styles.illustration} source={require('../../assets/images/onboard/slide2-2x.png')} />
                    </View>
                    <View style={styles.title}>
                      <Text
                        style={[
                          styles.titleText,
                          this.state.selectedTheme == 'night' ? { color: themes.night.uiCardTitle } : { color: themes.normal.uiCardTitle },
                        ]}>
                        {Locale(global.lang, "offline_mode")}
                      </Text>
                    </View>
                    <View style={styles.subtitle}>
                      <Text style={styles.subtitleText}>{Locale(global.lang, "offline_mode_subtitle")}</Text>
                    </View>
                  </TouchableOpacity>
                </View>
                <View style={[styles.slide, { width: viewportWidth }]}>
                  <TouchableOpacity
                    style={[
                      styles.tabButton,
                      this.state.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiBlue } : { borderBottomColor: themes.normal.uiBlue },
                      this.state.selectedIndex == 2 ? styles.activeTab : null,
                      this.state.selectedIndex == 2 && this.state.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiTabLine } : null,
                      this.state.selectedIndex == 2 && this.state.selectedTheme == 'normal' ? { borderBottomColor: themes.normal.uiTabLine } : null,
                    ]}
                  >
                    <View style={styles.illustrationView}>
                      <Image style={styles.illustration} source={require('../../assets/images/onboard/slide3-2x.png')} />
                    </View>
                    <View style={styles.title}>
                      <Text
                        style={[
                          styles.titleText,
                          this.state.selectedTheme == 'night' ? { color: themes.night.uiCardTitle } : { color: themes.normal.uiCardTitle },
                        ]}>
                        {Locale(global.lang, "selected_articles_subtitle")}
                      </Text>
                    </View>
                    <View style={styles.subtitle}>
                      <Text style={styles.subtitleText}>{Locale(global.lang, "selected_articles_subtitle")}</Text>
                    </View>
                  </TouchableOpacity>
                </View>
                <View style={[styles.slide, { width: viewportWidth }]}>
                  <TouchableOpacity
                    style={[
                      styles.tabButton,
                      this.state.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiBlue } : { borderBottomColor: themes.normal.uiBlue },
                      this.state.selectedIndex == 3 ? styles.activeTab : null,
                      this.state.selectedIndex == 3 && this.state.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiTabLine } : null,
                      this.state.selectedIndex == 3 && this.state.selectedTheme == 'normal' ? { borderBottomColor: themes.normal.uiTabLine } : null,
                    ]}
                  >
                    <View style={styles.illustrationView}>
                      <Image style={styles.illustration} source={require('../../assets/images/onboard/slide4-2x.png')} />
                    </View>
                    <View style={styles.title}>
                      <Text
                        style={[
                          styles.titleText,
                          this.state.selectedTheme == 'night' ? { color: themes.night.uiCardTitle } : { color: themes.normal.uiCardTitle },
                        ]}>
                        {Locale(global.lang, "reminding")}
                      </Text>
                    </View>
                    <View style={styles.subtitle}>
                      <Text style={styles.subtitleText}>{Locale(global.lang, "reminding_subtitle")}</Text>
                    </View>
                  </TouchableOpacity>
                </View>
                <View style={[styles.slide, { width: viewportWidth }]}>
                  <TouchableOpacity
                    style={[
                      styles.tabButton,
                      this.state.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiBlue } : { borderBottomColor: themes.normal.uiBlue },
                      this.state.selectedIndex == 4 ? styles.activeTab : null,
                      this.state.selectedIndex == 4 && this.state.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiTabLine } : null,
                      this.state.selectedIndex == 4 && this.state.selectedTheme == 'normal' ? { borderBottomColor: themes.normal.uiTabLine } : null,
                    ]}
                  >
                    <View style={styles.illustrationView}>
                      <Image style={styles.illustration} source={require('../../assets/images/onboard/slide5-2x.png')} />
                    </View>
                    <View style={styles.title}>
                      <Text
                        style={[
                          styles.titleText,
                          this.state.selectedTheme == 'night' ? { color: themes.night.uiCardTitle } : { color: themes.normal.uiCardTitle },
                        ]}>
                        {Locale(global.lang, "night_mode")}
                      </Text>
                    </View>
                    <View style={styles.subtitle}>
                      <Text style={styles.subtitleText}>{Locale(global.lang, "night_mode_subtitle")}</Text>
                    </View>
                  </TouchableOpacity>
                </View>
              </ScrollView>
            </View>
          </View>
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
    justifyContent: 'space-between',
    alignItems: 'flex-end',
  },
  close: {
    width: 36,
    height: 36,
    marginTop: 16,
    marginRight: 16,
  },
  closeIcon: {
    height: '100%',
    width: '100%',
    resizeMode: 'contain',
  },
  nextButton: {
    height: 54,
    flexGrow: 0,
    flexShrink: 0,
    marginHorizontal: 16,
    marginBottom: 16,
  },

  /* Slider */
  sliderWrap: {
    flexGrow: 1,
    flexShrink: 1,
  },
  slider: {
    flexGrow: 1,
    flexShrink: 1,
  },
  sliderContentContainer: {
  },
  slide: {
    width:viewportWidth,
    height:viewportHeight -76 ,
    justifyContent: 'center',
    alignItems: 'center',
  },
  illustrationView: {
    alignItems:'center',
    paddingBottom: 20,
  },
  illustration: {
    width: 200,
    height: 200,
    resizeMode: 'contain',
  },
  title: {
    paddingVertical: 16,
    marginHorizontal: 16,
  },
  titleText: {
    fontSize: fontSize,
    lineHeight: 36,
    fontFamily: 'Roboto-Medium',
    textAlign: 'center',
  },
  subtitle: {
    textAlign: 'center',
    marginHorizontal: 16,
  },
  subtitleText: {
    color: Colors.colLightGray,
    fontSize: 18,
    lineHeight: 24,
    textAlign: 'center',
    fontFamily: 'Roboto-Regular',
  },

});
