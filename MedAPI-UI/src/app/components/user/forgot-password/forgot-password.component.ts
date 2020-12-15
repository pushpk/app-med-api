import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PatientService } from '../../patient/service/patient.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss'],
})
export class ForgotPasswordComponent implements OnInit {
  forgotPasswordForm: FormGroup;
  sentForgotPasswordEmail: boolean;

  constructor(
    private fb: FormBuilder,
    private patientService: PatientService
  ) {}

  ngOnInit(): void {
    this.forgotPasswordForm = this.fb.group({
      username: [
        '',
        [
          Validators.required,
          Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}$'),
        ],
      ],
    });
  }

  forgotPassword() {
    const self = this;
    let username = self.forgotPasswordForm.get('username').value;

    console.log(username);
    this.patientService
      .forgotPassword(username)
      .then((response: any) => {
        // this.sentForgotPasswordEmail = true;
      })
      .catch((error: any) => {});
    this.sentForgotPasswordEmail = true;
  }
}
