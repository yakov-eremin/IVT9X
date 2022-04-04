import React from 'react';
import { Platform } from 'react-native';
import { createStackNavigator, createBottomTabNavigator } from 'react-navigation';

import bottomContentComponents from '../navigation/BottomContentComponent';

import HomeScreen from '../screens/HomeScreen';
import WelcomeScreen from '../screens/WelcomeScreen';
import OnBoardScreen from '../screens/onboard/OnBoardScreen';

import LiveScreen from '../screens/live/LiveScreen';

import MainScreen from '../screens/khabar/MainScreen';
import MainP1Screen from '../screens/khabar/MainP1Screen';
import MainP2Screen from '../screens/khabar/MainP2Screen';
import MainP3Screen from '../screens/khabar/MainP3Screen';
import MainP4Screen from '../screens/khabar/MainP4Screen';

import MainCatScreen from '../screens/khabar/MainCatScreen';

import NewsScreen from '../screens/khabar/NewsScreen';
import NewsLateScreen from '../screens/khabar/NewsLateScreen';
import NewsCategoryScreen from '../screens/khabar/NewsCategoryScreen';

import TVProjectsScreen from '../screens/tvproject/TVProjectsScreen';
import ProjectScreen from '../screens/tvproject/ProjectScreen';

import TVProgramScreen from '../screens/tvprogram/TVProgramScreen';

import ReporterScreen from '../screens/reporter/ReporterScreen';

import SettingsScreen from '../screens/more/SettingsScreen';
import ReadScreen from '../screens/more/ReadScreen';
import SettingsMoreScreen from '../screens/more/SettingsMoreScreen';
import LanguageScreen from '../screens/more/LanguageScreen';

import AboutAppScreen from '../screens/more/AboutAppScreen';

import SupportScreen from '../screens/about/SupportScreen';
import PoliticsScreen from '../screens/about/PoliticsScreen';
import ContactUsScreen from '../screens/about/ContactUsScreen';

const config = Platform.select({
  web: { headerMode: 'screen' },
  default: {},
});


const HomeStack = createStackNavigator(
  {
    Home: OnBoardScreen,
  },
  config
);
HomeStack.navigationOptions = {
  tabBarLabel: 'Home',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
HomeStack.path = '';

const WelcomeStack = createStackNavigator(
  {
    Welcome: WelcomeScreen,
  },
  config
);
WelcomeStack.navigationOptions = {
  tabBarLabel: 'Welcome',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
WelcomeStack.path = '';

const OnBoardStack = createStackNavigator(
  {
    OnBoard: OnBoardScreen,
  },
  config
);
OnBoardStack.navigationOptions = {
  tabBarLabel: 'OnBoard',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
OnBoardStack.path = '';

const LiveStack = createStackNavigator(
  {
    Live: LiveScreen,
  },
  config
);
LiveStack.navigationOptions = {
  tabBarLabel: 'Live',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
LiveStack.path = '';

const MainStack = createStackNavigator(
  {
    Main: MainScreen,
  },
  config
);
MainStack.navigationOptions = {
  tabBarLabel: 'Main',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
MainStack.path = '';

const MainP1Stack = createStackNavigator(
  {
    MainP1: MainP1Screen,
  },
  config
);
MainP1Stack.navigationOptions = {
  tabBarLabel: 'MainP1',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
MainP1Stack.path = '';

const MainP2Stack = createStackNavigator(
  {
    MainP2: MainP2Screen,
  },
  config
);
MainP2Stack.navigationOptions = {
  tabBarLabel: 'MainP2',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
MainP2Stack.path = '';

const MainP3Stack = createStackNavigator(
  {
    MainP3: MainP3Screen,
  },
  config
);
MainP3Stack.navigationOptions = {
  tabBarLabel: 'MainP3',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
MainP3Stack.path = '';

const MainP4Stack = createStackNavigator(
  {
    MainP4: MainP4Screen,
  },
  config
);
MainP4Stack.navigationOptions = {
  tabBarLabel: 'MainP4',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
MainP4Stack.path = '';

const MainCatStack = createStackNavigator(
  {
    MainCat: MainCatScreen,
  },
  config
);
MainCatStack.navigationOptions = {
  tabBarLabel: 'MainCat',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
MainCatStack.path = '';


const NewsLateStack = createStackNavigator(
  {
    NewsLate: NewsLateScreen,
  },
  config
);
NewsLateStack.navigationOptions = {
  tabBarLabel: 'News',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
NewsLateStack.path = '';

const NewsStack = createStackNavigator(
  {
    News: NewsScreen,
  },
  config
);
NewsStack.navigationOptions = {
  tabBarLabel: 'News',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
NewsStack.path = '';

const NewsCategoryStack = createStackNavigator(
  {
    NewsCategory: NewsCategoryScreen,
  },
  config
);
NewsCategoryStack.navigationOptions = {
  tabBarLabel: 'NewsCategory',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
NewsCategoryStack.path = '';

const TVProjectsStack = createStackNavigator(
  {
    TVProjects: TVProjectsScreen,
  },
  config
);
TVProjectsStack.navigationOptions = {
  tabBarLabel: 'TVProjects',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
TVProjectsStack.path = '';

const ProjectStack = createStackNavigator(
  {
    Project: ProjectScreen,
  },
  config
);
ProjectStack.navigationOptions = {
  tabBarLabel: 'Project',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
ProjectStack.path = '';

const TVProgramStack = createStackNavigator(
  {
    TVProgram: TVProgramScreen,
  },
  config
);
TVProgramStack.navigationOptions = {
  tabBarLabel: 'TVProgram',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
TVProgramStack.path = '';

const ReporterStack = createStackNavigator(
  {
    Reporter: ReporterScreen,
  },
  config
);
ReporterStack.navigationOptions = {
  tabBarLabel: 'Reporter',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
ReporterStack.path = '';

const SettingsStack = createStackNavigator(
  {
    Settings: SettingsScreen,
  },
  config
);
SettingsStack.navigationOptions = {
  tabBarLabel: 'Settings',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
SettingsStack.path = '';

const ReadStack = createStackNavigator(
  {
    Read: ReadScreen,
  },
  config
);
ReadStack.navigationOptions = {
  tabBarLabel: 'Read',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
ReadStack.path = '';

const SettingsMoreStack = createStackNavigator(
  {
    SettingsMore: SettingsMoreScreen,
  },
  config
);
SettingsMoreStack.navigationOptions = {
  tabBarLabel: 'SettingsMore',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
SettingsMoreStack.path = '';

const LanguageStack = createStackNavigator(
  {
    Language: LanguageScreen,
  },
  config
);
LanguageStack.navigationOptions = {
  tabBarLabel: 'Language',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
LanguageStack.path = '';



const AboutAppStack = createStackNavigator(
  {
    AboutApp: AboutAppScreen,
  },
  config
);
AboutAppStack.navigationOptions = {
  tabBarLabel: 'AboutApp',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
AboutAppStack.path = '';

const SupportStack = createStackNavigator(
  {
    Support: SupportScreen,
  },
  config
);
SupportStack.navigationOptions = {
  tabBarLabel: 'Support',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
SupportStack.path = '';

const ContactUsStack = createStackNavigator(
  {
    ContactUs: ContactUsScreen,
  },
  config
);
ContactUsStack.navigationOptions = {
  tabBarLabel: 'ContactUs',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
ContactUsStack.path = '';

const PoliticsStack = createStackNavigator(
  {
    Politics: PoliticsScreen,
  },
  config
);
PoliticsStack.navigationOptions = {
  tabBarLabel: 'Politics',
  tabBarVisible: false,
  tabBarComponent:  bottomContentComponents,
};
PoliticsStack.path = '';





const tabNavigator = createBottomTabNavigator({
  HomeStack,
  WelcomeStack,
  OnBoardStack,
  LiveStack,
  MainStack,
  MainP1Stack,
  MainP2Stack,
  MainP3Stack,
  MainP4Stack,

  MainCatStack,
  NewsStack,
  NewsLateStack,
  NewsCategoryStack,
  TVProjectsStack,
  ProjectStack,

  TVProgramStack,

  ReporterStack,

  SettingsStack,
  ReadStack,
  SettingsMoreStack,
  LanguageStack,
  AboutAppStack,

  SupportStack,
  ContactUsStack,
  PoliticsStack,
  
});

tabNavigator.path = '';

export default tabNavigator;
