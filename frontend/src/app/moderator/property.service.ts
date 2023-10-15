import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Property } from '../models/property';

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
}
