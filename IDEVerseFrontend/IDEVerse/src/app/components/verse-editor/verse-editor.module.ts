import {NgModule} from "@angular/core";

import {VerseEditorComponent} from "./verse-editor.component";
import {MaterialModule} from "../../material.module";
import {AngularEditorModule} from "@gimemor/angular-editor-exp";

@NgModule({
  imports: [
    MaterialModule,
    AngularEditorModule,
  ],
  exports: [VerseEditorComponent],
  declarations: [VerseEditorComponent],
  providers: [],
})
export class VerseEditorModule {
}
