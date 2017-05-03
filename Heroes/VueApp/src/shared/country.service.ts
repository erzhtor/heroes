import { Country } from './country'
import $ from 'jquery'

export class CountryService {
    constructor(public apiURL: string) {

    }

    public getCountries(): Country[] {
        return [
            new Country(1, 'KG'),
            new Country(2, 'RU'),
            new Country(3, 'US')
        ]
    }
}