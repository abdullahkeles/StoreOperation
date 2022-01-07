import router from "@/router/router";
import store from "@/store/store";

const UserMenuService = {

    appMenu: null,
    init() {
        if (this.appMenu === null) {
            let r = router.options.routes
            this.appMenu = []
            this.setAllLeftNavigation(r, 10, this.appMenu)
            store.commit('setMenu')
        }
    },
    // menüleri tek tek getirir
    //  | menu 1
    //  | menu 2
    //  | menu 3
    getLeftUserMenuList() {
        const _menu = this.getLeftUserMenuTree();
        let menu = [];
        _menu.forEach((current) => {
            if (current.isChild) {
                current.children.forEach((cChild) => {
                    menu.push(cChild);
                });
            } else {
                menu.push(current);
            }
        });
        return menu;
    },

    //  | menü 1
    //  | menü 2
    //  | menü 3
    //     - alt menu
    // ağaç yapısında sırlar
    getLeftUserMenuTree() {
            let menu = this.appMenu.filter(x => x.id.length === 4)
            menu.forEach((current) => {
                let menu_child = this.appMenu.filter(x => x.id.length > 4 & x.id.startsWith(current.id))
                if (menu_child.length > 0) {
                    current.isChild = true
                    current.children = menu_child
                }
            })
            return menu
    },

    setAllLeftNavigation(routers, id, allMenu) {
        let i = id
        let item
        routers.forEach((el) => {
            item = {}
            i++
            if (this.hasPropertyMeta(el, "isLeftNavigation")) {
                if (el.meta.isLeftNavigation) {
                    item = {
                        name: el.name,
                        id: `${i}`,
                        icon: el.meta.icon,
                        title: el.meta.title,
                        isChild: false,
                    }
                    allMenu.push(item)
                    if (this.hasProperty(el, "children")) {
                        // recursive
                        this.setAllLeftNavigation(el.children, i * 100, allMenu)
                    }
                }
            }
        })
    },

    // nesnenin meta isimli nesne propertisinin propertilerini kontrol eder. :) bende hayran kaldım açıklamaya
    hasPropertyMeta(item, propertyName) {
        if (this.hasProperty(item, "meta")) {
            return this.hasProperty(item.meta, propertyName)
        }
        return false
    },

    hasProperty(item, propertyName) {
        console.log("menu item : ",item)
        // eslint-disable-next-line no-prototype-builtins
        return Object.prototype.hasOwnProperty.call(item, propertyName)
    },
}

export default UserMenuService
