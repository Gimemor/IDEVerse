import { Component, OnInit } from '@angular/core';
import { Schedule } from '../../entities/schedule';
import { Subject } from 'src/app/entities/subject';
import { SubjectService } from 'src/app/services/subject.service';
import { catchError } from 'rxjs/operators';
import { EMPTY } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { ScheduleService } from 'src/app/services/schedule.service';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent implements OnInit {
  public scheduleItems: Schedule[] = [
  ];

  public allSubjects: Subject[] = [];

  constructor(private subjectService: SubjectService, private scheduleService: ScheduleService, private toastr: ToastrService) {
   }

  ngOnInit(): void {
    this.scheduleService.getSchedule().pipe(catchError(e => {
      this.toastr.error('Ошибка запроса предметов:' + e.message);
      return EMPTY;
    })).subscribe(schedule => {
      this.scheduleItems = schedule;
      console.log(schedule);
    });
  }
}
