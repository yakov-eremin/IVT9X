import { AppLoading } from 'expo';
import { Asset } from 'expo-asset';
import * as Font from 'expo-font';
import React, { useState } from 'react';
import { Platform, StatusBar, StyleSheet, View } from 'react-native';
import { Ionicons } from '@expo/vector-icons';

import AppNavigator from './navigation/AppNavigator';

export default function App(props) {
  const [isLoadingComplete, setLoadingComplete] = useState(false);

  if (!isLoadingComplete && !props.skipLoadingScreen) {
    return (
      <AppLoading
        startAsync={loadResourcesAsync}
        onError={handleLoadingError}
        onFinish={() => handleFinishLoading(setLoadingComplete)}
      />
    );
  } else {
    return (
      <View style={styles.container}>
        {Platform.OS === 'ios' && <StatusBar barStyle="default" />}
        <AppNavigator />
      </View>
    );
  }
}

async function loadResourcesAsync() {
  await Promise.all([
    Asset.loadAsync([
      require('./assets/images/robot-dev.png'),
      require('./assets/images/robot-prod.png'),
      require('./assets/images/logo.png'),

      require('./assets/images/about/bulb-blue-2x.png'),
      require('./assets/images/about/bulb-light-2x.png'),
      require('./assets/images/about/comment-blue-2x.png'),
      require('./assets/images/about/comment-light-2x.png'),
      require('./assets/images/about/mobile-blue-2x.png'),
      require('./assets/images/about/mobile-light-2x.png'),
      require('./assets/images/about/share-blue-2x.png'),
      require('./assets/images/about/share-light-2x.png'),
      require('./assets/images/about/star-blue-2x.png'),
      require('./assets/images/about/star-light-2x.png'),
      require('./assets/images/about/unlock-blue-2x.png'),
      require('./assets/images/about/unlock-light-2x.png'),

      require('./assets/images/cards/bell.png'),
      require('./assets/images/cards/bell-blue.png'),
      require('./assets/images/cards/bell-outline.png'),
      require('./assets/images/cards/clock.png'),
      require('./assets/images/cards/eye.png'),
      require('./assets/images/cards/play-red.png'),
      require('./assets/images/cards/youtube.png'),

      require('./assets/images/notification/deleteSweep.png'),
      require('./assets/images/notification/deleteSweep-3x.png'),

      require('./assets/images/onboard/slide1-2x.png'),
      require('./assets/images/onboard/slide2-2x.png'),
      require('./assets/images/onboard/slide3-2x.png'),
      require('./assets/images/onboard/slide4-2x.png'),
      require('./assets/images/onboard/slide5-2x.png'),

      require('./assets/images/tabs/ellipsis-2x.png'),
      require('./assets/images/tabs/ellipsis-blue-2x.png'),
      require('./assets/images/tabs/ellipsis-light-2x.png'),
      require('./assets/images/tabs/khabar-blue-2x.png'),
      require('./assets/images/tabs/khabar-light-2x.png'),
      require('./assets/images/tabs/khabar-outline-2x.png'),
      require('./assets/images/tabs/program-2x.png'),
      require('./assets/images/tabs/program-blue-2x.png'),
      require('./assets/images/tabs/program-light-2x.png'),
      require('./assets/images/tabs/program-outline-2x.png'),
      require('./assets/images/tabs/project-2x.png'),
      require('./assets/images/tabs/project-blue-2x.png'),
      require('./assets/images/tabs/project-light-2x.png'),
      require('./assets/images/tabs/project-outline-2x.png'),
      require('./assets/images/tabs/report-2x.png'),
      require('./assets/images/tabs/report-blue-2x.png'),
      require('./assets/images/tabs/report-light-2x.png'),
      require('./assets/images/tabs/report-outline-2x.png'),

      require('./assets/images/ui/arrowBack-2x.png'),
      require('./assets/images/ui/bookmark.png'),
      require('./assets/images/ui/bookmark-blue.png'),
      require('./assets/images/ui/bookmark-outline.png'),
      require('./assets/images/ui/cancel-2x.png'),
      require('./assets/images/ui/check-2x.png'),
      require('./assets/images/ui/checkbox-2x.png'),
      require('./assets/images/ui/checkbox-check-2x.png'),
      require('./assets/images/ui/checkbox-light-2x.png'),
      require('./assets/images/ui/check-light-2x.png'),
      require('./assets/images/ui/chevronRight-2x.png'),
      require('./assets/images/ui/close-2x.png'),
      require('./assets/images/ui/cloud-2x.png'),
      require('./assets/images/ui/cogs.png'),
      require('./assets/images/ui/cogs-blue.png'),
      require('./assets/images/ui/delete-2x.png'),
      require('./assets/images/ui/globe.png'),
      require('./assets/images/ui/globe-blue.png'),
      require('./assets/images/ui/globe-light.png'),
      require('./assets/images/ui/like-blue-2x.png'),
      require('./assets/images/ui/like-outline-2x.png'),
      require('./assets/images/ui/link-2x.png'),
      require('./assets/images/ui/near-2x.png'),
      require('./assets/images/ui/radio-2x.png'),
      require('./assets/images/ui/radio-add-2x.png'),
      require('./assets/images/ui/radio-light-2x.png'),
      require('./assets/images/ui/radio-select-2x.png'),
      require('./assets/images/ui/rad-light-2x.png'),
      require('./assets/images/ui/rectangle-2x.png'),
      require('./assets/images/ui/sad-2x.png'),
      require('./assets/images/ui/search-2x.png'),
      require('./assets/images/ui/searchClear-2x.png'),
      require('./assets/images/ui/setting-2x.png'),
      require('./assets/images/ui/youtube.png'),
      
    ]),
    Font.loadAsync({
      // This is the font that we are using for our tab bar
      ...Ionicons.font,
      // We include SpaceMono because we use it in HomeScreen.js. Feel free to
      // remove this if you are not using it in your app
      'space-mono': require('./assets/fonts/SpaceMono-Regular.ttf'),
    }),
  ]);
}

function handleLoadingError(error) {
  // In this case, you might want to report the error to your error reporting
  // service, for example Sentry
  console.warn(error);
}

function handleFinishLoading(setLoadingComplete) {
  setLoadingComplete(true);
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
});
