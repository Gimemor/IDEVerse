import { UserRole } from 'src/app/entities/user-role';
import { Entity } from './entity';
import { Subject } from './subject';
import { Schedule } from './schedule';

export class User extends Entity {
    public phone: string;
    public email: string;
    public firstName: string;
    public lastName: string;
    public roleId: string;
    public role: UserRole;
    public subjects: Subject[];
    public isConfirmed: boolean;
    public attendance: Schedule[];
}
