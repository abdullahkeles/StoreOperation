<template>
  <v-container class="fill-height" fluid>
    <v-layout fill-height align-center justify-center>
      <v-flex xs12 sm6 md4 lg4 xl3>
        <v-card>
          <v-card-title class="justify-center">
            <img src="../assets/b&oil-200.png" height="80" width="200"/>
          </v-card-title>
          <v-card-text>
            <v-form>
              <v-text-field
                  ref="userName"
                  v-model="model.userName"
                  :rules="[rules.required]"
                  name="email"
                  autocomplete="email"
                  label="Kullanıcı Adı"
                  hint="example@xxx.com"
                  counter
              ></v-text-field>
              <v-text-field
                  ref="password"
                  v-model="model.password"
                  :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
                  :rules="[rules.required, rules.min]"
                  :type="showPassword ? 'text' : 'password'"
                  name="password"
                  autocomplete="current-password"
                  label="Parola"
                  hint="Güçlü şifre için en az 6 karakter önerilir."
                  counter
                  @click:append="showPassword = !showPassword"
              ></v-text-field>
            </v-form>
          </v-card-text>
          <v-card-actions class="justify-end">
            <v-btn class="ma-2" :loading="loading" :disabled="loading" color="primary" rounded @click="login()">
              Devam
            </v-btn>
          </v-card-actions>
        </v-card>

      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import {AppLogon} from "@/models/AppLogon";
import ModelRules from "@/utility/ModelRules";

export default {
  name: "Logon",
  data() {
    return {
      rules: ModelRules,
      model: new AppLogon("", ""),
      showPassword: false,
      loader: null,
      loading: false,
      formHasErrors: false,
    }
  },
  computed: {
    form() {
      return {
        model: this.model
      }
    }
  },
  methods: {
    login() {
      this.formHasErrors = false
      Object.keys(this.form.model).forEach(f => {
        if (!this.form.model[f]) this.formHasErrors = true;
        this.$refs[f].validate(true);
      })
      if (!this.formHasErrors) {
        const request = this.$store.dispatch("logon", this.model);
        this.$store.commit('setOverlay', {stt: true});
        request.then((x) => {
          console.log(x);
          this.$store.commit('setOverlay', {stt: false});
          this.$router.push({name: "Home"});
        })
      }
    }
  }
}
</script>

<style scoped>

</style>