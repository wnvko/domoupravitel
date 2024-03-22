import { registerLocaleData } from '@angular/common';
import localeBG from '@angular/common/locales/bg';
import { Component, OnInit } from '@angular/core';
import { changei18n, IgxNavigationDrawerComponent } from '@infragistics/igniteui-angular';
import { IgxResourceStringsBG } from 'igniteui-angular-i18n';
import { UserService } from './auth/user.service';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  public selected = 'settings';

  constructor(public userService: UserService, router: Router) {
    router.events.subscribe(e => {
      if (e instanceof NavigationEnd) {
        this.selected = e.url;
      }
    });
  }

  ngOnInit(): void {
    changei18n(IgxResourceStringsBG);
    registerLocaleData(localeBG);
  }

  public toggleNavDrawer = (navDrawer: IgxNavigationDrawerComponent): void => {
    navDrawer?.toggle();
  }
}
