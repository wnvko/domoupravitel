import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CellType, IGridEditDoneEventArgs, IRowDataEventArgs, ISortingOptions, IgxDialogComponent, IgxGridComponent } from '@infragistics/igniteui-angular';
import { Observable, Subject, first, takeUntil } from 'rxjs';
import { Car } from 'src/app/models/car';
import { DeleteComponent } from 'src/app/shared/delete/delete.component';
import { CarService } from '../car.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.scss']
})
export class CarComponent implements OnInit, OnDestroy {
  private destroy$: Subject<void> = new Subject<void>();

  @ViewChild('deleteDialog', { static: true, read: DeleteComponent })
  private deleteDialog!: DeleteComponent;

  @ViewChild('dialog', { static: true, read: IgxDialogComponent })
  private dialog!: IgxDialogComponent;

  public cars!: Observable<Car[]>;
  public sortingOptions: ISortingOptions = {
    mode: 'single'
  }

  constructor(
    private carsService: CarService
  ) { }

  ngOnInit(): void {
    this.cars = this.carsService.all();
    this.deleteDialog.result.pipe(takeUntil(this.destroy$)).subscribe(() => this.dialog.close());
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
