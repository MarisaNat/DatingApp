import { Component, OnInit } from '@angular/core';
import { AccountService } from "./_services/account.service";
import { PresenceService } from "./_services/presence.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'The Dating App';

  constructor(private accountService: AccountService,
              private presenceService:PresenceService) {
  }

  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser() {
    let currentUser = localStorage.getItem('user');
    const user = (currentUser ? JSON.parse(currentUser) : null);
    if(user){
      this.accountService.setCurrentUser(user);
      this.presenceService.createHubConnection(user);
    }

  }

}
