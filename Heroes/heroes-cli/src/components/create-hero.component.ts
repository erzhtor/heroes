import { PowerService } from "../services/power.service";
import { Country } from "../shared/country";
import { Inject } from "vue-property-decorator";
import { SearchHeroesComponent } from "./search-hero.component";
import { Hero } from "../shared/hero";
import Vue from "vue";
import Component from "vue-class-component";
import { Power } from "../shared/power";
import { CountryService } from "../services/country.service";

@Component({
    template: require("./create-hero.component.html")
})
export class CreateHeroComponent extends Vue {
    constructor() {
        super();
    }
    @Inject() powerService: PowerService;
    @Inject() countryService: CountryService;

    private hero: Hero = new Hero("", 0, true, "", []);

    countries: Country[] = null;
    powers: Power[] = null;

    mounted(): void {
        this.powerService.fetchPowers()
            .then((result) => {
                this.powers = result;
            })
            .catch(err => {
                alert(err);
            });
        this.countryService.loadCountries()
            .then((result) => {
                this.countries = result;
            })
            .catch(err => {
                alert(err);
            });
    }
    submitHero(): void {
        // test
    }
}
