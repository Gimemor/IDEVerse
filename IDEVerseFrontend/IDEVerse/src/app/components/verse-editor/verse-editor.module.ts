import {NgModule} from "@angular/core";
import {VerseEditorComponent} from "./verse-editor.component";
import {MaterialModule} from "../../material.module";
import {AngularEditorModule} from "@gimemor/angular-editor-exp";
import {VerseSelectorComponent} from "./components/verse-selector/verse-selector.component";
import {CommonModule} from "@angular/common";

@NgModule({
  imports: [
    MaterialModule,
    CommonModule,
    AngularEditorModule,
  ],
  exports: [VerseEditorComponent, VerseSelectorComponent],
  declarations: [VerseEditorComponent, VerseSelectorComponent],
  providers: [],
})
export class VerseEditorModule {
}
