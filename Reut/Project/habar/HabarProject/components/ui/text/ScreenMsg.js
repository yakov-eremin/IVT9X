import React from 'react';
import { 
  StyleSheet, 
  Text, 
  View, 
  Image, 
  Alert
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import cancelIcon from '../../../assets/images/ui/cancel-2x.png';

import Colors, {themes} from '../../../constants/Colors.js';

import UiButtonBlue from '../../../components/ui/button/ButtonBlue.js';
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

export default class UiScreenMsg extends React.Component {
  
  state = { 
    fontsLoaded: false,
    lang: "ru",
   };

  constructor(props){
    super(props);
  }

  componentDidMount = async() => { 
    await Font.loadAsync({
      'Roboto-Regular': require('../../../assets/fonts/Roboto-Regular.ttf'),
      'Roboto-Medium': require('../../../assets/fonts/Roboto-Medium.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
  }

  render() {
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }

    return (
      <View style={styles.screenMsg}>
        {this.props.noTitle ? <Image source={cancelIcon} style={styles.noContentImage} /> : null}
        {this.props.noTitle ? 
          <Text style={[
            styles.noContentTitle, 
            this.props.selectedTheme == 'night' ? {color: themes.night.uiCardTitle} : {color: themes.normal.uiCardTitle} ]}
          >
            {this.props.noTitle}
          </Text>
          : null
        }
        <Text style={styles.noContentText}>{this.props.noText}</Text>
        {this.props.noButton ?
          <UiButtonBlue 
            selectedTheme={this.props.selectedTheme}
            buttonText = {this.props.buttonText ? this.props.buttonText : this.props.noButtonText  }
            onPress={()=>  this.props.onPress()}
          />
        : null }
      </View>
    );
  }
}

const styles = StyleSheet.create({
  screenMsg: {
    flex: 1,
    justifyContent: 'flex-start',
    alignItems: 'center',
    paddingTop: 60,
    paddingHorizontal: 60,
  },
  noContentImage: {
    width: 48,
    height: 48,
    resizeMode: 'contain',
  },
  noContentTitle: {
    fontFamily: 'Roboto-Medium',
    fontSize: 20,
    lineHeight: 24,
    marginTop: 16,
    marginBottom: 4,
    textAlign: 'center',
  },
  noContentText: {
    fontFamily: 'Roboto-Regular',
    fontSize: 14,
    lineHeight: 16,
    color: Colors.colGray,
    textAlign: 'center',
    marginBottom: 24,
  },

});
