import * as WebBrowser from 'expo-web-browser';
import React from 'react';
import {
  StyleSheet,
  View,
  SafeAreaView,
  ScrollView,
  Text,
  TouchableOpacity,
  Image,
  Alert
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import { SwipeListView, SwipeRow } from 'react-native-swipe-list-view';

import Loader from '../../components/ui/Loader.js';
import UiHeader from '../../components/ui/header/Header.js';
import UiSubHeader from '../../components/ui/header/SubHeader.js';
import UiTopNewsCard from '../../components/ui/cards/TopNewsCard.js';
import UiNewsCardSlide from '../../components/ui/cards/NewsCardSlide.js';
import UiClearCard from '../../components/ui/cards/ClearAndroidCard.js';
import UiScreenMsg from '../../components/ui/text/ScreenMsg.js';
import UiAlert from '../../components/ui/modal/Alert.js';

import Colors, { themes } from '../../constants/Colors.js';

import deleteSweep from '../../assets/images/ui/delete-2x.png';

import { Locale, getTheme, getLang } from '../../i18n/locale.js';
import { parseTags } from '../../services/Feed.js';

import { setNews, getNews, remNews } from '../../services/Storage.js';
import { formatDateTimeString } from '../../components/common/Date.js';


export default class ReadScreen extends React.Component {

  state = {
    fontsLoaded: false,
    loginProgress: false,
    markActive: false,
    lang: "kz",
    modalAlertVisible: false,
    list: [],
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
    this.props.navigation.addListener('willFocus', this.load);
    this.setState({ loader: true });
    getNews().then((res) => {
      this.setState({ list: res.reverse(), loader: false });
      ////console.log("my_list",  res)
    });
  }

  load = () => {
    this.setState({ loader: true });
    getLang().then((res) => this.setState({ lang: res }));
    this.changeTheme();
    getNews().then((res) => {
      this.setState({ list: res.reverse(), loader: false });
      // //console.log("my_list",  res)
    });
  }

  changeTheme() {
    getTheme().then((res) => {
      //console.log("theme", res);
      this.setState({ selectedTheme: res });
    });
  }

  closeRow(rowMap, rowKey) {
    if (rowMap[rowKey]) {
      rowMap[rowKey].closeRow();
    }
  }

  readMsg(item, id, rowMap, rowKey) {
    this.setState({ loader: true });
    this.closeRow(rowMap, rowKey);
    //readNotifications(this.state.user.authToken, id).then((res)=>{
    remNews(item).then(() => {
      this.load();
    });
  }

  deleteRow(secId, rowId, rowMap) {
    rowMap[`${secId}${rowId}`].closeRow();
    const newData = [...this.state.list];
    newData.splice(rowId, 1);
    this.setState({ listViewData: newData });
  }


  render() {
    var newsList = this.state.list.map((item, index) => {
      return (
        <UiNewsCardSlide
          key={index}
          selectedTheme={this.state.selectedTheme}
          image={parseTags(item.description).images}
          title={item.title}
          category={item.categories[0].name}
          date={formatDateTimeString(item.published)}
          cardPress={() => { this.props.navigation.navigate("NewsLate", { info: item }) }}
        />
      )
    });
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
          selectedTheme={this.state.selectedTheme}
          btnLeft='back'
          pressLeft={() => navigate('Settings')}
          pressRight={() => navigate('Live')}
        />

        <SafeAreaView style={styles.safeArea} forceInset={{ top: 'never' }}>
          {newsList.length > 0 ?
            <ScrollView style={styles.content}>
              <View style={styles.notification}>

                <SwipeListView
                  data={this.state.list}
                  renderItem={(data, rowMap) => (
                    <View style={styles.rowFront}>
                      <UiNewsCardSlide style={[styles.rowFrontCard]}
                        image={parseTags(data.item.description).images}
                        title={data.item.title}
                        category={data.item.categories[0].name}
                        date={formatDateTimeString(data.item.published)}
                        cardPress={() => { this.props.navigation.navigate("NewsLate", { info: data.item }) }} />
                    </View>
                  )}
                  renderHiddenItem={(data, rowMap) => (
                    <View style={styles.rowBack}>
                      
                      <TouchableOpacity
                        style={[styles.backRightBtn, styles.backRightBtnRight]}
                        onPress={_ => this.readMsg(data.item, data.item.id, rowMap, data.item.key )}>
                        <Text style={styles.backTextWhite}>
                          <Image source={deleteSweep} style={styles.backRightIcon} />
                        </Text>
                      </TouchableOpacity>
                    </View>
                  )}
                  leftOpenValue={75}
                  rightOpenValue={-75}
                />



              </View>

              {/*  <SwipeListView
                    useFlatList
                    onSwipeValueChange={this.onSwipeValueChange}
                    data={this.state.list}
                    renderItem={ (data, rowMap) => (
                        <View style={styles.rowFront}>
                              <UiNewsCardSlide style={[styles.rowFrontCard]} image={parseTags(data.item.description).images}  title={data.item.title} category={data.item.categories[0].name} date={formatDateTimeString(data.item.published)} cardPress={()=>{  this.props.navigation.navigate("NewsLate", {info: data.item } )}} />
                        </View>
                    )}
                    renderHiddenItem={ (data, rowMap) => (
                      <TouchableOpacity onPress={ _=> this.readMsg(data.item, data.item.id, rowMap, data.item.key )}  style={styles.rowBack}>
                        <View style={[styles.backRightBtn, styles.backRightBtnRight]}>
                          <Image source={deleteSweep} style={styles.backRightIcon} />
                        </View>
                      </TouchableOpacity>
                    )}
                    rightOpenValue={-120}
                    /> */}
            </ScrollView>
            :
            <View style={styles.noContent}>
              <UiScreenMsg
                selectedTheme={this.state.selectedTheme}
                noTitle={Locale(global.lang, "no_record")}
                noText={Locale(global.lang, "no_record_text")}
              />
            </View>
          }
        </SafeAreaView>

        <Loader selectedTheme={this.state.selectedTheme} show={this.state.loader} />
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
    marginVertical: 16,
  },
  noContent: {
    flex: 1,
  },

  rowFront: {
    justifyContent: 'center',
  },
  rowBack: {
    backgroundColor: 'rgba(252,63,63,0.37)',
    alignItems: 'center',
    flex: 1,
    flexGrow: 1,
    flexShrink: 1,
    flexDirection: 'row',
    alignItems: 'stretch',
    justifyContent: 'space-between',
    marginLeft: '50%',
    right: 0,
  },
  backRightBtn: {
    alignItems: 'flex-end',
    bottom: 0,
    justifyContent: 'center',
    position: 'absolute',
    top: 0,
    width: 120,
    paddingRight: 24,
    flex: 1,
  },
  backRightBtnRight: {
    right: 0
  },
  backRightIcon: {
    width: 24,
    height: 24,
    resizeMode: 'contain',
  },

  notifNull: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    paddingHorizontal: 44,
  },
  notifNullTitle: {
    fontFamily: 'Roboto-Medium',
    fontSize: 18,
    textAlign: 'center',
    lineHeight: 24,
    color: 'rgb(16,0,43)',
    marginBottom: 8,
  },
  notifNullText: {
    fontFamily: 'Roboto-Regular',
    fontSize: 16,
    textAlign: 'center',
    lineHeight: 22,
    color: 'rgb(138,149,157)',
  },

  rowFront: {
    backgroundColor: '#fff',
    borderBottomWidth: 1,
    justifyContent: 'center',
  },
  rowBack: {
    backgroundColor: 'rgba(252,63,63,0.87)',
    alignItems: 'center',
    flex: 1,
    flexGrow: 1,
    flexShrink: 1,
    flexDirection: 'row',
    alignItems: 'stretch',
    justifyContent: 'space-between',
    marginLeft: '50%',
    right: 0,
  },
  backRightBtn: {
    alignItems: 'flex-end',
    bottom: 0,
    justifyContent: 'center',
    position: 'absolute',
    top: 0,
    width: 120,
    paddingRight: 24,
    flex: 1,
  },
  backRightBtnRight: {
    right: 0
  },
  backRightIcon: {
    width: 24,
    height: 24,
    resizeMode: 'contain',
  },
  notification: {},
  notificationTitle: {
    fontFamily: 'Roboto-Medium',
    fontSize: 16,
    lineHeight: 22,
    color: 'rgb(16,0,43)',
    paddingHorizontal: 16,
    paddingTop: 21,
    paddingBottom: 13,
  },
  notificationView: {
    marginLeft: 16,
    paddingRight: 16,
    paddingVertical: 12,
    borderBottomWidth: 1,
    borderBottomColor: 'rgb(226,224,229)',
  },
  notificationViewType: {
    fontFamily: 'Roboto-Regular',
    fontSize: 14,
    lineHeight: 20,
    color: 'rgb(138,149,157)',
    marginBottom: 2,
  },
  notificationViewTitle: {
    fontFamily: 'Roboto-Regular',
    fontSize: 14,
    lineHeight: 20,
    color: 'rgb(16,0,43)',
  },
  notificationViewText: {
    fontFamily: 'Roboto-Regular',
    fontSize: 12,
    lineHeight: 18,
    color: 'rgb(138,149,157)',
    marginTop: 8,
  },


});
