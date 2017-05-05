import { Country } from './country'
import $ from 'jquery'
import { fetchData } from './helpers'

export class CountryService {
    constructor(public apiUrl: string) {
    }

    public fetchCountries(): Promise<Country[]> {
        return fetchData<Country[]>(this.apiUrl, 'GET');
    }
}