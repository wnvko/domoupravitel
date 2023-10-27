import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Role } from "../models/enums/role";
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
    const payload = this._jwtPayload;
    if (!payload) return false;

    return payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']*1 === Role.Admin;
  }

  public isModerator(): boolean {
    const payload = this._jwtPayload;
    if (!payload) return false;

    return payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']*1 === Role.Moderator;
  }

  public isUser(): boolean {
    return !this.isAdmin && !this.isModerator;
  }

  public all(): Observable<User[]> {
    return this.http.get<User[]>(`${this.serverUrl}/user/all`);
  }

  public add(user: User): Observable<User> {
    return this.http.post<User>(`${this.serverUrl}/user/register`, user);
  }

  public changePassword(password: string, newPassword: string, repeatPassword: string) {
    var request = { username: this.userName, password, newPassword, repeatPassword }
    return this.http.put<User>(`${this.serverUrl}/user/changePassword`, request);
  }

  public update(user: User): Observable<User> {
    return this.http.put<User>(`${this.serverUrl}/user/update`, user);
  }
  
  public delete(user: User): Observable<User> {
    return this.http.delete<User>(`${this.serverUrl}/user/delete`, { body: user });
  }

  public login(username: string, password: string): Observable<JWT> {
    return this.http.post<JWT>(`${this.serverUrl}/auth/login`, { username, password });
  }

  public logout(): void {
    localStorage.removeItem('id_token');
    this.router.navigate(['/auth']);
  }

  private get _name(): string | undefined {
    const payload = this._jwtPayload;
    if (!payload) return undefined;

    return payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
  }

  private get _jwtPayload(): JwtPayload | undefined {
    let rawJwt = localStorage.getItem('id_token');
    if (!rawJwt) return undefined;

    return JSON.parse(atob(rawJwt.split('.')[1])) as JwtPayload;
  }
}
