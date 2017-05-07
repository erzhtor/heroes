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
        countryByID: function (countryID: number, countries: Country[]) {
            for (let country of countries) {
                if (country.ID == countryID)
                    return country.Name
            }
            return 'Not Found'
        },
        powerByID: function (powerID: number, powers: Power[]) {
            for (let power of powers) {
                if (power.ID == powerID)
                    return power.Name
            }
            return 'Not Found'
        }
    }
})