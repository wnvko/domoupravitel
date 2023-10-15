import { Component } from '@angular/core';
import { PropertyService } from '../property.service';
import { Observable, first } from 'rxjs';
import { Property } from 'src/app/models/property';
import { IGridEditDoneEventArgs, IRowDataEventArgs } from 'igniteui-angular';
import { PropertyType } from 'src/app/models/enums/property-type';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.scss']
})
export class PropertyComponent {
  public pets!: Observable<Property[]>;
  public types = Object.keys(PropertyType).filter(k => !isNaN(Number(k))).map(v => {
    if (parseInt(v) === PropertyType.Apartment) return { name: 'Апартамент', value: 0 };
    if (parseInt(v) === PropertyType.InsideOffice) return { name: 'Офис вътрешен', value: 1 };
    if (parseInt(v) === PropertyType.OutsideOffice) return { name: 'Офис външен', value: 2 };
    return { name: 'Гараж', value: 3 };
  });

  constructor(
    private propertiesService: PropertyService
  ) { }

  ngOnInit(): void {
    this.pets = this.propertiesService.all();
  }

  public propertyAdded(e: IRowDataEventArgs) {
    this.propertiesService.create(e.data as Property).pipe(first()).subscribe();
  }

  public propertyEdited(e: IGridEditDoneEventArgs) {
    if (e.isAddRow)
      return;

    this.propertiesService.update(e.newValue as Property).pipe(first()).subscribe();
  }

  public propertyDeleted(e: IRowDataEventArgs) {
    this.propertiesService.delete(e.data as Property).pipe(first()).subscribe();
  }
  
  public parseType(type: number): string {
    if (type === 0) return 'Апартамент';
    if (type === 1) return 'Офис външен';
    if (type === 2) return 'Офис вътрешен';
    if (type === 3) return 'Гараж';
    return '';
  }

}
