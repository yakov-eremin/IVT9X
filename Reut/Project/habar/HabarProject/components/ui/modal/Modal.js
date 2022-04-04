import React from 'react';
import { 
  StyleSheet, 
  Modal, 
  View,
  Text,
  Alert,
  TouchableOpacity,
  TouchableHighlight,
} from 'react-native';

import { isIphoneX } from '../../isIphoneX';
const bottomX = isIphoneX() ? 38 : 8;

export default class UiModal extends React.Component {

  constructor(props){
    super(props);
  }

  render() {
    return (
      <Modal
        animationType="fade"
        transparent={true}
        visible={this.props.modalVisible}
        onRequestClose={() => {
        //  Alert.alert('Modal has been closed.');
      }}>
        <View style={styles.modal}>
          <TouchableOpacity 
            style={styles.modalClose}
            onPress={ this.props.modalUnvisble }
          >
          </TouchableOpacity>
          <View style={styles.modalInner}>

            {!this.props.subtitle ? 
              null : 
              <Text style={styles.subtitleText}>{this.props.subtitle}</Text>
            }
            
            <TouchableHighlight underlayColor='rgb(245,245,245)' 
              style={styles.modalButton}
              onPress={this.props.modalButtonFunc}
            >
              <Text style={styles.modalButtonText}>{this.props.buttonText}</Text>
            </TouchableHighlight>

            {!this.props.buttonText1 || this.props.hideButton1 ?
              null : 
              <TouchableHighlight underlayColor='rgb(245,245,245)' 
                style={styles.modalButton}
                onPress={this.props.modalButtonFunc1}
              >
                <Text style={styles.modalButtonText}>{this.props.buttonText1}</Text>
              </TouchableHighlight>
            }
            {!this.props.buttonText2 ? 
              null :
              <TouchableHighlight underlayColor='rgb(245,245,245)' 
                style={styles.modalButton}
                onPress={this.props.modalButtonFunc2}
              >
                <Text style={styles.modalButtonText}>{this.props.buttonText2}</Text>
              </TouchableHighlight>
            }
            {!this.props.buttonText3 ? 
              null :
              <TouchableHighlight underlayColor='rgb(245,245,245)' 
                style={styles.modalButton}
                onPress={this.props.modalButtonFunc3}
              >
                <Text style={styles.modalButtonText}>{this.props.buttonText3}</Text>
              </TouchableHighlight>
            }
            {!this.props.buttonCancel ? 
              null :
              <TouchableHighlight underlayColor='rgb(245,245,245)' 
                style={styles.modalButton}
                onPress={this.props.modalButtonCancel}
              >
                <Text style={styles.modalButtonText}>{this.props.buttonCancel}</Text>
              </TouchableHighlight>
            }

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
    backgroundColor: 'rgba(0,0,0,0.68)',
    justifyContent: 'flex-end',
  },
  modalClose: {
    flexGrow: 1,
  },
  modalInner: {
    backgroundColor: '#fff',
    borderTopLeftRadius: 5,
    borderTopRightRadius: 5,
    shadowColor: '#000',
    shadowOffset: {
      width: 0,
      height: 0,
    },
    shadowOpacity: 0.35,
    shadowRadius: 5,
    elevation: 3,
    paddingTop: 8,
    paddingBottom: bottomX,
  },
  subtitleText: {
    paddingHorizontal: 16,
    paddingVertical: 13,
    fontSize: 14,
    lineHeight: 22,
    letterSpacing: 0.13,
    color: 'rgb(138,149,157)',
    fontFamily: 'Roboto-Regular',
  },
  modalButton: {
    height: 48,
    alignItems: 'center',
    justifyContent: 'space-between',
    paddingHorizontal: 16,
    flexDirection: 'row',
    backgroundColor: 'rgb(255,255,255)',
  },
  modalButtonText: {
    fontSize: 16,
    lineHeight: 24,
    letterSpacing: 0.15,
    color: 'rgb(16,0,43)',
  },

})

 