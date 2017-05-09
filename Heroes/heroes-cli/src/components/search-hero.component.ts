import Vue from "vue";
import Component from "vue-class-component";
import { Inject, Provide, Watch, Prop } from "vue-property-decorator";
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

    @Prop() countries: Country[];
    @Prop() powers: Power[];

    mounted(): void { }

    search(): void {
        this.$emit("filter-heroes", this.filterHero);
    }

    clear(): void {
        this.filterHero = new FilterHero();
        this.$emit("filter-heroes", this.filterHero);
    }
}
