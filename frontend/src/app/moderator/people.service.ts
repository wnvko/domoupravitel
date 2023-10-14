import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Person } from "../models/person";

@Injectable({
    providedIn: 'root'
})
export class PeopleService {
    private serverUrl = environment.API_URL;

    constructor(
        private http: HttpClient) { }

    public all(): Observable<Person[]> {
        return this.http.get<Person[]>(`${this.serverUrl}/person/all`);
    }

    public create(user: Person): Observable<Person> {
        return this.http.post<Person>(`${this.serverUrl}/person/create`, user);
    }

    public update(user: Person): Observable<Person> {
        return this.http.put<Person>(`${this.serverUrl}/person/update`, user);
    }

    public delete(user: Person): Observable<Person> {
        return this.http.delete<Person>(`${this.serverUrl}/person/delete`, { body: user });
    }
}
