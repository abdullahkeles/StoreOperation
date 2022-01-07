<template>
  <v-container>
<!--    <v-row align="start" justify="center">-->
<!--      <v-col cols="12">-->
<!--        <v-text-field-->
<!--            :append-icon="'mdi-magnify'"-->
<!--            placeholder="Ara"-->
<!--            solo-->
<!--            clearable-->
<!--            @click:append="search"-->
<!--            @keyup.enter="search"-->
<!--        ></v-text-field>-->
<!--      </v-col>-->
<!--    </v-row>-->
    <v-row>
      <v-col cols="12">
        <shope-store-check-list-days/>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
// @ is an alias to /src
import ShopeStoreCheckListDays from "@/components/CheckList/ShopeStoreCheckListDays";
import {mapGetters} from "vuex";

export default {
  name: 'Home',
  components: {
    ShopeStoreCheckListDays,
  },
  data: () => ({

    search: () => {
    }
  }),
  computed:{
    ...mapGetters({

    })
  }

}
</script>