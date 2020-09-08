import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PatientService } from '../../patient/service/patient.service';
import { ToastrService } from 'ngx-toastr';
import { MedicUser } from 'src/app/models/medicuser.model';
import { Medic } from 'src/app/models/medic.model';

@Component({
  selector: 'app-patient-registration',
  templateUrl: './patient-registration.component.html',
  styleUrls: ['./patient-registration.component.scss']
})
export class PatientRegistrationComponent implements OnInit {
  resources: any;
  medic: Medic = new Medic();

  constructor(public router: Router, private patientService: PatientService, public toastr: ToastrService) {
    this.medic.user = new MedicUser();
    this.medic.user.roleId = 4;
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

}
