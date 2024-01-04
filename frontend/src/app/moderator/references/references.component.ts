import { Component, OnInit, ViewChild } from '@angular/core';
import { IgxGridComponent } from '@infragistics/igniteui-angular';
import { PersonType } from 'src/app/models/enums/person-type';
import { Residence } from 'src/app/models/enums/residence';
import { PropertyService } from '../property.service';

@Component({
  selector: 'app-references',
  templateUrl: './references.component.html',
  styleUrls: ['./references.component.scss']
})
export class ReferencesComponent implements OnInit {
  public people: { 'property': string, 'name': string, 'type': string, 'phone': string, 'mail': string }[] = []
  public cars: { 'property': string, 'car': string }[] = []
  public groups: { 'property': string, 'adults': number, 'kids': number, 'pets': number, 'temporary': number }[] = [];

  @ViewChild('peopleGrid', { static: true, read: IgxGridComponent })
  private peopleGrid?: IgxGridComponent;

  @ViewChild('groupsGrid', { static: true, read: IgxGridComponent })
  private groupsGrid?: IgxGridComponent;

  constructor(private propertiesService: PropertyService,) { }

  ngOnInit(): void {
    this.propertiesService.all().subscribe(p => {
      for (let property of p) {
        const group = { 'property': property.number, 'adults': 0, 'kids': 0, 'pets': 0, 'temporary': 0 };
        this.groups.push(group);
        for (let person of property.people) {
          let type = this.parseType(person.type);
          this.people.push(
            {
              property: property.number,
              name: person.person.name,
              type,
              phone: person.person.phone,
              mail: person.person.email
            }
          );
          if (person.unRegisteredOn || person.residence == Residence.Absent)
            continue;

          const todayBefore18years = new Date();
          todayBefore18years.setFullYear(todayBefore18years.getFullYear() - 18);
          const birthDay = new Date(person.person.birthDate);
          if (birthDay && birthDay.getTime() > todayBefore18years.getTime()) {
            group.kids++;
          } else {
            group.adults++;
            if (person.residence === Residence.Temporary) {
              group.temporary++;
            }
          }
        }
        for (let car of property.cars) {
          this.cars.push({
            property: property.number,
            car: `${car.number} ${car.brand} ${car.color}`
          });
        }
        group.pets = property.pets.length;
      }
      this.peopleGrid?.markForCheck();
      this.groupsGrid?.markForCheck();
    });
  }

  private parseType = (type: PersonType): string => {
    switch (type) {
      case 0:
        return 'Собственик';
      case 1:
        return 'Ползвател';
      case 2:
        return 'Наемател';
      case 3:
        return 'Външен';
      default:
        return '';
    }
  }
}
