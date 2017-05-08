<template>
    <div id="app">
        <router-view></router-view>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
import { Provide } from "vue-property-decorator";
import { Country } from "./shared/country";
import { Power } from "./shared/power";
import { Hero } from "./shared/hero";
import { CountryService } from "./services/country.service";
import { PowerService } from "./services/power.service";
import { HeroService } from "./services/hero.service";

@Component({
    name: "app",
    template: "#app"
})
export default class App extends Vue {
    @Provide() apiUrl: string = "/api";

    @Provide() countryService: CountryService = new CountryService(`${this.apiUrl}/countries`);
    @Provide() powerService: PowerService = new PowerService(`${this.apiUrl}/powers`);
    @Provide() heroService: HeroService = new HeroService(`${this.apiUrl}/heroes`);

    constructor() {
        super();
    }

    mounted(): void { }
}
</script>
