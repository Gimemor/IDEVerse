import { SharedModule } from './../shared/shared.module';
import { MaterialModule } from 'src/app/material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TasksComponent } from './tasks.component';
import { TaskComponent } from './task/task.component';

@NgModule({
  declarations: [TasksComponent, TaskComponent],
  imports: [
    CommonModule,
    SharedModule,
    MaterialModule
  ]
})
export class TasksModule { }
