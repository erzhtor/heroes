import Vue from 'vue/dist/vue'
import VueRouter from 'vue-router/dist/vue-router'
import VeeValidate from 'vee-validate';
import $ from 'jquery'
import { CreateHeroComponent, ListHeroesComponent } from './heroes/index'
import { Hero, Country, Power } from './models/index'

Vue.use(VeeValidate);
Vue.use(VueRouter)

const router = new VueRouter({
    history: true,
    root: "my-vue-routing",
    routes: [
        { path: '/list-heroes', component: ListHeroesComponent },
        { path: '/create-hero', component: CreateHeroComponent }
    ]
})

const v = new Vue({
    router,
    el: '#app',
    created: function () {
        this.loadCountries();
        this.loadPowers();
    },
    data: {
        hero: new Hero('Tarzan', 1, true, new Date(1994, 1, 1), [1, 2]),
        countries: [],
        powers: []
    },
    methods: {
        loadCountries: function () {
            this.$data.countries = [
                new Country(1, 'KG'),
                new Country(2, 'RU'),
                new Country(3, 'US')
            ]
//            const that = this;
//            $.ajax({
//                url: "/api/countries",
//                method: "GET",
//                success: (response) => {
//                    that.$data.countries = [
//                        new Country(1, 'KG'),
//                        new Country(2, 'RU'),
//                        new Country(3, 'US')
//                    ]
////                        response as Country[]
//                    console.log(that.$data.countries);
//                },
//                error: function () {
//                    console.log("Oops")
//                }
//            })
        },
        loadPowers: function () {
            this.$data.powers = [
                new Power(1, 'Strong'),
                new Power(2, 'Smart'),
                new Power(3, 'Can Fly')
            ]
        }
    }
})

//VeeValidate.Validator.extend('passphrase', {
//    getMessage: field => 'Sorry dude, wrong pass phrase.',
//    validate: value => value.toUpperCase() == 'Demogorgon'.toUpperCase()
//});
