import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CellType, IGridEditDoneEventArgs, IRowDataEventArgs, IgxDialogComponent, IgxGridComponent } from '@infragistics/igniteui-angular';
import { Observable, Subject, first, takeUntil } from 'rxjs';
import { Role } from 'src/app/models/enums/role';
import { User } from 'src/app/models/user';
import { DeleteDialogComponent } from 'src/app/shared/delete-dialog/delete-dialog.component';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-manager',
  templateUrl: './user-manager.component.html',
  styleUrls: ['./user-manager.component.scss']
})
export class UserManagerComponent implements OnInit, OnDestroy {
  private destroy$: Subject<void> = new Subject<void>();

  @ViewChild('deleteDialog', { static: true, read: DeleteDialogComponent })
  private deleteDialog!: DeleteDialogComponent;

  @ViewChild('dialog', { static: true, read: IgxDialogComponent })
  private dialog!: IgxDialogComponent;

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
    this.deleteDialog.result.pipe(takeUntil(this.destroy$)).subscribe(() => this.dialog.close());
  }
    
  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  public addUser = (grid: IgxGridComponent): void => {
    grid.beginAddRowByIndex(0);
  }

  public userAdded(e: IRowDataEventArgs) {
    this.user.add(e.data as User).pipe(first()).subscribe();
  }

  public userEdited(e: IGridEditDoneEventArgs) {
    this.user.update(e.newValue as User).pipe(first()).subscribe();
  }
  
  public startDeleteUser =(e: CellType): void => {
    this.deleteDialog.deleteFunction = { function: this.userDeleted, args: e };
    const user = e.row.data as User;
    this.deleteDialog.message = `${user.userName} ще бъде изтрит/а!`;
    this.dialog.open();
  }

  public userDeleted = (e: CellType): void => {
    this.user.delete(e.row.data as User).pipe(first()).subscribe({
      next: c => e.grid.deleteRowById(c.id),
      error: err => console.log(err)
    });
  }

  public parseRole(role: number): string {
    return role === 0 ? 'Администратор' : role === 1 ? 'Модератор' : 'Потребител'
  }
}
