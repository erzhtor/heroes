import { Base } from "./base";

export class Power extends Base {
    constructor(public ID: number | null, public Name: string, public Description: string | null = null) {
        super(ID);
    }
}
