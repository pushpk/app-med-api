import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PatientService } from '../../patient/service/patient.service';
import { ToastrService } from 'ngx-toastr';
import { MedicUser } from 'src/app/models/medicuser.model';
import { Medic } from 'src/app/models/medic.model';
import { Patient } from 'src/app/models/patient.model';

@Component({
  selector: 'app-patient-registration',
  templateUrl: './patient-registration.component.html',
  styleUrls: ['./patient-registration.component.scss']
})
export class PatientRegistrationComponent implements OnInit {
  resources: any;
  patient: Patient = new Patient();

  constructor(public router: Router, private patientService: PatientService, public toastr: ToastrService) {
   
    this.patient.roleId = 4;
   }

  ngOnInit(): void {
    let resourcesPath: string = 'users/resources';

    this.patientService.getResources(resourcesPath).then((response: any) => {
      this.patientService.resources.next(response);
    }).catch((error) => {
      console.log(error);
    });

    this.patientService.resources.subscribe((o) => {
      this.resources = o;
    });
  }

  submitRequest(){
    
  }
  updateProvinces() {
    let resourcesPath: string = 'department/' + this.patient.department + '/provinces';

    this.patientService.updateProvinces(resourcesPath).then((response: any) => {
      console.log(response, 'response');
      this.resources.provinces = response;
    }).catch((error) => {
      console.log(error);
    });
  }

  updateDistricts() {
    let resourcesPath: string = 'province/' + this.patient.province + '/districts';

    this.patientService.updateDistricts(resourcesPath).then((response: any) => {
      console.log(response, 'response');
      this.resources.districts = response;
    }).catch((error) => {
      console.log(error);
    });
  }

}
