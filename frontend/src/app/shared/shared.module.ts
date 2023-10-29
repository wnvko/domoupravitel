import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { IgxButtonModule } from '@infragistics/igniteui-angular';
import { DeleteComponent } from './delete/delete.component';

@NgModule({
  declarations: [
    DeleteComponent,
  ],
  imports: [
    CommonModule,
    IgxButtonModule,
  ],
  exports: [
    DeleteComponent,
  ]
})
export class SharedModule { }
