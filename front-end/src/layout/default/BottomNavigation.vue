<template>
  <v-bottom-navigation v-model="value" color="primary" app grow shift>
    <v-btn value="home" :to="{name:'Home'}">
      <span>Anasayfa</span>

      <v-icon>mdi-home</v-icon>
    </v-btn>

    <v-btn value="check" :to="{name:'CheckList'}">
      <span>Kontrol</span>

      <v-icon>mdi-check</v-icon>
    </v-btn>

    <v-btn value="nearby" :to="{name:'CheckedListDays'}">
      <span>Günlük Kontroller</span>

      <v-icon>mdi-view-day</v-icon>
    </v-btn>
  </v-bottom-navigation>
</template>

<script>
export default {
  name: "BottomNavigation",

  data: () => ({
    value: 'home'
  })
}
</script>

<style scoped>
.v-item-group.v-bottom-navigation .v-btn {
  background-color: transparent;
  border-radius: 0;
  box-shadow: none;
  flex: 0 1 auto;
  font-size: .75rem;
  height: inherit;
  max-width: 168px;
  min-width: 80px;
  position: relative;
  text-transform: none
}
</style>