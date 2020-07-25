import { Component, OnInit, Input } from '@angular/core';
import { PatientService } from '../service/patient.service';

@Component({
  selector: 'app-form-four',
  templateUrl: './form-four.component.html',
  styleUrls: ['./form-four.component.scss']
})
export class FormFourComponent implements OnInit {
  @Input() patient: any;
  resources: any;

  constructor(private patientService: PatientService) { }

  ngOnInit(): void {
    console.log(this.patient, 'patient');
    this.patientService.resources.subscribe((o) => {
      this.resources = o;
    });
  }

}
