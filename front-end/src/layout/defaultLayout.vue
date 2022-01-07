<template>
  <div>
    <v-navigation-drawer v-model="drawer" app>
      <left-user-navigation/>
      <v-divider></v-divider>
      <left-navigation/>
    </v-navigation-drawer>
    <v-app-bar app color="primary" dark>
      <v-app-bar-nav-icon @click="drawer=!drawer"></v-app-bar-nav-icon>
      <v-app-bar-title>B&OIL</v-app-bar-title>
      <v-spacer></v-spacer>
      <v-autocomplete
          :items="searchUserMenu"
          item-text="title"
          item-value="name"
          class="d-none d-sm-flex"
          style="max-width: 20em"
          v-model="value"
          placeholder="menü arama"
          rounded
          dense
          solo-inverted
          hide-details
          hide-no-data
          @change="userMenuAutoClick"
      ></v-autocomplete>
    </v-app-bar>
    <v-main>
      <v-container class="fill-height align-start">
        <router-view/>
      </v-container>
    </v-main>
    <bottom-navigation class="d-flex d-sm-none"/>
  </div>
</template>
<script>
import LeftUserNavigation from "@/layout/default/LeftUserNavigation";
import LeftNavigation from "@/layout/default/LeftNavigation";
import BottomNavigation from "@/layout/default/BottomNavigation";
import {mapGetters} from "vuex";

export default {
  name: "defaultLayout",
  components: {
    LeftUserNavigation,
    LeftNavigation,
    BottomNavigation,
  },
  data() {
    return {
      value: null,
      drawer: null,
    }
  },
  methods: {
    userMenuAutoClick() {
      if (this.value) {
        this.$router.push({name: this.value})
      }
    },
  },
  computed: {
    ...mapGetters(['searchUserMenu'])
  }
}
</script>
