import Base from './base'
class Hero extends Base {
    constructor(
        public NickName: string,
        public CountryId: number,
        public IsMale: boolean,
        public DateOfBirth: Date,
        public PowerIds: number[]) {
        super()
    }
}
export default Hero