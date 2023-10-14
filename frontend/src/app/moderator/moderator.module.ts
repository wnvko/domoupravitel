import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PeopleComponent } from './people/people.component';
import { ModeratorRoutingModule } from './moderator-routing.module';
import { IgxActionStripModule, IgxGridModule } from 'igniteui-angular';



@NgModule({
  declarations: [
    PeopleComponent
  ],
  imports: [
    CommonModule,
    ModeratorRoutingModule,
    IgxActionStripModule,
    IgxGridModule,
  ]
})
export class ModeratorModule { }
