import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { MemberListComponent } from "./members/member-list/member-list.component";
import { MemberDetailComponent } from "./members/member-detail/member-detail.component";
import { ListsComponent } from "./lists/lists.component";
import { MessagesComponent } from "./messages/messages.component";
import { AuthGuard } from "./_guards/auth.guard";

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path:'',
    runGuardsAndResolvers:'always',
    canActivate:[AuthGuard],
    children:[ {path: 'members', component: MemberListComponent, canActivate:[AuthGuard]},
      {path: 'memebers/:id', component: MemberDetailComponent},
      {path: 'lists', component: ListsComponent},
      {path: 'messages', component: MessagesComponent},]
  },
  {path: '**', component: HomeComponent, pathMatch:'full'} //Beliebige Eingabe, wenn nicht 'full', dann würde Endlosschleife entstehen, da auf / folgende Routenteile ignoriert werden
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
