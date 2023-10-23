import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { IgxActionStripModule, IgxDialogModule, IgxGridModule, IgxHierarchicalGridModule, IgxIconModule } from '@infragistics/igniteui-angular';
import { CarComponent } from './car/car.component';
import { ModeratorRoutingModule } from './moderator-routing.module';
import { PeopleComponent } from './people/people.component';
import { PetComponent } from './pet/pet.component';
import { SortPipe } from './pipes/sort.pipe';
import { PropertyComponent } from './property/property.component';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';



@NgModule({
  declarations: [
    PeopleComponent,
    CarComponent,
    PetComponent,
    PropertyComponent,
    SortPipe,
    DeleteDialogComponent
  ],
  imports: [
    CommonModule,
    ModeratorRoutingModule,
    IgxActionStripModule,
    IgxDialogModule,
    IgxHierarchicalGridModule,
    IgxIconModule,
    IgxGridModule,
  ]
})
export class ModeratorModule { }
