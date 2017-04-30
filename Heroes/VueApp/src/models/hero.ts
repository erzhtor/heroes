export default class Hero {
    constructor(
        public NickName: string,
        public CountryId: number,
        public IsMale: boolean,
        public DateOfBirth: Date,
        public PowerIds: number[],
        public Id: number | null = null,
        public CreatedAt: Date | null = null) {

    }
}