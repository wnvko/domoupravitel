import { Component, OnInit, ViewChild } from '@angular/core';
import { grid } from '@igniteui/material-icons-extended';
import { IgxExcelExporterService, IgxGridComponent } from '@infragistics/igniteui-angular';
import { PropertyService } from '../property.service';

@Component({
  selector: 'app-references',
  templateUrl: './references.component.html',
  styleUrls: ['./references.component.scss']
})
export class ReferencesComponent implements OnInit {
  public data: { 'property': string, 'name': string, 'type': string, 'phone': string, 'mail': string }[] = []

  @ViewChild('grid', { static: true, read: IgxGridComponent })
  private grid?: IgxGridComponent;
  constructor(
    private propertiesService: PropertyService,
    excelExportService: IgxExcelExporterService
  ) {
    excelExportService.columnExporting.subscribe(e => {
      if (e.field === 'type') {
        e.header = ' ';
      }
    });
  }

  ngOnInit(): void {
    this.propertiesService.all().subscribe(p => {
      for (let property of p) {
        for (let person of property.people) {
          let type = '';
          switch (person.type) {
            case 0:
              type = 'Собственик';
              break;
            case 1:
              type = 'Ползвател';
              break;
            case 2:
              type = 'Наемател';
              break;
            case 3:
              type = 'Външен';
              break;
            default:
              type = '';
              break;
          }
          this.data.push(
            {
              property: property.number,
              name: person.person.name,
              type,
              phone: person.person.phone,
              mail: person.person.email
            }
          );
        }
      }
      this.grid?.markForCheck();
    });
  }
}
