import Vue from 'vue'
import VueRouter from 'vue-router'
import defaultLayout from "@/layout/defaultLayout";
import emtyLayout from "@/layout/emtyLayout";
import {authenticationGuard} from "@/router/AuthenticationGuard";

Vue.use(VueRouter)
let isLeftNavigation = true;

const routes = [
    {
        meta: {isLeftNavigation, title: null, icon: null},
        path: '/',
        component: defaultLayout,
        children: [
            {
                meta: {
                    title: "Ana Sayfa",
                    icon: "mdi-home",
                },
                path: '',
                name: 'default',
                component: () => import('@/views/Home'),
                beforeEnter: authenticationGuard,
            },
            {
                meta: {
                    isLeftNavigation,
                    title: "Ana Sayfa",
                    icon: "mdi-home",
                },
                path: '/home',
                name: 'Home',
                component: () => import('@/views/Home'),
                beforeEnter: authenticationGuard,
            },
            {
                path: 'about',
                name: 'About',
                component: () => import('@/views/About.vue'),
                beforeEnter: authenticationGuard,
            },
            {
                meta: {isLeftNavigation, title: "Mağaza", icon: null},
                path: 'shope-store',
                name: 'ShopeStore',
                component: () => import('@/views/ShopeStore'),
                children: [
                    {
                        meta: {
                            isLeftNavigation,
                            title: "Kontrol Ekle",
                            icon: "mdi-playlist-plus",
                        },
                        path: 'check-list',
                        name: 'CheckList',
                        component: () => import('@/components/CheckList/ShopeStoreCheckList'),
                        beforeEnter: authenticationGuard,

                    },
                    {
                        meta: {
                            isLeftNavigation,
                            title: "Kontrol Listeleri",
                            icon: "mdi-view-list",
                        },
                        path: 'check-list-days',
                        name: 'CheckedListDays',
                        component: () => import('@/components/CheckList/ShopeStoreCheckListDays'),
                        beforeEnter: authenticationGuard,

                    },
                    {
                        meta: {
                            title: "Günlük Kontrol Raporu",
                            icon: "mdi-view-list",
                        },
                        path: 'check-list-day-report',
                        name: 'CheckListDayReport',
                        component: () => import('@/components/CheckList/CheckListDayReport'),
                        beforeEnter: authenticationGuard,

                    },
                ]
            },
            {
                meta: {isLeftNavigation, title: "Uygulama Yönetimi", icon: null},
                path: 'app-manage',
                name: 'AppMange',
                component: () => import('@/views/AppManage'),
                children: [
                    {
                        meta: {isLeftNavigation, title: "Mağaza", icon: "mdi-cog",},
                        path: 'store',
                        name: 'AppManageStore',
                        component: () => import('@/components/appStore/AppManageStore'),
                        beforeEnter: authenticationGuard,
                    },
                    {
                        meta: {isLeftNavigation, title: "Kontrol Grup", icon: "mdi-cog",},
                        path: 'quuestion-group',
                        name: 'AppManageQuestionsGroup',
                        component: () => import('@/components/CheckList/management/QuestionsGroup'),
                        beforeEnter: authenticationGuard,
                    },
                    {
                        meta: {isLeftNavigation, title: "Günlük Kontrol Listeleri", icon: "mdi-view-list",},
                        path: 'stores-check-list-days',
                        name: 'StoresCheckListDays',
                        component: () => import('@/components/CheckList/management/StoresCheckListDays'),
                        beforeEnter: authenticationGuard,
                    },
                ]
            },
        ],

    },
    {
        path: '/auth',
        name: 'Auth',
        component: emtyLayout,
        children: [
            {
                path: 'logon',
                name: 'LogOn',
                component: () => import('@/views/Logon.vue')
            },
            {
                path: 'register',
                name: 'Register',
                component: () => import('@/views/Register.vue')
            }
        ]
    },
];


const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
});
export default router