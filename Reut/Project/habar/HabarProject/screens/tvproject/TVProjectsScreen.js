import * as WebBrowser from 'expo-web-browser';
import React from 'react';
import {
  StyleSheet,
  View,
  SafeAreaView,
  ScrollView,
  Keyboard,
  Alert
} from 'react-native';

import { AppLoading } from 'expo';
import * as Font from 'expo-font';

import Loader from '../../components/ui/Loader.js';
import UiHeaderProjects from '../../components/ui/header/HeaderProjects.js';
import UiTabs from '../../components/ui/tabs/Tabs.js';

import UiProjectCard from '../../components/ui/cards/ProjectCard.js';
import UiNewsCard from '../../components/ui/cards/NewsCard.js';
import UiClearCard from '../../components/ui/cards/ClearAndroidCard.js';
import UiScreenMsg from '../../components/ui/text/ScreenMsg.js';
import UiButtonIcon from '../../components/ui/button/ButtonIcon.js'

import { formatDateTimeString } from '../../components/common/Date.js';

import Colors, { themes } from '../../constants/Colors.js';

import { parseTags, getNews, getPopularNews, getTv_Projects, getCategorys, getCategorysTV, getTv } from '../../services/Feed.js';
import { Locale, getLang, getTheme } from '../../i18n/locale.js';

export default class TVProjectsScreen extends React.Component {

  state = {
    fontsLoaded: false,
    loginProgress: false,
    markActive: false,
    loader: false,
    isSearch: false,
    lang: "kz",
    tvNews: [],
    searchNews: [],
    catNews: [],
    showCategory: false, 


    catMyProjectsRus: [
      {title:"Агробизнес", value: "https://24.kz/ru/tv-projects/agrobiznes?format=feed"},
      {title:"Актуально", value: "https://24.kz/ru/tv-projects/aktualno?format=feed"},
      {title:"Әскер KZ", value: "https://24.kz/ru/tv-projects/sker-kz?format=feed"},
      {title:"Бастау керек", value: "https://24.kz/ru/tv-projects/bastau-kerek?format=feed"},
      {title:"Блог в помощь", value: "https://24.kz/ru/tv-projects/blog-v-pomoshch?format=feed"},
      {title:"Большие города", value: "https://24.kz/ru/tv-projects/bolshie-goroda?format=feed"},
      {title:"Брифинг", value: "https://24.kz/ru/tv-projects/brifing?format=feed"},
      {title:"Большая страна", value: "https://24.kz/ru/tv-projects/bolshaya-strana?format=feed"},
      {title:"Блогеры 2.0", value: "https://24.kz/ru/tv-projects/blogery-2-0?format=feed"},
      {title:"Большой спорт", value: "https://24.kz/ru/tv-projects/bolshoj-sport?format=feed"},
      {title:"Бюро расследований", value: "https://24.kz/ru/tv-projects/byuro-rassledovanij?format=feed"},
      {title:"Білім", value: "https://24.kz/ru/tv-projects/bilim?format=feed"},
      {title:"В деталях", value: "https://24.kz/ru/tv-projects/v-detalyakh?format=feed"},
      {title:"Дело особой важности", value: "https://24.kz/ru/tv-projects/delo-osoboj-vazhnosti?format=feed"},
      {title:"Деловые новости", value: "https://24.kz/ru/tv-projects/delovye-novosti?format=feed"},
      {title:"Вопросы Экономики", value: "https://24.kz/ru/tv-projects/voprosy-ekonomiki?format=feed"},
      {title:"Городская среда", value: "https://24.kz/ru/tv-projects/gorodskaya-sreda?format=feed"},
      {title:"Драйв", value: "https://24.kz/ru/tv-projects/drajv?format=feed"},
      {title:"Зеленая экономика", value: "https://24.kz/ru/tv-projects/zelenaya-ekonomika?format=feed"},
      {title:"История в лицах", value: "https://24.kz/ru/tv-projects/istoriya-v-litsakh?format=feed"},
      {title:"Интервью", value: "https://24.kz/ru/tv-projects/intervyu?format=feed"},
      {title:"Инфографика", value: "https://24.kz/ru/tv-projects/infograifka?format=feed"},
      {title:"Как это сделано в Казахстане", value: "https://24.kz/ru/tv-projects/kak-eto-sdelano-v-kazakhstane?format=feed"},
      {title:"Кабинеты", value: "https://24.kz/ru/tv-projects/kabinety?format=feed"},
      {title:"Квадратный метр", value: "https://24.kz/ru/tv-projects/kvadratnyj-metr?format=feed"},
      {title:"Кинобизнес", value: "https://24.kz/ru/tv-projects/kinobiznes?format=feed"},
      {title:"Круглый стол", value: "https://24.kz/ru/tv-projects/kruglyj-stol?format=feed"},
      {title:"Культвояж", value: "https://24.kz/ru/tv-projects/kultvoyazh?format=feed"},
      {title:"Между строк", value: "https://24.kz/ru/tv-projects/mezhdu-strok?format=feed"},
      {title:"Мегаполис", value: "https://24.kz/ru/tv-projects/megapolis?format=feed"},
      {title:"Мегастройки столицы", value: "https://24.kz/ru/tv-projects/megastrojki-stolitsy?format=feed"},
      {title:"Медицина", value: "https://24.kz/ru/tv-projects/meditsina?format=feed"},
      {title:"Мир за неделю", value: "https://24.kz/ru/tv-projects/mir-za-nedelyu?format=feed"},
      {title:"На страже", value: "https://24.kz/ru/tv-projects/na-strazhe?format=feed"},
      {title:"Новости культуры", value: "https://24.kz/ru/tv-projects/novosti-kultury?format=feed"},
      {title:"Новости одной строкой", value: "https://24.kz/ru/tv-projects/novosti-odnoj-strokoj?format=feed"},
      {title:"Олимп", value: "https://24.kz/ru/tv-projects/olimp?format=feed"},
      {title:"Особое мнение", value: "https://24.kz/ru/tv-projects/osoboe-mnenie?format=feed"},
      {title:"По факту", value: "https://24.kz/ru/tv-projects/po-faktu?format=feed"},
      {title:"Проект закона", value: "https://24.kz/ru/tv-projects/proekt-zakona?format=feed"},
      {title:"Промышленность", value: "https://24.kz/ru/tv-projects/promyshlennost?format=feed"},
      {title:"Проверено", value: "https://24.kz/ru/tv-projects/provereno?format=feed"},
      {title:"Предприниматели", value: "https://24.kz/ru/tv-projects/predprinimateli?format=feed"},
      {title:"Пища для размышления", value: "https://24.kz/ru/tv-projects/pishcha-dlya-razmyshleniya?format=feed"},
      {title:"Строительство и недвижимость", value: "https://24.kz/ru/tv-projects/stroitelstvo-i-nedvizhimost?format=feed"},
      {title:"Семейный бюджет", value: "https://24.kz/ru/tv-projects/semejnyj-byudzhet?format=feed"},
      {title:"Спецвыпуск", value: "https://24.kz/ru/tv-projects/semejnyj-byudzhet?format=feed"},
      {title:"Специальный репортаж", value: "https://24.kz/ru/tv-projects/spetsialnyj-reportazh?format=feed"},
      {title:"Транзитный Казахстан", value: "https://24.kz/ru/tv-projects/tranzitnyj-kazakhstan?format=feed"},
      {title:"Финансы", value: "https://24.kz/ru/tv-projects/finansy?format=feed"},
      {title:"Цифровой Казахстан", value: "https://24.kz/ru/tv-projects/tsifrovoj-kazakhstan?format=feed"},
      {title:"Цитата дня", value: "https://24.kz/ru/tv-projects/tsitata-dnya?format=feed"},
      {title:"Цифра дня", value: "https://24.kz/ru/tv-projects/tsifra-dnya?format=feed"},
      {title:"Экономика", value: "https://24.kz/ru/tv-projects/ekonomika?format=feed"},
      {title:"Astana Life", value: "https://24.kz/ru/tv-projects/astana-life?format=feed"},
      {title:"Art Global", value: "https://24.kz/ru/tv-projects/art-global?format=feed"},
      {title:"DIGITAL.KZ", value: "https://24.kz/ru/tv-projects/digital-kz?format=feed"},
      {title:"Hi-Tech", value: "https://24.kz/ru/tv-projects/ni-tech?format=feed"},
      {title:"PRO Здоровье", value: "https://24.kz/ru/tv-projects/pro-zdorove?format=feed"},
      {title:"Overtime", value: "https://24.kz/ru/tv-projects/overtime?format=feed"},
      {title:"Qazbooks", value: "https://24.kz/ru/tv-projects/qazbooks?format=feed"},
      ],
    catMyProjectsKz: [
      {title:"Агробизнес", value: "https://24.kz/kz/telepoject/agrobiznes?format=feed"},
      {title:"Алып құрылыс", value: "https://24.kz/ru/tv-projects/aktualno?format=feed"},
      {title:"Арнайы репортаж", value: "https://24.kz/kz/telepoject/arnajy-reportazh?format=feed"},
      {title:"Арнайы шығарылым", value: "https://24.kz/kz/telepoject/arnajy-shy-arylym?format=feed"},
      {title:"Анығын айтқанда", value: "https://24.kz/kz/telepoject/anygyn-aitkanda?format=feed"},
      {title:"Әскер KZ", value: "https://24.kz/kz/telepoject/lem-tynysy?format=feed"},
      {title:"Әлем тынысы", value: "https://24.kz/kz/telepoject/lem-tynysy?format=feed"},
      {title:"Бастау керек", value: "https://24.kz/kz/telepoject/bastau-kerek?format=feed"},
      {title:"Байыбына барсақ", value: "https://24.kz/kz/telepoject/baibyny-barsak?format=feed"},
      {title:"Билік айнасы", value: "https://24.kz/kz/telepoject/bilik-ajnasy?format=feed"},
      {title:"Брифинг", value: "https://24.kz/kz/telepoject/brifing?format=feed"},
      {title:"Блогерлер", value: "https://24.kz/kz/telepoject/blogerler?format=feed"},
      {title:"Білім", value: "https://24.kz/kz/telepoject/bilim?format=feed"},
      {title:"Дархан дала", value: "https://24.kz/kz/telepoject/darkhan-dala?format=feed"},
      {title:"Драйв", value: "https://24.kz/kz/telepoject/drajv?format=feed"},
      {title:"Дәл дерек", value: "https://24.kz/kz/telepoject/dal-derek?format=feed"},
      {title:"Ерекше көзқарас", value: "https://24.kz/kz/telepoject/erekshe-kozkaras?format=feed"},
      {title:"Жасыл экономика", value: "https://24.kz/kz/telepoject/zhasyl-ekonomika?format=feed"},
      {title:"Жерұйық", value: "https://24.kz/kz/telepoject/zher-jy?format=feed"},
      {title:"Заң жобасы", value: "https://24.kz/kz/telepoject/za-zhobasy?format=feed"},
      {title:"Инфографика", value: "https://24.kz/kz/telepoject/infograifka?format=feed"},
      {title:"Мәдениет жаңалықтары", value: "https://24.kz/kz/telepoject/m-deniet-zha-aly-tary?format=feed"},
      {title:"Мәдениетке саяхат", value: "https://24.kz/kz/telepoject/kultvoyazh?format=feed"},
      {title:"Мегаполис", value: "https://24.kz/kz/telepoject/megapolis?format=feed"},
      {title:"Медицина", value: "https://24.kz/kz/telepoject/meditsina?format=feed"},
      {title:"Кабинеттер", value: "https://24.kz/kz/telepoject/kabinet?format=feed"},
      {title:"Кәсіпкерлер", value: "https://24.kz/kz/telepoject/k-sipkerler?format=feed"},
      {title:"Кемел қала", value: "https://24.kz/kz/telepoject/kemel-kala?format=feed"},
      {title:"Кинобизнес", value: "https://24.kz/kz/telepoject/kinobiznes?format=feed"},
      {title:"Қазақстанда бұл қалай жасалған", value: "https://24.kz/kz/telepoject/aza-standa-b-l-alaj-zhasal-an?format=feed"},
      {title:"Қаржы", value: "https://24.kz/kz/telepoject/arzhy?format=feed"},
      {title:"Қысқа - нұсқа", value: "https://24.kz/kz/telepoject/kyska-nuska?format=feed"},
      {title:"Құрылыс нарығы", value: "https://24.kz/kz/telepoject/rylys-nary-y?format=feed"},
      {title:"Олимп", value: "https://24.kz/kz/telepoject/olimp?format=feed"},
      {title:"Отандық медицина", value: "https://24.kz/kz/telepoject/otandy-meditsina?format=feed"},
      {title:"Отбасылық бюджет", value: "https://24.kz/kz/telepoject/otbasylyk-byudzhet?format=feed"},
      {title:"Өнеркәсіп", value: "https://24.kz/kz/telepoject/nerk-sib?format=feed"},
      {title:"Өзекті", value: "https://24.kz/kz/telepoject/ozekty?format=feed"},
      {title:"Сұхбат", value: "https://24.kz/kz/telepoject/s-khbat?format=feed"},
      {title:"Сақшы", value: "https://24.kz/kz/telepoject/sa-shy?format=feed"},
      {title:"Талдау", value: "https://24.kz/kz/telepoject/tarix-tolk-tulgalar?format=feed"},
      {title:"Тарих толқынындағы тұлғалар", value: "https://24.kz/kz/telepoject/tarix-tolk-tulgalar?format=feed"},
      {title:"Транзитті Қазақстан", value: "https://24.kz/kz/telepoject/tranzitti-azastan?format=feed"},
      {title:"Тексердік", value: "https://24.kz/kz/telepoject/tekserdyk?format=feed"},
      {title:"Тұтынушы таңдауы", value: "https://24.kz/kz/telepoject/tutynushy-tandauy?format=feed"},
      {title:"Түйінсөз", value: "https://24.kz/kz/telepoject/tuiynsoz?format=feed"},
      {title:"Үлкен спорт", value: "https://24.kz/kz/telepoject/lken-sport?format=feed"},
      {title:"Цифрлық Қазақстан", value: "https://24.kz/kz/telepoject/tsifrlyk-kazakhstan?format=feed"},
      {title:"Шаршы метр", value: "https://24.kz/kz/telepoject/sharshy-metr?format=feed"},
      {title:"Шетелдік БАҚ: шолу және талдау", value: "https://24.kz/kz/telepoject/sheteldik-ba-sholu-zh-ne-taldau?format=feed"},
      {title:"Іскерлік ақпарат", value: "https://24.kz/kz/telepoject/iskerlik-a-parat?format=feed"},
      {title:"Экономика", value: "https://24.kz/kz/telepoject/ekonomika?format=feed"},
      {title:"Экономика мәселелері", value: "https://24.kz/kz/telepoject/ekonomika-m-seleleri?format=feed"},
      {title:"Этикет", value: "https://24.kz/kz/telepoject/etiket?format=feed"},
      {title:"Astana Life", value: "https://24.kz/kz/telepoject/astana-life?format=feed"},
      {title:"Art Global", value: "https://24.kz/kz/telepoject/art-global?format=feed"},
      {title:"DIGITAL.KZ", value: "https://24.kz/kz/telepoject/digital-kz?format=feed"},
      {title:"Hi-Tech", value: "https://24.kz/kz/telepoject/ni-tech?format=feed"},
      {title:"Overtime", value: "https://24.kz/kz/telepoject/overtime?format=feed"},
      {title:"Qazbooks", value: "https://24.kz/kz/telepoject/qazbooks?format=feed"},
      ]
      
      
      
  }

  static navigationOptions = {
    header: null,
  };

  componentDidMount = async () => {
    await Font.loadAsync({
      'Roboto-Regular': require('../../assets/fonts/Roboto-Regular.ttf'),
      'Roboto-Medium': require('../../assets/fonts/Roboto-Medium.ttf'),
    }).then(() => this.setState({ fontsLoaded: true }));

    getLang().then((res) => {
      this.setState({ lang: res });
       

      this.setState({ loader: true });
      getTv_Projects(global.lang).then((rss) => {
        ////console.log(rss)
        this.setState({ tvNewsOld: rss.items, tvNews: rss.items, loader: false });
      });

  
      if(res == "ru"){
        this.setState({catNews: this.state.catMyProjectsRus });
      } else {
        this.setState({catNews: this.state.catMyProjectsKz });
      }

    });



    this.changeTheme();
    this.props.navigation.addListener('willFocus', this.load);
  }

  sort = (val) => {
    this.setState({ loader: true });
    getTv(val).then((rss) => {
      ////console.log(rss)
      
      this.setState({tvNews: rss.items, showCategory: false, loader: false });
    });
  }

  load = () => {
    getLang().then((res) => {
      this.setState({ lang: res });
      //console.log(res, global.lang)

      this.setState({ loader: true });
      getTv_Projects(global.lang).then((rss) => {
        ////console.log(rss)
        this.setState({ tvNewsOld: rss.items, tvNews: rss.items, loader: false });
      });

      if(res == "ru"){
        this.setState({catNews: this.state.catMyProjectsRus });
      } else {
        this.setState({catNews: this.state.catMyProjectsKz });
      }

    });
    this.changeTheme();


  }

  changeTheme() {
    getTheme().then((res) => {
      //console.log("theme", res);
      this.setState({ selectedTheme: res });
    });
  }

  render() {
    const { navigate } = this.props.navigation;
    if (!this.state.fontsLoaded) {
      return <AppLoading />
    }

    var catList = this.state.catNews.map((item, index) => {
      return (
        <UiButtonIcon
          key={index}
          selectedTheme={this.state.selectedTheme}
          buttonText={item.title}
          onPress={() => this.sort(item.value)}
        />
      )
    });

    var tvNewsList = this.state.tvNews.map((item, index) => {
      if(index < 40){
        return (
          <UiProjectCard
            key={index}
            selectedTheme={this.state.selectedTheme}
            image={parseTags(item.description).images}
            title={item.title}
            date={formatDateTimeString(item.published)}
            cardPress={() => {
              this.props.navigation.navigate("Project", { info: item });
              ////console.log(item);
            }}
            bookMarkPress={() => {
              this.setState({ modalAlertVisible: true });
              setNews(item);
            }}
          />
        )
      }
     

    })

    var searchList = this.state.searchNews.map((item, index) => {

      return (
        <UiProjectCard
          key={index}
          selectedTheme={this.state.selectedTheme}
          image={parseTags(item.description).images}
          title={item.title}
          date={formatDateTimeString(item.published)}
          cardPress={() => {
            this.props.navigation.navigate("Project", { info: item });
            ////console.log(item);
          }}
          bookMarkPress={() => {
            this.setState({ modalAlertVisible: true });
            setNews(item);
          }}
        />
      )

    })


    return (
      <View style={[
        styles.container,
        this.state.selectedTheme == 'night' ? { backgroundColor: themes.night.uiBg } : { backgroundColor: themes.normal.uiBg }
      ]}>
        <UiHeaderProjects
          selectedTheme={this.state.selectedTheme}
          headerText={Locale(global.lang, "cancel")}
          pressSettings={() => this.setState({ showCategory: !this.state.showCategory })}
          searchHeader
          searchText={Locale(global.lang, "search_by_tv")}
          pressRight={() => navigate('Live')}

          items={this.state.tvNews}
          isSearchCallBack={(res) => {
            this.setState({ isSearch: res });
            if (!res) Keyboard.dismiss();
          }}
          searchCallBack={(res) => {
            ////console.log(res.searchRes);
            this.setState({ searchNews: res.searchRes });
          }}

        />

        <SafeAreaView style={styles.safeArea} forceInset={{ top: 'never' }}>
          {/*<View style={styles.noContent}>
            <UiScreenMsg 
              noTitle="Нет телепроектов"
              noText="Проверьте интернет соединение и обновите страницу"
            />
          </View>*/}

          {this.state.isSearch ?
            <ScrollView style={styles.content}>
              {searchList.length > 0 ? searchList :
                <UiScreenMsg
                  selectedTheme={this.state.selectedTheme}
                  noTitle={Locale(global.lang, "not_found")}
                  noText={Locale(global.lang, "not_found_text")}
                  noButton={false}
                />
              }
              <UiClearCard />
            </ScrollView>
            :
            this.state.showCategory ?
              <ScrollView style={styles.content}>
                {catList}
              </ScrollView>
              :
              <ScrollView style={styles.content}>

                {tvNewsList.length > 0 ? tvNewsList :
                  <UiScreenMsg
                    selectedTheme={this.state.selectedTheme}
                    noTitle={Locale(global.lang, "not_found")}
                    noText={Locale(global.lang, "not_found_text")}
                    noButton={true}
                    onPress={() => this.setState({ tvNews: this.state.tvNewsOld })}
                    buttonText={Locale(global.lang, "drop_text")}
                  />
                }
              </ScrollView>
          }

        </SafeAreaView>

        <UiTabs
          selectedTheme={this.state.selectedTheme}
          navigation={this.props.navigation}
          activeTabs={2}
        />

        <Loader selectedTheme={this.state.selectedTheme} show={this.state.loader} />

      </View>
    );
  }
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  safeArea: {
    flex: 1,
  },
  content: {
    flex: 1,
    paddingVertical: 12,
  },
  noContent: {
    flex: 1,
  },

});
