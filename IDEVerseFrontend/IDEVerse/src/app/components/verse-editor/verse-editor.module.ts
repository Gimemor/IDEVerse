import {NgModule} from "@angular/core";

import {VerseEditorComponent} from "./verse-editor.component";
import {MaterialModule} from "../../material.module";

@NgModule({
  imports: [
    MaterialModule,
  ],
  exports: [VerseEditorComponent],
  declarations: [VerseEditorComponent],
  providers: [],
})
export class VerseEditorModule {
}
