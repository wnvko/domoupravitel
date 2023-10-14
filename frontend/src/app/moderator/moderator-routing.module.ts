import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PeopleComponent } from "./people/people.component";
import { GuardService } from "../auth/guard.service";

const routes: Routes = [
    { path: '', redirectTo: 'people', pathMatch: 'full' },
    { path: 'people', component: PeopleComponent, canActivate: [GuardService] },
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ModeratorRoutingModule {
}
