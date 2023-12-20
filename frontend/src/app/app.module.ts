import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { LOCALE_ID, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IgxAvatarModule, IgxButtonModule, IgxCardModule, IgxDialogModule, IgxIconModule, IgxInputGroupModule, IgxNavbarModule, IgxNavigationDrawerModule, IgxRippleModule, IgxTabsModule, IgxToggleModule } from '@infragistics/igniteui-angular';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthInterceptor } from './auth/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    IgxAvatarModule,
    IgxButtonModule,
    IgxCardModule,
    IgxDialogModule,
    IgxIconModule,
    IgxInputGroupModule,
    IgxNavbarModule,
    IgxNavigationDrawerModule,
    IgxRippleModule,
    IgxToggleModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: LOCALE_ID, useValue: 'bg' },
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
