import { Entity } from "./entity";
import * as moment from "moment";
import { Subject } from "./subject";

export class Task extends Entity {
    public title: string;
    public description: string;
    public deadline: moment.Moment;
    public subject: Subject;
}
