import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { IgxActionStripModule, IgxButtonModule, IgxCardModule, IgxDialogModule, IgxGridModule, IgxIconModule, IgxInputGroupModule, IgxRippleModule, IgxSelectModule, IgxToastModule } from '@infragistics/igniteui-angular';
import { SharedModule } from "../shared/shared.module";
import { AuthRoutingModule } from "./auth-routing.module";
import { LoginComponent } from "./login/login.component";
import { UserManagerComponent } from './user-manager/user-manager.component';
import { UserSettingsComponent } from './user-settings/user-settings.component';

@NgModule({
    declarations: [
        LoginComponent,
        UserManagerComponent,
        UserSettingsComponent,
    ],
    imports: [
        CommonModule,
        AuthRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        SharedModule,
        IgxActionStripModule,
        IgxCardModule,
        IgxButtonModule,
        IgxGridModule,
        IgxDialogModule,
        IgxInputGroupModule,
        IgxIconModule,
        IgxRippleModule,
        IgxSelectModule,
        IgxToastModule
    ]
})
export class AuthModule{
}
