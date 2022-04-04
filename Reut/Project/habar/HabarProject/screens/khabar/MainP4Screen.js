import * as WebBrowser from 'expo-web-browser';
import React from 'react';
import {
  Alert,
  Dimensions,
  Keyboard,
  Linking,
  SafeAreaView,
  ScrollView,
  StyleSheet,
  Text,
  Image,
  View,
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';
import { Notifications, ScreenOrientation } from 'expo';
import * as Permissions from 'expo-permissions';

import Loader from '../../components/ui/Loader.js';
import UiHeaderWithLogo from '../../components/ui/header/HeaderWithLogo.js';
import UiSubHeader from '../../components/ui/header/SubHeader.js';
import UiTabs from '../../components/ui/tabs/Tabs.js';

import UiTopNewsCard from '../../components/ui/cards/TopNewsCard.js';
import UiNewsCard from '../../components/ui/cards/NewsCard.js';
import UiClearCard from '../../components/ui/cards/ClearAndroidCard.js';
import UiScreenMsg from '../../components/ui/text/ScreenMsg.js';
import UiAlert from '../../components/ui/modal/Alert.js';
import UiButtonIcon from '../../components/ui/button/ButtonIcon.js'

import { formatDateTimeString } from '../../components/common/Date.js';

import Colors, { themes } from '../../constants/Colors.js';

import { setUserPushToken, parseTags, parseVideoTag, getNews, getPopularNews, getTv_Projects, getCategorys, getSettingsUF } from '../../services/Feed.js';
import { getOffline, setOffline, setOfflineNews, getOfflineNew, } from '../../services/Storage.js';
import { Locale, setLang, getLang, getTheme } from '../../i18n/locale.js';
import { getCategory, setNews, checkInNews } from '../../services/Storage.js';

export default class MainScreen extends React.Component {

  state = {
    fontsLoaded: false,
    loginProgress: false,

    screenWidth: Dimensions.get('window').width,

    markActive: false,
    modalAlertVisible: false,
    lang: "kz",
    modalLoadVisible: false,
    loader: false,
    firstLoader: true,
    isSearch: false,

    offlineEnabled: false,
    offline: false,
    url: 'https://24.kz/ru/',
    bannerUri: '',

    selectedCat: 0,
    deadlist: [],
    catNews: [],
    catMyNews: [],
    catMyNewsRu: [
      { title: "Главные новости", value: 0 },
      { title: "Выпуски новостей", value: 1 },
      { title: "В мире", value: 2 },
      { title: "Деловые новости", value: 3 },
      { title: "Культура", value: 4 },
      { title: "Новости Казахстана", value: 5 },
      { title: "Народный репортер", value: 6 },
      { title: "Общество", value: 7 },
      { title: "Образование и наука", value: 8 },
      { title: "Обзор прессы", value: 9 },
      { title: "Политика", value: 10 },
      { title: "Происшествия", value: 11 },
      { title: "Полезно знать", value: 12 },
      { title: "Спорт", value: 13 },
      { title: "Экономика", value: 14 }
    ],
    catMyNewsKz: [
      { title: "Басты жаңалықтар", value: 0 },
      { title: "Жаңалықтар топтамасы", value: 1 },
      { title: "Әлемде", value: 2 },
      { title: "Экономика жаңалықтары", value: 3 },
      { title: "Мәдениет", value: 4 },
      { title: "Қазақстан жаңалықтары", value: 5 },
      { title: "Оқиға куәгері", value: 6 },
      { title: "Қоғам", value: 7 },
      { title: "Білім және ғылым", value: 8 },
      { title: "Баспасөзге шолу", value: 9 },
      { title: "Саясат", value: 10 },
      { title: "Оқиға", value: 11 },
      { title: "Білгенге маржан", value: 12 },
      { title: "Спорт", value: 13 },
      { title: "Экономика", value: 14 }
    ],
    myNews: [],
    tvNews: [],
    news: [],
    myCategorys: [],
    newsPopular: [],
    searchNews: [],
  }

  static navigationOptions = {
    header: null,
  };


  async registerForPushNotificationsAsync() {

  }

  checkInternt = () => {
    getOffline().then((res) => {
      //console.log("OF",res)

      this.setState({ offlineEnabled: res });
    });

    Linking.canOpenURL(this.state.url).then(offline => {
      this.setState({ loader: true });
      //console.log("offline", offline)
      if (!offline) {

        this.setState({ offline: true, loader: false });
      } else {
        fetch(this.state.url).then(res => {
          this.setState({ offline: res.status !== 200 ? false : true });
          if (res.status == 200) {
            this.getRSS();
          } else {
            this.setState({ loader: false });
            if (this.state.offlineEnabled) {
              Alert.alert("Внимание", "Вы в режиме offline");
              getOfflineNew().then((res) => this.state = res);
            }
          }
        }
        );
      }
    });
  };

  componentDidMount = async () => {
    await Font.loadAsync({
      'Roboto-Regular': require('../../assets/fonts/Roboto-Regular.ttf'),
      'Roboto-Medium': require('../../assets/fonts/Roboto-Medium.ttf'),
    }).then(() => this.setState({ fontsLoaded: true }));

    this.registerForPushNotificationsAsync();
    //Notifications.addListener(this._handleNotification);
    this._notificationSubscription = Notifications.addListener(this._handleNotification);

    ScreenOrientation.addOrientationChangeListener((ref)=>{
     
        //console.log("PORTRAIT_UP11")
        this.setState({
          screenWidth : Dimensions.get('window').width,
        })
      
    })

    getSettingsUF().then((res) => {
      res = JSON.parse(res);
      //console.log(res.settings)
      this.setState({
        deadlist: res.settings.deadlist,
        bannerUri: res.settings.banner
      });

    })

    
    
    checkInNews().then((res) => {
      this.setState({bookMarksArr: res});
    })


    this.getRSS(true);
    this.props.navigation.addListener('willFocus', this.load);
  }

  load = () => {
    this.getRSS(false);
  }

  checkInNewsLocal(title){
    let ff = false;
    this.state.bookMarksArr.map((item)=> {
      if(item.title == title) ff = true; 
    });
    return ff;
  }


  checkDisabled(id) {
    ff = true;
    this.state.deadlist.map((item) => {
      if (item.value == id && item.disabled == 1) ff = false;
    })
    return ff;
  }

  getRSS(_isLoader) {
    if (global.lang == "ru") {
      this.setState({ catMyNews: this.state.catMyNewsRu });
    } else {
      this.setState({ catMyNews: this.state.catMyNewsKz });
    }
    if(_isLoader) this.setState({loader: true});
    this.setState({ offline: false,   firstLoader: true });
    getTv_Projects(global.lang).then((rss) => {
        this.setState({ tvNews: rss.items });
      
        this.setState({ firstLoader: false, loader: false })
    }).catch((err) => {
      //console.log(err)
      this.setState({ offline: true,  firstLoader: false, loader: false })
    });
  }

  render() {
    const { navigate } = this.props.navigation;
    if (!this.state.fontsLoaded) {
      return <AppLoading />
    }

    
    var tvNewsList = this.state.tvNews.map((item, index) => {
      if (index == 0) {
        return (
          <UiTopNewsCard
            key={index}
            selectedTheme={global.theme}
            image={parseTags(item.description).images}
            title={item.title}
            category={item.categories[0].name}
            date={formatDateTimeString(item.published)}
            video={parseVideoTag(item.description)}
            cardPress={() => this.props.navigation.navigate("News", { info: item })}
            markActive={this.checkInNewsLocal(item.title) }
            bookMarkPress={() => {
              this.setState({ modalAlertVisible: true });
              
            }}
          />
        )
      } else {
        return (
          <UiNewsCard
            key={index}
            selectedTheme={global.theme}
            image={parseTags(item.description).images}
            title={item.title}
            category={item.categories[0].name}
            date={formatDateTimeString(item.published)}
            video={parseVideoTag(item.description)}
            cardPress={() => { this.props.navigation.navigate("News", { info: item }) }}
            markActive={this.checkInNewsLocal(item.title) }
            bookMarkPress={() => {
              this.setState({ modalAlertVisible: true });
               
            }}
          />
        )
      }
    })

   

    var searchList = this.state.searchNews.map((item, index) => {
      return (
        <UiNewsCard
          key={index}
          selectedTheme={global.theme}
          image={parseTags(item.description).images}
          title={item.title}
          category={item.categories[0].name}
          date={formatDateTimeString(item.published)}
          cardPress={() => { this.props.navigation.navigate("News", { info: item }) }}
        />
      )
    })

    return (
      <View style={[
        styles.container,
        global.theme == 'night' ? { backgroundColor: themes.night.uiBg } : { backgroundColor: themes.normal.uiBg }
      ]}>
        <UiHeaderWithLogo
          selectedTheme={global.theme}
          pressSave={() => Alert.alert('Save')}
          searchHeader
          searchText={Locale(global.lang, "search_by_news")}
          pressRight={() => navigate('Live')}
          items={this.state.news}
          isSearchCallBack={(res) => {
            this.setState({ isSearch: res });
            if (!res) Keyboard.dismiss();
          }}
          searchCallBack={(res) => {
            ////console.log(res.searchRes);
            this.setState({ searchNews: res.searchRes });
          }}
        />
        <UiSubHeader
          selectedTheme={global.theme}
          selectedIndex={4}
          title1={Locale(global.lang, "latest_news")}
          title2={Locale(global.lang, "my_news")}
          title3={Locale(global.lang, "popular")}
          title4={Locale(global.lang, "headings")}
          title5={Locale(global.lang, "tv_projects")}
          
          itemWidth={this.state.screenWidth}

          callBack={(res) => {
            if(res == 0){
              this.props.navigation.navigate("Main");
            } else if(res == 1){
              this.props.navigation.navigate("MainP1");
            } else if(res == 2){
              this.props.navigation.navigate("MainP2");
            } else if(res == 3){
              this.props.navigation.navigate("MainP3");
            } else if(res == 4){
              this.props.navigation.navigate("MainP4");
            }
          }}
        />

        <SafeAreaView style={styles.safeArea} forceInset={{ top: 'never' }}>
          {this.state.offline && !this.state.loader ?
            <View style={styles.noContent}>
              <UiScreenMsg
                selectedTheme={global.theme}
                noTitle={Locale(global.lang, "connect_off")}
                noText={Locale(global.lang, "connect_off_text")}
                noButtonText={Locale(global.lang, "choice_of_subject")}
              />
            </View> : null
          }
 

          {!this.state.isSearch ?
            <ScrollView style={styles.content}>
              {tvNewsList}
              <UiClearCard />
            </ScrollView>
            : null}



          {this.state.isSearch ?
            <ScrollView style={styles.content}>
              {searchList.length > 0 ? searchList :
                <UiScreenMsg
                  selectedTheme={global.theme}
                  noTitle={Locale(global.lang, "not_found")}
                  noText={Locale(global.lang, "not_found_text")}
                  noButton={false}
                  noButtonText={Locale(global.lang, "choice_of_subject")}
                />
              }
              <UiClearCard />
            </ScrollView>
            : null}

          {this.state.bannerUri && this.state.bannerUri != '' ?
            <View style={styles.bannerWrap}>
              <Image style={styles.banner} source={{ uri: this.state.bannerUri }} />
            </View>
            : null
          }
        </SafeAreaView>

        <UiTabs
          selectedTheme={global.theme}
          navigation={this.props.navigation}
          activeTabs={1}
        />

        <UiAlert
          modalVisible={this.state.modalAlertVisible}
          alertTitle={Locale(global.lang, "read_later")}
          alertText={Locale(global.lang, "read_later_add")}
          cancelText={Locale(global.lang, "cancel")}
          okText={Locale(global.lang, "yes")}
          cancelPress={() => {
            this.setState({ modalAlertVisible: !this.state.modalAlertVisible });
          }}
          okPress={() => {
            this.setState({ modalAlertVisible: !this.state.modalAlertVisible });
            setNews(item);
          }}

        />

        <UiAlert
          modalVisible={this.state.modalLoadVisible}
          alertTitle={Locale(global.lang, "offline_mode")}
          alertText={Locale(global.lang, "active_offline_mode")}
          alertText2={Locale(global.lang, "message_offline_mode")}
          alertText3={Locale(global.lang, "message_offline_mode2")}
          okText={Locale(global.lang, "yes")}
          cancelText={Locale(global.lang, "cancel")}
          okPress={() => {
            this.setState({ modalLoadVisible: !this.state.modalLoadVisible });
          }}
        />

        <Loader
          selectedTheme={global.theme}
          show={this.state.loader}
        />
      </View>
    );
  }
}


var styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  safeArea: {
    flex: 1,
  },
  content: {
    flex: 1,
    paddingTop: 16,
  },
  noContent: {
    flex: 1,
  },
  bannerWrap: {
    width: '100%',
    height: 100,
  },
  banner: {
    height: '100%',
    width: '100%',
    resizeMode: 'stretch',
  }

});
