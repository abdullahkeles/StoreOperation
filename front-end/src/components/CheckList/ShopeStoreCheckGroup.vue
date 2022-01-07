<template>
  <v-list>
    <v-list-item-group>
      <template v-for="(item) in group.checkListNewQuestions">
        <v-list-item active-class="" :key="`item-${item.checkListQuestionId}`" :ripple="false">
          <template>
            <v-list-item-content>
              <div class="text--primary" v-html="item.question"/>
            </v-list-item-content>
            <v-list-item-action>
              <v-switch dense v-model="item.answer"/>
            </v-list-item-action>
          </template>
        </v-list-item>
      </template>
    </v-list-item-group>
  </v-list>
</template>

<script>

export default {
  name: "ShopeStoreCheckGroup",
  props: {
    group: {},
  },

}
</script>