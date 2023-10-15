import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Pet } from '../models/pet';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PetService {
  private serverUrl = environment.API_URL;

  constructor(
      private http: HttpClient) { }

  public all(): Observable<Pet[]> {
      return this.http.get<Pet[]>(`${this.serverUrl}/pets/all`);
  }

  public create(pet: Pet): Observable<Pet> {
      return this.http.post<Pet>(`${this.serverUrl}/pets/create`, pet);
  }

  public update(pet: Pet): Observable<Pet> {
      return this.http.put<Pet>(`${this.serverUrl}/pets/update`, pet);
  }

  public delete(pet: Pet): Observable<Pet> {
      return this.http.delete<Pet>(`${this.serverUrl}/pets/delete`, { body: pet });
  }}
