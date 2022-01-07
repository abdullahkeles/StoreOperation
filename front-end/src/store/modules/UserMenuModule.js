import UserMenuService from "@/services/UserMenuServices";

const userMenuModule = {
    state: {
        LeftListMenu:[],
        LeftTreeMenu:[]
    },
    getters: {
        leftUserMenuTree: (state) => {
            return state.LeftTreeMenu
        },
        leftUserMenuList: (state) => {
            return state.LeftListMenu
        },
        searchUserMenu: (state) => {
            return state.LeftListMenu//.filter(x => x.title.includes(val))
        }
    },
    //setter işlemlerinde kullanıyoruz synchronize
    mutations: {
        setMenu(state) {
            state.LeftTreeMenu = UserMenuService.getLeftUserMenuTree();
            state.LeftListMenu = UserMenuService.getLeftUserMenuList();
        }
    },
    actions: {}
}

export default userMenuModule