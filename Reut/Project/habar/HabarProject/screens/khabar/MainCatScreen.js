import * as WebBrowser from 'expo-web-browser';
import React from 'react';
import {
  StyleSheet,
  View,
  SafeAreaView,
  ScrollView,
  Alert,
  Keyboard,
  Linking
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import Loader from '../../components/ui/Loader.js';
import UiHeaderWithLogo from '../../components/ui/header/HeaderWithLogo.js';
import UiTabs from '../../components/ui/tabs/Tabs.js';
import UiTopNewsCard from '../../components/ui/cards/TopNewsCard.js';
import UiNewsCard from '../../components/ui/cards/NewsCard.js';
import UiClearCard from '../../components/ui/cards/ClearAndroidCard.js';
import UiScreenMsg from '../../components/ui/text/ScreenMsg.js';
import UiAlert from '../../components/ui/modal/Alert.js';
import UiButtonBlue from '../../components/ui/button/ButtonBlue.js';
import UiButtonIcon from '../../components/ui/button/ButtonIcon.js'

import Carousel from 'react-native-snap-carousel';

import Colors, { themes } from '../../constants/Colors.js';

import { formatDateTimeString } from '../../components/common/Date.js';
import { parseTags, getFedCategory, getCatNews, getNews, getPopularNews, getTv_Projects, getCategorys } from '../../services/Feed.js';

import { Locale, getLang, getTheme } from '../../i18n/locale.js';
import { getCategory, setNews } from '../../services/Storage.js';

export default class MainScreen extends React.Component {

  state = {
    fontsLoaded: false,
    loginProgress: false,
    markActive: false,
    modalAlertVisible: false,
    lang: "kz",
    modalLoadVisible: false,
    loader: false,
    isSearch: false,
    offline: false,

    selectedCat: 0,
    catNews: [],
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

  componentDidMount = async () => {
    await Font.loadAsync({
      'Roboto-Regular': require('../../assets/fonts/Roboto-Regular.ttf'),
      'Roboto-Medium': require('../../assets/fonts/Roboto-Medium.ttf'),
    }).then(() => this.setState({ fontsLoaded: true }));

    getLang().then((res) => {
      this.setState({ lang: res });
      this.getRSS();
    });
    this.props.navigation.addListener('willFocus', this.load);
    this.changeTheme();
  }

  load = () => {
    getLang().then((res) => {
      this.setState({ lang: res });
      this.getRSS();
    });
    this.changeTheme();
  }

  changeTheme() {
    getTheme().then((res) => {
      //console.log("theme", res);
      this.setState({ selectedTheme: res });
    });
  }

  getRSS() {
    this.setState({ loader: true });
    getFedCategory(this.state.lang, this.props.navigation.state.params.id).then((rss) => {
      //console.log("news done");
      this.setState({ offline: false, news: rss.items, loader: false }, () => {
      });

    }).catch(() => {
      this.setState({ offline: true, loader: false })
    });
  }

  render() {
    const { navigate } = this.props.navigation;
    if (!this.state.fontsLoaded) {
      return <AppLoading />
    }

    var newsList = this.state.news.map((item, index) => {
      if (index == 0) {
        return (
          <UiTopNewsCard
            key={index}
            selectedTheme={this.state.selectedTheme}
            image={parseTags(item.description).images}
            title={item.title}
            category={item.categories[0].name}
            date={formatDateTimeString(item.published)}
            cardPress={() => this.props.navigation.navigate("News", { info: item })}
            bookMarkPress={() => {
              this.setState({ modalAlertVisible: true });
              setNews(item);
            }}
          />
        )
      } else {
        return (
          <UiNewsCard
            key={index}
            selectedTheme={this.state.selectedTheme}
            image={parseTags(item.description).images}
            title={item.title}
            category={item.categories[0].name}
            date={formatDateTimeString(item.published)}
            cardPress={() => { this.props.navigation.navigate("News", { info: item }) }}
            bookMarkPress={() => {
              this.setState({ modalAlertVisible: true });
              setNews(item);
            }}
          />
        )
      }
    })

    var searchList = this.state.searchNews.map((item, index) => {
      return (
        <UiNewsCard
          key={index}
          selectedTheme={this.state.selectedTheme}
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
        this.state.selectedTheme == 'night' ? { backgroundColor: themes.night.uiBg } : { backgroundColor: themes.normal.uiBg }
      ]}>
        <UiHeaderWithLogo
          selectedTheme={this.state.selectedTheme}
          pressSave={() => Alert.alert('Save')}
          searchHeader
          searchText={Locale(this.state.lang, "search_by_news")}
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


        <SafeAreaView style={styles.safeArea} forceInset={{ top: 'never' }}>
          {this.state.offline ?
            <View style={styles.noContent}>
              <UiScreenMsg
                selectedTheme={this.state.selectedTheme}
                noTitle="Телепрограмма не доступна"
                noText="Проверьте интернет соединение и обновите страницу"
              />
            </View> : null
          }

          {!this.state.isSearch ?
            <ScrollView style={styles.content}>
              {newsList}
              <UiClearCard />
            </ScrollView>
            : null}

          {this.state.isSearch ?
            <ScrollView style={styles.content}>
              {searchList.length > 0 ? searchList :
                <UiScreenMsg
                  selectedTheme={this.state.selectedTheme}
                  noTitle={Locale(this.state.lang, "not_found")}
                  noText={Locale(this.state.lang, "not_found_text")}
                  noButton={false}
                />
              }
              <UiClearCard />
            </ScrollView>
            : null}
        </SafeAreaView>

        <UiTabs
          selectedTheme={this.state.selectedTheme}
          navigation={this.props.navigation}
        />

        <UiAlert
          modalVisible={this.state.modalAlertVisible}
          alertTitle={Locale(this.state.lang, "read_later")}
          alertText={Locale(this.state.lang, "read_later_add")}
          okText={Locale(this.state.lang, "yes")}

          okPress={() => {
            this.setState({ modalAlertVisible: !this.state.modalAlertVisible });
          }}
        />

        <UiAlert
          modalVisible={this.state.modalLoadVisible}
          alertTitle={Locale(this.state.lang, "offline_mode")}
          alertText={Locale(this.state.lang, "active_offline_mode")}
          alertText2={Locale(this.state.lang, "message_offline_mode")}
          alertText3={Locale(this.state.lang, "message_offline_mode2")}
          okText={Locale(this.state.lang, "yes")}
          cancelText={Locale(this.state.lang, "cancel")}
          okPress={() => {
            this.setState({ modalLoadVisible: !this.state.modalLoadVisible });
          }}
        />
        <Loader
          selectedTheme={this.state.selectedTheme}
          show={this.state.loader}
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
    paddingTop: 16,
  },
  noContent: {
    flex: 1,
  },

});
