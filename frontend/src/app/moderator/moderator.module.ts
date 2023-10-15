import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PeopleComponent } from './people/people.component';
import { ModeratorRoutingModule } from './moderator-routing.module';
import { IgxActionStripModule, IgxGridModule, IgxHierarchicalGridModule } from 'igniteui-angular';
import { CarComponent } from './car/car.component';
import { PetComponent } from './pet/pet.component';
import { PropertyComponent } from './property/property.component';



@NgModule({
  declarations: [
    PeopleComponent,
    CarComponent,
    PetComponent,
    PropertyComponent
  ],
  imports: [
    CommonModule,
    ModeratorRoutingModule,
    IgxActionStripModule,
    IgxHierarchicalGridModule,
    IgxGridModule,
  ]
})
export class ModeratorModule { }
