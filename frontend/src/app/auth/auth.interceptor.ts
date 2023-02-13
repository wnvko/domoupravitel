import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map, Observable, tap } from "rxjs";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const jwtToken = localStorage.getItem('id_token');
        const cloned = req.clone({
            withCredentials: true,
            headers: req.headers.set('Authorization', `Bearer ${jwtToken}`)
        });
        return next.handle(cloned).pipe(
            map((v: any) => {
                if (typeof v !== 'object') return;
                if (typeof v.body !== 'object') return;
                if (typeof v.body.jwt !== 'string') return;

                localStorage.setItem('id_token', v.body.jwt + '');

                return v;
            })
        );
    }
}
