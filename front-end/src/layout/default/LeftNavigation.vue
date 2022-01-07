<template>
  <v-list>
    <!--    <route-to-list v-for="i in storeLeftUserMenuList" :key="i.id" :route="i"/>-->
    <route-to-list v-for="i in menuList" :key="i.id" :route="i"/>
    <v-list-item v-on:click="logout">
      <v-list-item-icon>
        <v-icon>
          mdi-logout
        </v-icon>
      </v-list-item-icon>
      <v-list-item-title>
        Oturumu Kapat
      </v-list-item-title>
    </v-list-item>
  </v-list>
</template>

<script>
import routeToList from "@/layout/default/LeftNavigation/routeToList";

export default {
  name: "LeftNavigation",
  components: {
    routeToList
  },
  methods: {
    logout() {
      this.$store.dispatch("logout")
    }
  },
  computed: {
    menuList: function () {
      return this.$store.getters.leftUserMenuList;
    }
  }
}
</script>