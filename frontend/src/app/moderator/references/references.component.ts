import { Component, OnInit, ViewChild } from '@angular/core';
import { IgxGridComponent } from '@infragistics/igniteui-angular';
import { PersonType } from 'src/app/models/enums/person-type';
import { PropertyService } from '../property.service';

@Component({
  selector: 'app-references',
  templateUrl: './references.component.html',
  styleUrls: ['./references.component.scss']
})
export class ReferencesComponent implements OnInit {
  public people: { 'property': string, 'name': string, 'type': string, 'phone': string, 'mail': string }[] = []
  public cars: { 'property': string, 'car': string }[] = []

  @ViewChild('peopleGrid', { static: true, read: IgxGridComponent })
  private peopleGrid?: IgxGridComponent;
  
  constructor(private propertiesService: PropertyService,) { }

  ngOnInit(): void {
    this.propertiesService.all().subscribe(p => {
      for (let property of p) {
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
        }
        for (let car of property.cars) {
          this.cars.push({
            property: property.number,
            car: `${car.number} ${car.brand} ${car.color}`
          });
        }
      }
      this.peopleGrid?.markForCheck();
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
