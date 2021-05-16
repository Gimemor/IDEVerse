import {Component, OnInit} from "@angular/core";
import {AngularEditorConfig, AngularEditorService} from "@gimemor/angular-editor-exp";
import {VerseTheftService} from "../../services/verse-theft.service";
import {take} from "rxjs/operators";

@Component({
  selector: "app-verse-editor-component",
  templateUrl: "verse-editor.component.html",
  styleUrls: [ "verse-editor.component.css" ]
})

export class VerseEditorComponent implements OnInit {
  editorConfig: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    height: "auto",
    minHeight: "500px",
    maxHeight: "auto",
    width: "auto",
    minWidth: "0",
    translate: "yes",
    enableToolbar: true,
    showToolbar: true,
    placeholder: "Enter text here...",
    defaultParagraphSeparator: "",
    defaultFontName: "",
    defaultFontSize: "",
    fonts: [
      {class: "arial", name: "Arial"},
      {class: "times-new-roman", name: "Times New Roman"},
      {class: "calibri", name: "Calibri"},
      {class: "comic-sans-ms", name: "Comic Sans MS"}
    ],
    customClasses: [
      {
        name: "quote",
        class: "quote",
      },
      {
        name: "redText",
        class: "redText"
      },
      {
        name: "titleText",
        class: "titleText",
        tag: "h1",
      },
    ],
    uploadUrl: "v1/image",
    uploadWithCredentials: false,
    sanitize: true,
    toolbarPosition: "top",
    toolbarHiddenButtons: [
      ["bold", "italic"],
      ["fontSize"]
    ]
  };

  constructor(public editorService: AngularEditorService, public verseTheftService: VerseTheftService) {
  }

  ngOnInit() {
  }

  public handleHotkey(event: KeyboardEvent): boolean {
    if (event.ctrlKey && event.code === "Space") {
      let selection = this.editorService.actualizeCurrentSelection();
      selection = selection.split(" ").pop();
      selection = /[а-яА-ЯЁёA-Za-z0-9_]+/.exec(selection)[0];
      this.verseTheftService.getRhymes(selection)
        .pipe(take(1))
        .subscribe(rhymes => {
          console.log(rhymes);
        });
    }

    return false; // Prevent bubbling
  }
}
