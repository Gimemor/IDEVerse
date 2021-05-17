import {Component, EventEmitter, Input, OnInit, Output} from "@angular/core";
import {Observable} from "rxjs";

@Component({
  selector: "app-verse-selector",
  templateUrl: "verse-selector.component.html"
})

export class VerseSelectorComponent implements OnInit {
  @Input() dataSource: Observable<string[]>;
  @Output() wordSelected = new EventEmitter<string>();
  constructor() {
  }

  ngOnInit() {
  }

  handleSelect(word): void {
    this.wordSelected.next(word);
  }
}
