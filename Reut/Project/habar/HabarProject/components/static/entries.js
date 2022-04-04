import {Locale, getLang} from '../../i18n/locale.js';

state = {
  lang: "kz"
}

export const Entries = [
    {
        title: Locale(this.state.lang, "stay_informed"),
        subtitle: Locale(this.state.lang, "stay_informed_subtitle"),
        illustration: require('../../assets/images/onboard/slide1-2x.png')
    },
    {
        title: Locale(this.state.lang, "offline_mode"),
        subtitle: Locale(this.state.lang, "offline_mode_subtitle"),
        illustration: require('../../assets/images/onboard/slide2-2x.png')
    },
    {
        title: Locale(this.state.lang, "selected_articles"),
        subtitle: Locale(this.state.lang, "selected_articles_subtitle"),
        illustration: require('../../assets/images/onboard/slide3-2x.png')
    },
    {
        title: Locale(this.state.lang, "reminding"),
        subtitle: Locale(this.state.lang, "reminding_subtitle"),
        illustration: require('../../assets/images/onboard/slide4-2x.png')
    },
    {
        title: Locale(this.state.lang, "night_mode"),
        subtitle: Locale(this.state.lang, "night_mode_subtitle"),
        illustration: require('../../assets/images/onboard/slide5-2x.png')
    }
];