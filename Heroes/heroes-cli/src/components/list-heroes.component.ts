import { FilterHero } from './../shared/filter-hero';
import { HeroService } from "../services/hero.service";
import { Inject } from "vue-property-decorator";
import Vue from "vue";
import Component from "vue-class-component";
import { Hero } from "../shared/hero";
import { CountryService } from "../services/country.service";
import { PowerService } from "../services/power.service";
import { Country } from "../shared/country";
import { Power } from "../shared/power";

@Component({
    template: require("./list-heroes.component.html"),
    filters: {
        genderToStr: function (isMale: boolean): string {
            return isMale ? "Male" : "Female";
        },
        countryByID: function (countryID: number, countries: Country[]): string {
            for (let country of countries) {
                if (country.ID === countryID) {
                    return country.Name;
                }
            }
            return "Not Found";
        },
        powerByID: function (powerID: number, powers: Power[]): string {
            for (let power of powers) {
                if (power.ID === powerID) {
                    return power.Name;
                }
            }
            return "Not Found";
        }
    }
})
export class ListHeroesComponent extends Vue {
    constructor() {
        super();
    }

    @Inject() heroService: HeroService;
    @Inject() powerService: PowerService;
    @Inject() countryService: CountryService;

    heroes: Hero[] = null;
    countries: Country[] = null;
    powers: Power[] = null;

    mounted(): void {
        let filter: FilterHero = new FilterHero();
        filter.IsMale = true;
        this.loadHeroes(filter);
        this.loadCountries();
        this.loadPowers();
    }

    loadHeroes(filter: FilterHero = null): void {
        this.heroService.fetchHeroes(filter)
            .then((heroes) => {
                this.heroes = heroes;
            })
            .catch((err) => {
                console.log(err);
            });
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
}
