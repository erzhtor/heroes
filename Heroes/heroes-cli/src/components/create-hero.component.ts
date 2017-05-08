import { SearchHeroesComponent } from "./search-hero.component";
import { Hero } from "../shared/hero";
import Vue from "vue";
import Component from "vue-class-component";

@Component({
    template: require("./create-hero.component.html")
})
export class CreateHeroComponent extends Vue {
    constructor() {
        super();
    }

    private hero: Hero = new Hero("", 0, true, "", []);
    mounted(): void { }

    submitHero(): void {
        // test
    }
}
