import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IgxActionStripModule, IgxButtonModule, IgxDialogModule, IgxGridModule, IgxHierarchicalGridModule, IgxIconModule, IgxSelectModule } from '@infragistics/igniteui-angular';
import { SharedModule } from '../shared/shared.module';
import { CarComponent } from './car/car.component';
import { ModeratorRoutingModule } from './moderator-routing.module';
import { PeopleComponent } from './people/people.component';
import { PetComponent } from './pet/pet.component';
import { SortPipe } from './pipes/sort.pipe';
import { PropertyComponent } from './property/property.component';

@NgModule({
  declarations: [
    PeopleComponent,
    CarComponent,
    PetComponent,
    PropertyComponent,
    SortPipe,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ModeratorRoutingModule,
    SharedModule,
    IgxActionStripModule,
    IgxButtonModule,
    IgxDialogModule,
    IgxGridModule,
    IgxHierarchicalGridModule,
    IgxIconModule,
    IgxSelectModule
  ]
})
export class ModeratorModule { }
