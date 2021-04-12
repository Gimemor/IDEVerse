import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ScheduleComponent } from './schedule.component';
import { MatCardModule } from '@angular/material/card';
import { ScheduleItemComponent } from './schedule-item/schedule-item.component';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [ScheduleComponent, ScheduleItemComponent],
  imports: [
    CommonModule,
    MatCardModule,
    SharedModule,
    ToastrModule.forRoot(),
  ],
  providers: []
})
export class ScheduleModule { }
