import Vue from 'vue'
import Vuex from 'vuex'
import userMenuModule from "@/store/modules/UserMenuModule";
import checkListModule from "@/store/modules/CheckListModule";
import sessionModule from "@/store/modules/SessionModule";
import StoreModule from "@/store/modules/StoreModule";
import SnackbarModule from "@/store/modules/snackbar";

Vue.use(Vuex)

export default new Vuex.Store({
    state: {},
    getters: {},
    //setter işlemlerinde kullanıyoruz synchronize
    mutations: {},
    // mutation asynchronous
    actions: {},
    modules: {
        userMenuModule,
        checkListModule,
        sessionModule,
        StoreModule,
        SnackbarModule,
    }
})
