import Vue from "vue/dist/vue";
import $ from "jquery";
import { HeroService } from "../services";
import { Hero } from "../models";

const CreateHeroComponent = Vue.extend({
    template: "#create-hero-template",
    data() {
        return {
            hero: new Hero("", 0, true, "", []),
            countries: this.$parent.countries,
            powers: this.$parent.powers
        };
    },
    methods: {
        submitHero: function (): void {
            this.$parent.submitHero(this.hero);
        }
    }
});

export { CreateHeroComponent };
