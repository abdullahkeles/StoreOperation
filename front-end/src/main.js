import Vue from 'vue'
import App from '@/App.vue'
import router from '@/router/router'
import store from '@/store/store'
import vuetify from '@/plugins/vuetify'
import ApiService from "@/services/ApiService";

//Vue.config.productionTip = false
//base url imizi tanımlıyoruz.
ApiService.init();
new Vue({
    router,
    store,
    vuetify,
    render: h => h(App)
}).$mount('#app')
