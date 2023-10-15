import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Property } from '../models/property';
import { Car } from '../models/car';
import { Pet } from '../models/pet';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  private serverUrl = environment.API_URL;

  constructor(
    private http: HttpClient) { }

  public all(): Observable<Property[]> {
    return this.http.get<Property[]>(`${this.serverUrl}/properties/all`);
  }

  public create(property: Property): Observable<Property> {
    return this.http.post<Property>(`${this.serverUrl}/properties/create`, property);
  }

  public update(property: Property): Observable<Property> {
    return this.http.put<Property>(`${this.serverUrl}/properties/update`, property);
  }

  public delete(property: Property): Observable<Property> {
    return this.http.delete<Property>(`${this.serverUrl}/properties/delete`, { body: property });
  }

  public addCar(car: Car): Observable<Car> {
    return this.http.post<Car>(`${this.serverUrl}/properties/addCar`, car);
  }

  public updateCar(car: Car): Observable<Car> {
    return this.http.put<Car>(`${this.serverUrl}/properties/updateCar`, car);
  }

  public deleteCar(car: Car): Observable<Car> {
    return this.http.delete<Car>(`${this.serverUrl}/properties/deleteCar`, { body: car });
  }

  public addPet(pet: Pet): Observable<Pet> {
    return this.http.post<Pet>(`${this.serverUrl}/properties/addPet`, pet);
  }

  public updatePet(pet: Pet): Observable<Pet> {
    return this.http.put<Pet>(`${this.serverUrl}/properties/updatePet`, pet);
  }

  public deletePet(pet: Pet): Observable<Pet> {
    return this.http.delete<Pet>(`${this.serverUrl}/properties/deletePet`, { body: pet });
  }
}
