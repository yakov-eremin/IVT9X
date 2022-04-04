import React from 'react';
import { StyleSheet, Text, View } from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import { ValidateInput } from '../../../components/common/Validator.js' 
import { TextInputMask } from 'react-native-masked-text';

import Colors, {themes} from '../../../constants/Colors.js';

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
  //RSS
}

export default class UiTextInputMasked extends React.Component {
  
  state = { 
    fontsLoaded: false,
    inputValidation: true,
    lang: "ru",
    dt: '',
  };

  constructor(props){
    super(props);
  }

  componentDidMount() { 
    Font.loadAsync({
      'Roboto-Regular': require('../../../assets/fonts/Roboto-Regular.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
    this.setState({dt: ''});
  }

  shouldComponentUpdate(nProps,nState){
    if(nProps.clear != undefined && nProps.clear){
      //console.log('upd');
      this.setState({inputValidation: true, validationType: '', dt: ''});
      this.props.clearCallBack(false);
    }
    return true;
  }

  handlerFocus = (input) => {
    if(this.props.inputValue) {  this.setState({ inputValidation: this.props.inputValue, dt:this.props.inputValue  });    }
    this.setState({
        [input]:true
    });
  };

  handlerBlur = (input) => {
    this.handlerValidation('inputValidation', this.props.validationType , this.state.dt );
    this.setState({
        [input]:false
    });
  };

  handlerValidation = (input, key, value) => {
    this.setState({
      [input]: ValidateInput(key, value)
    });
    //this.props.callBack(value);
  };

  render() {
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }
    return (
      <View style={styles.input}>
        <TextInputMask
          style={[
            styles.textInput, 
            this.props.selectedTheme == 'night' ? {color: themes.night.uiText, borderColor: themes.night.uiLine} : {color: themes.normal.uiText, borderColor: themes.normal.uiLine},
            this.state.inputFocus ? styles.textBlured:'',
            !this.state.inputValidation ? styles.inputDanger:'', 
          ]}
          refInput={ref => { this.TextInputMask = ref }} 
          type={this.props.type}
          options={this.props.format}
          value={ this.state.dt == '' && this.props.inputValue ? this.props.inputValue : this.state.dt }
          onChangeText={text => {
            if(this.props.validationType == "phone"){
              if(text[1]=='8'){
                text = "+7";
              }  
            }
            this.setState({
              dt: text
            })
            this.setState({
              ['inputValidation']:text
            });
            if(this.props.inputFocus) this.props.callBack(text);
            if(this.props.callBack) this.props.callBack(text);
            if(this.props.callBackValidation) this.props.callBackValidation(this.state.inputValidation);
          }}
          onFocus = {() => this.handlerFocus('inputFocus')}
          onBlur = {() => this.handlerBlur('inputFocus')}
                    
          placeholder={this.props.placeholder}
          placeholderTextColor={Colors.colLightGray}
          autoCapitalize={this.props.autoCapitalize}
          autoFocus={this.props.inputFocus}
          keyboardType={this.props.keyboardType}
          maxLength={this.props.maxLength}
          secureTextEntry={this.props.secureTextEntry}
          textContentType={this.props.textContentType}
          allowFontScaling={false}

          multiline={this.props.multiline}
          numberOfLines={this.props.numberOfLines}
        />
        <Text style={[
          styles.warnText, 
          this.state.inputValidation ? styles.hideWarnText:'' 
        ]}>
         {Locale(this.state.lang, "wrong_date")}
        </Text>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  textInput: {
    fontSize: 16,
    lineHeight: 20,
    color: Colors.uiDark,
    height: 48,
    borderWidth: 1,
    borderRadius: 8,
    marginBottom: 8,
    paddingHorizontal: 16,
    fontFamily: 'Roboto-Regular',
  },
  textBlured: {
    borderColor: Colors.uiBlue,
  },
  inputDanger: {
    borderColor: Colors.uiRed,
  },
  warnText: {
    color: Colors.uiRed,
    fontSize: 12,
    marginBottom: 8,
    marginTop: -4,
    lineHeight: 18,
    letterSpacing: 0.19,
    fontFamily: 'Roboto-Regular',
  },
  hideWarnText: {
    opacity: 0,
    marginTop: -8,
    height: 0,
  },

});
