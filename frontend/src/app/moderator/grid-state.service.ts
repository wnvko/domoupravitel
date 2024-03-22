import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { GridState } from '../models/grid-state';

@Injectable({
  providedIn: 'root'
})
export class GridStateService {
  private serverUrl = environment.API_URL;

  constructor(
    private http: HttpClient) { }

  public getState(name: string): Observable<GridState> {
    return this.http.get<GridState>(`${this.serverUrl}/GridState/get/${name}`);
  }

  public putState(GridState: GridState): Observable<GridState> {
    return this.http.put<GridState>(`${this.serverUrl}/GridState/put`, GridState);
  }
}
