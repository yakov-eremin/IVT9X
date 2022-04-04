import React from 'react';
import { 
  StyleSheet, 
  Platform, 
  View, 
} from 'react-native';

export default class UiClearCard extends React.Component {

  constructor(props){
    super(props);
  }

  render() {
    return (
      <View style={[styles.clearCard, Platform.OS == 'ios' ? {height: 24} : {height: 32}]}>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  newsCard: {
    width: '100%',
  },
});