import { Country } from './country'
import $ from 'jquery'
import { httpRequest } from './helpers'

export class CountryService {
    constructor(public apiUrl: string) {
    }

    public fetchCountries(): Promise<Country[]> {
        return httpRequest<Country[]>(this.apiUrl);
    }
}