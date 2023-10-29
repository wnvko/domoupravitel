import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Person } from 'src/app/models/person';
import { PeopleService } from '../people.service';

@Component({
  selector: 'app-add-person',
  templateUrl: './add-person.component.html',
  styleUrls: ['./add-person.component.scss']
})
export class AddPersonComponent {
  public person: FormGroup;

  @Output()
  public added: EventEmitter<Person | undefined> = new EventEmitter<Person | undefined>();

  constructor(fb: FormBuilder, private peopleService: PeopleService) {
    this.person = fb.group({
      name: ['', Validators.required],
      phone: [''],
      email: ['']
    });
  }

  public onSubmit = (): void => {
    if (this.person.valid) {
      this.peopleService.create(this.person.value).subscribe({
        next: (p) => {
          this.added.emit(p);
          this.person.reset();
        },
        error: (err: any) => {
          this.added.emit(undefined);
          this.person.reset();
        }
      });
    }
  }

  public cancel = (): void => {
    this.added.emit(undefined);
    this.person.reset();
  }
}
