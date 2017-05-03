import { Power } from './power'

export class PowerService {
    constructor(public URL: string) {
    }

    getPowers(): Power[] {
        return [
            new Power(1, 'Strong'),
            new Power(2, 'Smart'),
            new Power(3, 'Can Fly')
        ]
    }
}