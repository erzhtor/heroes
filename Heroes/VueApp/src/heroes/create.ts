import Vue from 'vue/dist/vue'

export default Vue.extend({
    template: '#create-hero-template',
    data () {
        return {
            hero: this.$parent.hero,
            countries: this.$parent.countries,
            powers: this.$parent.powers
        }
    }
})
