import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PatientService } from '../../patient/service/patient.service';
import { User } from '../model/user.model';

@Component({
  selector: 'app-account-confirmation',
  templateUrl: './account-confirmation.component.html',
  styleUrls: ['./account-confirmation.component.scss'],
})
export class AccountConfirmationComponent implements OnInit {
  confirmSuccess: boolean;
  id: string = '';
  code: string = '';
  showMedic: boolean = false;
  constructor(
    public router: Router,
    private activatedRouter: ActivatedRoute,
    private patientService: PatientService,
    public toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.activatedRouter.queryParams.subscribe((params) => {
      this.id = params['id'];
      this.code = params['code'];
    });

    console.log(this.id);
    console.log(this.code);

    //call service to confirm account

    this.patientService
      .confirmEmail(this.id, encodeURIComponent(this.code))
      .then((response: User) => {
        this.confirmSuccess = true;
        console.log(response.role);
        if (response.role === 2) {
          this.showMedic = true;
        } else {
          this.showMedic = false;
        }
      })
      .catch((error: any) => {
        console.log(error);
        this.confirmSuccess = false;
      });
  }
}
