import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';
import { CellType, IGridEditDoneEventArgs, IGridState, IRowDataEventArgs, ISortingOptions, IgxDialogComponent, IgxGridComponent, IgxGridStateDirective } from '@infragistics/igniteui-angular';
import { Observable, Subject, first, takeUntil } from 'rxjs';
import { Car } from 'src/app/models/car';
import { GridState } from 'src/app/models/grid-state';
import { DeleteComponent } from 'src/app/shared/delete/delete.component';
import { restoreState } from 'src/app/shared/util';
import { v4 } from 'uuid';
import { CarService } from '../car.service';
import { GridStateService } from '../grid-state.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.scss']
})
export class CarComponent implements OnInit, OnDestroy {
  private destroy$: Subject<void> = new Subject<void>();
  private gridName: string = 'Cars.Grid';

  @ViewChild('grid',  { static: true, read: IgxGridComponent})
  private grid!: IgxGridComponent;

  @ViewChild('deleteDialog', { static: true, read: DeleteComponent })
  private deleteDialog!: DeleteComponent;

  @ViewChild('dialog', { static: true, read: IgxDialogComponent })
  private dialog!: IgxDialogComponent;

  @ViewChild(IgxGridStateDirective, { static: true })
  private state!: IgxGridStateDirective;

  public cars!: Observable<Car[]>;
  public sortingOptions: ISortingOptions = { mode: 'single' };

  constructor(
    private carsService: CarService,
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
    this.cars = this.carsService.all();
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

  public addCar = (grid: IgxGridComponent): void => {
    grid.beginAddRowByIndex(0);
  }

  public carAdded = (e: IRowDataEventArgs): void => {
    this.carsService.create(e.data as Car).pipe(first()).subscribe();
  }

  public carEdited = (e: IGridEditDoneEventArgs): void => {
    if (e.isAddRow)
      return;

    this.carsService.update(e.newValue as Car).pipe(first()).subscribe();
  }

  public startDeleteCar =(e: CellType): void => {
    this.deleteDialog.deleteFunction = { function: this.carDeleted, args: e };
    const car = e.row.data as Car;
    this.deleteDialog.message = `Кола ${car.number} ще бъде изтрита!`;
    this.dialog.open();
  }

  public carDeleted = (e: CellType): void => {
    this.carsService.delete(e.row.data as Car).pipe(first()).subscribe({
      next: c => e.grid.deleteRow(c),
      error: err => console.log(err)
    });
  }
}
