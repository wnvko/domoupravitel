import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CellType, GridType, IGridEditDoneEventArgs, IGridSortingStrategy, IGridState, IRowDataEventArgs, ISortingExpression, ISortingOptions, IgxDialogComponent, IgxGridComponent, IgxGridStateDirective, IgxSorting } from '@infragistics/igniteui-angular';
import { Observable, Subject, first, takeUntil } from 'rxjs';
import { Chip } from 'src/app/models/chip';
import { Person } from 'src/app/models/person';
import { PersonDescriptor } from 'src/app/models/person-descriptor';
import { DeleteComponent } from 'src/app/shared/delete/delete.component';
import { PeopleService } from '../people.service';
import { GridStateService } from '../grid-state.service';
import { GridState } from 'src/app/models/grid-state';
import { NavigationStart, Router } from '@angular/router';
import { restoreState } from 'src/app/shared/util';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})
export class PeopleComponent implements OnInit, OnDestroy {
  private destroy$: Subject<void> = new Subject<void>();
  private gridName: string = 'People.Grid';

  @ViewChild('grid',  { static: true, read: IgxGridComponent})
  private grid!: IgxGridComponent;

  @ViewChild('deleteDialog', { static: true, read: DeleteComponent })
  private deleteDialog!: DeleteComponent;

  @ViewChild('dialog', { static: true, read: IgxDialogComponent })
  private dialog!: IgxDialogComponent;

  @ViewChild(IgxGridStateDirective, { static: true })
  private state!: IgxGridStateDirective;

  public people!: Observable<Person[]>;
  public sortingOptions: ISortingOptions = { mode: 'single' };
  public sortStrategy: IGridSortingStrategy = DescriptorSortingStrategy.instance();

  constructor(
    private peopleService: PeopleService,
    private gridStateService: GridStateService,
    router: Router,
  ) {
    router.events.pipe(takeUntil(this.destroy$)).subscribe(e => {
      if (e instanceof NavigationStart) {
        const newGridState: GridState = {
          id: crypto.randomUUID(),
          gridName: this.gridName,
          options: this.state.getState().toString()
        }
        this.gridStateService.putState(newGridState).subscribe()
      }
    });
  }

  ngOnInit(): void {
    this.people = this.peopleService.all();
    this.deleteDialog.result.pipe(takeUntil(this.destroy$)).subscribe(() => this.dialog.close());
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

  public startDeletePerson = (e: CellType): void => {
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
    const descriptors: PersonDescriptor[] = cell.value;
    return descriptors?.map(d => d.property.number).join(', ') ?? '';
  }

  public renderChips = (cell: CellType): string => {
    if (!cell.value) 
      return '';

      const chips: Chip[] = cell.value;
    const active = chips.filter(c => c.disabled === false).length;
    const inactive = chips.filter(c => c.disabled === true).length;
    return `${active} / ${inactive}`;
  }
}

class DescriptorSortingStrategy implements IGridSortingStrategy {
  private static _instance: DescriptorSortingStrategy;

  private constructor() { }

  public static instance(): IGridSortingStrategy {
    return this._instance || (this._instance = new DescriptorSortingStrategy());
  }

  sort(data: any[], expressions: ISortingExpression<any>[], grid?: GridType | undefined): any[] {
    if (expressions.length === 1 && expressions[0].fieldName === 'descriptors') {
      const direction = expressions[0].dir;
      switch (direction) {
        case 0:
          return data;
        case 1:
          return data.sort((a: Person, b: Person) => this.comparePerson(a, b));
        case 2:
          return data.sort((a: Person, b: Person) => this.comparePerson(a, b) * (-1));
      }
    }
    const defaultSorting = new IgxSorting();
    return defaultSorting.sort(data, expressions, grid);
  }

  comparePerson = (first: Person, second: Person): number => {
    const firstDescriptors = first.descriptors.sort((a: PersonDescriptor, b: PersonDescriptor) => a.property.type - b.property.type);
    const secondDescriptors = second.descriptors.sort((a: PersonDescriptor, b: PersonDescriptor) => a.property.type - b.property.type);
    const firstDescriptor = firstDescriptors[0];
    const secondDescriptor = secondDescriptors[0];
    if (!firstDescriptor && !secondDescriptor) return 0;
    if (!firstDescriptor) return 1;
    if (!secondDescriptor) return -1;

    const firstProperty = firstDescriptor.property;
    const secondProperty = secondDescriptor.property;
    if (!firstProperty && !secondProperty) return 0;
    if (!firstProperty) return 1;
    if (!secondProperty) return -1;

    if (firstProperty.number < secondProperty.number) return -1;
    if (firstProperty.number > secondProperty.number) return 1;
    return 0;
  }
}
