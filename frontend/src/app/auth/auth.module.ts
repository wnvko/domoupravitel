import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { IgxActionStripModule, IgxButtonModule, IgxGridModule, IgxInputGroupModule, IgxRippleModule, IgxToastModule } from "igniteui-angular";
import { AuthRoutingModule } from "./auth-routing.module";
import { LoginComponent } from "./login/login.component";
import { UserManagerComponent } from './user-manager/user-manager.component';

@NgModule({
    declarations: [
        LoginComponent,
        UserManagerComponent
    ],
    imports: [
        CommonModule,
        AuthRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        IgxActionStripModule,
        IgxButtonModule,
        IgxGridModule,
        IgxInputGroupModule,
        IgxRippleModule,
        IgxToastModule
    ]
})
export class AuthModule{
}
