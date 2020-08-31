import { Component, OnInit } from '@angular/core';
import { Medic } from 'src/app/models/medic.model';
import { PatientService } from '../../patient/service/patient.service';
import {  MedicUser } from 'src/app/models/medicuser.model';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { MustMatchDirective } from 'src/app/shared/directive/mustMatch.directive';

@Component({
  selector: 'app-medic-registration',
  templateUrl: './medic-registration.component.html',
  styleUrls: ['./medic-registration.component.scss']
})
export class MedicRegistrationComponent implements OnInit {
  [x: string]: any;
  specialities : string[];

  medic: Medic = new Medic();
   
  constructor(public router: Router, private patientService: PatientService, public toastr: ToastrService) { 
    
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

    this.specialities = ["ALEGOLOGIA",
    "ANESTESIOLOGIA",
    "CARDIOLOGIA",
    "GASTROENTEROLOGIA",
    "ENDOCRINOLOGIA",
    "GERIATRIA",
    "HEMATOLOGIA",
    "HIDROLOGIA MEDICA",
    "INFECTOLOGIA",
    "MEDICINA AEROESPACIAL",
    "MEDICINA DEL DEPORTE",
    "MEDICINA DEL TRABAJO",
    "MEDICINA DE URGENCIAS",
    "MEDICINA FAMILIAR",
    "MEDICINA FISICA Y REHABILITACION",
    "MEDICINA INTENSIVA",
    "MEDICINA INTERNA",
    "MEDICINA LEGAL Y FORENSE",
    "MEDICINA PREVENTIVA",
    "NEFROLOGIA",
    "NEUMOLOGIA",
    "NEUROLOGIA",
    "NUTRIOLOGIA",
    "ODONTOLOGIA",
    "OFTALMOLOGIA",
    "ONCOLOGIA MEDICA",
    "ONCOLOGIA RADIOTERAPICA",
    "OTORRINOLARINGOLOGIA",
    "PEDIATRIA",
    "PROCTOLOGIA",
    "PSIQUIATRIA",
    "REHABILITACION",
    "REUMATOLOGIA",
    "TRAUMATOLOGIA",
    "TOXICOLOGIA",
    "UROLOGIA",
    "QUIRUGICAS",
    "CIRUGIA VASCULAR",
    "DERMATOLOGIA",
    "ESTOMATOLOGIA",
    "GINECOLOGIA Y OBSTETRICIA",
    "CIRUGIA CARDIOVASCULAR",
    "CIRUGIA GENERAL",
    "CIRUGIA ORAL Y MAXILOFACIAL",
    "CIRUGIA ORTOPEDICA Y TRAUMATOLOGIA",
    "CIRUGIA PEDIATRICA",
    "CIRUGIA PLASTICA",
    "CIRUGIA TORACICA",
    "NEUROCIRUGIA",
    "ANALISIS CLINICOS",
    "ANATOMIA PATOLOGICA",
    "BIOQUIMICA CLINICA",
    "FARMACOLOGIA CLINICA",
    "GENETICA MEDICA",
    "INMUNOLOGIA",
    "MEDICINA NUCLEAR",
    "MICROBIOLOGIA Y PARASITOLOGIA",
    "NEUROFISIOLOGIA CLINICA",
    "RADIOLOGIA"
    ];
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

  numberOnly(ele : any) {
   var regex = /[^0-9]/gi;
   ele.value = ele.value.replace(regex, "");
}

}
