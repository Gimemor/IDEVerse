import { UserRight } from "./user-right";
import { Entity } from "./entity";

export class UserRole extends Entity {
  title: string;
  mnemo: string;
  rights: UserRight[];
}
