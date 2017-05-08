import { Hero } from "../shared/hero";
import $ from "jquery";
import { httpRequest } from "../shared/helpers";


export class HeroService {
    constructor(public apiUrl: string) {
    }

    public fetchHeroes(): Promise<Hero[]> {
        return httpRequest<Hero[]>(this.apiUrl);
    }

    public postHero(hero: Hero): Promise<Hero> {
        return httpRequest<Hero>(this.apiUrl, "POST", hero);
    }
}
