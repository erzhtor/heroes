import Vue from 'vue/dist/vue'
import VueRouter from 'vue-router/dist/vue-router'
import { CreateHeroComponent, ListHeroesComponent } from './components'
import { Hero, Country, Power } from './models'
import { PowerService, CountryService, HeroService, httpRequest } from './services'

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
const countryService = new CountryService(`${apiUrl}/countries`)
const powerService = new PowerService(`${apiUrl}/powers`)
const heroService = new HeroService(`${apiUrl}/heroes`)

const v = new Vue({
    router,
    el: '#app',
    created: function () {
        this.initPowers();
        this.initCountries();
        this.initHeroes();
    },
    data: {
        countries: [],
        powers: [],
        heroes: []
    },
    methods: {
        initPowers: function () {
            powerService.fetchPowers()
                .then((powers) => {
                    const tmp: Power[] = this.$data.powers;
                    tmp.slice(0, tmp.length)
                    tmp.push(...powers)
                })
                .catch((err) => {
                    console.log(err);
                })
        },
        initHeroes: function () {
            heroService.fetchHeroes()
                .then((heroes) => {
                    const tmp: Hero[] = this.$data.heroes;
                    tmp.slice(0, tmp.length)
                    tmp.push(...heroes)
                })
                .catch((err) => {
                    console.log(err);
                })
        },
        initCountries: function () {
            countryService.fetchCountries()
                .then((countries) => {
                    const tmp: Country[] = this.$data.countries;
                    tmp.slice(0, tmp.length)
                    tmp.push(...countries)
                })
                .catch((err) => {
                    console.log(err);
                })
        },
        submitHero: function (hero: Hero) {
            heroService.postHero(hero)
                .then((hero: Hero) => {
                    this.$data.heroes.unshift(hero)
                    router.push({ path: '/list-heroes' })
                    alert('successfully created')
                })
                .catch((err) => {
                    alert(err)
                })
        }
    }
})
