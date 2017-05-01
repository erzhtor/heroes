import Vue from 'vue/dist/vue'

export default Vue.extend({
    template: '#create-hero-template',
    data: function() {
        return {
            hero: this.$parent.hero
        }
    }
})
