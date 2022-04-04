import React from "react";
import {NavigationActions} from 'react-navigation';
import { 
  View, 
  Text, 
  StyleSheet, 
  TouchableOpacity, 
  Image, 
  Dimensions, 
  SafeAreaView 
} from "react-native";

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import khabarIcon from '../assets/images/tabs/khabar-outline-2x.png';
import khabarBlueIcon from '../assets/images/tabs/khabar-blue-2x.png';
import projectIcon from '../assets/images/tabs/project-outline-2x.png';
import projectBlueIcon from '../assets/images/tabs/project-blue-2x.png';
import programIcon from '../assets/images/tabs/program-outline-2x.png';
import programBlueIcon from '../assets/images/tabs/program-blue-2x.png';
import reportIcon from '../assets/images/tabs/report-outline-2x.png';
import reportBlueIcon from '../assets/images/tabs/report-blue-2x.png';
import moreIcon from '../assets/images/tabs/ellipsis-2x.png';
import moreBlueIcon from '../assets/images/tabs/ellipsis-blue-2x.png';

import Colors from '../constants/Colors.js';
import {Locale, getLang} from '../i18n/locale.js';

componentDidMount = async() => { 
  await Font.loadAsync({
    'Roboto-Regular': require('../assets/fonts/Roboto-Regular.ttf'),
    'Roboto-Medium': require('../assets/fonts/Roboto-Medium.ttf'),
  }).then( () => this.setState( { fontsLoaded: true } ) );

  getLang().then((res)=>  this.setState({lang: res}) );
  this.props.navigation.addListener('willFocus', this.load);

//this.getRSS();
}

load = () => { 
  getLang().then((res)=>  this.setState({lang: res}) );

  //RSS
  
}

const { width: viewportWidth, height: viewportHeight } = Dimensions.get('window');
const phoneWidth = viewportWidth;
const labelSize = phoneWidth < 326 ? 8.5 : 10;

const S = StyleSheet.create({
  safeArea: {
    borderTopColor: '#e0e0e0',
    alignItems: 'flex-start',
    backgroundColor: '#fcfcfc',
  },
  container: { 
    flexDirection: "row", 
    alignItems: 'flex-start',
    borderTopWidth: 1,
    borderTopColor: '#e0e0e0',
  },
  tabButton: { 
    height: 56,
    flex: 1, 
    justifyContent: "center", 
    alignItems: "center",
    backgroundColor: '#fcfcfc',
  },
  tabButtonIcon: { 
    height: 28,
    width: 28,
    resizeMode: 'contain',
  },
  tabButtonText: { 
    fontSize: labelSize,
    fontWeight: 'bold',
    lineHeight: 14,
    color: Colors.uiLightGray,
  },
  tabButtonTextActive: {
    color: Colors.uiBlue,
  },
});

state = {
  lang: "ru",
}

navigateToScreen = ( route ) =>(
  () => {
    const navigateAction = NavigationActions.navigate({
      routeName: route
  });
  this.setState({currentRoute: route});
  this.props.navigation.dispatch(navigateAction);
})

const TabBar = props => {
  const {
    renderIcon,
    getLabelText,
    activeTintColor,
    inactiveTintColor,
    onTabPress,
    onTabLongPress,
    getAccessibilityLabel,
    navigation
  } = props;

  const { routes, index: activeRouteIndex } = navigation.state;
   
  //console.log("_index_ ", props.navigation.state.routes[props.navigation.state.index].key );
  
  return (
    <SafeAreaView style={S.safeArea} forceInset={{top:'never'}}>
      <View style={S.container}>
          <TouchableOpacity
              key={1}
              style={[S.tabButton ]}
              onPress={() => {navigation.navigate('Main');}}
              onLongPress={() => {navigation.navigate('Main');}}>
              { props.navigation.state.routes[props.navigation.state.index].key == 'MainStack' ? 
                <Image style={S.tabButtonIcon} source={khabarBlueIcon} /> : 
                <Image style={S.tabButtonIcon} source={khabarIcon} /> 
              }
              { props.navigation.state.routes[props.navigation.state.index].key == 'MainStack' ? 
                <Text style={[S.tabButtonText, S.tabButtonTextActive]}>{Locale(this.state.lang, "habar24")}</Text> : 
                <Text style={S.tabButtonText}>{Locale(this.state.lang, "habar24")}</Text>
              }
          </TouchableOpacity>

          <TouchableOpacity
              key={2}
              style={[S.tabButton ]}
              onPress={() => {navigation.navigate('TVProjects');}}
              onLongPress={() => {navigation.navigate('TVProjects');}}>
              { props.navigation.state.routes[props.navigation.state.index].key == 'TVProjectsStack' ? 
                <Image style={S.tabButtonIcon} source={projectBlueIcon} /> : 
                <Image style={S.tabButtonIcon} source={projectIcon} /> 
              }
              { props.navigation.state.routes[props.navigation.state.index].key == 'TVProjectsStack' ? 
                <Text style={[S.tabButtonText, S.tabButtonTextActive]}>{Locale(this.state.lang, "tv_projects_spec")}</Text> : 
                <Text style={S.tabButtonText}>{Locale(this.state.lang, "tv_projects_spec")}</Text>
              }
          </TouchableOpacity>

          <TouchableOpacity
              key={3}
              style={[S.tabButton ]}
              onPress={() => {navigation.navigate('TVProgram');}}
              onLongPress={() => {navigation.navigate('TVProgram');}}>
              { props.navigation.state.routes[props.navigation.state.index].key == 'TVProgramStack' ? 
                <Image style={S.tabButtonIcon} source={programBlueIcon} /> : 
                <Image style={S.tabButtonIcon} source={programIcon} /> 
              }
              { props.navigation.state.routes[props.navigation.state.index].key == 'TVProgramStack' ? 
                <Text style={[S.tabButtonText, S.tabButtonTextActive]}>{Locale(this.state.lang, "tv_programm")}</Text> : 
                <Text style={S.tabButtonText}>{Locale(this.state.lang, "tv_programm")}</Text>
              }
          </TouchableOpacity>

          <TouchableOpacity
              key={4}
              style={[S.tabButton]}
              onPress={() => {navigation.navigate('Reporter', {isAlert: false, id: 0} );}}
              onLongPress={() => {navigation.navigate('Reporter', {isAlert: false, id: 0} );}}>
              { props.navigation.state.routes[props.navigation.state.index].key == 'ReporterStack' ? 
                <Image style={S.tabButtonIcon} source={reportBlueIcon} /> : 
                <Image style={S.tabButtonIcon} source={reportIcon} /> 
              }
              { props.navigation.state.routes[props.navigation.state.index].key == 'ReporterStack' ? 
                <Text style={[S.tabButtonText, S.tabButtonTextActive]}>{Locale(this.state.lang, "reporter")}</Text> : 
                <Text style={S.tabButtonText}>{Locale(this.state.lang, "reporter")}</Text>
              }
          </TouchableOpacity>

          <TouchableOpacity
              key={5}
              style={[S.tabButton ]}
              onPress={() => {navigation.navigate('Settings');}}
              onLongPress={() => {navigation.navigate('Settings');}}>

              { props.navigation.state.routes[props.navigation.state.index].key == 'SettingsStack' ? 
                <Image style={S.tabButtonIcon} source={moreBlueIcon} /> : 
                <Image style={S.tabButtonIcon} source={moreIcon} /> 
              }
              { props.navigation.state.routes[props.navigation.state.index].key == 'SettingsStack' ? 
                <Text style={[S.tabButtonText, S.tabButtonTextActive]}>{Locale(this.state.lang, "more")}</Text> : 
                <Text style={S.tabButtonText}>{Locale(this.state.lang, "more")}</Text>
              }
          </TouchableOpacity>
      </View>
    </SafeAreaView>
  );
};

export default TabBar;