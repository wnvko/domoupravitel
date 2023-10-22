import { Component, OnInit } from '@angular/core';
import { Observable, first } from 'rxjs';
import { Person } from 'src/app/models/person';
import { PeopleService } from '../people.service';
import { IGridEditDoneEventArgs, IRowDataEventArgs } from '@infragistics/igniteui-angular';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})
export class PeopleComponent implements OnInit {
  public people!: Observable<Person[]>;

  constructor(
    private peopleService: PeopleService
  ) { }

  ngOnInit(): void {
    this.people = this.peopleService.all();
  }

  public personAdded(e: IRowDataEventArgs) {
    this.peopleService.create(e.data as Person).pipe(first()).subscribe();
  }

  public personEdited(e: IGridEditDoneEventArgs) {
    if (e.isAddRow)
      return;

    this.peopleService.update(e.newValue as Person).pipe(first()).subscribe();
  }

  public personDeleted(e: IRowDataEventArgs) {
    this.peopleService.delete(e.data as Person).pipe(first()).subscribe();
  }
}
