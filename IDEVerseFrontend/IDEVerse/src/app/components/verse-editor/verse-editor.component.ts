import {Component, OnInit} from "@angular/core";
import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";

@Component({
  selector: "app-verse-editor-component",
  templateUrl: "verse-editor.component.html"
})

export class VerseEditorComponent implements OnInit {
  public Editor = ClassicEditor;

  constructor() {
  }

  ngOnInit() {
  }
}
