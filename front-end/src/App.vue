<template>
  <v-app>
    <router-view/>
    <v-snackbar v-model="snackbar.showing">
      {{ snackbar.content }}
      <template v-slot:action="{ attrs }">
        <v-btn :color="snackbar.color" text v-bind="attrs" @click="snackbar.showing = false">
          Kapat
        </v-btn>
      </template>
    </v-snackbar>
    <v-overlay :value="overlay">
      <v-progress-circular
          :width="3"
          color="red"
          indeterminate
      ></v-progress-circular>
    </v-overlay>
  </v-app>
</template>
<script>

import UserMenuService from "@/services/UserMenuServices";

export default {
  name: 'App',
  components: {},
  created() {
    document.title = "Mağaza - Operasyon";
    //menu yükleniyor hiç hoşuma gitmedi yapı gece kondu gibi oldu acil kentsel dönüşüm
    //todo yapı tamamen değiştirilecek servis ve store dendency olmamalı
    UserMenuService.init()
  },
  computed: {
    snackbar: function () {
      return this.$store.getters.getSnackbar
    },
    overlay: function () {
      return this.$store.getters.getOverlay
    }
  }
  ,
  methods: {}
};
</script>
