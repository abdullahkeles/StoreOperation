<template>
  <v-data-table
      :headers="headers"
      :items="dataStores"
      sort-by="calories"
      class="elevation-1"
  >
    <template v-slot:top>
      <v-toolbar flat>
        <v-toolbar-title>Mağazaların Yönetimi</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-dialog v-model="dialog" max-width="600">
          <template v-slot:activator="{ on, attrs }">
            <v-btn color="primary" dark class="mb-2" v-bind="attrs" v-on="on">
              EKLE
            </v-btn>
          </template>
          <v-card>
            <v-card-title>
              <span class="text-h5">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12" sm="9" md="9">
                    <v-text-field v-model="editedItem.name" label="Mağaza Adı"></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="3" md="3">
                    <v-switch
                        v-model="editedItem.storeState"
                        label="Durumu"
                    ></v-switch>
                  </v-col>
                  <v-col cols="12" sm="8" md="8">
                    <v-text-field v-model="editedItem.vergiKimlikNo" type="number"
                                  label="Vergi Kimlik No"></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="4" md="4">
                    <v-text-field v-model="editedItem.categoryId" label="Mağaza Tipi"></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="6">
                    <v-text-field v-model="editedItem.ilId" label="İli"></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="6">
                    <v-text-field v-model="editedItem.ilceId" label="İlçesi"></v-text-field>
                  </v-col>

                  <v-col cols="12" sm="12" md="12">
                    <v-text-field v-model="editedItem.adress" label="Adres"></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="12" md="12">
                    <v-text-field v-model="editedItem.email" label="e-Posta"></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="6">
                    <v-text-field v-model="editedItem.officePhone" label="Telefon"></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="6">
                    <v-text-field v-model="editedItem.officeFax" label="Fax"></v-text-field>
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
        <v-dialog v-model="dialogDelete" max-width="500px">
          <v-card>
            <v-card-title class="text-h5">Are you sure you want to delete this item?</v-card-title>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" text @click="closeDelete">Cancel</v-btn>
              <v-btn color="blue darken-1" text @click="deleteItemConfirm">OK</v-btn>
              <v-spacer></v-spacer>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
    </template>
    <template v-slot:item.actions="{ item }">
      <v-icon small class="mr-2" @click="editItem(item)"> mdi-pencil</v-icon>
      <!--      <v-icon small @click="deleteItem(item)"> mdi-delete</v-icon>-->
    </template>
    <template v-slot:no-data>
      <v-btn color="primary" @click="initialize">
        Sıfırla
      </v-btn>
    </template>
    <template v-slot:item.storeState="{ item }">
      {{ item.storeState ? "Aktif" : "Pasif" }}
    </template>
  </v-data-table>
</template>

<script>
import ModelRules from "@/utility/ModelRules";

export default {
  name: "AppManageStore",
  data: () => ({
    dialog: false,
    dialogDelete: false,
    rules: ModelRules,
    headers: [
      {text: 'Mağaza', value: 'name',},
      {text: 'Vergi Kimlik No', value: 'vergiKimlikNo',},
      {text: 'İli', value: 'ilId'},
      {text: 'İlçesi', value: 'ilceId'},
      {text: 'Adres', value: 'adress'},
      {text: 'Telefon', value: 'officePhone'},
      {text: 'Fax', value: 'officeFax'},
      {text: 'E-posta', value: 'email'},
      {text: 'Durumu', value: 'storeState'},
      {text: 'Mağaza Tipi', value: 'categoryId'},
      {text: '', value: 'actions', sortable: false},
    ],
    editedIndex: -1,
    editedItem: {
      name: '',
      vergiKimlikNo: '',
      ilId: 0,
      ilceId: 0,
      adress: '',
      officePhone: '',
      officeFax: '',
      email: '',
      storeState: 0,
      categoryId: 0,
      storeId: '',
    },
    defaultItem: {
      name: '',
      vergiKimlikNo: '',
      ilId: 0,
      ilceId: 0,
      adress: '',
      officePhone: '',
      officeFax: '',
      email: '',
      storeState: 0,
      categoryId: 0,
      storeId: '',
    },
  }),

  computed: {
    formTitle() {
      return this.editedIndex === -1 ? 'Yeni Mağaza' : this.editedItem.name
    },
    dataStores: function () {
      return this.$store.getters.getDataStores
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

  created() {
    this.initialize()
  },

  methods: {
    initialize() {
      this.$store.dispatch('getStores')
    },

    editItem(item) {
      this.editedIndex = this.dataStores.indexOf(item)
      this.editedItem = Object.assign({}, item)
      this.dialog = true
    },

    deleteItem(item) {
      this.editedIndex = this.dataStores.indexOf(item)
      this.editedItem = Object.assign({}, item)
      this.dialogDelete = true
    },

    deleteItemConfirm() {
      this.$store.dispatch('deleteStore', this.editedItem.storeId).then((response) => {
        response.data
      })

      this.dataStores.splice(this.editedIndex, 1)
      this.closeDelete()
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
      if (this.editedIndex > -1) {
        let currentItem = this.dataStores[this.editedIndex]
        this.$store.dispatch('updateStore', this.editedItem).then((res) => {
          Object.assign(currentItem, res.data.data)
        })
      } else {
        this.$store.dispatch('createStore', this.editedItem).then(() => {
          this.initialize()
        })
      }
      this.close()
    },
  },
}
</script>
<style scoped>

</style>