import Vue from 'vue/dist/vue'
import VueRouter from 'vue-router/dist/vue-router'
import ListHeroesComponent from './heroes/list-heroes.component'
import CreateHeroComponent from './heroes/create-hero.component'
import { Hero } from './heroes/hero'
import { CountryService } from './shared/country.service'
import { PowerService } from './shared/power.service'
import { Country } from './shared/country'
import { Power } from './shared/power'

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
const countryService = new CountryService(`${apiUrl}/countries`);
const powerService = new PowerService(`${apiUrl}/powers`);

const v = new Vue({
    router,
    el: '#app',
    created: function () {
        this.loadData();
    },
    data: {
        hero: new Hero('Tarzan', 4, true, '1/1/1994', [1, 2]),
        countries: [],
        powers: [],
        apiUrl: apiUrl
    },
    methods: {
        loadData: function () {
            countryService.fetchCountries()
                .then((countries) => {
                    const tmp: Country[] = this.$data.countries;
                    tmp.slice(0, tmp.length)
                    tmp.push(...countries)
                })
                .catch((err) => {
                    console.log(err);
                })
            powerService.fetchPowers()
                .then((powers) => {
                    const tmp: Power[] = this.$data.powers;
                    tmp.slice(0, tmp.length)
                    tmp.push(...powers)
                })
                .catch((err) => {
                    console.log(err);
                })
        }
    }
})
