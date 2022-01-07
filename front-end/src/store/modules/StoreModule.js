import ApiService from "@/services/ApiService";

const StoreModule = {
    state: {
        dialog: false,
        dialogDelete: false,
        stores: [],
    },
    getters: {
        getDialog: state => {
            return state.dialog
        },
        getDialogDelete: state => {
            return state.dialogDelete
        },
        getDataStores: state => {
            return state.stores
        }
    },
    mutations: {
        setDialog: (state, newValue) => {
            state.dialog = newValue
        },
        setDialogDelete: (state, newValue) => {
            state.dialogDelete = newValue
        },
        setStores: (state, dataStores) => {
            state.stores = dataStores
        }
    },
    actions: {
        getStores({commit}) {
            ApiService.get('app-store/get-all').then((response) => {
                let model = response.data
                commit('setStores', model.data)
            });
        },
        createStore(context,model) {
            ApiService.post('app-store/create', model).then(() => {
                //return response;
            });
        },
        updateStore(context,model) {
            return ApiService.post('app-store/update', model).then((response) => {
               return response;
            });
        },
        deleteStore(context,storeId) {
            return ApiService.post('app-store/update', storeId).then((response) => {
               return response;
            });
        },
    }
}
export default StoreModule