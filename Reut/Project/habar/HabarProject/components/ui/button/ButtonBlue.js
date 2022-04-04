import React from 'react';
import { StyleSheet, Text, TouchableOpacity } from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import Colors, {themes} from '../../../constants/Colors.js';

export default class UiButtonBlue extends React.Component {
  
  state = { fontsLoaded: false };

  constructor(props){
    super(props);
  }

  componentDidMount() { 
    Font.loadAsync({
      'Roboto-Medium': require('../../../assets/fonts/Roboto-Medium.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
  }

  render() {
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }

    return (
      <TouchableOpacity 
        style={[
          styles.blueButton, 
          this.props.selectedTheme == 'night' ? {backgroundColor: themes.night.uiBlue} : {backgroundColor: themes.normal.uiBlue},
          this.props.disabled ? styles.disButton : null,
        ]} 
        disabled={this.props.disabled} 
        onPress={this.props.onPress}
      >
        <Text style={[styles.blueButtonText, this.props.disabled ? styles.disButtonText : null]}>
          {this.props.buttonText}
        </Text>
      </TouchableOpacity>
    );
  }
}

const styles = StyleSheet.create({
  blueButton: {
    borderRadius: 8,
    alignItems: 'center',
    justifyContent: 'center',
    height: 48,
    width: '100%',
  },
  disButton: {
    backgroundColor: Colors.colTitanWhite,
  },
  blueButtonText: {
    color: Colors.colWhite,
    fontSize: 16,
    lineHeight: 20,
    letterSpacing: 0.25,
    fontFamily: 'Roboto-Medium',
  },
  disButtonText: {
    color: Colors.colBlueGrey,
  },

});
