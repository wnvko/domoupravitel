import { Component, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { IgxToastComponent } from 'igniteui-angular';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-settings',
  templateUrl: './user-settings.component.html',
  styleUrls: ['./user-settings.component.scss']
})
export class UserSettingsComponent {
  @ViewChild('toast', { static: true, read: IgxToastComponent })
  private toast?: IgxToastComponent;

  public updatePassword: FormGroup;

  constructor(fb: FormBuilder, public userService: UserService) {
    this.updatePassword = fb.group({
      password: ['', Validators.required],
      newPassword: ['', [Validators.required, Validators.minLength(6)]],
      repeatPassword: ['', [Validators.required, Validators.minLength(6)]],
    }, { validators: this.passwordConfirming })
  }

  public onSubmit() {
    const result = this.updatePassword.value;
    this.userService.update(result.password, result.newPassword, result.repeatPassword).subscribe({
      next: (e) => {
        this.toast!.textMessage = 'Паролата е успешно обновена!';
        this.toast?.open();
        this.clearForm();
      },
      error: (err: any) => {
        let textMessage = '';
        switch (err.error) {
          case 'Bad credentials':
            textMessage = 'Въвели сте грешна парола. Моля опитайте отново!';
            break;
          case 'Not matching passwords':
            textMessage = 'Новата и старата парола не си съвпадат. Добър опит :)';
            break;
          default:
            textMessage = 'Паролата не е обновена! Опитайте отново.'
        }
        this.toast!.textMessage = textMessage;
        this.toast?.open();
        this.clearForm();
      }
    });
  }

  public clearForm() {
    this.updatePassword.reset({ password: '', newPassword: '', repeatPassword: '' });
  }

  passwordConfirming: ValidatorFn = (c: AbstractControl): ValidationErrors | null => {
    if (c.get('newPassword')?.value != c.get('repeatPassword')?.value) {
      return { invalid: true };
    }
    return null;
  }

}
