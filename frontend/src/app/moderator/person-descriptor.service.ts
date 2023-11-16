import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PersonDescriptor } from '../models/person-descriptor';
import { cleanDate } from '../shared/util';

@Injectable({
  providedIn: 'root'
})
export class PersonDescriptorService {
  public get http(): HttpClient {
    return this._http;
  }
  public set http(value: HttpClient) {
    this._http = value;
  }
  private serverUrl = environment.API_URL;

  constructor(
    private _http: HttpClient) { }

  public all(): Observable<PersonDescriptor[]> {
    return this.http.get<PersonDescriptor[]>(`${this.serverUrl}/personDescriptors/all`);
  }

  public create(descriptor: PersonDescriptor): Observable<PersonDescriptor> {
    descriptor.registeredOn = cleanDate(descriptor.registeredOn!);
    descriptor.unRegisteredOn = cleanDate(descriptor.unRegisteredOn!);
    return this.http.post<PersonDescriptor>(`${this.serverUrl}/personDescriptors/create`, descriptor);
  }

  public update(descriptor: PersonDescriptor): Observable<PersonDescriptor> {
    descriptor.registeredOn = cleanDate(descriptor.registeredOn!);
    descriptor.unRegisteredOn = cleanDate(descriptor.unRegisteredOn!);
    return this.http.put<PersonDescriptor>(`${this.serverUrl}/personDescriptors/update`, descriptor);
  }

  public delete(descriptor: PersonDescriptor): Observable<PersonDescriptor> {
    return this.http.delete<PersonDescriptor>(`${this.serverUrl}/personDescriptors/delete`, { body: descriptor });
  }
}
