import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { mergeMap, Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { JWT, JwtPayload } from "../models/JWT";
import { User } from "../models/user";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private serverUrl = environment.API_URL;
  private _currentUser?: User;

  constructor(
    private http: HttpClient,
    private router: Router) {
  }

  public get currentUser(): User | undefined {
    return this._currentUser;
  }

  public isLoggedIn(): boolean {
    return !!this._name;
  }

  public isAdmin(): boolean {
    return this._name === "wnvko";
  }

  public login(username: string, password: string): Observable<JWT> {
    return this.http.post<JWT>(`${this.serverUrl}/auth/login`, { username, password });
  }

  public logout(): void {
    delete this._currentUser;
    localStorage.removeItem('id_token');
    this.router.navigate(['/authentication']);
  }

  private get _name(): string | undefined {
    let rawJwt = localStorage.getItem('id_token');
    if (!rawJwt) return undefined;
    const payload = JSON.parse(atob(rawJwt.split('.')[1])) as JwtPayload;

    return payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
  }
}
