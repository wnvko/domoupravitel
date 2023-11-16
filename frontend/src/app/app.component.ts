import { registerLocaleData } from '@angular/common';
import localeBG from '@angular/common/locales/bg';
import { Component, OnInit } from '@angular/core';
import { changei18n } from '@infragistics/igniteui-angular';
import { IgxResourceStringsBG } from 'igniteui-angular-i18n';
import { UserService } from './auth/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor(public userService: UserService) { }

  ngOnInit(): void {
    changei18n(IgxResourceStringsBG);
    registerLocaleData(localeBG);
  }
}
