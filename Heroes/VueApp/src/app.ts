import Vue from 'vue/dist/vue'
import VueRouter from 'vue-router/dist/vue-router'
import ListHeroesComponent from './heroes/list-heroes.component'
import CreateHeroComponent from './heroes/create-hero.component'
import { Hero } from './heroes/hero'
import { CountryService } from './shared/country.service'
import { PowerService } from './shared/power.service'

Vue.use(VueRouter)
const router = new VueRouter({
    history: true,
    root: "/",
    routes: [
        { path: '/list-heroes', component: ListHeroesComponent },
        { path: '/create-hero', component: CreateHeroComponent }
    ]
})
const apiUrl = '/api';
const countryService = new CountryService(apiUrl);
const powerService = new PowerService(apiUrl);

const v = new Vue({
    router,
    el: '#app',
    created: function () {
        this.$data.countries = countryService.getCountries();
        this.$data.powers = powerService.getPowers();
    },
    data: {
        hero: new Hero('Tarzan', 1, true, '1/1/1994', [1, 2]),
        countries: [],
        powers: [],
        apiUrl: apiUrl
    }
})
