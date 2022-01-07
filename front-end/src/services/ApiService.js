import Vue from "vue";
import axios from "axios";
import VueAxios from "vue-axios";
import appSettings from "@/appSettings";
import store from "@/store/store";

Vue.use(VueAxios, axios);

const ApiService = {
    init() {
        Vue.axios.defaults.baseURL = appSettings.baseURL

        if (localStorage.token) {
            Vue.axios.defaults.headers.common['Authorization'] = `Bearer ${localStorage.token}`
        }
        //You can intercept requests or responses before they are handled by then or catch.
        //İstekleri veya yanıtları o zamana kadar işlenmeden veya yakalamadan önce durdurabilirsiniz.
        Vue.axios.interceptors.response.use(
            // Any status code that lie within the range of 2xx cause this function to trigger
            // 2xx aralığında bulunan herhangi bir durum kodu bu fonksiyonun tetiklenmesine neden olur
            // Do something with response data
            (response) => {
                return response;
            },
            (error) => {

                /**
                 * Create an Error with the specified message, config, error code, request and response.
                 *
                 * @param {string} message The error message.
                 * @param {Object} config The config.
                 * @param {string} [code] The error code (for example, 'ECONNABORTED').
                 * @param {Object} [request] The request.
                 * @param {Object} [response] The response.
                 * @returns {Error} The created error.
                 */
                store.commit('setOverlay', {stt: false})

                // Any status codes that falls outside the range of 2xx cause this function to trigger
                // 2xx aralığının dışında kalan herhangi bir durum kodu bu fonksiyonun tetiklenmesine neden olur
                if (error.response) {
                    // The request was made and the server responded with a status code
                    // that falls out of the range of 2xx
                    // İstek yapıldı ve sunucu 2xx aralığının dışında kalan bir durum koduyla yanıt verdi
                    if (error.response.status === 401) {
                        store.dispatch('logout')
                    }
                    store.commit('showMessage', {
                        content: `Hata Kodu[${error.response.status}] : ${error.response.data.message}`,
                        color: 'error',
                        showing: true
                    })

                } else if (error.request) {
                    // The request was made but no response was received
                    // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
                    // http.ClientRequest in node.js
                    store.commit('showMessage', {
                        content: "Sunucu ile bağlantı kurulamadı.",
                        color: 'error',
                        showing: true
                    })

                } else {
                    // Something happened in setting up the request that triggered an Error
                    store.commit('showMessage', {content: "###-hata", color: 'error', showing: true})
                }
                return Promise.reject(error);
            }
        );

        Vue.axios.interceptors.request.use(function (config) {
            return config
        }, function (error) {
            return Promise.reject(error)
        })
    },

    get(resource) {
        return Vue.axios.get(`${resource}`);
    },
    getWithParams(resource, params) {
        console.log(params)
        return Vue.axios.get(`${resource}`, {params: params});
    },

    post(resource, params) {
        return Vue.axios.post(`${resource}`, params);
    },

    put(resource, params) {
        return Vue.axios.put(`${resource}`, params);
    },

    delete(resource, params) {
        return Vue.axios.delete(`${resource}`, params);
    },
};

export default ApiService;
