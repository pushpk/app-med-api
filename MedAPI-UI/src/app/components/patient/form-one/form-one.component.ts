import { Component, Input, OnInit } from '@angular/core';
import { DateAdapter } from '@angular/material/core';
import { MyDateAdapter } from 'src/app/shared/directive/date-adapter';
import { PatientService } from '../service/patient.service';

@Component({
  selector: 'app-form-one',
  templateUrl: './form-one.component.html',
  styleUrls: ['./form-one.component.scss'],
  providers: [{provide: DateAdapter, useClass: MyDateAdapter}]
})
export class FormOneComponent implements OnInit {
  @Input() patient;
  @Input() isEditable: boolean;
  @Input() userRole: string;

  resources: any;

  constructor(private patientService: PatientService, private dateAdapter: DateAdapter<Date>,
    ) {
    this.dateAdapter.setLocale('en-GB');
  }

  ngOnInit(): void {
    this.patientService.resources.subscribe((o) => {
      this.resources = o;
    });
  }

  updateProvinces() {
    let resourcesPath: string =
      'department/' + this.patient.department + '/provinces';

    this.patientService
      .updateProvinces(resourcesPath)
      .then((response: any) => {
        // console.log(response, 'response');
        this.resources.provinces = response;
      })
      .catch((error) => {
        console.log(error);
      });
  }

  updateDistricts() {
    let resourcesPath: string =
      'province/' + this.patient.province + '/districts';

    this.patientService
      .updateDistricts(resourcesPath)
      .then((response: any) => {
        // console.log(response, 'response');
        this.resources.districts = response;
      })
      .catch((error) => {
        console.log(error);
      });
  }
}
