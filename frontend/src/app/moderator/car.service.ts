import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Car } from '../models/car';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  private serverUrl = environment.API_URL;

  constructor(
      private http: HttpClient) { }

  public all(): Observable<Car[]> {
      return this.http.get<Car[]>(`${this.serverUrl}/cars/all`);
  }

  public create(car: Car): Observable<Car> {
      return this.http.post<Car>(`${this.serverUrl}/cars/create`, car);
  }

  public update(car: Car): Observable<Car> {
      return this.http.put<Car>(`${this.serverUrl}/cars/update`, car);
  }

  public delete(car: Car): Observable<Car> {
      return this.http.delete<Car>(`${this.serverUrl}/cars/delete`, { body: car });
  }
}
