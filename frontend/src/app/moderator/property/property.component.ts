import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CellType, IGridEditDoneEventArgs, IRowDataEventArgs, ISortingOptions, IgxDialogComponent, IgxGridToolbarComponent, IgxHierarchicalGridComponent, IgxRowIslandComponent } from '@infragistics/igniteui-angular';
import { Observable, Subject, first, takeUntil } from 'rxjs';
import { Car } from 'src/app/models/car';
import { PersonType } from 'src/app/models/enums/person-type';
import { PropertyType } from 'src/app/models/enums/property-type';
import { Residence } from 'src/app/models/enums/residence';
import { Person } from 'src/app/models/person';
import { PersonDescriptor } from 'src/app/models/person-descriptor';
import { Pet } from 'src/app/models/pet';
import { Property } from 'src/app/models/property';
import { CarService } from '../car.service';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { PeopleService } from '../people.service';
import { PersonDescriptorService } from '../person-descriptor.service';
import { PetService } from '../pet.service';
import { PropertyService } from '../property.service';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.scss']
})
export class PropertyComponent implements OnInit, OnDestroy {
  private destroy$: Subject<void> = new Subject<void>();

  @ViewChild('personRowIsland', { static: true, read: IgxRowIslandComponent })
  private personRowIsland!: IgxRowIslandComponent;

  @ViewChild('carRowIsland', { static: true, read: IgxRowIslandComponent })
  private carRowIsland!: IgxRowIslandComponent;

  @ViewChild('petRowIsland', { static: true, read: IgxRowIslandComponent })
  private petRowIsland!: IgxRowIslandComponent;

  @ViewChild('deleteDialog', { static: true, read: DeleteDialogComponent })
  private deleteDialog!: DeleteDialogComponent;

  @ViewChild('dialog', { static: true, read: IgxDialogComponent })
  private dialog!: IgxDialogComponent;

  public properties!: Observable<Property[]>;
  public people!: Observable<Person[]>;
  public cars!: Observable<Car[]>;
  public pets!: Observable<Pet[]>;
  public types = Object.keys(PropertyType).filter(k => !isNaN(Number(k))).map(v => {
    if (parseInt(v) === PropertyType.Apartment) return { name: 'Апартамент', value: 0 };
    if (parseInt(v) === PropertyType.OutsideOffice) return { name: 'Офис външен', value: 1 };
    if (parseInt(v) === PropertyType.InsideOffice) return { name: 'Офис вътрешен', value: 2 };
    return { name: 'Гараж', value: 3 };
  });
  public personTypes = Object.keys(PersonType).filter(k => !isNaN(Number(k))).map(v => {
    if (parseInt(v) === PersonType.Owner) return { name: 'Собственик', value: 0 };
    if (parseInt(v) === PersonType.User) return { name: 'Ползвател', value: 1 };
    return { name: 'Наемател', value: 2 };
  });
  public residencies = Object.keys(Residence).filter(k => !isNaN(Number(k))).map(v => {
    if (parseInt(v) === Residence.Permanent) return { name: 'Постоянно', value: 0 };
    if (parseInt(v) === Residence.Absent) return { name: 'Отсъства', value: 1 };
    return { name: 'Временно', value: 2 };
  });
  public sortingOptions: ISortingOptions = {
    mode: 'single'
  }

  constructor(
    private propertiesService: PropertyService,
    private peopleService: PeopleService,
    private personDescriptorService: PersonDescriptorService,
    private carsService: CarService,
    private petsService: PetService,
  ) {
  }

  //#region System overloads
  ngOnInit(): void {
    this.properties = this.propertiesService.all();
    this.people = this.peopleService.all();
    this.cars = this.carsService.all();
    this.pets = this.petsService.all();

    this.personRowIsland.rowAdded.pipe(takeUntil(this.destroy$)).subscribe(e => this.personAdded(e, this.personRowIsland));
    this.personRowIsland.rowEditDone.pipe(takeUntil(this.destroy$)).subscribe(this.personEdited);

    this.carRowIsland.rowAdded.pipe(takeUntil(this.destroy$)).subscribe(e => this.carAdded(e, this.carRowIsland));
    this.carRowIsland.rowEditDone.pipe(takeUntil(this.destroy$)).subscribe(this.carEdited);

    this.petRowIsland.rowAdded.pipe(takeUntil(this.destroy$)).subscribe(e => this.petAdded(e, this.petRowIsland));
    this.petRowIsland.rowEditDone.pipe(takeUntil(this.destroy$)).subscribe(this.petEdited);

    this.deleteDialog.result.pipe(takeUntil(this.destroy$)).subscribe(e => this.dialog.close());
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
  //#endregion  System overloads

  //#region CRUD
  public addProperty = (grid: IgxHierarchicalGridComponent): void => {
    grid.beginAddRowByIndex(0);
  }

  public propertyAdded = (e: IRowDataEventArgs): void => {
    this.propertiesService.create(e.data as Property).pipe(first()).subscribe();
  }

  public propertyEdited = (e: IGridEditDoneEventArgs): void => {
    if (e.isAddRow)
      return;

    this.propertiesService.update(e.newValue as Property).pipe(first()).subscribe();
  }

  public startDeleteProperty =(e: CellType): void => {
    this.deleteDialog.deleteFunction = { function: this.propertyDeleted, args: e };
    const property = e.row.data as Property;
    this.deleteDialog.message = `Имот ${property.number} ще бъде изтрит!`;
    this.dialog.open();
  }

  public propertyDeleted = (e: CellType): void => {
    this.propertiesService.delete(e.row.data as Property).pipe(first()).subscribe({
      next: c => e.grid.deleteRow(c),
      error: err => console.log(err)
    });
  }

  public addPerson = (e: IgxGridToolbarComponent): void => {
    const grid: IgxHierarchicalGridComponent = e.grid as IgxHierarchicalGridComponent;
    grid.beginAddRowByIndex(0);
  }

  public personAdded = (e: IRowDataEventArgs, rowIsland: IgxRowIslandComponent): void => {
    const propertyId = rowIsland.gridAPI.getParentRowId(e.owner);
    e.data.propertyId = propertyId;
    e.data.personId = e.data.person.id;
    this.personDescriptorService.create(e.data).pipe(first()).subscribe();
  }

  public personEdited = (e: IGridEditDoneEventArgs): void => {
    if (e.isAddRow) return;

    this.personDescriptorService.update(e.newValue).pipe(first()).subscribe();
  }

  public startDeletePerson =(e: CellType): void => {
    this.deleteDialog.deleteFunction = { function: this.personDeleted, args: e };
    const personDescriptor = e.row.data as PersonDescriptor;
    this.deleteDialog.message = `${personDescriptor.person.name} ще бъде изтрит/а!`;
    this.dialog.open();
  }

  public personDeleted = (e: CellType): void => {
    this.personDescriptorService.delete(e.row.data as PersonDescriptor).pipe(first()).subscribe({
      next: c => e.grid.deleteRow(c),
      error: err => console.log(err)
    });
  }

  public addCar = (e: IgxGridToolbarComponent): void => {
    const grid: IgxHierarchicalGridComponent = e.grid as IgxHierarchicalGridComponent;
    grid.beginAddRowByIndex(0);
  }

  public carAdded = (e: IRowDataEventArgs, rowIsland: IgxRowIslandComponent): void => {
    const propertyId = rowIsland.gridAPI.getParentRowId(e.owner);
    e.data.propertyId = propertyId;
    this.propertiesService.addCar(e.data).pipe(first()).subscribe();
  }

  public carEdited = (e: IGridEditDoneEventArgs): void => {
    if (e.isAddRow) return;

    this.propertiesService.deleteCar(e.oldValue).pipe(first()).subscribe();
    this.propertiesService.updateCar(e.newValue).pipe(first()).subscribe();
  }

  public startDeleteCar =(e: CellType): void => {
    this.deleteDialog.deleteFunction = { function: this.carDeleted, args: e };
    const car = e.row.data as Car;
    this.deleteDialog.message = `Кола ${car.number} ще бъде изтрита!`;
    this.dialog.open();
  }

  public carDeleted = (e: CellType): void => {
    this.propertiesService.deleteCar(e.row.data as Car).pipe(first()).subscribe({
      next: c => e.grid.deleteRow(c.id),
      error: err => console.log(err)
    });
  }

  public addPet = (e: IgxGridToolbarComponent): void => {
    const grid: IgxHierarchicalGridComponent = e.grid as IgxHierarchicalGridComponent;
    grid.beginAddRowByIndex(0);
  }

  public petAdded = (e: IRowDataEventArgs, rowIsland: IgxRowIslandComponent): void => {
    const propertyId = rowIsland.gridAPI.getParentRowId(e.owner);
    e.data.propertyId = propertyId;
    this.propertiesService.addPet(e.data).pipe(first()).subscribe();
  }

  public petEdited = (e: IGridEditDoneEventArgs): void => {
    if (e.isAddRow) return;

    this.propertiesService.deletePet(e.oldValue).pipe(first()).subscribe();
    this.propertiesService.updatePet(e.newValue).pipe(first()).subscribe();
  }

  public startDeletePet = (e: CellType): void => {
    this.deleteDialog.deleteFunction = { function: this.petDeleted, args: e };
    const pet = e.row.data as Pet;
    this.deleteDialog.message = `Животно ${pet.name} ще бъде изтрито!`;
    this.dialog.open();
  }

  public petDeleted = (e: CellType): void => {
    this.propertiesService.deletePet(e.row.data as Pet).pipe(first()).subscribe({
      next: c => e.grid.deleteRow(c.id),
      error: err => console.log(err)
    });
  }
  //#endregion

  //#region Parsers
  public parseType = (type: number): string => {
    if (type === 0) return 'Апартамент';
    if (type === 1) return 'Офис външен';
    if (type === 2) return 'Офис вътрешен';
    if (type === 3) return 'Гараж';
    return '';
  }

  public parsePersonType = (type: number): string => {
    if (type === 0) return 'Собственик';
    if (type === 1) return 'Ползвател';
    if (type === 2) return 'Наемател';
    return '';
  }

  public parseResidence = (type: number): string => {
    if (type === 0) return 'Постоянно';
    if (type === 1) return 'Отсъства';
    if (type === 2) return 'Временно';
    return '';
  }
  //#endregion
}
