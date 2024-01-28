import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  IgxActionStripModule,
  IgxButtonModule,
  IgxCheckboxModule,
  IgxDatePickerModule,
  IgxDialogModule,
  IgxGridModule,
  IgxHierarchicalGridModule,
  IgxIconModule,
  IgxInputGroupModule,
  IgxSelectModule,
  IgxSimpleComboModule,
  IgxSwitchModule,
  IgxTabsModule
} from '@infragistics/igniteui-angular';
import { SharedModule } from '../shared/shared.module';
import { AddPersonComponent } from './add-person/add-person.component';
import { CarComponent } from './car/car.component';
import { ModeratorRoutingModule } from './moderator-routing.module';
import { PeopleComponent } from './people/people.component';
import { PetComponent } from './pet/pet.component';
import { SortPipe } from './pipes/sort.pipe';
import { PropertyComponent } from './property/property.component';
import { ReferencesComponent } from './references/references.component';
import { ChipsComponent } from './chips/chips.component';

@NgModule({
  declarations: [
    PeopleComponent,
    CarComponent,
    ChipsComponent,
    PetComponent,
    PropertyComponent,
    SortPipe,
    AddPersonComponent,
    ReferencesComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ModeratorRoutingModule,
    SharedModule,
    IgxActionStripModule,
    IgxButtonModule,
    IgxCheckboxModule,
    IgxSimpleComboModule,
    IgxDatePickerModule,
    IgxDialogModule,
    IgxGridModule,
    IgxHierarchicalGridModule,
    IgxIconModule,
    IgxInputGroupModule,
    IgxSelectModule,
    IgxSwitchModule,
    IgxTabsModule
  ]
})
export class ModeratorModule { }
