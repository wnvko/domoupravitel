import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { IgxButtonModule } from '@infragistics/igniteui-angular';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';

@NgModule({
  declarations: [
    DeleteDialogComponent,
  ],
  imports: [
    CommonModule,
    IgxButtonModule,
  ],
  exports: [
    DeleteDialogComponent,
  ]
})
export class SharedModule { }
