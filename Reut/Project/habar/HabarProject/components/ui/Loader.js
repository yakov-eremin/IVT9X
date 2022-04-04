import React, { Component } from 'react'
import {
  ActivityIndicator,
  AppRegistry,
  StyleSheet,
  Text,
  Image,
  View,
  Animated,
  Easing ,
} from 'react-native'

import Colors from '../../constants/Colors.js';

export default class Loader extends React.Component {

  constructor(props) {
    super(props)
    this.state = {
      visible: props.show
    }
  }

  rotateValue = new Animated.Value(0); 

  componentDidMount(){
  }

  render() {
    if(this.props.show){
      return (
        <View style={[styles.container, this.props.selectedTheme == 'night' ? {backgroundColor: 'rgba(0, 0, 0, 0.85)'} : {backgroundColor: 'rgba(255, 255, 255, 0.85)'}]}>
          <View style={styles.loader}>
            <ActivityIndicator size="large" color={Colors.colBlue} />
          </View>
        </View>
      )
    } else {
      return (null);
    }
  }
}

const styles = StyleSheet.create({
  container: {
    position: 'absolute',
    top: 0,
    left: 0,
    zIndex: 9999,
    width: '100%',
    height: '100%',
  },
  loader: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  },

});
