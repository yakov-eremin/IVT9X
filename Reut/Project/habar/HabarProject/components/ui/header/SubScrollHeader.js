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

import Colors, {themes} from '../../../constants/Colors.js';

import Carousel from 'react-native-snap-carousel';
import {Locale, getLang} from '../../../i18n/locale.js';

const { width: viewportWidth } = Dimensions.get('window');
function wp (percentage) {
    const value = (percentage * viewportWidth) / 100;
    return Math.round(value);
  }
const itemWidth = wp(100)/3;
const sliderWidth = viewportWidth;

export default class UiSubScrollHeader extends React.Component {

  state = { 
    fontsLoaded: false,
    activeTab: 0, 
    lang: "ru",
  };

  constructor(props){
    super(props);
  }

  componentDidMount = async() => { 
    await Font.loadAsync({
      'Roboto-Regular': require('../../../assets/fonts/Roboto-Regular.ttf'),
      'Roboto-Medium': require('../../../assets/fonts/Roboto-Medium.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );

    let dd = new Date();
    this.setState({activeTab: dd.getDay() });
 
  }
  
  componentDidUpdate(nProps, nState){
     if(nState.activeTab != this.state.activeTab){
      setTimeout(()=> this.myScroll.scrollTo({ y: 0, x:  (this.state.activeTab)*(sliderWidth/3) - 2*(sliderWidth/3) , animated: true }) , 100);
     }
  }
 

  setValue = (value) => {
    this.setState({ activeTab: value });
    this.props.callBack(value);
  }

  render() {
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }
    return (
      <View style={[
        styles.subHeader, 
        this.props.selectedTheme == 'night' ? {backgroundColor: themes.night.uiBlue} : {backgroundColor: themes.normal.uiBlue}
      ]}>
        <ScrollView 
          disableIntervalMomentum={true}
          showsHorizontalScrollIndicator={false}
          scrollEventThrottle={1}
          decelerationRate={0}
          snapToInterval={itemWidth}
          horizontal={true}
          ref={(ref) => this.myScroll = ref}
        >
          <View style={styles.tabSlide}>

            <TouchableOpacity 
              style={[
                styles.tabButton, 
                this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiBlue} : {borderBottomColor: themes.normal.uiBlue},
                this.state.activeTab==1 && this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiTabLine} : null,
                this.state.activeTab==1 && this.props.selectedTheme == 'normal' ? {borderBottomColor: themes.normal.uiTabLine} : null,
              ]} 
              onPress={()=> this.setValue(1)}>
              <Text style={[styles.tabButtonText, this.state.activeTab==1 ? styles.activeTabText : null]}>{Locale(global.lang, "monday_short")}</Text>
            </TouchableOpacity>

            <TouchableOpacity 
              style={[
                styles.tabButton, 
                this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiBlue} : {borderBottomColor: themes.normal.uiBlue},
                this.state.activeTab==2 && this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiTabLine} : null,
                this.state.activeTab==2 && this.props.selectedTheme == 'normal' ? {borderBottomColor: themes.normal.uiTabLine} : null,
              ]} 
              onPress={()=> this.setValue(2)}
            >
              <Text style={[styles.tabButtonText, this.state.activeTab==2 ? styles.activeTabText : null]}>{Locale(global.lang, "tuesday_short")}</Text>
            </TouchableOpacity>

            <TouchableOpacity 
              style={[
                styles.tabButton, 
                this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiBlue} : {borderBottomColor: themes.normal.uiBlue},
                this.state.activeTab==3 && this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiTabLine} : null,
                this.state.activeTab==3 && this.props.selectedTheme == 'normal' ? {borderBottomColor: themes.normal.uiTabLine} : null,
              ]}
              onPress={()=> this.setValue(3)}
            >
              <Text style={[styles.tabButtonText, this.state.activeTab==3 ? styles.activeTabText : null]}>{Locale(global.lang, "wednesday_short")}</Text>
            </TouchableOpacity>

            <TouchableOpacity 
              style={[
                styles.tabButton, 
                this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiBlue} : {borderBottomColor: themes.normal.uiBlue},
                this.state.activeTab==4 && this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiTabLine} : null,
                this.state.activeTab==4 && this.props.selectedTheme == 'normal' ? {borderBottomColor: themes.normal.uiTabLine} : null,
              ]}
              onPress={()=> this.setValue(4)}
            >
              <Text style={[styles.tabButtonText, this.state.activeTab==4 ? styles.activeTabText : null]}>{Locale(global.lang, "thursday_short")}</Text>
            </TouchableOpacity>
        
            <TouchableOpacity 
              style={[
                styles.tabButton, 
                this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiBlue} : {borderBottomColor: themes.normal.uiBlue},
                this.state.activeTab==5 && this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiTabLine} : null,
                this.state.activeTab==5 && this.props.selectedTheme == 'normal' ? {borderBottomColor: themes.normal.uiTabLine} : null,
              ]}
              onPress={()=> this.setValue(5)}
            >
              <Text style={[styles.tabButtonText, this.state.activeTab==5 ? styles.activeTabText : null]}>{Locale(global.lang, "friday_short")}</Text>
            </TouchableOpacity>

            <TouchableOpacity 
              style={[
                styles.tabButton, 
                this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiBlue} : {borderBottomColor: themes.normal.uiBlue},
                this.state.activeTab==6 && this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiTabLine} : null,
                this.state.activeTab==6 && this.props.selectedTheme == 'normal' ? {borderBottomColor: themes.normal.uiTabLine} : null,
              ]}
              onPress={()=> this.setValue(6)}
            >
              <Text style={[styles.tabButtonText, this.state.activeTab==6 ? styles.activeTabText : null]}>{Locale(global.lang, "saturday_short")}</Text>
            </TouchableOpacity>

            <TouchableOpacity 
              style={[
                styles.tabButton, 
                this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiBlue} : {borderBottomColor: themes.normal.uiBlue},
                this.state.activeTab==7 && this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiTabLine} : null,
                this.state.activeTab==7 && this.props.selectedTheme == 'normal' ? {borderBottomColor: themes.normal.uiTabLine} : null,
              ]}
              onPress={()=> this.setValue(7)}
            >
              <Text style={[styles.tabButtonText, this.state.activeTab==7 ? styles.activeTabText : null]}>{Locale(global.lang, "sunday_short")}</Text>
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
    flex:1,
    justifyContent:'center',
    alignItems:'center'
  },
  tabs: {
    flex: 1,
    flexDirection: 'row',
  },
  tabSlide: {
    flexDirection: 'row',
  },
  tabButton: {
    width: itemWidth,
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
    fontSize: 11,
    lineHeight: 14,
    paddingHorizontal:5,
    textTransform: 'uppercase',
    opacity: 0.8,
  },
  activeTabText: {
    fontFamily: 'Roboto-Medium',
    fontSize: 13,
    opacity: 1,
  },

});