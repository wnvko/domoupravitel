import { Component, OnInit } from '@angular/core';
import { CellType, IGridEditDoneEventArgs, IRowDataEventArgs, ISortingOptions, IgxGridComponent } from '@infragistics/igniteui-angular';
import { Observable, first } from 'rxjs';
import { Person } from 'src/app/models/person';
import { PeopleService } from '../people.service';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})
export class PeopleComponent implements OnInit {
  public people!: Observable<Person[]>;
  public sortingOptions: ISortingOptions = {
    mode: 'single'
  }

  constructor(
    private peopleService: PeopleService
  ) { }

  ngOnInit(): void {
    this.people = this.peopleService.all();
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

  public personDeleted = (e: CellType): void => {
    this.peopleService.delete(e.row.data as Person).pipe(first()).subscribe({
      next: c => e.grid.deleteRow(c),
      error: err => console.log(err)
    });
  }
}
