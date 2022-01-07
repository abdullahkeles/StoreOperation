<template>
  <v-chip @click="toReport()" v-if="state === 1" small class="ma-0" color="light-blue" text-color="white">
    <v-avatar left>
      <v-icon>mdi-checkbox-marked-circle</v-icon>
    </v-avatar>
    İlk Yayın
  </v-chip>
  <v-chip v-else-if="state === 0" small class="ma-0" color="red" text-color="white">
    <v-avatar left>
      <v-icon>mdi-minus-circle-outline</v-icon>
    </v-avatar>
    Bilgi girişi yapılmadı.
  </v-chip>
  <v-chip @click="toReport()" v-else-if="state > 1" small class="ma-0" color="orange" text-color="white">
    <v-avatar left>
      <v-icon>mdi-alert-circle-outline</v-icon>
    </v-avatar>
    {{ `Revizyon ${state - 1}` }}
  </v-chip>
</template>

<script>
export default {
  name: "CheckListStateChip",
  props: {
    state: {
      type: Number,
      default: null,
    },
    dayId: {
      type: String,
      default: null
    },
    day: {
      type: String,
      default: null
    },
    storeName: {
      type: String,
      default: null
    }
  },
  methods: {
    toReport() {
      if (this.dayId){
        this.$router.push({name: 'CheckListDayReport', params: {dayId: this.dayId,day:this.day,storeName:this.storeName}})
      }
    }
  }
}
</script>

<style scoped>

</style>