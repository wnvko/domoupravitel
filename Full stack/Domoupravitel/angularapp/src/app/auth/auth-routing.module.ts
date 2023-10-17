import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { GuardService } from "./guard.service";
import { LoginComponent } from "./login/login.component";
import { UserManagerComponent } from "./user-manager/user-manager.component";
import { UserSettingsComponent } from "./user-settings/user-settings.component";

const routes: Routes = [
    { path: '', redirectTo: 'login', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'user-manager', component: UserManagerComponent, canActivate: [GuardService] },
    { path: 'user-settings', component: UserSettingsComponent, canActivate: [GuardService] },
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AuthRoutingModule {
}
