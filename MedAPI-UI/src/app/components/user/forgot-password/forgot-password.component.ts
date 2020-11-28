import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {
  forgotPasswordField: string = '';
  forgotPasswordForm: FormGroup;

  constructor(private fb: FormBuilder) { 
    this.forgotPasswordForm = this.fb.group({
      username: ['', [Validators.required, Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$')]],
    });
  }

  ngOnInit(): void {
  }

  forgotPassword(){

    console.log(this.forgotPasswordField);
  }
}
