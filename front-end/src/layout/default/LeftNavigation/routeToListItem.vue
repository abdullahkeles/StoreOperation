<template>
  <v-list-item :to="{name:route.name}">
    <v-list-item-icon>
      <v-icon v-text="route.icon"></v-icon>
    </v-list-item-icon>
    <v-list-item-title v-text="route.title"></v-list-item-title>
  </v-list-item>
</template>
<script>
export default {
  name: "routeToListItem",
  props: ["route"],
}
</script>