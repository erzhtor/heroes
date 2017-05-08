import Vue from "vue";
import Component from "vue-class-component";
import { Inject, Provide, Watch } from "vue-property-decorator";
import { FilterHero } from "../shared/filter-hero";
import { PowerService } from "../services/power.service";
import { CountryService } from "../services/country.service";
import { Power } from "../shared/power";
import { Country } from "../shared/country";

@Component({
    template: require("./search-hero.component.html"),
    name: "search-heroes"
})
export class SearchHeroesComponent extends Vue {
    @Inject() apiUrl: string;
    @Inject() powerService: PowerService;
    @Inject() countryService: CountryService;
    constructor() {
        super();
    }

    filterHero: FilterHero = new FilterHero();
    countries: Country[] = null;
    powers: Power[] = null;

    mounted(): void {
        this.loadCountries();
        this.loadPowers();
    }

    loadCountries(): void {
        this.countryService.fetchCountries()
            .then((result) => {
                this.countries = result;
            })
            .catch(err => {
                alert(err);
            });
    }
    loadPowers(): void {
        this.powerService.fetchPowers()
            .then((result) => {
                this.powers = result;
            })
            .catch(err => {
                alert(err);
            });
    }

    search(): void {
        console.log("search");
    }
}
