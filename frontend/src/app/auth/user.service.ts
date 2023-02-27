import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { map, Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { JWT, JwtPayload } from "../models/JWT";
import { User } from "../models/user";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private serverUrl = environment.API_URL;

  constructor(
    private http: HttpClient,
    private router: Router) {
  }

  public get userName(): string {
    return this._name ?? '';
  }

  public isLoggedIn(): boolean {
    return !!this._name;
  }

  public isAdmin(): boolean {
    return this._name === "wnvko";
  }

  public all(): Observable<User[]> {
    return this.http
      .get<User[]>(`${this.serverUrl}/user/all`)
      .pipe(map(e => e.map(u => {
        return { id: u.id, userName: u.userName, password: ''} as User;
      })));
  }

  public add(user: User): Observable<User> {
    return this.http.post<User>(`${this.serverUrl}/user/register`, user);
  }

  public update(password: string, newPassword: string, repeatPassword: string) {
    var request = { username: this.userName, password, newPassword, repeatPassword }
    return this.http.put<User>(`${this.serverUrl}/user/update`, request);
  }

  public login(username: string, password: string): Observable<JWT> {
    return this.http.post<JWT>(`${this.serverUrl}/auth/login`, { username, password });
  }

  public logout(): void {
    localStorage.removeItem('id_token');
    this.router.navigate(['/auth']);
  }

  private get _name(): string | undefined {
    let rawJwt = localStorage.getItem('id_token');
    if (!rawJwt) return undefined;
    const payload = JSON.parse(atob(rawJwt.split('.')[1])) as JwtPayload;

    return payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
  }
}
