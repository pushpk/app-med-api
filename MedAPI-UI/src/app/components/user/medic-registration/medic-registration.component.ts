import { Component, OnInit } from '@angular/core';
import { Medic } from 'src/app/models/medic.model';
import { PatientService } from '../../patient/service/patient.service';
import {  MedicUser } from 'src/app/models/medicuser.model';

@Component({
  selector: 'app-medic-registration',
  templateUrl: './medic-registration.component.html',
  styleUrls: ['./medic-registration.component.scss']
})
export class MedicRegistrationComponent implements OnInit {
  [x: string]: any;

  medic: Medic = new Medic();
  
  constructor(private patientService: PatientService) { 
    
    this.medic.user = new MedicUser();
    this.medic.user.roleId = 2;

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
    console.log(this.medic);
    this.patientService.createMedic(this.medic).then((response: any) => {
      console.log(response);
      
      this.toastr.success('Médica registrada con éxito.');
      this.router.navigateByUrl('/login');
    }).catch((error) => {
      console.log(error);
      
      this.toastr.error('Se produjo un error al crear medic.');
    });
    
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
