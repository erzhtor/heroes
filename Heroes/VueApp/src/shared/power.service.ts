import { Power } from './power'
import $ from 'jquery'
import { fetchData } from './helpers'

export class PowerService {
    constructor(public apiUrl: string) {
    }

    fetchPowers(): Promise<Power[]> {
        return fetchData<Power[]>(this.apiUrl, 'GET');
    }
}