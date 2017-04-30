import Vue from 'vue/dist/vue'
import Hero from './models/hero'

const v = new Vue({
    el: '#app',
    data: {
        message: 'Hello Vue World!',
        hero: new Hero('Tarzan', 1, true, new Date(1994, 1, 1), [1, 2])
    }
})