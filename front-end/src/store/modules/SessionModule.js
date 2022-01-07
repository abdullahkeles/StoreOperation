// import ApiService from "@/services/ApiService";
// import ResultType from "@/utility/enums/ResultType";
import local from "@/utility/LocalStorageHelper";
//import axios from "axios";
import ApiService from "@/services/ApiService";
import router from "@/router/router";

const sessionModule = {
    state: {
        token: "",
        tokenExpiryDate: null,
        user: {},
        // data to be kept in localstorage
        sessionModel: {}
    },
    getters: {
        isAuthenticated(state) {
            let result = false
            if (state.token && state.tokenExpiryDate) {
                let expiry = new Date(state.tokenExpiryDate).getTime()
                let currentDate = new Date().getTime()
                if (expiry > currentDate) {
                    result = true
                }
            }
            return result
        },
        getToken(state) {
            return state.token
        }
    },
    //setter işlemlerinde kullanıyoruz synchronize
    mutations: {
        setSession(state, model) {
            state.token = model.token;
            state.tokenExpiryDate = new Date(model.tokenExpiryDate);
            state.sessionModel = model;
            // write model to localstorage
            local.setLocalStorage(model);
            // oturum acıldıktan sonra tekrar yüklüyoruz.
            ApiService.init()
        },
        removeSession(state) {
            state.token = "";
            state.tokenExpiryDate = "";
            local.removeLocalStorage(state.sessionModel)
        }
    },
    actions: {
        initSession(context) {
            let token = localStorage.getItem("token")
            let tokenExpiryDate = localStorage.getItem("tokenExpiryDate")
            if (token && tokenExpiryDate) {
                context.commit('setSession', {token: token, tokenExpiryDate: tokenExpiryDate})
            }
        },
        logon({commit}, model) {
            return ApiService.post('users/login', model).then((response) => {
                let model = response.data
                commit("setSession", {
                    token: model.data.token,
                    tokenExpiryDate: model.data.tokenExpiryDate,
                })
                // the next then
                return model;
            })
        },
        logout({commit}) {
            commit("removeSession");
            router.push({name: "LogOn"});
        },
        userInfo(context){
            return ApiService.post('users/info',context.getters.getToken)
        },
        userProfileImage(context){
            return ApiService.post('users/profile-image',context.getters.getToken)
        }
    }
}
export default sessionModule