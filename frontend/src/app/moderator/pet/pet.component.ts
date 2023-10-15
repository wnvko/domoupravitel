import { Component } from '@angular/core';
import { Observable, first } from 'rxjs';
import { Pet } from 'src/app/models/pet';
import { PetService } from '../pet.service';
import { IGridEditDoneEventArgs, IRowDataEventArgs } from 'igniteui-angular';

@Component({
  selector: 'app-pet',
  templateUrl: './pet.component.html',
  styleUrls: ['./pet.component.scss']
})
export class PetComponent {
  public pets!: Observable<Pet[]>;

  constructor(
    private petsService: PetService
  ) { }

  ngOnInit(): void {
    this.pets = this.petsService.all();
  }

  public petAdded(e: IRowDataEventArgs) {
    this.petsService.create(e.data as Pet).pipe(first()).subscribe();
  }

  public petEdited(e: IGridEditDoneEventArgs) {
    if (e.isAddRow)
      return;

    this.petsService.update(e.newValue as Pet).pipe(first()).subscribe();
  }

  public petDeleted(e: IRowDataEventArgs) {
    this.petsService.delete(e.data as Pet).pipe(first()).subscribe();
  }

}
