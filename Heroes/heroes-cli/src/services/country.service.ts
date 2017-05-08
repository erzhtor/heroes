import { Country } from "../shared/country";
import $ from "jquery";
import { httpRequest } from "../shared/helpers";

export class CountryService {
    constructor(public apiUrl: string) {
    }

    fetchCountries(): Promise<Country[]> {
        return httpRequest<Country[]>(this.apiUrl);
    }
}
