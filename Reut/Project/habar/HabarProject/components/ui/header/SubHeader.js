import React from 'react';
import {
  Dimensions,
  ScrollView,
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import Colors, { themes } from '../../../constants/Colors.js';

import Carousel from 'react-native-snap-carousel';
import { Locale, getLang } from '../../../i18n/locale.js';

const { width: viewportWidth } = Dimensions.get('window');
function wp (percentage) {
    const value = (percentage * viewportWidth) / 100;
    return Math.round(value);
  }
const itemWidth = wp(100)/3;
const sliderWidth = viewportWidth;

export default class UiSubHeader extends React.Component {

  state = {
    fontsLoaded: false,
    activeTab: 0,
    lang: "ru",
  };

  constructor(props) {
    super(props);
  }

  componentDidMount = async () => {
    await Font.loadAsync({
      'Roboto-Regular': require('../../../assets/fonts/Roboto-Regular.ttf'),
      'Roboto-Medium': require('../../../assets/fonts/Roboto-Medium.ttf'),
    }).then(() => this.setState({ fontsLoaded: true }));

    let _x = (this.props.selectedIndex)*(sliderWidth/3) - (sliderWidth/3) ;
    setTimeout(()=> this.myScroll.scrollTo({ y: 0, x:  _x, animated: true }) , 50);
  }

 
  setValue = (value) => {
    this.setState({ activeTab: value });
    this.props.callBack(value);
  }

 
 
 
  render() {
    if (!this.state.fontsLoaded) {
      return <AppLoading />
    }
    return (
      <View style={[
        styles.subHeader,
        this.props.selectedTheme == 'night' ? { backgroundColor: themes.night.uiBlue } : { backgroundColor: themes.normal.uiBlue }
      ]}>
        <ScrollView
          disableIntervalMomentum={true}
          showsHorizontalScrollIndicator={false}
          scrollEventThrottle={1}
          decelerationRate={0}
          snapToInterval={this.props.itemWidth}
          horizontal={true}
          ref={(ref) => this.myScroll = ref}
        >
          <View style={[styles.tabSlide, { width: this.props.itemWidth }]}>
            <TouchableOpacity
              style={[
                styles.tabButton,
                this.props.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiBlue } : { borderBottomColor: themes.normal.uiBlue },
                this.props.selectedIndex == 0 && this.props.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiTabLine } : null,
                this.props.selectedIndex == 0 && this.props.selectedTheme == 'normal' ? { borderBottomColor: themes.normal.uiTabLine } : null,
              ]}
              onPress={() => this.setValue(0)}>
              <Text style={[styles.tabButtonText, this.props.selectedIndex == 0 ? styles.activeTabText : null]}>{Locale(global.lang, "latest_news")}</Text>
            </TouchableOpacity>
            <TouchableOpacity
              style={[
                styles.tabButton,
                this.props.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiBlue } : { borderBottomColor: themes.normal.uiBlue },
                this.props.selectedIndex == 1 && this.props.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiTabLine } : null,
                this.props.selectedIndex == 1 && this.props.selectedTheme == 'normal' ? { borderBottomColor: themes.normal.uiTabLine } : null,
              ]}
              onPress={() => this.setValue(1)}
            >
              <Text style={[styles.tabButtonText, this.props.selectedIndex == 1 ? styles.activeTabText : null]}>{Locale(global.lang, "my_news")}</Text>
            </TouchableOpacity>
            <TouchableOpacity
              style={[
                styles.tabButton,
                this.props.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiBlue } : { borderBottomColor: themes.normal.uiBlue },
                this.props.selectedIndex == 2 && this.props.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiTabLine } : null,
                this.props.selectedIndex == 2 && this.props.selectedTheme == 'normal' ? { borderBottomColor: themes.normal.uiTabLine } : null,
              ]}
              onPress={() => this.setValue(2)}
            >
              <Text style={[styles.tabButtonText, this.props.selectedIndex == 2 ? styles.activeTabText : null]}>{Locale(global.lang, "popular")}</Text>
            </TouchableOpacity>
          </View>

          <View style={[styles.tabSlide, { width: this.props.itemWidth }]}>
            <TouchableOpacity
              style={[
                styles.tabButton,
                this.props.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiBlue } : { borderBottomColor: themes.normal.uiBlue },
                this.props.selectedIndex == 3 && this.props.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiTabLine } : null,
                this.props.selectedIndex == 3 && this.props.selectedTheme == 'normal' ? { borderBottomColor: themes.normal.uiTabLine } : null,
              ]}
              onPress={() => this.setValue(3)}
            >
              <Text style={[styles.tabButtonText, this.props.selectedIndex == 3 ? styles.activeTabText : null]}>{Locale(global.lang, "headings")}</Text>
            </TouchableOpacity>

            <TouchableOpacity
              style={[
                styles.tabButton,
                this.props.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiBlue } : { borderBottomColor: themes.normal.uiBlue },
                this.props.selectedIndex == 4 ? styles.activeTab : null,
                this.props.selectedIndex == 4 && this.props.selectedTheme == 'night' ? { borderBottomColor: themes.night.uiTabLine } : null,
                this.props.selectedIndex == 4 && this.props.selectedTheme == 'normal' ? { borderBottomColor: themes.normal.uiTabLine } : null,
              ]}
              onPress={() => this.setValue(4)}
            >
              <Text style={[styles.tabButtonText, this.props.selectedIndex == 4 ? styles.activeTabText : null]}>{Locale(global.lang, "tv_projects")}</Text>
            </TouchableOpacity>
          </View>
        </ScrollView>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  subHeader: {
    width: '100%',
    height: 36,
    shadowColor: '#000',
    shadowOffset: {
      width: 0,
      height: 2,
    },
    shadowOpacity: 0.15,
    shadowRadius: 2,
  },
  tabsWrap: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center'
  },
  tabs: {
    flex: 1,
    flexDirection: 'row',
  },
  tabSlide: {
    flexDirection: 'row',
  },
  tabButton: {
    flex: 1,
    height: 36,
    alignItems: 'center',
    justifyContent: 'center',
    borderBottomWidth: 2,
  },
  activeTab: {
  },
  tab50: {
    width: '50%',
  },
  tab30: {
    width: '33%',
  },
  tabButtonText: {
    color: Colors.colWhite,
    fontFamily: 'Roboto-Regular',
    fontSize: 10,
    lineHeight: 14,
    paddingHorizontal: 5,
    textAlign: 'center',
    textTransform: 'uppercase',
    opacity: 0.8,
  },
  activeTabText: {
    fontFamily: 'Roboto-Medium',
    opacity: 1,
  },

});