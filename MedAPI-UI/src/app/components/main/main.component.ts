import { Component, OnInit } from '@angular/core';
import { CommonService } from '../../services/common.service';
import { UserAuthService } from '../../auth/user-auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  isUserPatient: boolean;

  constructor(public router: Router, public commonService: CommonService, public userAuthService: UserAuthService) {
    if (this.router.url === '/') {
      this.router.navigateByUrl('/records');
    }
  }

  ngOnInit(): void {
  }

  onActivate(event) {
    document.body.scrollTop = 0;
  }
}
