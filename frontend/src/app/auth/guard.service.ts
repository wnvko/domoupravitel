import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { UserService } from "./user.service";

@Injectable({
    providedIn: 'root'
})
export class GuardService  {
    constructor(
        private user: UserService,
        private router: Router
    ) { }

    canActivate(): boolean {
        if (this.user.isLoggedIn()) return true;
        this.router.navigate(['/auth']);
        return false;
    }
}
