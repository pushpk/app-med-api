import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PatientService } from '../../patient/service/patient.service';

@Component({
  selector: 'app-account-confirmation',
  templateUrl: './account-confirmation.component.html',
  styleUrls: ['./account-confirmation.component.scss']
})
export class AccountConfirmationComponent implements OnInit {
  confirmSuccess: boolean = false;
  id:string = '';
  code:string = '';
  constructor( public router: Router,  private activatedRouter: ActivatedRoute, private patientService: PatientService, public toastr: ToastrService,) { }

  ngOnInit(): void {
   
    this.activatedRouter.queryParams.subscribe(params => {
      this.id = params['id'];
      this.code = params['code'];
  });

    console.log(this.id);
    console.log(this.code);

    //call service to confirm account

    this.patientService.confirmEmail(this.id,this.code).then((response: any) => {

      this.confirmSuccess = true;
      
    }).catch((error: any) => {
      console.log(error);
      this.confirmSuccess = false;
   });

  }


}
