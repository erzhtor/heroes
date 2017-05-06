import Vue from 'vue/dist/vue'
import $ from 'jquery'
import { HeroService } from './hero.service'

export default Vue.extend({
    template: '#create-hero-template',
    data () {
        return {
            hero: this.$parent.hero,
            countries: this.$parent.countries,
            powers: this.$parent.powers
        }
    },
    methods: {
        submitHero: function (): void {
            this.$parent.submitHero(this.hero)
        }
    }
})
