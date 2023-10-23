import { Component } from '@angular/core';
import { CellType, IGridEditDoneEventArgs, IRowDataEventArgs, ISortingOptions, IgxGridComponent } from '@infragistics/igniteui-angular';
import { Observable, first } from 'rxjs';
import { Car } from 'src/app/models/car';
import { CarService } from '../car.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.scss']
})
export class CarComponent {
  public cars!: Observable<Car[]>;
  public sortingOptions: ISortingOptions = {
    mode: 'single'
  }

  constructor(
    private carsService: CarService
  ) { }

  ngOnInit(): void {
    this.cars = this.carsService.all();
  }

  public addCar = (grid: IgxGridComponent): void => {
    grid.beginAddRowByIndex(0);
  }

  public carAdded(e: IRowDataEventArgs) {
    this.carsService.create(e.data as Car).pipe(first()).subscribe();
  }

  public carEdited(e: IGridEditDoneEventArgs) {
    if (e.isAddRow)
      return;

    this.carsService.update(e.newValue as Car).pipe(first()).subscribe();
  }

  public carDeleted(e: CellType) {
    this.carsService.delete(e.row.data as Car).pipe(first()).subscribe({
      next: c => e.grid.deleteRow(c),
      error: err => console.log(err)
    });
  }
}
