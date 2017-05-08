import Vue from "vue/dist/vue";
import VueRouter from "vue-router/dist/vue-router";
import { CreateHeroComponent, ListHeroesComponent } from "./components";
import { Hero, Country, Power } from "./models";
import { PowerService, CountryService, HeroService, httpRequest } from "./services";

Vue.use(VueRouter);
const router: any = new VueRouter({
    history: true,
    root: "/",
    routes: [
        { path: "/list-heroes", component: ListHeroesComponent },
        { path: "/create-hero", component: CreateHeroComponent }
    ]
});
const apiUrl: string = "/api";
const countryService: CountryService = new CountryService(`${apiUrl}/countries`);
const powerService: PowerService = new PowerService(`${apiUrl}/powers`);
const heroService: HeroService = new HeroService(`${apiUrl}/heroes`);

const v: any = new Vue({
    router,
    el: "#app",
    created: function (): void {
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
        initPowers: function (): void {
            powerService.fetchPowers()
                .then((powers) => {
                    const tmp: Power[] = this.$data.powers;
                    tmp.slice(0, tmp.length);
                    tmp.push(...powers);
                })
                .catch((err) => {
                    console.log(err);
                });
        },
        initHeroes: function (): void {
            heroService.fetchHeroes()
                .then((heroes) => {
                    const tmp: Hero[] = this.$data.heroes;
                    tmp.slice(0, tmp.length);
                    tmp.push(...heroes);
                })
                .catch((err) => {
                    console.log(err);
                });
        },
        initCountries: function (): void {
            countryService.fetchCountries()
                .then((countries) => {
                    const tmp: Country[] = this.$data.countries;
                    tmp.slice(0, tmp.length);
                    tmp.push(...countries);
                })
                .catch((err) => {
                    console.log(err);
                });
        },
        submitHero: function (hero: Hero): void {
            heroService.postHero(hero)
                .then((hero: Hero) => {
                    this.$data.heroes.unshift(hero);
                    router.push({ path: "/list-heroes" });
                    alert("successfully created");
                })
                .catch((err) => {
                    alert(err);
                });
        }
    }
});
