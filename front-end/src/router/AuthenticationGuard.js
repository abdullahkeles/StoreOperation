import store from "@/store/store";

export const authenticationGuard = async function (to, from, next) {
    if (store.getters.isAuthenticated) {
        next();
    } else {
        await store.dispatch('initSession').then(() => {
            if (store.getters.isAuthenticated) {
                next();
            } else {
                next({name: "LogOn"});
            }
        });
    }
}