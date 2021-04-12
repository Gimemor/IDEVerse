import { Entity } from './entity';

export class UserRight extends Entity {
  title: string;
  description: string;
  mnemo: string;
}


export enum RightsMnemos {
  controlPanelAccess = 'right.rbcacademy/control-panel-access',
  scheduleAccess = 'right.rbcacademy/schedule-access',
}
