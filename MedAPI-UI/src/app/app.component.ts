import { Component } from '@angular/core';
import { UserAuthService } from './auth/user-auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'MedAPI-UI';
  constructor(public userAuthService: UserAuthService) { }
}
