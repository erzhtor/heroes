import { Power } from './power'
import $ from 'jquery'
import { httpRequest } from './helpers'

export class PowerService {
    constructor(public apiUrl: string) {
    }

    fetchPowers(): Promise<Power[]> {
        return httpRequest<Power[]>(this.apiUrl);
    }
}