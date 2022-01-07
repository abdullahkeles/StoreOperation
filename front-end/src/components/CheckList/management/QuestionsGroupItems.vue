<template>
  <v-data-table
      :headers="headers"
      :items="questions"
      class="elevation-1"
      :items-per-page="-1"
      hide-default-footer
      multi-sort
      :sort-by="['state','sort']"
      :sort-desc="[true,false]"
  >
    <template v-slot:item.state="{ item }">
      <utility-state :state="item.state"/>
    </template>

    <template v-slot:top>
      <v-toolbar flat>
        <v-toolbar-title>{{ qgName }}</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-dialog
            v-model="dialog"
            max-width="500px"
        >
          <template v-slot:activator="{ on, attrs }">
            <v-btn color="primary" dark class="mb-2" v-bind="attrs" v-on="on"> Soru Ekle</v-btn>
          </template>
          <v-card>
            <v-card-title>
              <span class="text-h5">{{ qgName + " Grubuna Soru Ekleme" }}</span>
            </v-card-title>

            <v-card-text>
              <v-container>
                <v-row>
                  <v-col
                      cols="12"
                      sm="12"
                      md="12"
                  >
                    <v-text-field
                        v-model="editedItem.question"
                        label="Soru"
                    ></v-text-field>
                  </v-col>
                  <v-col
                      cols="12"
                      sm="6"
                      md="4"
                  >
                    <v-text-field
                        v-model="editedItem.skor"
                        label="Puan"
                    ></v-text-field>
                  </v-col>
                  <v-col
                      cols="12"
                      sm="6"
                      md="4"
                  >
                    <v-text-field
                        v-model="editedItem.sort"
                        label="Sıralama"
                    ></v-text-field>
                  </v-col>
                  <v-col
                      cols="12"
                      sm="6"
                      md="4"
                  >
                    <v-switch
                        v-model="editedItem.state"
                        :label="`${ editedItem.state?'Aktif':'Pasif' }`"
                    ></v-switch>
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
    <template v-slot:item.actions="{ item }">
      <v-icon
          small
          class="mr-2"
          @click="editItem(item)"
      >
        mdi-pencil
      </v-icon>
    </template>
    <template v-slot:no-data>
      <v-btn
          color="primary"
          @click="initialize"
      >
        Reset
      </v-btn>
    </template>
  </v-data-table>
</template>


<script>
import UtilityState from "@/components/app/utilityState";

export default {
  components: {UtilityState},
  props: ['qgId', 'qgName'],
  data: () => ({
    questions: [],
    dialog: false,
    dialogDelete: false,
    headers: [
      {text: 'Soru', value: 'question',},
      {text: 'Puan', value: 'skor'},
      {text: 'Sıralama', value: 'sort'},
      {text: 'Durumu', value: 'state'},
      {text: '', value: 'actions', sortable: false},
    ],
    editedIndex: -1,
    editedItem: {
      question: '',
      skor: 0,
      sort: 0,
      state: true,
    },
    defaultItem: {
      question: '',
      skor: 0,
      sort: 0,
      state: true,
    },
  }),
  created() {
    this.initialize();

  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? 'New Item' : 'Edit Item'
    },
  },

  watch: {
    dialog(val) {
      val || this.close()
    },
    dialogDelete(val) {
      val || this.closeDelete()
    },
  },

  methods: {
    initialize() {
      this.$store.dispatch('getCheckListQuestionInGroup', this.qgId).then((qs) => {
        this.questions = qs
      }).then(() => {
        let groupTotalSkor = this.questions.reduce(function (toplam, x) {
          if (x.state) {
            return toplam + x.skor
          } else {
            return toplam;
          }

        }, 0)
        console.log("groupTotalSkor", groupTotalSkor)
        this.$emit("groupTotalSkor", groupTotalSkor)
      });
    },

    editItem(item) {
      this.editedItem = Object.assign({}, item)
      this.dialog = true
    },
    close() {
      this.dialog = false
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem)
        this.editedIndex = -1
      })
    },

    closeDelete() {
      this.dialogDelete = false
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem)
        this.editedIndex = -1
      })
    },

    save() {
      if (this.editedItem.checkListQuestionId) {
        this.$store.dispatch('updateQuestion', this.editedItem).then(() => {
          this.initialize();
          this.close();
        })
      } else {
        var item = Object.assign({}, this.editedItem);
        item.checkListQuestionGroupId = this.qgId;
        this.$store.dispatch('createQuestion', item).then(() => {
          this.initialize();
          this.close();
        });
      }
    },
    getStateColor(state) {
      if (state) {
        return 'success'
      } else {
        return 'grey'
      }
    },
  },
}
</script>