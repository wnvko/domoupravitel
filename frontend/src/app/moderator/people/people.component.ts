import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CellType, IGridEditDoneEventArgs, IRowDataEventArgs, ISortingOptions, IgxDialogComponent, IgxGridComponent } from '@infragistics/igniteui-angular';
import { Observable, Subject, first, takeUntil } from 'rxjs';
import { Person } from 'src/app/models/person';
import { DeleteComponent } from 'src/app/shared/delete/delete.component';
import { PeopleService } from '../people.service';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})
export class PeopleComponent implements OnInit, OnDestroy {
  private destroy$: Subject<void> = new Subject<void>();

  @ViewChild('deleteDialog', { static: true, read: DeleteComponent })
  private deleteDialog!: DeleteComponent;

  @ViewChild('dialog', { static: true, read: IgxDialogComponent })
  private dialog!: IgxDialogComponent;

  public people!: Observable<Person[]>;
  public sortingOptions: ISortingOptions = {
    mode: 'single'
  }

  constructor(
    private peopleService: PeopleService
  ) { }

  ngOnInit(): void {
    this.people = this.peopleService.all();
    this.deleteDialog.result.pipe(takeUntil(this.destroy$)).subscribe(() => this.dialog.close());
  }
  
  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
  
  public addPerson = (grid: IgxGridComponent): void => {
    grid.beginAddRowByIndex(0);
  }

  public personAdded = (e: IRowDataEventArgs): void => {
    this.peopleService.create(e.data as Person).pipe(first()).subscribe();
  }

  public personEdited = (e: IGridEditDoneEventArgs): void => {
    if (e.isAddRow)
      return;

    this.peopleService.update(e.newValue as Person).pipe(first()).subscribe();
  }

  public startDeletePerson =(e: CellType): void => {
    this.deleteDialog.deleteFunction = { function: this.personDeleted, args: e };
    const person = e.row.data as Person;
    this.deleteDialog.message = `${person.name} ще бъде изтрит/а!`;
    this.dialog.open();
  }

  public personDeleted = (e: CellType): void => {
    this.peopleService.delete(e.row.data as Person).pipe(first()).subscribe({
      next: c => e.grid.deleteRow(c),
      error: err => console.log(err)
    });
  }

  public renderProperties = (cell: CellType): string => {
    var person: Person = cell.row.data;
    return person.descriptors.map(d => d.property.number).join(', ');
  }
}
