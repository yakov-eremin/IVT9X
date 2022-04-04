import * as WebBrowser from 'expo-web-browser';
import React from 'react';
import {
  StyleSheet,
  View,
  SafeAreaView,
  ScrollView,
  Alert
} from 'react-native';

import { Notifications } from 'expo';
import * as Permissions from 'expo-permissions';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import Loader from '../../components/ui/Loader.js';
import UiHeader from '../../components/ui/header/Header.js';
import UiSubScrollHeader from '../../components/ui/header/SubScrollHeader.js';
import UiTabs from '../../components/ui/tabs/Tabs.js';

import UiProgramCard from '../../components/ui/cards/ProgramCard.js';
import UiClearCard from '../../components/ui/cards/ClearAndroidCard.js';
import UiScreenMsg from '../../components/ui/text/ScreenMsg.js';
import UiAlert from '../../components/ui/modal/Alert.js';
import UiModal from '../../components/ui/modal/Modal.js';

import Colors, {themes} from '../../constants/Colors.js';

import {Locale, getLang, getTheme} from '../../i18n/locale.js';

import {formatDateTimeString, formatTimeString} from '../../components/common/Date.js';
import {parseTags, getTv_Programm} from '../../services/Feed.js';

export default class TVProgramScreen extends React.Component  {

  state = {
    fontsLoaded: false,
    loginProgress: false,
    markActive: false,
    modalAlertVisible: false,
    modalTimeVisible: false,
    offline: false,
    selectedItem: {},
    programms: [],
    searchNews: [],
    sorttingProgramms: {
      today: [],
      tomorrow: [],
      yesterday: [],
    },
    selectedSchedule: [],
    lang: "kz",
  }

  static navigationOptions = {
    header: null,
  };

  componentDidMount = async() => { 
    await Font.loadAsync({
      'Roboto-Regular': require('../../assets/fonts/Roboto-Regular.ttf'),
      'Roboto-Medium': require('../../assets/fonts/Roboto-Medium.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
  
  
      this.setState({loader: true});
      getTv_Programm(global.lang).then((rss) => {
        //console.log(rss.items.length  );
        let sort = this.sortByDate(rss.items);
        let dd = new Date();
        //console.log("a", sort[dd.getDay()]);
        this.setState({offline: false, sorttingProgramms: sort , programms: sort[dd.getDay()], loader: false });
        this.scrollTo();
      }).catch((res)=>{
        //console.log(res);
        Alert.alert("Внимание", "Ошибка сети");
        this.setState({offline: true, loader: false})
      });
  
    this.changeTheme();
    this.askPermissions();
    this.props.navigation.addListener('willFocus', this.load);
  }

  askPermissions = async () => {
    const { status: existingStatus } = await Permissions.getAsync(Permissions.NOTIFICATIONS);
    let finalStatus = existingStatus;
    if (existingStatus !== "granted") {
      const { status } = await Permissions.askAsync(Permissions.NOTIFICATIONS);
      finalStatus = status;
    }
    if (finalStatus !== "granted") {
      return false;
    }
    return true;
  };

  scheduleNotification = async (time) => {
    
    this.addScheduleList(this.state.selectedItem.published);

    let std =  this.state.selectedItem.published.slice(0, 25);
    console.log(std);
    var d = new Date(std),
    month =  (d.getMonth() ),
    day =  d.getDate(),
    year = d.getFullYear();
    hour = d.getHours();
    min = d.getMinutes();

    if(min < time){
      hour = hour-1;
      min = 60 + (min - time);
    } else {
      min = min - time;
    }

    if(day  < 10) day = '0'+day;
    if(hour  < 10) hour = '0'+hour;
 
    if(min  < 10) min = '0'+min;


    var oldDateObj = new Date(year+'-'+(month+1)+'-'+day+'T'+hour+':'+min+':00.000Z');
    
    console.log("HHMM", hour, min, oldDateObj);
   // oldDateObj.setHours(hour);
   // oldDateObj.setMinutes(min - time);
    
    console.log(oldDateObj);

    let notificationId = Notifications.scheduleLocalNotificationAsync(
      {
        title: "Уведомление",
        body: 'Скоро начнется '+ this.state.selectedItem.title,
        android: { sound: true }, // Make a sound on Android
        ios: { sound: true }, // Make a sound on iOS
      },
      {
        //repeat: 'minute',
        time: oldDateObj,
      },
    );
    //console.log(this.state.selectedItem.published, new Date(this.state.selectedItem.published).getTime() + time*10000 ,notificationId);
  };

  sortByDate(arr){
    var arrToday = [ [],[],[],[],[],[],[],[] ];
    var currDate = new Date();
    var currDay = currDate.getDate();
    arr.map((item)=>{
      let std = item.published.slice(0, 25)
      let dd = new Date(std);
      let d = dd.getDay();
      arrToday[d].push(item);
      
    });
    
    return arrToday;

  }

  isCurrent(item, item2){
    var _item2 = item2;
    let dd2 = new Date( );
    if(_item2 == undefined){
    }  else {
      let std2 = _item2.published.slice(0, 25);
      dd2 = new Date(std2);
    }
    var currDate = new Date();
    var hh = currDate.getHours(), mm = currDate.getMinutes();
    var ff = false;

    let std = item.published.slice(0, 25);
    let dd = new Date(std);
    if( (dd.getTime() < currDate.getTime() ) && ( currDate.getTime() <  dd2.getTime() ) ){
      
      ff = true;
    }
    return ff;
  }

  isOld(item){
    var currDate = new Date();
    var hh = currDate.getHours(), mm = currDate.getMinutes();
    var ff = false;
    let std = item.published.slice(0, 25);
    let dd = new Date(std);
    if( (dd.getTime() > currDate.getTime() )  ){
      ff = true;
    }
    return ff;
  }

  inScheduleList(time){
    let ff = false;
    this.state.selectedSchedule.map((item)=>{
      if(item == time) ff = true;
    })
    return ff;
  }

  addScheduleList(time){
    let arr = this.state.selectedSchedule;
    arr.push(time);
    this.setState({selectedSchedule: arr});
  }

  scrollTo(){
    this.state.programms.map((item,index)=>{
      if(this.isCurrent(item, this.state.programms[index+1] ) ){
        console.log("scroll",index*100);
        setTimeout(()=> this.myScroll.scrollTo({ x: 0, y: index*50 + 100 , animated: true }) , 200);
      }
    });

    
  }



  load = () => { 
    this.setState({loader: true});
    getLang().then((res)=> {
      this.setState({lang: res});
      getTv_Programm(global.lang).then((rss) => {
        this.setState({programmms: rss.items, loader: false });
        this.scrollTo();
      });
    });
    this.changeTheme();
  }

  changeTheme(){
    getTheme().then((res)=>  {
      //console.log("theme", res);
      this.setState({selectedTheme: res});
    });
  }

  setModalTimeVisible(visible) {
    this.setState({modalTimeVisible: visible});
  }

  render() {
    const {navigate} = this.props.navigation;
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }

    var list =  this.state.programms.map((item,index)=>{
        let date = new Date();
       
        if(this.isCurrent(item, this.state.programms[index+1] ) ){

          
          return (
            <UiProgramCard 
              key={index} 
              selectedTheme={this.state.selectedTheme}
              pastProgram 
              image={item.enclosures[0].url} 
              title={item.title} 
              live={true}
              category={item.categories[0].name} 
              date={formatTimeString(item.published)} 
              onPress={()=> {
                
                  navigate('Live')
                 
              } }
              bookMarkActiv={this.inScheduleList(item.published)}
              bookMarkPress={()=> {
                this.setState({selectedItem: item, modalTimeVisible: true});
              }} 
            />
          )
        } else {
          
             
            return (
              <UiProgramCard 
                key={index} 
                selectedTheme={this.state.selectedTheme}
                title={item.title} 
                image={item.enclosures[0].url} 
                category={item.categories[0].name} 
                date={formatTimeString(item.published)} 
                onPress={()=> {
                  
                } }
                pastProgram={!this.isOld(item)}
                live={false}
                bookMarkActiv={this.inScheduleList(item.published)}
                bookMarkPress={()=> {
                  this.setState({selectedItem: item, modalTimeVisible: true});
                }} 
              />
            )
       
        }
    });

    return (
      <View style={[
        styles.container,
        this.state.selectedTheme == 'night' ? {backgroundColor: themes.night.uiBg} : {backgroundColor: themes.normal.uiBg} 
      ]}>
        <UiHeader 
          selectedTheme={this.state.selectedTheme}
          headerText={Locale(global.lang, "tv_programm_header")}
          pressRight={()=> navigate('Live')}
        />
        <UiSubScrollHeader 
          selectedTheme={this.state.selectedTheme}
      
          callBack={(val)=>{
            //console.log(val)
            if(val == 1){
              this.setState({programms: this.state.sorttingProgramms[1]})
            }else if(val == 2){
              this.setState({programms:this.state.sorttingProgramms[2]})
            }else if(val == 3){
              this.setState({programms: this.state.sorttingProgramms[3]})
            }else if(val == 4){
              this.setState({programms: this.state.sorttingProgramms[4]})
            }else if(val == 5){
              this.setState({programms: this.state.sorttingProgramms[5]})
            }else if(val == 6){
              this.setState({programms: this.state.sorttingProgramms[6]})
            }else if(val == 7){
              this.setState({programms: this.state.sorttingProgramms[0]})
            } 
          }}
 
        />

        <SafeAreaView style={styles.safeArea} forceInset={{top:'never'}}>
          {this.state.offline ?
            <View style={styles.noContent}>
              <UiScreenMsg 
                selectedTheme={this.state.selectedTheme}
                noTitle="Телепрограмма не доступна"
                noText="Проверьте интернет соединение и обновите страницу"
              />
            </View> : 
            <ScrollView  ref={(ref) => this.myScroll = ref} style={styles.content}>
              {list}
            </ScrollView>
          }
          
        </SafeAreaView>

        <UiTabs 
          selectedTheme={this.state.selectedTheme}
          navigation={this.props.navigation}
          activeTabs={3}
        />

        <UiAlert 
          modalVisible={this.state.modalAlertVisible} 
          alertTitle={Locale(global.lang, "create_notification")}
          alertText={Locale(global.lang, "create_notification_text")} 
          okText={Locale(global.lang, "yes")}
          cancelText={Locale(global.lang, "cancel")}
          cancelPress={() => {this.setState({modalAlertVisible: !this.state.modalAlertVisible}) }}
          okPress={() => {
            Linking.openURL('tel:8-800-500-03-03');
            this.setState({modalAlertVisible: !this.state.modalAlertVisible});
          }}
        />

        <UiModal 
          subtitle={Locale(global.lang, "notification_time")}
          buttonText={Locale(global.lang, "notification_time_5m")}
          buttonText1={Locale(global.lang, "notification_time_15m")}
          buttonText2={Locale(global.lang, "notification_time_30m")}
          buttonText3={Locale(global.lang, "notification_time_60m")}
          buttonCancel={Locale(global.lang, "cancel")}
          modalButtonFunc={() => {
            this.setModalTimeVisible(!this.state.modalTimeVisible);
            this.scheduleNotification(5);
          }}
          modalButtonFunc1={() => {
            this.setModalTimeVisible(!this.state.modalTimeVisible)
            this.scheduleNotification(15);
          }}
          modalButtonFunc2={() => {
            this.setModalTimeVisible(!this.state.modalTimeVisible)
            this.scheduleNotification(30);
          }}
          modalButtonFunc3={() => {
            this.setModalTimeVisible(!this.state.modalTimeVisible)
            this.scheduleNotification(60);
          }}
          modalButtonCancel={() => {
            this.setModalTimeVisible(!this.state.modalTimeVisible)
          }}
          modalVisible={this.state.modalTimeVisible}
          modalUnvisble={() => {this.setModalTimeVisible(!this.state.modalTimeVisible)}}
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
  },
  noContent: {
    flex: 1,
  },
  
});
