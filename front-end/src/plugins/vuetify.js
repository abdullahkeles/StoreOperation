import Vue from 'vue';
import Vuetify from 'vuetify/lib/framework';
import VueI18n from 'vue-i18n'
import tr from 'vuetify/lib/locale/tr'

Vue.use(Vuetify);
Vue.use(VueI18n)

export default new Vuetify({
    lang: {
        //t: (key, ...params) => i18n.t(key, params),
        locales:{tr},
        current:'tr'
    },
});
