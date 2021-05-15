import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { PatientService } from 'src/app/components/patient/service/patient.service';
import { MustMatchDirective } from 'src/app/shared/directive/mustMatch.directive';

@Component({
  selector: 'app-password-reset',
  templateUrl: './password-reset.component.html',
  styleUrls: ['./password-reset.component.scss'],
})
export class PasswordResetComponent implements OnInit {
  resetPasswordForm: FormGroup;
  passwordResetSuccess: boolean;

  constructor(
    private fb: FormBuilder,
    private patientService: PatientService,
    public toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.resetPasswordForm = this.fb.group({
      currentPassword: ['', [Validators.required]],
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]],
    });
  }

  resetPassword() {
    const self = this;
    let currentPassword = self.resetPasswordForm.get('currentPassword').value;
    let newPassword = self.resetPasswordForm.get('password').value;

    this.patientService
      .changePassword(currentPassword, newPassword)
      .then((response: any) => {
        this.passwordResetSuccess = true;
        this.toastr.success('Restablecimiento de contraseña con éxito.');
      })
      .catch((error: string) => {
        console.error();
        this.toastr.error('¡Algo salió mal. Por favor, vuelva a intentarlo!');
      });
  }
}
