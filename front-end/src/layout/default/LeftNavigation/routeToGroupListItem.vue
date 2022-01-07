<template>
      <v-list-group :value="false">
        <template v-slot:activator>
          <v-list-item-title v-text="route.title"></v-list-item-title>
        </template>
        <v-list-item v-for="child in route.children" :key="child.id" :to="{name:child.name}">
          <v-list-item-icon>
            <v-icon v-text="child.icon"></v-icon>
          </v-list-item-icon>
          <v-list-item-title  v-text="child.title"></v-list-item-title>
        </v-list-item>
      </v-list-group>
</template>

<script>
export default {
  name: "routeToGroupListItem",
  props: ["route"],
}
</script>