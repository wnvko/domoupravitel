import { Component, OnInit } from '@angular/core';
import { IGridEditDoneEventArgs, IRowDataEventArgs } from 'igniteui-angular';
import { first, Observable } from 'rxjs';
import { User } from 'src/app/models/user';
import { UserService } from '../user.service';
import { Role } from 'src/app/models/enums/role';

@Component({
  selector: 'app-user-manager',
  templateUrl: './user-manager.component.html',
  styleUrls: ['./user-manager.component.scss']
})
export class UserManagerComponent implements OnInit {
  public users!: Observable<User[]>;
  public roles = Object.keys(Role).filter(k => !isNaN(Number(k))).map(v => {
    if (parseInt(v) === Role.Admin) return { name: 'Администратор', value: 0 };
    if (parseInt(v) === Role.Moderator) return { name: 'Модератор', value: 1 };
    return { name: 'Потребител', value: 2 };
  });

  constructor(
    private user: UserService
  ) { }

  ngOnInit(): void {
    this.users = this.user.all();
  }

  public userAdded(e: IRowDataEventArgs) {
    this.user.add(e.data as User).pipe(first()).subscribe();
  }

  public userEdited(e: IGridEditDoneEventArgs) {
    this.user.update(e.newValue as User).pipe(first()).subscribe();
  }

  public parseRole(role: number): string {
    return role === 0 ? 'Администратор' : role === 1 ? 'Модератор' : 'Потребител'
  }
}
