import { Component } from '@angular/core';
import { Observable, first } from 'rxjs';
import { CarService } from '../services/car.service';
import { Car } from 'src/app/models/car';
import { IGridEditDoneEventArgs, IRowDataEventArgs } from 'igniteui-angular';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.scss']
})
export class CarComponent {
  public cars!: Observable<Car[]>;

  constructor(
    private carsService: CarService
  ) { }

  ngOnInit(): void {
    this.cars = this.carsService.all();
  }

  public carAdded(e: IRowDataEventArgs) {
    this.carsService.create(e.data as Car).pipe(first()).subscribe();
  }

  public carEdited(e: IGridEditDoneEventArgs) {
    if (e.isAddRow)
      return;

    this.carsService.update(e.newValue as Car).pipe(first()).subscribe();
  }

  public carDeleted(e: IRowDataEventArgs) {
    this.carsService.delete(e.data as Car).pipe(first()).subscribe();
  }
}
