import { Component, OnInit } from '@angular/core';
import { IRowDataEventArgs } from 'igniteui-angular';
import { first, Observable } from 'rxjs';
import { User } from 'src/app/models/user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-manager',
  templateUrl: './user-manager.component.html',
  styleUrls: ['./user-manager.component.scss']
})
export class UserManagerComponent implements OnInit {
  public users!: Observable<User[]>;

  constructor(
    private user: UserService
  ) { }

  ngOnInit(): void {
    this.users = this.user.all();
  }

  public userAdded(e: IRowDataEventArgs) {
    this.user.add(e.data as User).pipe(first()).subscribe();
  }
}
