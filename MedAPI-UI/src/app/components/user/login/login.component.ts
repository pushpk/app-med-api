import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../user.service';
import { UserAuthService } from '../../../auth/user-auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
 
  constructor(private fb: FormBuilder, public router: Router,
    public userService: UserService, private userAuthService: UserAuthService) { }

  ngOnInit(): void {
    this.buildForm();
  }

  buildForm() {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required, Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$')]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  control(name: string): AbstractControl {
    return this.loginForm.get(name);
  }
  
  doLogin() {
    const self = this;
    let credentials = {
      'username': self.loginForm.get('username').value,
      'password': self.loginForm.get('password').value
    }
    this.userService.login(credentials).then((response) => {
      this.userAuthService.save(response);
      this.router.navigateByUrl('/records');
    });
  }
}
