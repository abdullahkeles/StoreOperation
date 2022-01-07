const SnackbarModule = {
    state: {
        overlay: false,
        snackbar: {
            showing: false,
            content: '',
            color: ''
        }

    },
    getters: {
        getSnackbar(state) {
            return state.snackbar;
        },
        getOverlay(state) {
            return state.overlay;
        }
    },
    mutations: {
        showMessage(state, payload) {
            state.snackbar.content = payload.content || ''
            state.snackbar.color = payload.color || 'blue'
            state.snackbar.showing = payload.showing || false
        },
        // arkaplanın gizlenmesi.
        setOverlay(state, payload) {
            state.overlay = payload.stt
        }
    },
    actions: {}
}

export default SnackbarModule