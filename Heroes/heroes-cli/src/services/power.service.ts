import { Power } from "../shared/power";
import $ from "jquery";
import { httpRequest } from "../shared/helpers";

export class PowerService {
    constructor(public apiUrl: string) {
    }

    fetchPowers(): Promise<Power[]> {
        return httpRequest<Power[]>(this.apiUrl);
    }
}
