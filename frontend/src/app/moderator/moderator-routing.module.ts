import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { GuardService } from "../auth/guard.service";
import { CarComponent } from "./car/car.component";
import { PeopleComponent } from "./people/people.component";
import { PetComponent } from "./pet/pet.component";
import { PropertyComponent } from "./property/property.component";
import { ReferencesComponent } from "./references/references.component";
import { ChipsComponent } from "./chips/chips.component";

const routes: Routes = [
    { path: '', redirectTo: 'people', pathMatch: 'full' },
    { path: 'people', component: PeopleComponent, canActivate: [GuardService] },
    { path: 'chips', component: ChipsComponent, canActivate: [GuardService] },
    { path: 'cars', component: CarComponent, canActivate: [GuardService] },
    { path: 'pets', component: PetComponent, canActivate: [GuardService] },
    { path: 'properties', component: PropertyComponent, canActivate: [GuardService] },
    { path: 'references', component: ReferencesComponent, canActivate: [GuardService] },
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ModeratorRoutingModule {
}
