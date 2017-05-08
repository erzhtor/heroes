export class CountryService {

    private static _instance: CountryService;

    private constructor() {
    }

    static createInstance(): void {
        CountryService.getInstance();
    }

    static getInstance(): CountryService {
        return this._instance || (this._instance = new this());
    }

}
