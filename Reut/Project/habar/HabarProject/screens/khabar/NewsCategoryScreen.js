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
import UiHeaderWithLogo from '../../components/ui/header/HeaderWithLogo.js';
import UiRadioBtnBox from '../../components/ui/form/RadioBtnBox.js'
import UiButtonIcon from '../../components/ui/button/ButtonIcon.js'
import UiClearCard from '../../components/ui/cards/ClearAndroidCard.js';

import Carousel from 'react-native-snap-carousel';

import Colors, {themes} from '../../constants/Colors.js';

import {formatDateTimeString} from '../../components/common/Date.js';
import {parseTags, getNews, getPopularNews, getTv_Projects, getCategorys} from '../../services/Feed.js';
import {Locale, getLang, getTheme} from '../../i18n/locale.js';
import {getCategory ,remCategory, setCategory, clearCategory} from '../../services/Storage.js';

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

export default class NewsCategoryScreen extends React.Component  {

  state = {
    fontsLoaded: false,
    loginProgress: false,
    markActive: false,
    likeActive: false,
    lang: "kz",
    selectedCat: 0,
    myCategorys: [],
    categorys: [],
    tabSelect: [
      {
        title:"Добавить",
        value:0
      },
      {
        title:"Выбранные",
        value:1
      }
    ]
  }

  static navigationOptions = {
    header: null,
  };

  componentDidMount = async() => { 
    await Font.loadAsync({
      'Roboto-Regular': require('../../assets/fonts/Roboto-Regular.ttf'),
      'Roboto-Medium': require('../../assets/fonts/Roboto-Medium.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
  
    getLang().then((res)=> {
      this.setState({lang: res,
      tabSelect: [
          {
            title: Locale(res, "add_cat"),
            value:0
          },
          {
            title: Locale(res, "rem_cat"),
            value:1
          }
        ]
      });
      this.getRSS();
    }  );
    this.props.navigation.addListener('willFocus', this.load);
    //
    //clearCategory();
    this.getRSS();
    this.changeTheme();
  }

  load = () => { 
    getLang().then((res)=> {
      this.setState({lang: res,
        tabSelect: [
          {
            title: Locale(res, "add_cat"),
            value:0
          },
          {
            title: Locale(res, "rem_cat"),
            value:1
          }
        ]
      
      });
      this.getRSS();
    });
    this.changeTheme();
  }

  changeTheme(){
    getTheme().then((res)=>  {
      //console.log("theme", res);
      this.setState({selectedTheme: res});
    });
  }
 
  getRSS(){
    this.setState({loader: true});
    getCategorys(this.state.lang).then((rss) => {
      ////console.log("rss",rss);
      this.setState({categorys: rss.items});
      this.setState({loader: false});
    });
    this.getSaved();
  }

  getSaved(){
    getCategory().then((rss) => {
      if(rss == null) this.setState({myCategorys: [] }); else this.setState({myCategorys: rss});
      ////console.log("rss w",rss);
    });
  };
  
  render() {
    const {navigate} = this.props.navigation;
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }

    var catList = this.state.categorys.map((item,index)=>{
      return (
        <UiButtonIcon 
          key={index} 
          selectedTheme={this.state.selectedTheme}
          onPress={()=> {
            setCategory(item).then(()=> this.getSaved()); 
          }} 
          buttonText={item.title} 
        />
      );
    });

    var myCatList = this.state.myCategorys.map((item,index)=>{
      return (
        <UiButtonIcon 
          key={index} 
          selected={true}
          selectedTheme={this.state.selectedTheme}
          onPress={()=> {
            //console.log("pressed")
            remCategory(item).then(()=> this.getSaved()); 
          }} 
          buttonText={item.title} 
        />
      );
    });

    return (
      <View style={[styles.container, this.state.selectedTheme == 'night' ? {backgroundColor: themes.night.uiBgGray} : {backgroundColor: themes.normal.uiBgGray} ]}>
        <UiHeaderWithLogo 
          selectedTheme={this.state.selectedTheme}
          btnLeft='back'
          pressLeft={()=> navigate('Main')}
          pressBtnRight={()=> navigate('Main')}
        />
        <SafeAreaView style={styles.safeArea} forceInset={{top:'never'}}>

          <ScrollView style={styles.content}>
            <View style={[{alignItems: 'center'}]}>
              <UiRadioBtnBox 
                selectedTheme={this.state.selectedTheme}
                itemList={this.state.tabSelect}  
                callBack={(res)=>{
                  //console.log(res)
                  this.setState({selectedCat: res});
                }}
              />
            </View>
            {this.state.selectedCat == 0 ? catList : myCatList}
            <UiClearCard />
          </ScrollView>
        </SafeAreaView>
        <Loader
          selectedTheme={this.state.selectedTheme}
          show={this.state.laoder} 
        />
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

});
