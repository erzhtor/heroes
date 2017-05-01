import Vue from 'vue/dist/vue'
import VueRouter from 'vue-router/dist/vue-router'
import ListHeroesComponent from './heroes/list'
import CreateHeroComponent from './heroes/create'
import Hero from './models/hero'

Vue.use(VueRouter)

const router = new VueRouter({
    history: true,
    root: "my-vue-routing",
    routes: [
        { path: '/list-heroes', component: ListHeroesComponent },
        { path: '/create-hero', component: CreateHeroComponent }
    ]
})

new Vue({
    router,
    el: '#app',
    data: {
        hero: new Hero('Tarzan', 1, true, new Date(1994, 1, 1), [1, 2])
    }
})