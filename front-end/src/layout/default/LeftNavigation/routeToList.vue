<template>
  <route-to-list-item v-if="!route.isChild" :route="route"/>
  <route-to-group-list-item v-else :route="route"/>
</template>

<script>
import routeToListItem from "@/layout/default/LeftNavigation/routeToListItem";
import routeToGroupListItem from "@/layout/default/LeftNavigation/routeToGroupListItem";

export default {
  name: "routeToList",
  props: ["route"],
  components: {
    routeToListItem,
    routeToGroupListItem
  }
}
</script>

<style scoped>

</style>