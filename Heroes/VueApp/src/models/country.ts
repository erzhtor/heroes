import Base from './base'

class Country extends Base {
    constructor(ID: number | null, public Name: string, public Description: string | null = null) {
        super(ID)
    }
}

export default Country