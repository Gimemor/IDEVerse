import { Entity } from "./entity";
import * as moment from "moment";

export class Subject extends Entity {
  public title: string;
  public deadline: moment.Moment;

  constructor(title: string, deadline: moment.Moment) {
    super();
    this.title = title;
    this.deadline = deadline;
  }
}
