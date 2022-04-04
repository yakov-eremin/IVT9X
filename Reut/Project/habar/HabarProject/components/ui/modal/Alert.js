import React from 'react';
import { 
  StyleSheet, 
  Modal, 
  View,
  Text,
  Image,
  TouchableOpacity,
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

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

export default class UiAlert extends React.Component {

  constructor(props){
    super(props);
  }

  state = {
    lang: "ru",
  }

  componentDidMount() { 
    Font.loadAsync({
      'Roboto-Medium': require('../../../assets/fonts/Roboto-Medium.ttf'),
      'Roboto-Regular': require('../../../assets/fonts/Roboto-Regular.ttf'),
    }).then( () => this.setState( { fontsLoaded: true } ) );
  }

  render() {
    return (
      <Modal
        animationType="fade"
        transparent={true}
        visible={this.props.modalVisible}
        onRequestClose={() => {
          Alert.alert('Modal has been closed.');
        }}>
        <View style={styles.modal}>
          <View style={styles.modalAlert}>
            {!this.props.alertImage ? null :
              <Image source={this.props.alertImage} style={styles.alertIconImage} />
            }
            {!this.props.alertTitle ? null :
              <Text style={styles.modalAlertTitle}>{this.props.alertTitle}</Text>
            }
            <Text style={styles.modalAlertText}>{this.props.alertText}</Text>
            {this.props.alertText2 ? 
              <Text style={styles.modalAlertText}>{this.props.alertText2}</Text>
              : null
            }
            {this.props.alertText3 ? 
              <Text style={styles.modalAlertText}>{this.props.alertText3}</Text>
              : null
            }
            <View style={styles.modalAlertButtons}>
            {this.props.cancelPress ?
                <TouchableOpacity 
                  style={[styles.button, {paddingHorizontal: 12}]}
                  onPress={this.props.cancelPress}
                >
                  {this.props.cancelTitle ?  <Text style={styles.buttonText}>{this.props.cancelTitle}</Text> : <Text style={styles.buttonText}>{this.props.cancelText} </Text> }
                </TouchableOpacity>
              : null }

             {!this.props.okPress ? null :
                <TouchableOpacity 
                  style={[styles.button, {paddingHorizontal: 20}]}
                  onPress={this.props.okPress}
                >
                  {this.props.okTitle ?  <Text style={styles.buttonText}>{this.props.okTitle}</Text> : <Text style={styles.buttonText}>{this.props.okText} </Text> }
                </TouchableOpacity>
              }
           
             
            </View>
          </View>
        </View>
      </Modal>
    )
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  modal: {
    flex: 1,
    backgroundColor: 'rgba(0,0,0,0.6)',
    alignItems: 'center',
    justifyContent: 'center',
  },
  modalAlert: {
    width: 310,
    borderRadius: 8,
    backgroundColor: '#fff',
    paddingTop: 16,
    paddingLeft: 16,
    paddingBottom: 8,
    paddingRight: 8,
  },
  alertIconImage: {
    width: 36,
    height: 36,
    resizeMode: 'contain',
    marginBottom: 16,
  },
  modalAlertTitle: {
    fontFamily: 'Roboto-Medium',
    fontSize: 18,
    lineHeight: 24,
    color: 'rgb(16,0,43)',
    marginBottom: 12,
  },
  modalAlertText: {
    fontFamily: 'Roboto-Regular',
    fontSize: 14,
    lineHeight: 20,
    color: 'rgb(138,149,157)',
    marginRight: 16,
    marginBottom: 16,
  },
  modalAlertButtons: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'flex-end',
  },
  button: {
    paddingVertical: 8,
    marginLeft: 8,
  },
  buttonText: {
    fontFamily: 'Roboto-Medium',
    fontSize: 14,
    lineHeight: 20,
    color: 'rgb(39,51,76)',
  },

})

 