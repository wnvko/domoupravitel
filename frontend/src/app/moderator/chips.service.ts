import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Chip } from '../models/chip';

@Injectable({
  providedIn: 'root'
})
export class ChipsService {
  private serverUrl = environment.API_URL;

  constructor(
      private http: HttpClient) { }

  public all(): Observable<Chip[]> {
      return this.http.get<Chip[]>(`${this.serverUrl}/chip/all`);
  }

  public create(chip: Chip): Observable<Chip> {
      return this.http.post<Chip>(`${this.serverUrl}/chip/create`, chip);
  }

  public update(chip: Chip): Observable<Chip> {
      return this.http.put<Chip>(`${this.serverUrl}/chip/update`, chip);
  }

  public delete(chip: Chip): Observable<Chip> {
      return this.http.delete<Chip>(`${this.serverUrl}/chip/delete`, { body: chip });
  }
}
