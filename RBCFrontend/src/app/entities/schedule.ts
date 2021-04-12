import { Entity } from "./entity";
import * as moment from "moment";
import { Subject } from "./subject";
import { User } from "./user";

export class Schedule extends Entity {
    public lessonDate: moment.Moment;
    public subject: Subject;
    public teacher: User;
    public attendance: User[];

    constructor(learningDate: moment.Moment, subject: Subject, teacher: User) {
        super();
        this.lessonDate = learningDate;
        this.subject = subject;
        this.teacher = teacher;
    }
}
