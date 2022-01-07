<template>
  <span class="green--text" v-if="answer">{{trans}}</span>
  <span class="red--text" v-else>{{trans}}</span>
</template>

<script>
export default {
  name: "checListQuestionAnswer",
  props:['answer'],
  computed:{
    trans:function (){
      return this.answer?"Evet":"Hayır";
    }
  }
}
</script>

<style scoped>

</style>