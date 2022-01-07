export class CheckList {
    TimeSpan;
    QuestionGroups;
    Rank;
    Note;
    CheckListDayId;
    AppUser;

    constructor(TimeSpan, QuestionGroups, Rank, Note, CheckListDayId, AppUser) {
        this.TimeSpan = TimeSpan;
        this.QuestionGroups = QuestionGroups;
        this.Rank = Rank;
        this.Note = Note;
        this.CheckListDayId = CheckListDayId;
        // object
        this.AppUser = AppUser;
    }
}