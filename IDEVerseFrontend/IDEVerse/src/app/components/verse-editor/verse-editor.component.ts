import {Component, OnInit} from "@angular/core";
import * as BalloonEditor from "@ckeditor/ckeditor5-build-balloon";

@Component({
  selector: "app-verse-editor-component",
  templateUrl: "verse-editor.component.html",
  styleUrls: [ "verse-editor.component.css" ]
})

export class VerseEditorComponent implements OnInit {
  public Editor = BalloonEditor;

  constructor() {
  }

  ngOnInit() {
  }
}
