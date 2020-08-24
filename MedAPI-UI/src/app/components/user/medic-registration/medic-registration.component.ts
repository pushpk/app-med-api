import { Component, OnInit } from '@angular/core';
import { Medic } from 'src/app/models/medic.model';

@Component({
  selector: 'app-medic-registration',
  templateUrl: './medic-registration.component.html',
  styleUrls: ['./medic-registration.component.scss']
})
export class MedicRegistrationComponent implements OnInit {

  medic: Medic = new Medic();
  constructor() { }

  ngOnInit(): void {
  }

}
