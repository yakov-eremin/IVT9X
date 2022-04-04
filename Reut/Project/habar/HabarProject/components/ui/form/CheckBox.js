import React from 'react';
import { StyleSheet, Text, View, Image, TouchableOpacity } from 'react-native';
import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import checkImage from '../../../assets/images/ui/checkbox-2x.png';
import checkActiveImage from '../../../assets/images/ui/checkbox-check-2x.png';
import checkLight from '../../../assets/images/ui/check-light-2x.png';
import checkLightImage from '../../../assets/images/ui/checkbox-light-2x.png';

import Colors, {themes} from '../../../constants/Colors';

export default class UiCheckBox extends React.Component {
  
  state = { 
    fontsLoaded: false,
    checkBoxActive: false,
  };

  constructor(props){
    super(props);
  }

  componentDidMount() { 
    Font.loadAsync({
      'Roboto-Regular': require('../../../assets/fonts/Roboto-Regular.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
  }

  render() {
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }

    return (
      <TouchableOpacity style={styles.checkBox} onPress={()=> {
        this.setState({checkBoxActive:!this.state.checkBoxActive});
        this.props.callBack(this.state.checkBoxActive);
      }}>
        <View style={styles.checkBoxButton} >
          {this.state.checkBoxActive ? 
            <View>
              {this.props.selectedTheme == 'night' ?
                <Image source={checkLightImage} style={styles.checkBoxImage}/> 
                :
                <Image source={checkActiveImage} style={styles.checkBoxImage}/> 
              }
            </View>
            : 
            <View>
              {this.props.selectedTheme == 'night' ?
                <Image source={checkLight} style={styles.checkBoxImage}/>
                :
                <Image source={checkImage} style={styles.checkBoxImage}/>
              }
            </View>
          }
        </View>
        <Text style={[
          styles.checkBoxText, 
          this.props.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText},
          this.props.smallBoxText ? styles.smallBoxText : null,
        ]}>
          {this.props.labelText}
        </Text>
      </TouchableOpacity>
    );
  }
}

const styles = StyleSheet.create({
  checkBox: {
    height: 48,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'center',
  },
  checkBoxButton: {
    width: 24,
    height: 48,
    marginRight: 12,
    flexGrow: 0,
    flexShrink: 0,
    alignItems: 'center',
    justifyContent: 'center',
  },
  checkBoxImage: {
    width: 24,
    height: 24,
    resizeMode: 'contain',
  },
  checkBoxText: {
    fontSize: 16,
    lineHeight: 20,
    fontFamily: 'Roboto-Regular',
  },
  smallBoxText: {
    fontSize: 14,
    lineHeight: 16,
    flexGrow: 1,
    flexShrink: 1,
    flexWrap: 'wrap',
  },

});
