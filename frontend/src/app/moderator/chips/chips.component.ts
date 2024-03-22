import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';
import {
  CellType, GridType, IGridEditDoneEventArgs, IGridSortingStrategy, IGridState, IRowDataEventArgs,
  ISimpleComboSelectionChangingEventArgs, ISortingExpression, ISortingOptions, IgxDialogComponent,
  IgxGridComponent, IgxGridStateDirective, IgxSimpleComboComponent, IgxSorting
} from '@infragistics/igniteui-angular';
import { Observable, Subject, first, takeUntil } from 'rxjs';
import { Chip } from 'src/app/models/chip';
import { GridState } from 'src/app/models/grid-state';
import { Person } from 'src/app/models/person';
import { DeleteComponent } from 'src/app/shared/delete/delete.component';
import { restoreState } from 'src/app/shared/util';
import { v4 } from 'uuid';
import { AddPersonComponent } from '../add-person/add-person.component';
import { ChipsService } from '../chips.service';
import { GridStateService } from '../grid-state.service';
import { PeopleService } from '../people.service';

@Component({
  selector: 'app-chips',
  templateUrl: './chips.component.html',
  styleUrl: './chips.component.scss'
})
export class ChipsComponent implements OnInit, OnDestroy {
  private destroy$: Subject<void> = new Subject<void>();
  private gridName: string = 'Chips.Grid';

  @ViewChild('grid', { static: true, read: IgxGridComponent })
  private grid!: IgxGridComponent;

  @ViewChild('deleteDialog', { static: true, read: DeleteComponent })
  private deleteDialog!: DeleteComponent;

  @ViewChild('dialog', { static: true, read: IgxDialogComponent })
  private dialog!: IgxDialogComponent;

  @ViewChild('addPerson', { static: true, read: AddPersonComponent })
  private addPerson!: AddPersonComponent;

  @ViewChild('addPersonDialog', { static: true, read: IgxDialogComponent })
  private addPersonDialog!: IgxDialogComponent;

  @ViewChild(IgxGridStateDirective, { static: true })
  private state!: IgxGridStateDirective;

  public chips!: Observable<Chip[]>;
  public people!: Observable<Person[]>;
  public sortingOptions: ISortingOptions = { mode: 'single' };
  public sortStrategy: IGridSortingStrategy = ChipSortingStrategy.instance();

  constructor(
    private chipService: ChipsService,
    private peopleService: PeopleService,
    private gridStateService: GridStateService,
    router: Router,
  ) {
    router.events.pipe(takeUntil(this.destroy$)).subscribe(e => {
      if (e instanceof NavigationStart) {
        const newGridState: GridState = {
          id: v4(),
          gridName: this.gridName,
          options: this.state.getState().toString()
        }
        this.gridStateService.putState(newGridState).subscribe()
      }
    });
  }

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

    this.gridStateService.getState(this.gridName).pipe(takeUntil(this.destroy$)).subscribe({
      next: state => {
        const gridState: IGridState = JSON.parse(state.options);
        restoreState(gridState, this.grid);
      },
      error: err => console.log(err),
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

  public startDeleteChip = (e: CellType): void => {
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

class ChipSortingStrategy implements IGridSortingStrategy {
  private static _instance: ChipSortingStrategy;

  private constructor() { }

  public static instance(): IGridSortingStrategy {
    return this._instance || (this._instance = new ChipSortingStrategy());
  }

  sort(data: any[], expressions: ISortingExpression<any>[], grid?: GridType | undefined): any[] {
    if (expressions.length === 1 && expressions[0].fieldName === 'person') {
      const direction = expressions[0].dir;
      switch (direction) {
        case 0:
          return data;
        case 1:
          return data.sort((a: Chip, b: Chip) => {
            if (a.person.name < b.person.name) return -1;
            if (a.person.name > b.person.name) return 1;
            return 0;
          });
        case 2:
          return data.sort((a: Chip, b: Chip) => {
            if (a.person.name > b.person.name) return -1;
            if (a.person.name < b.person.name) return 1;
            return 0;
          });
      }
    }
    const defaultSorting = new IgxSorting();
    return defaultSorting.sort(data, expressions, grid);
  }
}
