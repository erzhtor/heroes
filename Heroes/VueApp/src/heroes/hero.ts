import Base from '../shared/base'

export class Hero extends Base {
    constructor(
        public NickName: string,
        public CountryID: number,
        public IsMale: boolean,
        public DateOfBirth: string,
        public PowerIDs: number[]) {
        super()
    }
}