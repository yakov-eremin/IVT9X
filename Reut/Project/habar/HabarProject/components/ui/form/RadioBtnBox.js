import React from 'react';
import { StyleSheet, Text, View, Image, Platform, TouchableOpacity } from 'react-native';
import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import radioImage from '../../../assets/images/ui/check-2x.png';

import Colors, {themes} from '../../../constants/Colors.js';

export default class UiRadioBtnBox extends React.Component {
  
  state = { 
    fontsLoaded: false,
    radioBoxActive: 0,
  };

  constructor(props){
    super(props);
  }

  componentDidMount() { 
    Font.loadAsync({
      'Roboto-Medium': require('../../../assets/fonts/Roboto-Medium.ttf'),
      'Roboto-Regular': require('../../../assets/fonts/Roboto-Regular.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );

   
  }

  componentDidUpdate(nProps,nState){
    if(nProps.clear != undefined && nProps.clear){
      this.setState({ radioBoxActive: null });
      this.props.clearCallBack(!nProps.clear);
    }
    if(nProps.defaultValue  != this.props.defaultValue){
      this.setState({radioBoxActive: this.props.defaultValue})
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
            this.props.selectedTheme == 'night' ? {backgroundColor: themes.night.uiCardBg} : {backgroundColor: themes.normal.uiBg},
            this.state.radioBoxActive == item.value && this.props.selectedTheme == 'night' ? {backgroundColor: themes.night.uiBlue} : null,
            this.state.radioBoxActive == item.value && this.props.selectedTheme != 'night' ? {backgroundColor: themes.normal.uiBlue} : null
          ]} 
          key={index}
        >
          <Text style={[
            styles.radioBoxText, 
            this.props.selectedTheme == 'night' ? {color: Colors.colWhite} : {color: Colors.colDark},
            this.state.radioBoxActive == item.value ? styles.activeBoxText : null
          ]}>
            {item.title}
          </Text>
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
    height: 32,
    width: 240,
    marginVertical: 8,
    flexDirection: 'row',
    justifyContent: 'center',
    alignItems: 'center',
    borderRadius: 16,
    overflow: 'hidden',
  },
  radioBoxInner: {
    height: 32,
    width: 120,
    flexDirection: 'row',
    justifyContent: 'center',
    alignItems: 'center',
    paddingHorizontal: 16,
  },
  radioBoxText: {
    fontSize: 14,
    lineHeight: 22,
    fontFamily: 'Roboto-Medium',
  },
  activeBoxText: {
    color: Colors.colWhite,
  },
  radioBoxImage: {
    width: 16,
    height: 16,
    resizeMode: 'contain',
    marginRight: 8,
  },

});
