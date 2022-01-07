<template>

  <div style="width: 100%">
    <v-row class="text-center">
      <v-col cols="12">
              <span class="title shades mb-3">
                Günlük Kontrol
              </span>
        <div class="subheading font-weight-regular grey--text">
          {{ dayStorename }}
        </div>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12">
        <v-expansion-panels focusable v-model="panel">
          <v-expansion-panel
              v-for="(day) in dayModel.checkListDays"
              :key="day.checkListDayId"
              v-model="panel">
            <v-expansion-panel-header>
              <v-row no-gutters>
                <v-col class="my-auto">
                  {{
                  getDayDate(day.day)
                  }}
                </v-col>
                <v-col cols="auto">
                  <check-list-state-chip :day-id="day.checkListDayId" :state="day.rank" :day="getDayDate(day.day)" :store-name="dayStorename"/>
                </v-col>
              </v-row>
            </v-expansion-panel-header>
            <v-expansion-panel-content>
              <v-timeline align-top dense>
                <v-timeline-item v-if="!day.checkLists || !day.checkLists.length" color="red lighten-4" small right>
                  <v-row class="pt-1">
                    <v-col v-bind:class="{'text-left':true, 'pl-0':true}">
                      <span class="red--text pa-2"> Kayıt yok. </span>
                    </v-col>
                  </v-row>
                </v-timeline-item>
                <v-timeline-item v-else v-for="i in day.checkLists" :key="i.checkListId"
                                 :color="i.rank>0?'orange lighten-2':'light-blue lighten-2'"
                                 small
                                 right>
                  <v-row class="pt-1">
                    <v-col v-bind:class="{'text-left':true, 'pl-0':true}">
                      <strong>{{ i.timeSpan }}</strong>
                      <span> - </span>
                      <span>{{ i.name + " " + i.surname }}</span>
                      <span> - </span>
                      <span v-if="i.rank==0" class="light-blue--text pa-2"> İlk Yayın </span>
                      <span v-else class="orange--text pa-2">{{ `Revizyon ${i.rank}` }}</span>
                    </v-col>
                  </v-row>
                </v-timeline-item>
              </v-timeline>
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-expansion-panels>
      </v-col>
    </v-row>
  </div>
</template>

<script>

import CheckListStateChip from "@/components/CheckList/_checkListStateChip";

export default {
  name: "ShopeStoreCheckListDays",
  components: {CheckListStateChip},
  data: () => ({
    panel: 0,
  }),
  methods: {
    getDayDate(dt) {
      return new Date(dt).toLocaleDateString('tr-TR', {
        day: 'numeric',
        month: 'long',
        year: 'numeric',
        weekday: 'long'
      })
    },
    routeToCheckList(id, event) {
      if (event && event.stopImmediatePropagation) event.stopImmediatePropagation();
      this.$router.push({path: `shope-store/check-list/${id}`});
    },
    loadDays() {
      this.$store.dispatch('getCheckListDays')
    },
    checkListState(rank) {
      let state = ''
      switch (rank) {
        case 0:
          state = "İlk Yayın"
          break;
        default:
          state = `Revizyon ${rank}`
          break;
      }
      return state;
    }
  },
  created() {
    this.loadDays()
  },
  computed: {
    dayModel: function () {
      return this.$store.getters.getCheckListDays;
    },
    dayStorename: function () {
      return this.$store.getters.getCheckListDaysStoreName
    },
  },
}
</script>

<style scoped>
.v-expansion-panel-content >>> .v-expansion-panel-content__wrap {
  padding: 0 !important;
}
</style>