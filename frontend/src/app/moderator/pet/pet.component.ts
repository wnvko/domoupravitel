import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CellType, IGridEditDoneEventArgs, IRowDataEventArgs, ISortingOptions, IgxDialogComponent, IgxGridComponent } from '@infragistics/igniteui-angular';
import { Observable, Subject, first, takeUntil } from 'rxjs';
import { Pet } from 'src/app/models/pet';
import { DeleteDialogComponent } from 'src/app/shared/delete-dialog/delete-dialog.component';
import { PetService } from '../pet.service';

@Component({
  selector: 'app-pet',
  templateUrl: './pet.component.html',
  styleUrls: ['./pet.component.scss']
})
export class PetComponent implements OnInit, OnDestroy {
  private destroy$: Subject<void> = new Subject<void>();

  @ViewChild('deleteDialog', { static: true, read: DeleteDialogComponent })
  private deleteDialog!: DeleteDialogComponent;

  @ViewChild('dialog', { static: true, read: IgxDialogComponent })
  private dialog!: IgxDialogComponent;

  public pets!: Observable<Pet[]>;
  public sortingOptions: ISortingOptions = {
    mode: 'single'
  }

  constructor(
    private petsService: PetService
  ) { }

  ngOnInit(): void {
    this.pets = this.petsService.all();
    this.deleteDialog.result.pipe(takeUntil(this.destroy$)).subscribe(() => this.dialog.close());
  }
  
  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  public addPet = (grid: IgxGridComponent): void => {
    grid.beginAddRowByIndex(0);
  }

  public petAdded = (e: IRowDataEventArgs): void => {
    this.petsService.create(e.data as Pet).pipe(first()).subscribe();
  }

  public petEdited = (e: IGridEditDoneEventArgs): void => {
    if (e.isAddRow)
      return;

    this.petsService.update(e.newValue as Pet).pipe(first()).subscribe();
  }

  public startDeletePet = (e: CellType): void => {
    this.deleteDialog.deleteFunction = { function: this.petDeleted, args: e };
    const pet = e.row.data as Pet;
    this.deleteDialog.message = `Животно ${pet.name} ще бъде изтрито!`;
    this.dialog.open();
  }

  public petDeleted = (e: CellType): void => {
    this.petsService.delete(e.row.data as Pet).pipe(first()).subscribe({
      next: c => e.grid.deleteRow(c),
      error: err => console.log(err)
    });
  }
}
