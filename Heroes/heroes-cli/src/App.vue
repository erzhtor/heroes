<template>
  <div id="app">
    <router-view></router-view>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
import { Provide } from "vue-property-decorator";

@Component({
  name: "app",
  template: "#app"
})
export default class App extends Vue {
    constructor() {
        super();
    }
    
    @Provide() apiUrl: string="/api";

    mounted(): void { }
}
</script>
