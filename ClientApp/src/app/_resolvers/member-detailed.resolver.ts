import { Member } from "../_models/member";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { MembersService } from "../_services/members.service";

@Injectable({
  providedIn:'root'
})
export class MemberDetailedResolver implements  Resolve<Member>{
  constructor(private memberService:MembersService) {
  }
  //Daten bekommen, bevor das Template erzeugt wird
  resolve(route: ActivatedRouteSnapshot): Observable<Member> {
    return this.memberService.getMember(route.paramMap.get('username'));
  }

}
