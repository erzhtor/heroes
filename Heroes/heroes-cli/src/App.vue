<template>
    <div id="app">
        <div>
            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <a class="navbar-brand" href="#">Heroes IMS</a>
                    </div>
                    <ul class="nav navbar-nav">
                        <router-link tag="li" to="/" active-class="active" exact>
                            <a>Home</a>
                        </router-link>
                        <router-link tag="li" to="/create-hero" active-class="active">
                            <a>Create New Hero</a>
                        </router-link>
                    </ul>
                </div>
            </nav>
            <div class="container">
                <router-view></router-view>
            </div>
        </div>
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
