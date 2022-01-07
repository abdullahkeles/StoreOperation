export class CheckListDay {
    DayId;
    ShopeStoreId;
    CheckLists;
    Day;
    Rank;


    constructor(DayId,ShopeStoreId, CheckLists, Day, Rank ) {
        this.DayId = DayId;
        this.ShopeStoreId=ShopeStoreId
        this.CheckLists = CheckLists;
        this.Day = Day;
        this.Rank = Rank;
    }
}