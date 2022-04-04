import React from 'react';
import { 
  StyleSheet, 
  View,
  Text, 
  Image, 
  TouchableOpacity,
  TextInput,
  StatusBar,
  Platform } from 'react-native';
  
import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import { isIphoneX } from '../../isIphoneX';

import Colors, {themes} from '../../../constants/Colors.js';

import arrowBack from '../../../assets/images/ui/arrowBack-2x.png';
import closeBack from '../../../assets/images/ui/close-2x.png';
import cloudIcon from '../../../assets/images/ui/cloud-2x.png';
import settingIcon from '../../../assets/images/ui/setting-2x.png';
import searchIcon from '../../../assets/images/ui/search-2x.png';
import searchClose from '../../../assets/images/ui/searchClear-2x.png';
import khabarLogo from '../../../assets/images/logo.png';

const statusHeight = Platform.OS === 'ios' ? 20 : StatusBar.currentHeight;
const statusX = isIphoneX() ? 30 : 0;
const headerTop = statusHeight + statusX;
const heightHeader = 56 + headerTop;

import {Locale, getLang} from '../../../i18n/locale.js';

 
export default class UiHeaderWithLogo extends React.Component {

  state = { 
    fontsLoaded: false, 
    searchActive: false,
    lang: "ru",
    searchText: '',
  };

  constructor(props){
    super(props);
  }

  componentDidMount = async() => { 
    await Font.loadAsync({
      'Roboto-Medium': require('../../../assets/fonts/Roboto-Medium.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
    getLang().then((res)=>  this.setState({lang: res}) );
  }


  search(val){
    var resArr = [];
    this.props.items.map((item,index)=>{
        var  addr = item.title.toLowerCase();
        if( addr.indexOf(val.toLowerCase()) !== -1) resArr.push(item);
    });
    this.props.searchCallBack({searchRes: resArr});
  }


  render() {
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }
    return (
      <View style={[styles.header, this.props.selectedTheme == 'night' ? {backgroundColor: themes.night.uiBlue} : {backgroundColor: themes.normal.uiBlue}]}>
        <StatusBar barStyle="light-content" />
        {!this.state.searchActive ?
          /* Search Input Close */
          <View style={styles.headerCtrl}>
            {/* Left Buttons Bar */}
            <View style={styles.leftSide}>
            {this.props.pressSettings ?
                <TouchableOpacity onPress={this.props.pressSettings} style={styles.button}>
                  <Image source={settingIcon} style={styles.buttonImage} /> 
                </TouchableOpacity>
              : null}
              {this.props.pressLeft || !this.props.pressSave || !this.props.pressSettings ? 
                <TouchableOpacity onPress={this.props.pressLeft} style={styles.button}>
                  {this.props.btnLeft == 'back' ? 
                    <Image source={arrowBack} style={styles.buttonImage} /> 
                  : null}
                  {this.props.btnLeft == 'close' ? 
                    <Image source={closeBack} style={styles.buttonImage} /> 
                  : null}
                </TouchableOpacity>
              : null}
              
              
            </View>
            {/* Center Title */}
            {this.props.headerText ? 
              <Text style={[styles.title, !this.props.pressLeft && this.props.searchHeader ? {marginRight: -65} : {marginRight: -9}]}>{this.props.headerText}</Text> :
              <Image source={khabarLogo} style={styles.logo} />
            }
            {/* Right Buttons Bar */}
            <View style={styles.rightSide}>
              {this.props.searchHeader ? 
                <TouchableOpacity style={styles.button} onPress={()=> {
                  this.setState({searchActive:true});
                  this.props.isSearchCallBack(true);
                } }>
                  <Image source={searchIcon} style={styles.buttonImage} />
                </TouchableOpacity>
              :null}
              {this.props.pressRight ? 
                <TouchableOpacity onPress={this.props.pressRight} style={[styles.button, styles.buttonLive]}>
                  <Text style={styles.liveText}>LIVE</Text>
                </TouchableOpacity>
              : null}
              {this.props.pressBtnRight ? 
                <TouchableOpacity onPress={this.props.pressBtnRight} style={styles.button}>
                  <Text style={styles.buttonText}>{Locale(global.lang, "save")}</Text>
                </TouchableOpacity>
              : null}
            </View>

          </View>
          :
          /* Search Input Open */
          <View style={styles.headerSearch}>
            <TextInput 
              style={styles.headerInput}
      
              onChangeText={(res)=>{ this.search(res) }}
              value={this.state.text}
              placeholder={this.props.searchText}
              placeholderTextColor="#fff"
            />
            <TouchableOpacity style={styles.button} onPress={()=>{
              this.props.isSearchCallBack(false);
              this.setState({searchActive:false});
            } }>
              <Image source={searchClose} style={styles.buttonImage} />
            </TouchableOpacity>
          </View>
        }

      </View>
    );
  }
}

const styles = StyleSheet.create({
  header: {
    flexGrow: 0,
    flexShrink: 0,
    flexDirection: 'row',
    width: '100%',
    height: heightHeader,
    paddingTop: headerTop,
    alignItems: 'center',
    justifyContent: 'center',
  },
  headerCtrl: {
    flexDirection: 'row',
    width: '100%',
    height: '100%',
    alignItems: 'center',
    justifyContent: 'space-between',
  },
  headerSearch: {
    flexDirection: 'row',
    width: '100%',
    height: '100%',
    alignItems: 'center',
    justifyContent: 'space-between',
  },
  leftSide: {
    height: 55,
    flexDirection: 'row',
    flexGrow: 0,
    flexShrink: 0,
    alignItems: 'center',
    justifyContent: 'flex-start',
  },
  rightSide: {
    height: 55,
    flexDirection: 'row',
    flexGrow: 0,
    flexShrink: 0,
    alignItems: 'center',
    justifyContent: 'flex-end',
  },
  button: {
    minWidth: 56,
    height: 55,
    alignItems: 'center',
    justifyContent: 'center',
  },
  buttonLive: {
    width: 65,
    paddingRight: 16,
    alignItems: 'flex-end',
  },
  buttonImage: {
    width: 24,
    height: 24,
    resizeMode: 'contain',
  },
  title: {
    color: Colors.colWhite,
    fontSize: 17,
    lineHeight: 21,
    fontFamily: 'Roboto-Medium',
  },
  logo: {
    height: 42,
    width: 42,
    marginLeft:60,
  },
  liveText: {
    color: Colors.colRed,
    fontSize: 14,
    lineHeight: 16,
    fontFamily: 'Roboto-Medium',
    backgroundColor: Colors.colWhite,
    paddingHorizontal: 8,
  },
  headerInput: {
    height: '100%',
    color: Colors.colWhite,
    paddingHorizontal: 16,
    flexGrow: 1,
    flexShrink: 1,
  },
  buttonText: {
    color: Colors.colWhite,
    fontSize: 14,
    lineHeight: 20,
    fontFamily: 'Roboto-Medium',
    paddingHorizontal: 16,
  },

});