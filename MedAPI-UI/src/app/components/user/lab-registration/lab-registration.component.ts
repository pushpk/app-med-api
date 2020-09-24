import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LabUser } from 'src/app/models/labUser.model';
import { MedicUser } from 'src/app/models/medicuser.model';
import { PatientService } from '../../patient/service/patient.service';

@Component({
  selector: 'app-lab-registration',
  templateUrl: './lab-registration.component.html',
  styleUrls: ['./lab-registration.component.scss']
})
export class LabRegistrationComponent implements OnInit {

  labUser: LabUser = new LabUser();

  constructor(public router: Router, private patientService: PatientService, public toastr: ToastrService) { 
    this.labUser.user = new MedicUser();
    this.labUser.user.roleId = 2;
  }

  ngOnInit(): void {
  }

  submitRequest(){

  }

}
