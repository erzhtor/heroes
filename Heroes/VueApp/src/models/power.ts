import Base from './base'

class Power extends Base {
    constructor(public ID: number | null, public Name: string, public Description: string | null = null) {
        super(ID)
    }
}

export default Power