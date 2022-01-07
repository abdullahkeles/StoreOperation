<template>
  <v-list>
    <v-list-item>
      <v-list-item-avatar>
        <v-img lazy-src="@/assets/account.black.png" :src="profileImage" />
      </v-list-item-avatar>
    </v-list-item>
    <v-list-item link>
      <v-list-item-content>
        <v-list-item-title class="text-h6">
          {{ info.name }} {{ info.surName }}
        </v-list-item-title>
        <v-list-item-subtitle>{{ info.email }}</v-list-item-subtitle>
      </v-list-item-content>
      <v-list-item-action>
        <v-icon>mdi-menu-down</v-icon>
      </v-list-item-action>
    </v-list-item>
  </v-list>
</template>
<script>

export default {
  name: "LeftUserNavigation",
  data: () => ({
    info: {},
    profileImage: {}
  }),
  created() {
    this.initialize();
  },
  computed: {
    getProfileImage: function () {
      return this.profileImage
    }
  },
  methods: {
    initialize() {
      this.$store.dispatch('userInfo').then((info) => {
        this.info = info.data.data;
      });
      this.$store.dispatch('userProfileImage').then((pImage) => {
        var data=pImage.data.data;
        this.profileImage = `data:${data.contentType};base64,${data.bytes}`;
      })
    }
  }
}
</script>

<style scoped>

</style>