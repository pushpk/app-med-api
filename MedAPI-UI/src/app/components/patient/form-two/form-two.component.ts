import { Component, Input, OnInit } from '@angular/core';
import { PatientService } from '../service/patient.service';

@Component({
  selector: 'app-form-two',
  templateUrl: './form-two.component.html',
  styleUrls: ['./form-two.component.scss'],
})
export class FormTwoComponent implements OnInit {
  @Input() patient: any;
  @Input() isEditable: boolean;
  @Input() userRole: any;

  resources: any;

  constructor(private patientService: PatientService) {}

  ngOnInit(): void {
    this;
    this.patientService.resources.subscribe((o) => {
      this.resources = o;
    });
  }
}
