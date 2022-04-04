import * as WebBrowser from 'expo-web-browser';
import React from 'react';
import {
  StyleSheet,
  View,
  SafeAreaView,
  ScrollView,
  Alert
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import Loader from '../components/ui/Loader.js';
import UiHeader from '../components/ui/header/Header.js';
import UiSubHeader from '../components/ui/header/SubHeader.js';
import UiTopNewsCard from '../components/ui/cards/TopNewsCard.js';
import UiNewsCard from '../components/ui/cards/NewsCard.js';
import UiClearCard from '../components/ui/cards/ClearAndroidCard.js';

import {Locale, getLang} from '../i18n/locale.js';


export default class HomeScreen extends React.Component  {

  state = {
    fontsLoaded: false,
    loginProgress: false,
    markActive: false,
    lang: "kz",
  }

  static navigationOptions = {
    header: null,
  };

  componentDidMount = async() => { 
    await Font.loadAsync({
      'Roboto-Regular': require('../assets/fonts/Roboto-Regular.ttf'),
      'Roboto-Medium': require('../assets/fonts/Roboto-Medium.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
  
    getLang().then((res)=>  global.lang = res );
    this.props.navigation.addListener('willFocus', this.load);

//this.getRSS();
}

load = () => { 
  getLang().then((res)=>  global.lang = res );

  //RSS
  
}

  render() {
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }

    return (
      <View style={styles.container}>
        <Loader show={this.state.loginProgress} />
        <UiHeader 
          headerText={"Хабар24" }
          pressSave={()=> Alert.alert('Save')}
          searchHeader
          searchText={Locale(global.lang, "search_by_news")}
          pressRight={()=> navigate('Live')}
        />
        <UiSubHeader 
          activeTab="1"
          title1={Locale(global.lang, "latest_news")}
          title2={Locale(global.lang, "my_news")}
          title3={Locale(global.lang, "popular")}
          title4={Locale(global.lang, "headings")}
          title5={Locale(global.lang, "tv_projects")}
         />

        <SafeAreaView style={styles.safeArea} forceInset={{top:'never'}}>
          <ScrollView style={styles.content}>
            <UiTopNewsCard />
            <UiNewsCard />
            <UiNewsCard />
            <UiNewsCard />
            <UiNewsCard />
            <UiClearCard />
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
  },
  
});
