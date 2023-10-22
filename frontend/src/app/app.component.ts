import { Component, OnInit } from '@angular/core';
import { UserService } from './auth/user.service';
import { changei18n } from '@infragistics/igniteui-angular';
import { IgxResourceStringsBG } from 'igniteui-angular-i18n';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'domoupravitel-front-end';

  constructor(public userService: UserService) { }
  ngOnInit(): void {
    changei18n(IgxResourceStringsBG);
  }

  public settings() {}
}
