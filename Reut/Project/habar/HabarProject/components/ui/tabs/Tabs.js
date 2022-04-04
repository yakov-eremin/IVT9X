import React from 'react';
import { 
  Dimensions,
  Image, 
  StyleSheet, 
  Text, 
  TouchableOpacity,
  View,
} from 'react-native';
import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import { isIphoneX } from '../../isIphoneX';

import Colors, {themes} from '../../../constants/Colors.js';

import khabarIcon from '../../../assets/images/tabs/khabar-outline-2x.png';
import khabarBlueIcon from '../../../assets/images/tabs/khabar-blue-2x.png';
import khabarLightIcon from '../../../assets/images/tabs/khabar-light-2x.png';
import projectIcon from '../../../assets/images/tabs/project-outline-2x.png';
import projectBlueIcon from '../../../assets/images/tabs/project-blue-2x.png';
import projectLightIcon from '../../../assets/images/tabs/project-light-2x.png';
import programIcon from '../../../assets/images/tabs/program-outline-2x.png';
import programBlueIcon from '../../../assets/images/tabs/program-blue-2x.png';
import programLightIcon from '../../../assets/images/tabs/program-light-2x.png';
import reportIcon from '../../../assets/images/tabs/report-outline-2x.png';
import reportBlueIcon from '../../../assets/images/tabs/report-blue-2x.png';
import reportLightIcon from '../../../assets/images/tabs/report-light-2x.png';
import moreIcon from '../../../assets/images/tabs/ellipsis-2x.png';
import moreBlueIcon from '../../../assets/images/tabs/ellipsis-blue-2x.png';
import moreLightIcon from '../../../assets/images/tabs/ellipsis-light-2x.png';

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
}

const statusX = isIphoneX() ? 34 : 0;
const { width: viewportWidth, height: viewportHeight } = Dimensions.get('window');
const phoneWidth = viewportWidth;
const labelSize = phoneWidth < 326 ? 8.5 : 10;

export default class UiTabs extends React.Component {

  state = { 
    fontsLoaded: false, 
    lang: "ru",
  };

  constructor(props){
    super(props);
  }

  componentDidMount = async() => { 
    await Font.loadAsync({
      'Roboto-Medium': require('../../../assets/fonts/Roboto-Medium.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
  }

  componentDidUpdate(){
    getLang().then((res)=>  this.setState({lang: res}) );
  }

  render() {
    const {navigate} = this.props.navigation;
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }
    return (
      <View style={[styles.tabs, this.props.selectedTheme == 'night' ? {backgroundColor: themes.night.uiTabsBg, borderTopColor: themes.night.uiTabsLine} : {backgroundColor: themes.normal.uiTabsBg, borderTopColor: themes.normal.uiTabsLine}]}>
        <TouchableOpacity 
          style={styles.tabButton}
          onPress={() => {
            this.props.navigation.navigate('Main');
          }}
        >
          {this.props.activeTabs == 1 ?
            <View>
              {this.props.selectedTheme == 'night' ?
                <Image style={styles.tabButtonIcon} source={khabarLightIcon} />
                :
                <Image style={styles.tabButtonIcon} source={khabarBlueIcon} />
              }
            </View>
            : 
            <Image style={styles.tabButtonIcon} source={khabarIcon} />
          }
          <Text style={[styles.tabButtonText, this.state.lang=="ru"?{fontSize: labelSize}:{fontSize: 8}]}>{Locale(this.state.lang, "habar24")}</Text>
        </TouchableOpacity>
        <TouchableOpacity 
          style={styles.tabButton}
          onPress={() => {
            this.props.navigation.navigate('TVProjects');
          }}
        >
          {this.props.activeTabs == 2 ?
            <View>
              {this.props.selectedTheme == 'night' ?
                <Image style={styles.tabButtonIcon} source={projectLightIcon} />
                :
                <Image style={styles.tabButtonIcon} source={projectBlueIcon} />
              }
            </View>
            : 
            <Image style={styles.tabButtonIcon} source={projectIcon} />
          }
          <Text style={[styles.tabButtonText, this.state.lang=="ru"?{fontSize: labelSize}:{fontSize: 8}]}>{Locale(this.state.lang, "tv_projects_spec")}</Text>
        </TouchableOpacity>
        <TouchableOpacity 
          style={styles.tabButton}
          onPress={() => {
            this.props.navigation.navigate('TVProgram');
          }}
        >
          {this.props.activeTabs == 3 ?
            <View>
              {this.props.selectedTheme == 'night' ?
                <Image style={styles.tabButtonIcon} source={programLightIcon} />
                :
                <Image style={styles.tabButtonIcon} source={programBlueIcon} />
              }
            </View>
            : 
            <Image style={styles.tabButtonIcon} source={programIcon} />
          }
          <Text style={[styles.tabButtonText, this.state.lang=="ru"?{fontSize: labelSize}:{fontSize: 8}]}>{Locale(this.state.lang, "tv_programm")}</Text>
        </TouchableOpacity>
        <TouchableOpacity 
          style={styles.tabButton}
          onPress={() => {
            this.props.navigation.navigate('Reporter');
          }}
        >
          {this.props.activeTabs == 4 ?
            <View>
              {this.props.selectedTheme == 'night' ?
                <Image style={styles.tabButtonIcon} source={reportLightIcon} />
                :
                <Image style={styles.tabButtonIcon} source={reportBlueIcon} />
              }
            </View>
            : 
            <Image style={styles.tabButtonIcon} source={reportIcon} />
          }
          <Text style={[styles.tabButtonText, this.state.lang=="ru"?{fontSize: labelSize}:{fontSize: 8}]}>{Locale(this.state.lang, "reporter")}</Text>
        </TouchableOpacity>
        <TouchableOpacity 
          style={styles.tabButton}
          onPress={() => {
            this.props.navigation.navigate('Settings');
          }}
        >
          {this.props.activeTabs == 5 ?
            <View>
              {this.props.selectedTheme == 'night' ?
                <Image style={styles.tabButtonIcon} source={moreLightIcon} />
                :
                <Image style={styles.tabButtonIcon} source={moreBlueIcon} />
              }
            </View>
            : 
            <Image style={styles.tabButtonIcon} source={moreIcon} />
          }
          <Text style={[styles.tabButtonText, this.state.lang=="ru"?{fontSize: labelSize}:{fontSize: 8}]}>{Locale(this.state.lang, "more")}</Text>
        </TouchableOpacity>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  tabs: {
    flexGrow: 0,
    flexShrink: 0,
    flexDirection: 'row',
    width: '100%',
    paddingBottom: statusX,
    borderTopWidth: 1,
  },
  tabButton: { 
    flex: 1, 
    height: 56,
    justifyContent: "center", 
    alignItems: "center",
  },
  tabButtonIcon: { 
    height: 28,
    width: 28,
    resizeMode: 'contain',
  },
  tabButtonText: { 
    fontWeight: 'bold',
    lineHeight: 14,
    color: Colors.colLightGray,
    textAlign: 'center'
  },
  tabButtonTextActive: {
    color: Colors.uiBlue,
  },

});