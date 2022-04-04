import * as WebBrowser from 'expo-web-browser';
import React from 'react';
import {
  StyleSheet,
  Switch,
  Platform,
  Dimensions,
  View,
  SafeAreaView,
  ScrollView,
  Image,
  Text,
  TouchableOpacity,
  Alert
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';
import * as ImagePicker from 'expo-image-picker';
import * as Permissions from 'expo-permissions';
import * as DocumentPicker from 'expo-document-picker';
import * as MailComposer from 'expo-mail-composer';

import Colors, {themes} from '../../constants/Colors.js';

import Loader from '../../components/ui/Loader.js';
import UiHeader from '../../components/ui/header/Header.js';
import UiTabs from '../../components/ui/tabs/Tabs.js';

import UiTextInput from '../../components/ui/form/TextInput.js';
import UiTextInputLines from '../../components/ui/form/TextInputLines.js';
import UiTextInputMasked from '../../components/ui/form/TextInputMasked.js';
import UiCheckBox from '../../components/ui/form/CheckBox.js';
import UiButtonBlue from '../../components/ui/button/ButtonBlue.js';
import UiButtonSmBlue from '../../components/ui/button/ButtonSmBlue.js';

import iconDelete from '../../assets/images/ui/delete-2x.png';
import { getSettingsUF } from '../../services/Feed.js';
import {Locale, getLang, getTheme} from '../../i18n/locale.js';


export default class ReporterScreen extends React.Component  {

  state = {
    fontsLoaded: false,
    loginProgress: false,
    nightEnabled: false,
    isConfirm: true,
    lang: "kz",
    title: "",
    content: "",
    phone: "",
    selectedUri: [],
    mail: "",
  }

  static navigationOptions = {
    header: null,
  };

  
  askPermissionsAsync = async () => {
    await Permissions.askAsync(Permissions.CAMERA);
    await Permissions.askAsync(Permissions.CAMERA_ROLL);
  };

  componentDidMount = async() => { 
    await Font.loadAsync({
      'Roboto-Regular': require('../../assets/fonts/Roboto-Regular.ttf'),
      'Roboto-Medium': require('../../assets/fonts/Roboto-Medium.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
  
    getLang().then((res)=>  this.setState({lang: res}) );
    this.changeTheme();
    this.props.navigation.addListener('willFocus', this.load);
    //this.getRSS();

    getSettingsUF().then((res)=>{
      res = JSON.parse(res);
      //console.log(res.settings)
      if(res.settings.mail != ""){
        this.setState({mail:res.settings.mail })
 
      }
    })


    const permission = await Permissions.getAsync(Permissions.CAMERA_ROLL);
    if (permission.status !== 'granted') {
        const newPermission = await Permissions.askAsync(Permissions.CAMERA_ROLL);
        if (newPermission.status === 'granted') {
          //its granted.
        }
    } 
  }

  _pickImage = async () => {
    let result = await ImagePicker.launchImageLibraryAsync({
      allowsEditing: true,
      aspect: [4, 3],
    });

    if (!result.cancelled) {
      await this._promisedSetState({modalAlertAddVisible: false, loader: true });
      let uri =  Platform.OS === "android" ? result.uri : result.uri.replace("file://", "");
      
      let _filename = result.uri.split('/').pop();
      let uriParts =  result.uri.split('.');
      let fileType = uriParts[uriParts.length - 1];

     
            
          uploadImageAsync(this.state.user.authToken, result.uri).then((res)=>{
            //console.log("upload_log_i", res);
            this._promisedSetState({loader: false });
            let _type = this.state.typesListRadio;
            _type.splice(0,1);
            //this.props.navigation.navigate('MedCardAdd',{file: res.result , category: this.state.categorysListRadio , type: _type, procedureName: ''  });
          }).catch((res)=> console.log("err",res));
 
      //this.setState({modalAlertAddVisible: !this.state.modalAlertAddVisible});
      //this.setState({ dealPhoto: result.uri, dealPhotoCard: result.uri, });
    } else {
      this.setState({modalAlertAddVisible: !this.state.modalAlertAddVisible});
    }
  };
 
  _pickDocument = () => {
    
    if(Platform.OS == 'ios'){
      this._pickImage();
    } else {
      DocumentPicker.getDocumentAsync({}).then((result)=>{
         //console.log("ew",result);
         if(result.type == "cancel"){
          this._promisedSetState({modalAlertAddVisible: false, loader: false });
         } else {
              let _filename = result.uri.split('/').pop();
              let uriParts =  result.uri.split('.');
              let fileType = uriParts[uriParts.length - 1];

              this._promisedSetState({modalAlertAddVisible: false });
              //console.log("fileType", fileType );
           
                let arr = this.state.selectedUri;
                arr.push(result.uri);  
                this.setState({ selectedUri : arr});
             
              
         }

      });
      
      //uploadResult = await uploadResponse.json();
    }
  }

  _sendMail = () =>{
    if(this.state.title.length > 3 && this.state.phone.length > 7 &&  this.state.content.length > 3 ){

      let email = this.state.mail; // The email exists.
      //let dir = `${Expo.FileSystem.documentDirectory}data/file.txt`; // The file exists.
      MailComposer.composeAsync({
          recipients: [email],
          subject: `Народный репортер`,
          attachments: this.state.selectedUri,
          body: 'Название: '+this.state.title+'\r\n Телефон: '+this.state.phone+'\r\n Описание: '+this.state.content,
          isHtml: false,
      }).then((res)=> {
        //console.log(res)
      });

    } else {
      Alert.alert("Внимание", "Заполните все поля")
    }
   
  }

  _promisedSetState = (newState) => {
    return new Promise((resolve) => {
        this.setState(newState, () => {
            resolve();
        });
    });
  }

  load = () => { 
    getLang().then((res)=>  this.setState({lang: res}) );
    this.changeTheme();
    //RSS
  }

  changeTheme(){
    getTheme().then((res)=>  {
      //console.log("theme", res);
      this.setState({selectedTheme: res});
    });
  }

  render() {
    const { navigate } = this.props.navigation;
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }

    return (
      <View style={[
        styles.container,
        this.state.selectedTheme == 'night' ? {backgroundColor: themes.night.uiBg} : {backgroundColor: themes.normal.uiBg}
      ]}>
        <UiHeader 
          selectedTheme={this.state.selectedTheme}
          headerText={Locale(global.lang, "reporter")}
          pressRight={()=> navigate('Live')}
        />

        <SafeAreaView style={styles.safeArea} forceInset={{top:'never'}}>
          <ScrollView style={styles.content}>
            <Text style={[
              styles.title,
              this.state.selectedTheme == 'night' ? {color: themes.night.uiCardTitle} : {color: themes.normal.uiCardTitle}
            ]}>
              {Locale(global.lang, "contact_phone")}
            </Text>
            <UiTextInputMasked 
              maxLength={16}
              type="custom"
              keyboardType="phone-pad" 
              format={{ mask: '+9(999) 999 9999'}} 
              validationType="phone"
              placeholder={Locale(global.lang, "contact_phone")}
              placeholderTextColor={this.state.selectedTheme == 'night' ? themes.night.uiText : null }
              selectedTheme={this.state.selectedTheme}
              callBack={(val)=> this.setState({phone:val})}
            />
            <Text style={[
              styles.title,
              this.state.selectedTheme == 'night' ? {color: themes.night.uiCardTitle} : {color: themes.normal.uiCardTitle}
            ]}>
              {Locale(global.lang, "news_title")}
            </Text>
            <UiTextInput 
              placeholder={Locale(global.lang, "news_title")}
              placeholderTextColor={this.state.selectedTheme == 'night' ? themes.night.uiText : null }
              maxLength={200}
              selectedTheme={this.state.selectedTheme}
              callBack={(val)=> this.setState({title:val})}
            />

            {/* 
            <Text style={[
              styles.title,
              this.state.selectedTheme == 'night' ? {color: themes.night.uiCardTitle} : {color: themes.normal.uiCardTitle}
            ]}>
              {Locale(global.lang, "date_time")}
            </Text>
            <UiTextInputMasked 
              maxLength={18}
              type="datetime"
              keyboardType="number-pad" 
              format={{format: 'DD.MM.YYYY / HH:mm'}} 
              validationType="birthday"
              placeholder={Locale(global.lang, "date_time")}
              selectedTheme={this.state.selectedTheme}
            />
          */} 

            <Text style={[
              styles.title,
              this.state.selectedTheme == 'night' ? {color: themes.night.uiCardTitle} : {color: themes.normal.uiCardTitle}
            ]}>
              {Locale(global.lang, "news_about")}
            </Text>
            <UiTextInputLines 
              placeholder={Locale(global.lang, "news_about")}
              placeholderTextColor={this.state.selectedTheme == 'night' ? themes.night.uiText : null }
              multiline={true}
              numberOfLines={3}
              selectedTheme={this.state.selectedTheme}
              callBack={(val)=> this.setState({content:val})}
            />
            <Text style={[
              styles.title,
              this.state.selectedTheme == 'night' ? {color: themes.night.uiCardTitle} : {color: themes.normal.uiCardTitle}
            ]}>
              {Locale(global.lang, "photo_and_video")}
            </Text>
            <UiButtonSmBlue 
              buttonText={Locale(global.lang, "load")} 
              onPress={()=> this._pickDocument() }
              selectedTheme={this.state.selectedTheme} 
            />
            <View style={styles.load}>
              <Text style={[
                styles.loadText,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText}
              ]}>
                {Locale(global.lang, "min_size")}
              </Text>
              <Text style={[
                styles.loadText,
                this.state.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText}
              ]}>
                {Locale(global.lang, "max_size")}
              </Text>
            </View>
            {/*<View style={styles.loadList}>
              <View style={styles.loadListItem}>
                <Text 
                  style={styles.itemTitle} 
                  numberOfLines={1} 
                  ellipsizeMode="tail"
                >
                  my_photo_123.png
                </Text>
                <Text style={styles.itemSize}>512КБ</Text>
                <TouchableOpacity style={styles.itemDelete}>
                  <Image source={iconDelete} style={styles.itemIcon} />
                </TouchableOpacity>
              </View>
              <View style={styles.loadListItem}>
                <Text 
                  style={styles.itemTitle} 
                  numberOfLines={1} 
                  ellipsizeMode="tail"
                >
                  my_video_123.png
                </Text>
                <Text style={styles.itemSize}>2МБ</Text>
                <TouchableOpacity style={styles.itemDelete}>
                  <Image source={iconDelete} style={styles.itemIcon} />
                </TouchableOpacity>
              </View>
              <View style={styles.loadListItem}>
                <Text 
                  style={styles.itemTitle} 
                  numberOfLines={1} 
                  ellipsizeMode="tail"
                >
                  add_report_new_photo_long_name_1234567890.png
                </Text>
                <Text style={styles.itemSize}>1,2МБ</Text>
                <TouchableOpacity style={styles.itemDelete}>
                  <Image source={iconDelete} style={styles.itemIcon} />
                </TouchableOpacity>
              </View>
            </View>*/}
            <View style={styles.reportCheck}>
              <UiCheckBox 
                selectedTheme={this.state.selectedTheme}
                labelText={Locale(global.lang, "no_read_label")}
                smallBoxText={true}
                callBack={(res)=>{
                  this.setState({ isConfirm: res })
                  //console.log(res)
                }}
              />
            </View>
            <UiButtonBlue 
              disabled={this.state.isConfirm}
              selectedTheme={this.state.selectedTheme} 
              buttonText={Locale(global.lang, "send")}
              onPress={()=> this._sendMail() }
            />
          </ScrollView>
        </SafeAreaView>

        

        <UiTabs 
          selectedTheme={this.state.selectedTheme}
          navigation={this.props.navigation}
          activeTabs={4}
        />

        <Loader 
          selectedTheme={this.state.selectedTheme} 
          show={this.state.loginProgress} 
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
    marginVertical: 8,
    marginHorizontal: 16,
  },
  title: {
    color: Colors.uiBlue,
    fontFamily: 'Roboto-Medium',
    fontSize: 16,
    lineHeight: 20,
    marginTop: 8,
    marginBottom: 4,
  },
  load: {
    marginVertical: 4,
  },
  loadText: {
    fontFamily: 'Roboto-Regular',
    fontSize: 10,
    lineHeight: 10,
    letterSpacing: 1,
    color: Colors.uiLightGray,
  },
  reportCheck: {
    marginVertical: 8,
  },
  loadList: {
    width: '100%',
  },
  loadListItem: {
    height: 48,
    flexDirection: 'row',
    borderBottomColor: Colors.uiLine,
    borderBottomWidth: 1,
    justifyContent: 'space-between',
    alignItems: 'center',
  },
  itemTitle: {
    fontFamily: 'Roboto-Regular',
    fontSize: 14,
    lineHeight: 16,
    flexGrow: 1,
    flexShrink: 1,
    color: Colors.uiDark,
  },
  itemSize: {
    width: 60,
    fontFamily: 'Roboto-Regular',
    fontSize: 14,
    lineHeight: 16,
    flexGrow: 0,
    flexShrink: 0,
    textAlign: 'right',
    color: Colors.uiLightGray,
  },
  itemDelete: {
    height: 48,
    width: 48,
    flexGrow: 0,
    flexShrink: 0,
    justifyContent: 'center',
    alignItems: 'center',
  },
  itemIcon: {
    height: 24,
    width: 24,
    resizeMode: 'contain',
  },
  
});
