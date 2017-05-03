import Vue from 'vue/dist/vue'
import $ from 'jquery'

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
        submit: function (): void {
        }
    }
})
