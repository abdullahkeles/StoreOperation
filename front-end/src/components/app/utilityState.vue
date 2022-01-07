<template>
  <v-chip :color="getStateColor(state)" dark>
    {{ getStateString(state) }}
  </v-chip>
</template>

<script>
import utilitySate from "@/utility/UtilityState";

export default {
  name: "utilityState",
  props: ['state'],
  methods: {
    getStateString(state) {
      return utilitySate.toString(state)
    },
    getStateColor(state) {
      return utilitySate.toColorString(state)
    }
  }
}
</script>
