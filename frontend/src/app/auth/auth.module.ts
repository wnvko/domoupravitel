import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { IgxActionStripModule, IgxButtonModule, IgxCardModule, IgxGridModule, IgxInputGroupModule, IgxRippleModule, IgxToastModule } from '@infragistics/igniteui-angular';
import { AuthRoutingModule } from "./auth-routing.module";
import { LoginComponent } from "./login/login.component";
import { UserManagerComponent } from './user-manager/user-manager.component';
import { UserSettingsComponent } from './user-settings/user-settings.component';

@NgModule({
    declarations: [
        LoginComponent,
        UserManagerComponent,
        UserSettingsComponent
    ],
    imports: [
        CommonModule,
        AuthRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        IgxActionStripModule,
        IgxCardModule,
        IgxButtonModule,
        IgxGridModule,
        IgxInputGroupModule,
        IgxRippleModule,
        IgxToastModule
    ]
})
export class AuthModule{
}
