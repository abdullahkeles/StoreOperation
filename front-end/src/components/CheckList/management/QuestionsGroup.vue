<template>
  <v-row>
    <v-col>
      <v-data-table
          :items="questionGroups"
          :expanded.sync="expanded"
          :headers="headers"
          :single-expand="true"
          item-key="checkListQuestionGroupId"
          show-expand
          class="elevation-1"
      >
        <template v-slot:item.state="{ item }">
          <utility-state :state="item.state"/>
        </template>
        <template v-slot:item.action="{ item }">
          <v-icon small class="mr-2" @click="fnEditItem(item)"> mdi-pencil</v-icon>
        </template>
        <template v-slot:top>
          <v-toolbar flat>
            <v-toolbar-title>Kontrol Soru Grupları</v-toolbar-title>
            <v-spacer/>
            <v-dialog v-model="stateEditDialog">
              <template v-slot:activator="{ on, attrs }">
                <v-btn color="primary" dark class="mb-2" v-bind="attrs" v-on="on">
                  EKLE
                </v-btn>
              </template>
              <v-card>
                <v-card-title>
                  <span class="text-h5">{{ editedItem.name || "Yeni Soru Grubu *" }}</span>
                </v-card-title>
                <v-card-text>
                  <v-container>
                    <v-row>
                      <v-col cols="12" sm="10" md="10">
                        <v-text-field v-model="editedItem.name" label="Soru Grubu"></v-text-field>
                      </v-col>
                      <v-col cols="12" sm="2" md="2">
                        <v-switch
                            v-model="editedItem.state"
                            :label="`${ editedItem.state?'Aktif':'Pasif' }`"
                        ></v-switch>
                      </v-col>
                      <v-col cols="12" sm="4" md="2">
                        <v-text-field v-model="editedItem.sort" type="number"
                                      label="Sıra"></v-text-field>
                      </v-col>
                    </v-row>
                  </v-container>
                </v-card-text>
                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn color="blue darken-1" text @click="close">
                    Vazgeç
                  </v-btn>
                  <v-btn color="blue darken-1" text @click="save">
                    Kaydet
                  </v-btn>
                </v-card-actions>
              </v-card>
            </v-dialog>
          </v-toolbar>
        </template>
        <template v-slot:expanded-item="{ headers, item }">
          <td class="pa-6" :colspan="headers.length">
            <expanded-item @groupTotalSkor="item.totalSkor=$event" :key="item.checkListQuestionGroupId"
                           :qgName="item.name" :qgId="item.checkListQuestionGroupId"></expanded-item>
          </td>
        </template>
        <template v-slot:body.append>
          <tr>
            <td class="pa-6 font-weight-bold text-right" colspan="3">
              Toplam Puan
            </td>
            <td class="font-weight-bold" colspan="3">
              {{ getAllTotalSkor }}
            </td>
          </tr>
        </template>

      </v-data-table>

    </v-col>
  </v-row>
</template>

<script>


import QuestionsGroupItems from "@/components/CheckList/management/QuestionsGroupItems";
import UtilityState from "@/components/app/utilityState";

export default {
  name: "AppManageQuestionsGroup",
  components: {
    UtilityState,
    expandedItem: QuestionsGroupItems
  },
  data() {
    return {
      expanded: [],
      headers: [
        {text: 'Sıralama', align: 'start', value: 'sort',},
        {text: 'Durumu', value: 'state',},
        {text: 'Kontrol Soru Grubu', align: 'start', value: 'name',},
        {text: `Grup Puanı`, value: 'totalSkor'},
        {text: '', value: 'action', sortable: false},
        {text: '', value: 'data-table-expand'},
      ],
      editedItem: {
        checkListQuestionGroupId: '',
        name: '',
        state: false,
        sort: 0,
      },
      createtItem: {
        name: '',
        state: false,
        sort: 0,
      },
      editItemId: '',
      stateEditDialog: false,
    }
  },
  created() {
    this.initialize();
  },
  methods: {
    initialize() {
      this.$store.dispatch('getQuestionGroups')
    },
    fnEditItem(qGroup) {
      this.editedItem = qGroup
      this.editItemId = qGroup.checkListQuestionGroupId
      this.stateEditDialog = true
    },
    close() {
      this.stateEditDialog = false
      this.editedItem = {}
      this.editItemId = ''

    },
    save() {
      if (this.editedItem.checkListQuestionGroupId == "") {
        this.createtItem.name = this.editedItem.name;
        this.createtItem.sort = this.editedItem.sort;
        this.createtItem.state = this.editedItem.state;
        this.$store.dispatch('createQuestionGroup', this.createtItem).then((res) => {
          if (res.data.statusCode == 200) {
            this.close();
          }
        });
      } else {
        this.$store.dispatch('updateQuestionGroup', this.editedItem).then((res) => {
          if (res.data.statusCode == 200) {
            this.close();
          }
        })
      }
    }
  },
  computed: {
    questionGroups: function () {
      return this.$store.getters.getQuestionGroups
    },
    getAllTotalSkor: function () {
      return this.questionGroups.reduce((t, x) => {
        if (x.state) {
          return t + x.totalSkor
        } else {
          return t;
        }

      }, 0);
    },
  }
}
</script>

<style scoped>

</style>