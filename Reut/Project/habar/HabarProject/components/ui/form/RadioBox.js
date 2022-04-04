import React from 'react';
import { StyleSheet, Text, View, Image, Platform, TouchableOpacity } from 'react-native';
import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import radioActiveImage from '../../../assets/images/ui/radio-select-2x.png';
import radioImage from '../../../assets/images/ui/radio-2x.png';
import radioLightImage from '../../../assets/images/ui/radio-light-2x.png';
import radioLight from '../../../assets/images/ui/rad-light-2x.png';

import Colors, {themes} from '../../../constants/Colors';

export default class UiRadioBox extends React.Component {
  
  state = { 
    fontsLoaded: false,
    radioBoxActive: 0,
  };

  constructor(props){
    super(props);
  }

  componentDidMount() { 
    Font.loadAsync({
      'Roboto-Regular': require('../../../assets/fonts/Roboto-Regular.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
   
    
  }

  shouldComponentUpdate(nProps,nState){
    if(nProps.clear != undefined && nProps.clear){
      this.setState({ radioBoxActive: null });
      this.props.clearCallBack(!nProps.clear);
    }
 
    if(nProps.defaultValue != undefined && nProps.defaultValue != this.state.radioBoxActive ){
      
      this.setState({ radioBoxActive: nProps.defaultValue });
    }

    return true;
  }

  setValue = (value) => {
    this.setState({ radioBoxActive: value });
    this.props.callBack(value);
  }

  render() {
    if( !this.state.fontsLoaded ) {
      return <AppLoading/>
    }
    
    var List = this.props.itemList.map((item,index)=>{
      return (
          <TouchableOpacity 
            onPress={()=>{ this.setValue(item.value) }} 
            style={[
              styles.radioBoxInner, 
              this.props.selectedTheme == 'night' ? {borderBottomColor: themes.night.uiLine} : {borderBottomColor: themes.normal.uiLine},
              (index === this.props.itemList.length - 1) ? styles.lastInner : null 
            ]} 
            key={index}
          >
            <Text style={[
              styles.radioBoxText,
              this.props.selectedTheme == 'night' ? {color: themes.night.uiText} : {color: themes.normal.uiText},
            ]}>
              {item.title}
            </Text>
            {this.state.radioBoxActive != item.value ? 
              <View style={styles.radioBoxButton}>
                {this.props.selectedTheme == 'night' ? 
                  <Image source={radioLight} style={styles.radioBoxImage}/> : 
                  <Image source={radioImage} style={styles.radioBoxImage}/> 
                }
              </View> :
              <View style={styles.radioBoxButton}>
                {this.props.selectedTheme == 'night' ? 
                  <Image source={radioLightImage} style={styles.radioBoxImage}/> : 
                  <Image source={radioActiveImage} style={styles.radioBoxImage}/> 
                }
              </View>
            }
          </TouchableOpacity>
      );
    });

    return (
      <View style={styles.radioBox}>
        {List}
      </View>
    );
  }
}

const styles = StyleSheet.create({
  radioBox: {
    
  },
  radioBoxInner: {
    height: 48,
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginLeft: 16,
    paddingRight: 16,
    borderBottomWidth: 1,
  },
  lastInner: {
    borderBottomWidth: 0,
  },
  radioBoxButton: {
    width: 24,
    height: 24,
    flexGrow: 0,
    flexShrink: 0,
  },
  radioBoxImage: {
    width: 24,
    height: 24,
    resizeMode: 'contain',
  },
  radioBoxText: {
    flexGrow: 1,
    flexShrink: 1,
    fontSize: 16,
    lineHeight: 22,
    fontFamily: 'Roboto-Regular',
  },

});
