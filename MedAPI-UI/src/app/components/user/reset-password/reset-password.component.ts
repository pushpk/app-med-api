import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PatientService } from '../../patient/service/patient.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {
  resetPasswordForm: FormGroup;

  constructor(private fb: FormBuilder, private patientService: PatientService) { }

  ngOnInit(): void {
    this.resetPasswordForm = this.fb.group({

          password: ['', [Validators.required]],
          confirmPassword: ['', [Validators.required]],


  },  {validator: this.passwordConfirming});
  }

  resetPassword(){

  }


  passwordConfirming(c: AbstractControl): { invalid: boolean } {
    if (c.get('password').value !== c.get('confirmPassword').value) {
        return {invalid: true};
    }
}

}
