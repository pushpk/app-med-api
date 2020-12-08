import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  AbstractControl,
} from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../user.service';
import { UserAuthService } from '../../../auth/user-auth.service';
import { RecordService } from '../../record/services/record.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    public router: Router,
    private recordService: RecordService,
    public userService: UserService,
    private userAuthService: UserAuthService
  ) {}

  ngOnInit(): void {
    this.buildForm();
  }

  buildForm() {
    this.loginForm = this.fb.group({
      username: [
        '',
        [
          Validators.required,
          Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}$'),
        ],
      ],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  control(name: string): AbstractControl {
    return this.loginForm.get(name);
  }

  doLogin() {
    const self = this;
    let username = self.loginForm.get('username').value;
    let password = self.loginForm.get('password').value;
    let credentials = {
      username: username,
      password: password,
    };
    this.userService.login(credentials).then((response: any) => {
      if (response === 'Email_Not_Confirmed') {
        var rt = '/email-not-confirmed?email=' + username;
        this.router.navigateByUrl(rt);
      } else {
        localStorage.setItem('email', username);
        this.recordService.passwordHash.next(password);
        this.userAuthService.save(response);

        localStorage.setItem('loggedInID', response.id);

        if (response['role'] === 4) {
          localStorage.setItem('role', 'patient');
          var rt = '/records/' + response.docNumber;

          this.router.navigateByUrl(rt);
        } else if (response['role'] === 5) {
          localStorage.setItem('role', 'lab');
          this.router.navigateByUrl('/records');
        } else {
          localStorage.setItem('role', 'admin');

          if (response['id'] === 1) {
            this.router.navigateByUrl('/admin');
          } else {
            if (!response['IsApproved']) {
              localStorage.clear();
              localStorage.setItem('reason', 'not-approved');
              this.router.navigateByUrl('/no-access');
            } else if (response['IsFreezed']) {
              localStorage.clear();
              localStorage.setItem('reason', 'freezed');
              this.router.navigateByUrl('/no-access');
            } else {
              this.router.navigateByUrl('/records');
            }
          }
        }
      }
    });
  }
}
