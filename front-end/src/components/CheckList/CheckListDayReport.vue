<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <div class="text-h5 text-center">{{ storeName }}</div>
        <div class="subtitle-2 text-center">{{ day }}</div>
      </v-col>
    </v-row>
    <v-row>
      <v-col order="2" order-lg="1" o cols="12" md="12" lg="8">
        <v-simple-table height="80vh" fixed-header>
          <template v-slot:default>
            <thead>
            <tr>
              <th class="text-h5"></th>
              <th class="text-center" v-for="c in dayReport.summaries" :key="c.checkedListId">
                <span v-if="c.rank==0" class="light-blue--text pa-2 text-center"> İlk_Yayın </span>
                <span v-else class="orange--text pa-2  text-center">{{ `Revizyon_${c.rank}` }}</span>
              </th>
            </tr>
            </thead>
            <tbody>
            <template v-for="g in dayReport.groups">
              <tr :key="g.groupId">
                <th class="grey lighten-5" :colspan="1+dayReport.summaries.length">{{ g.group }}</th>
              </tr>
              <tr v-for="q in g.questions" :key="q.questionId">
                <td>{{ q.question }}</td>
                <td class="text-center" v-for="c in dayReport.summaries" :key="c.checkedListId">
                  <chec-list-question-answer :answer="q.answers.find(el => el.checkListId == c.checkListId).answer"></chec-list-question-answer>
                </td>
              </tr>
            </template>
            </tbody>
          </template>
        </v-simple-table>
      </v-col>

      <v-col order="1" order-lg="2" cols="12" md="12" lg="4">
        <v-simple-table dense>
          <template v-slot:default>
            <thead>
            <tr class="grey lighten-3 black--text">
              <th class="text-center" colspan="4">Özet</th>
            </tr>
            <tr class="grey lighten-5 black--text">
              <th class="text-center">Durum</th>
              <th class="text-center">
                Kayıt Zamanı
              </th>
              <th class="green--text text-center">
                Evet
              </th>
              <th class="red--text text-center">
                Hayır
              </th>

            </tr>
            </thead>
            <tbody>
            <tr v-for="item in dayReport.summaries" :key="item.checkListId">
              <td class="text-center">
                <span v-if="item.rank==0" class="light-blue--text pa-2"> İlk Yayın </span>
                <span v-else class="orange--text pa-2">{{ `Revizyon ${item.rank}` }}</span>
              </td>
              <td class="text-center">{{ item.timespan }}</td>
              <td class="green--text text-center">
                {{ item.totalTrue }}
              </td>
              <td class="red--text text-center">
                {{ item.totalFalse }}
              </td>

            </tr>
            </tbody>
          </template>
        </v-simple-table>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import checListQuestionAnswer from "@/components/CheckList/management/_checListQuestionAnswer";
export default {
  name: "CheckListDayReport",
  components: {checListQuestionAnswer},
  data() {
    return {
      dayReport: {},
      day: null,
      storeName: null
    }
  },
  created() {
    this.initialize()
  },
  methods: {
    initialize() {
      const dayId = this.$route.params.dayId
      const day = this.$route.params.day
      const storeName = this.$route.params.storeName
      if (dayId) {
        this.$store.dispatch('reportCheckListStoreDay', dayId).then(_dayReport => {
          console.log("_dayReport.data.data", _dayReport.data.data)
          this.dayReport = _dayReport.data.data
          this.day = day
          this.storeName = storeName
        })
      } else {
        this.$router.push({name: 'CheckedListDays'})
      }
    }
  }
}
</script>