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
    this.labUser.user.roleId = 5;
  }

  ngOnInit(): void {
  }

  submitRequest(){
    console.log(this.labUser);
    this.patientService.createLab(this.labUser).then((response: any) => {
      console.log(response);
      
      this.toastr.success('Laboratorio registrado con éxito.');
      this.router.navigateByUrl('/login');
    }).catch((error) => {
      console.log(error);
      this.toastr.error('Se produjo un error al crear la cuenta.');
    });
  }

  numberOnly(ele : any) {
    var regex = /[^0-9]/gi;
    ele.value = ele.value.replace(regex, "");
 }

}
