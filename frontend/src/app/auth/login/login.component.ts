import { Component } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { UserService } from "../user.service";

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent {
    public credentials: FormGroup;

    constructor(
        fb: FormBuilder,
        private router: Router,
        private user: UserService) {
        this.credentials = fb.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });
    }

    public onSubmit(): void {
        if (this.credentials.valid) {
            this.user.login(this.credentials.value.username, this.credentials.value.password).subscribe({
                next: () => {
                    this.router.navigate(['/']);
                },
                error: (err: any) => {
                    this.credentials.reset();
                }
            });
        }
    }
}
