import Vue from 'vue/dist/vue'
import { Country } from '../shared/country'
import { Power } from '../shared/power'

export default Vue.extend({
    template: '#list-heroes-template',
    data() {
        return {
            heroes: this.$parent.heroes,
            countries: this.$parent.countries,
            powers: this.$parent.powers
        }
    },
    filters: {
        genderToStr: function (isMale: boolean) {
            return isMale ? 'Male' : 'Female'
        },
        countryByID: function (countryId: number, countries: Country[]) {
            for (let country of countries) {
                if (country.ID == countryId)
                    return country.Name
            }
            return 'Not Found'
        },
        powerById: function (powerId: number, powers: Power[]) {
            for (let power of powers) {
                if (power.ID == powerId)
                    return power.Name
            }
            return 'Not Found'
        }
    }
})