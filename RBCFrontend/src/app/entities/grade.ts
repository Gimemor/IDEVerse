import { Entity } from "./entity";
import { User } from "./user";
import { Task } from "./task";

export class Grade extends Entity {
    public user: User;
    public task: Task;
    public grade: number;
    public isCompleted: boolean;
}