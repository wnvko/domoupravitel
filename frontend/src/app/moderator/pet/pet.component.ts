import { Component } from '@angular/core';
import { Observable, first } from 'rxjs';
import { Pet } from 'src/app/models/pet';
import { PetService } from '../pet.service';
import { CellType, IGridEditDoneEventArgs, IRowDataEventArgs, ISortingOptions, IgxGridComponent } from '@infragistics/igniteui-angular';

@Component({
  selector: 'app-pet',
  templateUrl: './pet.component.html',
  styleUrls: ['./pet.component.scss']
})
export class PetComponent {
  public pets!: Observable<Pet[]>;
  public sortingOptions: ISortingOptions = {
    mode: 'single'
  }

  constructor(
    private petsService: PetService
  ) { }

  ngOnInit(): void {
    this.pets = this.petsService.all();
  }
  
  public addPet = (grid: IgxGridComponent): void => {
    grid.beginAddRowByIndex(0);
  }

  public petAdded = (e: IRowDataEventArgs): void => {
    this.petsService.create(e.data as Pet).pipe(first()).subscribe();
  }

  public petEdited = (e: IGridEditDoneEventArgs): void => {
    if (e.isAddRow)
      return;

    this.petsService.update(e.newValue as Pet).pipe(first()).subscribe();
  }

  public petDeleted = (e: CellType): void => {
    this.petsService.delete(e.row.data as Pet).pipe(first()).subscribe({
      next: c => e.grid.deleteRow(c),
      error: err => console.log(err)
    });
  }
}
