<template>
  <v-row>
    <v-col cols="12">
      <div class="text-center">
        <h4>
          Günlük Kontrol Listesi
        </h4>
        <p class="subheading font-weight-regular text--secondary">
          {{ checkListDayTitle }}
        </p>
      </div>
      <v-expansion-panels focusable>
        <v-expansion-panel v-for="group in newCheckList.groups" :key="group.checkListQuestionGroupId">
          <v-expansion-panel-header>
            <span class="text-center">{{ group.name }}</span>
          </v-expansion-panel-header>
          <v-expansion-panel-content>
            <shope-store-check-group :group="group"/>
          </v-expansion-panel-content>
        </v-expansion-panel>
        <v-expansion-panel>
          <v-expansion-panel-header>
            <span class="text-center">Diğer Önemli Notlar ve Aksiyonlar</span>
          </v-expansion-panel-header>
          <v-expansion-panel-content class="mt-2">
            <v-textarea
                solo
                v-model="newCheckList.note"
                label="Diğer Önemli Notlar ve Aksiyonlar"
            ></v-textarea>
          </v-expansion-panel-content>
        </v-expansion-panel>
      </v-expansion-panels>
      <div class="d-flex justify-end">
        <v-btn class="ma-2" @click="btnSave()" outlined color="indigo">
          Kaydet
        </v-btn>
      </div>
    </v-col>
  </v-row>
</template>

<script>
import ShopeStoreCheckGroup from "@/components/CheckList/ShopeStoreCheckGroup";
import utilityDateFormat from "@/utility/UtilityDateFormat";

export default {
  name: "CheckList",
  data() {
    return {}
  },
  created() {
    this.initialize()
  },
  components: {ShopeStoreCheckGroup},
  methods: {
    initialize() {
      this.$store.dispatch('createCheckList')
    },
    btnSave() {
      this.$store.dispatch('addCheckList').then(cl => {
        console.log(cl)
        const data = cl.data;
        console.log(data)
        if (data.statusCode == 201) {
          this.$store.commit('showMessage',{content:data.message,color:'success',showing:data.success})
          this.initialize()
          this.$router.push({name: "CheckedListDays"})
        }
      })
    }
  },
  computed: {
    newCheckList: function () {
      return this.$store.getters.getCheckList
    },
    checkListDayTitle: function () {
      return utilityDateFormat.toLocaleDateString(this.newCheckList.day)
    }
  },
}
</script>