import {NgModule} from "@angular/core";

import {VerseEditorComponent} from "./verse-editor.component";
import {MaterialModule} from "../../material.module";
import {CKEditorModule} from "@ckeditor/ckeditor5-angular";

@NgModule({
  imports: [
    MaterialModule,
    CKEditorModule
  ],
  exports: [VerseEditorComponent],
  declarations: [VerseEditorComponent],
  providers: [],
})
export class VerseEditorModule {
}
