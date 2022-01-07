export class QuestionGroup {
    QuestionGroupId;
    Name;
    Questions;

    constructor(QuestionGroupId, Name, Questions) {
        this.QuestionGroupId = QuestionGroupId;
        this.Name = Name;
        this.Questions = Questions;
    }
}