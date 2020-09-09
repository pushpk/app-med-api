import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { PatientService } from '../../patient/service/patient.service';
import { ToastrService } from 'ngx-toastr';
import { MedicUser } from 'src/app/models/medicuser.model';
import { Medic } from 'src/app/models/medic.model';
import { Patient } from 'src/app/models/patient.model';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { MatChipInputEvent } from '@angular/material/chips';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';

@Component({
  selector: 'app-patient-registration',
  templateUrl: './patient-registration.component.html',
  styleUrls: ['./patient-registration.component.scss']
})
export class PatientRegistrationComponent implements OnInit {
  resources: any;
  public selectable = true;
  public removable = true;
  patient: Patient = new Patient();
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  allergiesCtrl = new FormControl();
  filteredAllergies: Observable<string[]>;
  filteredMedicines: Observable<string[]>;
  filteredPersonalBackgrounds: Observable<string[]>;

  selectedAllergies = [];
  selectedMedicines = [];
  selectedPersonalBackgrounds = [];

  @ViewChild('allergieInput') allergieInput: ElementRef<HTMLInputElement>;


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

    this.selectedAllergies = this.patient.allergies.filter(x => !x.isDeleted);
  }

  submitRequest(){

  }

  addAllergie(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    if ((value || '').trim()) {
      this.patient.allergies.push(event);
    }

    if (input) {
      input.value = '';
    }

    this.allergiesCtrl.setValue(null);
  }

  selectedAllergie(event: MatAutocompleteSelectedEvent): void {
    if (this.patient.allergies.indexOf(event.option.value) === -1) {
      this.patient.allergies.push(event.option.value);
    }
    this.allergieInput.nativeElement.value = '';
    this.allergiesCtrl.setValue(null);
  }

  addAllergieSymptoms(a) {
    if (this.patient.allergies.indexOf(a) === -1 && !this.patient.allergies['isDeleted']) {
      let patients = this.patient.allergies.filter(x => !x.isDeleted && x.name === a.name);
      if (patients.length === 0) {
        let allergie = {
          id: this.patient.allergies['id'] ? 0 : this.patient.allergies['id'],
          patientId: this.patient.id,
          name: a.name,
          isDeleted: false
        }
        this.patient.allergies.push(allergie);
        this.selectedAllergies = this.patient.allergies.filter(x => !x.isDeleted);
      }
    }
  }

  removeAllergie(o: any): void {
    const index = this.patient.allergies.indexOf(o);

    if (index >= 0) {
      o.isDeleted = true;
      this.patient.allergies.map(obj => (o.id === obj.id) || obj);
      this.selectedAllergies = this.patient.allergies.filter(x => !x.isDeleted);
      //this.patient.allergies.splice(index, 1);
    }
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
