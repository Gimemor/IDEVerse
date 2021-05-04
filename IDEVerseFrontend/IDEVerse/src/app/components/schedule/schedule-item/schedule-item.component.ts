import { Component, OnInit, Input } from '@angular/core';
import { Schedule } from 'src/app/entities/schedule';

@Component({
  selector: 'app-schedule-item',
  templateUrl: './schedule-item.component.html',
  styleUrls: ['./schedule-item.component.css']
})
export class ScheduleItemComponent implements OnInit {
  @Input() public schedule: Schedule;

  constructor() { }

  ngOnInit(): void {
  }

}
