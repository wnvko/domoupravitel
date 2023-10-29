import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CellType } from '@infragistics/igniteui-angular';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.scss']
})
export class DeleteComponent {
  @Input()
  public deleteFunction!: { function: (e: CellType) => void, args: CellType } | undefined

  @Input()
  public message: string = '';

  @Output()
  public result: EventEmitter<void> = new EventEmitter<void>();

  public cancel = (): void => {
    this.deleteFunction = undefined;
    this.message = '';
    this.result.emit();
  }

  public delete = (): void => {
    this.deleteFunction!.function(this.deleteFunction!.args);
    this.deleteFunction = undefined;
    this.message = '';
    this.result.emit();
  }
}
