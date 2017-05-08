import { Country } from "../shared/country";
import $ from "jquery";
import { httpRequest } from "../shared/helpers";

export class CountryService {
    constructor(public apiUrl: string) {
    }

    loadCountries(): Promise<Country[]> {
        return httpRequest<Country[]>(this.apiUrl);
    }
}
