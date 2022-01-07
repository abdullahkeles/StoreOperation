<template>
  <v-container>
    <v-row class="text-center">
      <v-col cols="12">
        <span class="font-weight-bold text-h5 mb-3">BARRELS AND OIL</span>
        <span> </span>
        <span class="mb-3 text-h5"> Günlük Kontrol Listeleri</span>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12">
        <v-expansion-panels focusable v-model="panel">
          <v-expansion-panel v-for="day in days" :key="day.day">
            <v-expansion-panel-header>
              {{ day.day }}
              <v-spacer></v-spacer>
              <div class="text-right">
                <span class="red--text mr-2">{{ day.bilgiGirisYapılmadı }}</span>
                <span class="blue--text mr-2">{{ day.ilkYayin }}</span>
                <span class="green--text mr-2">{{ day.revizyon }}</span>
              </div>
            </v-expansion-panel-header>
            <v-expansion-panel-content>
              <v-timeline align-top dense>
                <v-timeline-item v-if="!currentDay.stores || !currentDay.stores.length" color="red lighten-4" small
                                 right>
                  <v-row class="pt-1">
                    <v-col v-bind:class="{'text-left':true, 'pl-0':true}">
                      <span class="red--text pa-2"> Kayıt yok. </span>
                    </v-col>
                  </v-row>
                </v-timeline-item>
                <v-timeline-item v-else v-for="i in currentDay.stores" :key="i.day"
                                 :color="i.rank>0?'orange lighten-2':'light-blue lighten-2'"
                                 small
                                 right>
                  <v-row class="pt-1">
                    <v-col v-bind:class="{'text-left':true, 'pl-0':true}">
                      <strong>{{ i.timespan }}</strong>
                      <span> - </span>
                      <span>{{ i.storeName }}</span>
                      <span> - </span>
                      <span class="green--text mr-2"> Evet : {{i.totalTrue}}</span>
                      <span class="red--text mr-2"><b>Hayır</b> : {{i.totalFalse}}</span>
                      <span class="blue-grey--text darken-4"> Puanı : {{i.totalSkor}}</span>
                    </v-col>
                  </v-row>
                </v-timeline-item>
              </v-timeline>
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-expansion-panels>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "StoresCheckListDays",
  data: () => ({
    panel: 0,
    days: [],
    dayDetails: [],
    currentDay: {}
  }),
  created() {
    this.initialize()
  },
  methods: {
    initialize() {
      this.$store.dispatch('reportCheckListAppStoresDays').then(_days => {
        this.days = _days.data.data
        this.getDay(this.days[0].dayDate)
      })
    },
    isDayDetail(dateValue) {
      return this.dayDetails.some(x => x.day === dateValue)
    },
    getDay(dateValue) {
      this.currentDay = {};
      if (this.isDayDetail(dateValue)) {
        this.currentDay = this.dayDetails.find(x => x.day === dateValue);
        console.log(dateValue, "keepDetail", this.currentDay)
      } else {
        this.$store.dispatch("reportCheckListAppStoresDay", dateValue)
            .then(stores => {
              console.log(stores);
              const day = {day: dateValue, stores: [...stores.data.data]};
              console.log(dateValue, "addDetail", day)
              this.dayDetails.push(day);
              this.currentDay = day;
            });
      }
    }
  },
  watch: {
    panel: function (newPanel) {
      this.getDay(this.days[newPanel].dayDate)
    }
  }
}
</script>

<style scoped>

</style>