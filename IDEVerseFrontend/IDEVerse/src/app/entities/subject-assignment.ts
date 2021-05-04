import { Entity } from "./entity";
import { Subject } from "./subject";
import { User } from "./user";

export class SubjectAssignment extends Entity {
    public subject: Subject;
    public user: User;
    public isCompleted: boolean;
}