import React from 'react';
import { StyleSheet, Text, Image, TouchableOpacity } from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import Colors, {themes} from '../../../constants/Colors.js';

import addIcon from '../../../assets/images/ui/radio-add-2x.png';
import selectIcon from '../../../assets/images/ui/radio-select-2x.png';
import closeIcon from '../../../assets/images/ui/close-2x.png';


export default class UiButtonIcon extends React.Component {
  
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
          styles.button, 
          this.props.selectedTheme == 'night' ? {
            backgroundColor: themes.night.uiCardBg,
            borderBottomColor: themes.night.uiBgGray,
          } : {
            backgroundColor: themes.normal.uiCardBg,
            borderBottomColor: themes.normal.uiBgGray,
          },
          this.props.disabled ? styles.disButton : null
        ]} 
        disabled={this.props.disabled} 
        onPress={this.props.onPress}
      >
        {this.props.selected ? 
          <Image style={styles.iconClose} source={closeIcon} /> :
          <Image style={styles.icon} source={addIcon} />
        }
        <Text style={[
          styles.buttonText, 
          this.props.selectedTheme == 'night' ? {color: themes.night.uiCardTitle} : {color: themes.normal.uiCardTitle},
          this.props.disabled ? styles.disButtonText : null,
        ]}>
          {this.props.buttonText}
        </Text>
      </TouchableOpacity>
    );
  }
}

const styles = StyleSheet.create({
  button: {
    borderBottomWidth: 1,
    alignItems: 'center',
    justifyContent: 'center',
    height: 48,
    width: '100%',
    flexDirection: 'row',
    paddingHorizontal: 16,
  },
  disButton: {
    backgroundColor: 'rgb(226,224,229)',
  },
  buttonText: {
    fontSize: 16,
    lineHeight: 20,
    letterSpacing: 0.25,
    fontFamily: 'Roboto-Medium',
    flexGrow: 1,
    flexShrink: 1,
  },
  disButtonText: {
    color: 'rgb(138,149,157)',
  },
  icon: {
    flexGrow: 0,
    flexShrink: 0,
    width: 24,
    height: 24,
    marginRight: 12,
    resizeMode: 'contain',
  },
  iconClose: {
    flexGrow: 0,
    flexShrink: 0,
    width: 24,
    height: 24,
    marginRight: 12,
    resizeMode: 'contain',
    backgroundColor: '#003865',

  },

});
