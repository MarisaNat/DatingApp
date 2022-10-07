import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { ToastrModule } from "ngx-toastr";
import { TabsModule } from "ngx-bootstrap/tabs";
import { NgxGalleryModule } from "@kolkov/ngx-gallery";
import { FileUploadModule } from "ng2-file-upload";



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(), //Wird direkt beim Laden des app-modules geladen
    ToastrModule.forRoot({positionClass:'toast-bottom-right'}),
    TabsModule.forRoot(),
    NgxGalleryModule,
    FileUploadModule
  ],
  //Alles was exportiert wird, kann auaßerhalb verwendet werden!
  exports:[
    BsDropdownModule,
    ToastrModule,
    TabsModule,
    NgxGalleryModule,
    FileUploadModule
  ]
})
export class SharedModule { }
