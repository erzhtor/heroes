import { FilterHero } from "./../shared/filter-hero";
import { Hero } from "../shared/hero";
import $ from "jquery";
import { httpRequest } from "../shared/helpers";


export class HeroService {
    constructor(public apiUrl: string) {
    }

    public fetchHeroes(filter: FilterHero = null): Promise<Hero[]> {
        let query: string = filter ? this.filterToRequestQuery(filter) : "";
        return httpRequest<Hero[]>(`${this.apiUrl}?${query}`);
    }

    private filterToRequestQuery(f: FilterHero): string {
        let query: string = "";
        if (f.Nickname != null) {
            query += `nickname=${f.Nickname}`;
        }
        if (f.IsMale != null) {
            query += `&ismale=${f.IsMale}`;
        }
        if (f.CountryID != null) {
            query += `&countryid=${f.CountryID}`;
        }
        if (f.PowerID != null) {
            query += `&powerid=${f.PowerID}`;
        }
        return query.trim();
    }

    public postHero(hero: Hero): Promise<Hero> {
        return httpRequest<Hero>(this.apiUrl, "POST", hero);
    }
}
