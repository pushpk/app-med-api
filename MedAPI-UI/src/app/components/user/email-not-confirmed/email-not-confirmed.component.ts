import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PatientService } from '../../patient/service/patient.service';

@Component({
  selector: 'app-email-not-confirmed',
  templateUrl: './email-not-confirmed.component.html',
  styleUrls: ['./email-not-confirmed.component.scss'],
})
export class EmailNotConfirmedComponent implements OnInit {
  email: any;
  sendConfirmationEmail: boolean;

  constructor(
    public router: Router,
    private activatedRouter: ActivatedRoute,
    private patientService: PatientService,
    public toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.activatedRouter.queryParams.subscribe((params) => {
      this.email = params['email'];
    });
  }

  sendConfirmation() {
    this.patientService
      .sendConfirmation(this.email)
      .then((response: any) => {
        this.sendConfirmationEmail = true;
      })
      .catch((error: any) => {});
  }
}
