import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserAuthService } from '../../../auth/user-auth.service';
import { RecordService } from '../../record/services/record.service';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  timer: any;
  showInactivityAlert: boolean = false;
  isLoading = false;

  constructor(
    private fb: FormBuilder,
    public router: Router,
    private recordService: RecordService,
    public userService: UserService,
    private userAuthService: UserAuthService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.buildForm();
    this.showInactivityAlert = this.userService.showInactivityAlert;
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
    this.isLoading = true;
    const self = this;
    let username = self.loginForm.get('username').value;
    let password = self.loginForm.get('password').value;
    let credentials = {
      username: username,
      password: password,
      grant_type: 'password',
    };
    this.userService.login(credentials).then((response: any) => {
      this.isLoading = false;
      if (response === 'Email_Not_Confirmed') {
        var rt = '/email-not-confirmed?email=' + username;
        this.router.navigateByUrl(rt);
      } else {
        localStorage.setItem('email', username);
        this.recordService.passwordHash.next(password);
        this.userAuthService.save(response);

        localStorage.setItem('loggedInID', response.id);

        const returnUrl = this.route.snapshot.queryParams.returnUrl;

        if (response['role'] === 4) {
          localStorage.setItem('role', 'patient');
          if (returnUrl){
            this.router.navigateByUrl(returnUrl);
          }
          else{
            var rt = '/records/' + response.docNumber;
            this.router.navigateByUrl(rt);
          }

        } else if (response['role'] === 5) {
          if (!response['IsApproved']) {
            localStorage.clear();
            localStorage.setItem('reason', 'not-approved');
            this.router.navigateByUrl('/no-access');
          } else if (response['IsFreezed']) {
            localStorage.clear();
            localStorage.setItem('reason', 'freezed');
            this.router.navigateByUrl('/no-access');
          } else if (returnUrl){
            this.router.navigateByUrl(returnUrl);
          }
          else {
            localStorage.setItem('role', 'lab');
            this.router.navigateByUrl('/records');
          }
        } else {
          localStorage.setItem('role', 'admin');

          if (response['role'] === 1) {
            this.router.navigateByUrl('/admin');
          } else {
            localStorage.setItem('role', 'medic');
            if (!response['IsApproved']) {
              localStorage.clear();
              localStorage.setItem('reason', 'not-approved');
              this.router.navigateByUrl('/no-access');
            } else if (response['IsFreezed']) {
              localStorage.clear();
              localStorage.setItem('reason', 'freezed');
              this.router.navigateByUrl('/no-access');
            } else if (returnUrl){
              this.router.navigateByUrl(returnUrl);
            }
            else {
              this.router.navigateByUrl('/records');
            }
          }
        }
      }
    });
  }
}
