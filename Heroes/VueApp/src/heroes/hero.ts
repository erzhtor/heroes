import Base from '../shared/base'

export class Hero extends Base {
    constructor(
        public NickName: string,
        public CountryId: number,
        public IsMale: boolean,
        public DateOfBirth: string,
        public PowerIDs: number[]) {
        super()
    }
}