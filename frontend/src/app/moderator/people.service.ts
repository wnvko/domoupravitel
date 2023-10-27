import { HttpClient } from "@angular/common/http";
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

    public create(person: Person): Observable<Person> {
        return this.http.post<Person>(`${this.serverUrl}/person/create`, person);
    }

    public update(person: Person): Observable<Person> {
        return this.http.put<Person>(`${this.serverUrl}/person/update`, person);
    }

    public delete(person: Person): Observable<Person> {
        return this.http.delete<Person>(`${this.serverUrl}/person/delete`, { body: person });
    }
}
