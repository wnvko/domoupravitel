import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CellType, IGridEditDoneEventArgs, IRowDataEventArgs, ISimpleComboSelectionChangingEventArgs, ISortingOptions, IgxDialogComponent, IgxGridComponent, IgxSimpleComboComponent } from '@infragistics/igniteui-angular';
import { Observable, Subject, first, takeUntil } from 'rxjs';
import { Chip } from 'src/app/models/chip';
import { DeleteComponent } from 'src/app/shared/delete/delete.component';
import { ChipsService } from '../chips.service';
import { Person } from 'src/app/models/person';
import { PeopleService } from '../people.service';
import { AddPersonComponent } from '../add-person/add-person.component';

@Component({
  selector: 'app-chips',
  templateUrl: './chips.component.html',
  styleUrl: './chips.component.scss'
})
export class ChipsComponent  implements OnInit, OnDestroy {
  private destroy$: Subject<void> = new Subject<void>();

  @ViewChild('deleteDialog', { static: true, read: DeleteComponent })
  private deleteDialog!: DeleteComponent;

  @ViewChild('dialog', { static: true, read: IgxDialogComponent })
  private dialog!: IgxDialogComponent;
  
  @ViewChild('addPerson', { static: true, read: AddPersonComponent })
  private addPerson!: AddPersonComponent;

  @ViewChild('addPersonDialog', { static: true, read: IgxDialogComponent })
  private addPersonDialog!: IgxDialogComponent;

  public chips!: Observable<Chip[]>;
  public people!: Observable<Person[]>;
  public sortingOptions: ISortingOptions = { mode: 'single' };

  constructor(
    private chipService: ChipsService,
    private peopleService: PeopleService,
  ) { }

  ngOnInit(): void {
    this.chips = this.chipService.all();
    this.people = this.peopleService.all();

    this.deleteDialog.result.pipe(takeUntil(this.destroy$)).subscribe(() => this.dialog.close());
    this.addPerson.added.pipe(takeUntil(this.destroy$)).subscribe(e => {
      if (e) {
        this.people = this.peopleService.all();
      }
      this.addPersonDialog.close();
    });
  }
  
  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  public addChip = (grid: IgxGridComponent): void => {
    grid.beginAddRowByIndex(0);
  }

  public chipAdded = (e: IRowDataEventArgs): void => {
    e.data.personId = e.data.person.id;
    this.chipService.create(e.data as Chip).pipe(first()).subscribe();
  }

  public chipEdited = (e: IGridEditDoneEventArgs): void => {
    if (e.isAddRow)
      return;

    this.chipService.update(e.newValue as Chip).pipe(first()).subscribe();
  }

  public startDeleteChip =(e: CellType): void => {
    this.deleteDialog.deleteFunction = { function: this.chipDeleted, args: e };
    const chip = e.row.data as Chip;
    this.deleteDialog.message = `Чип ${chip.number} ще бъде изтрит!`;
    this.dialog.open();
  }

  public chipDeleted = (e: CellType): void => {
    this.chipService.delete(e.row.data as Chip).pipe(first()).subscribe({
      next: c => e.grid.deleteRow(c),
      error: err => console.log(err)
    });
  }
  
  public personSelected = (e: ISimpleComboSelectionChangingEventArgs, cell: CellType): void => {
    const combo = e.owner as IgxSimpleComboComponent;
    const person = combo.data?.find((p: Person) => p.id === e.newValue) as Person;
    cell.editValue = person;
  }
  
  public addNewPerson = (): void => {
    this.addPersonDialog.open();
  }
}
