import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { ToastrModule } from "ngx-toastr";



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(), //Wird direkt beim Laden des app-modules geladen
    ToastrModule.forRoot({positionClass:'toast-bottom-right'})
  ],
  //Alles was exportiert wird, kann auaßerhalb verwendet werden!
  exports:[
    BsDropdownModule,
    ToastrModule
  ]
})
export class SharedModule { }
