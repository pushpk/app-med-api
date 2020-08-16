import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { PatientService } from '../service/patient.service';
import { MatChipInputEvent } from '@angular/material/chips';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { MatAutocomplete, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { map, startWith, delay } from 'rxjs/operators';

@Component({
  selector: 'app-form-three',
  templateUrl: './form-three.component.html',
  styleUrls: ['./form-three.component.scss']
})
export class FormThreeComponent implements OnInit {
  @Input() patient: any;
  resources: any;
  public selectable = true;
  public removable = true;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  allergiesCtrl = new FormControl();
  medicineCtrl = new FormControl();
  personalBackgroundCtrl = new FormControl();
  fatherBackgroundCtrl = new FormControl();
  motherBackgroundCtrl = new FormControl();
  filteredAllergies: Observable<string[]>;
  filteredMedicines: Observable<string[]>;
  filteredPersonalBackgrounds: Observable<string[]>;
  filteredFatherBackgrounds: Observable<string[]>;
  filteredMotherBackgrounds: Observable<string[]>;

  selectedAllergies = [];
  selectedMedicines = [];
  selectedFatherBackgrounds = [];
  selectedMotherBackgrounds = [];
  selectedPersonalBackgrounds = [];

  @ViewChild('allergieInput') allergieInput: ElementRef<HTMLInputElement>;
  @ViewChild('medicineInput') medicineInput: ElementRef<HTMLInputElement>;
  @ViewChild('personalBackgroundInput') personalBackgroundInput: ElementRef<HTMLInputElement>;
  @ViewChild('fatherBackgroundInput') fatherBackgroundInput: ElementRef<HTMLInputElement>;
  @ViewChild('motherBackgroundInput') motherBackgroundInput: ElementRef<HTMLInputElement>;
  @ViewChild('auto') matAutocomplete: MatAutocomplete;

  constructor(private patientService: PatientService) { }

  ngOnInit(): void {
    this.patientService.resources.subscribe((o) => {
      this.resources = o;
      this.filteredAllergies = this.allergiesCtrl.valueChanges.pipe(
        delay(1000),
        startWith(null),
        map((data: string | null) => data ? this._filterAllergies(data) : this.resources.allergies));

      this.selectedAllergies = this.patient.allergies.filter(x => !x.isDeleted);

      this.filteredMedicines = this.medicineCtrl.valueChanges.pipe(
        delay(1000),
        startWith(null),
        map((data: string | null) => data ? this._filterMedicines(data) : this.resources.medicines));
      this.selectedMedicines = this.patient.medicines.filter(x => !x.isDeleted);

      this.filteredPersonalBackgrounds = this.personalBackgroundCtrl.valueChanges.pipe(
        delay(1000),
        startWith(null),
        map((data: string | null) => data ? this._filterBackgrounds(data) : this.resources.backgrounds));
      this.selectedPersonalBackgrounds = this.patient.personalBackground.filter(x => !x.isDeleted);

      this.filteredFatherBackgrounds = this.fatherBackgroundCtrl.valueChanges.pipe(
        delay(1000),
        startWith(null),
        map((data: string | null) => data ? this._filterBackgrounds(data) : this.resources.backgrounds));
      this.selectedFatherBackgrounds = this.patient.fatherBackground.filter(x => !x.isDeleted);

      this.filteredMotherBackgrounds = this.motherBackgroundCtrl.valueChanges.pipe(
        delay(1000),
        startWith(null),
        map((data: string | null) => data ? this._filterBackgrounds(data) : this.resources.backgrounds));
      this.selectedMotherBackgrounds = this.patient.motherBackground.filter(x => !x.isDeleted);
    });
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

  removeAllergie(o: any): void {
    const index = this.patient.allergies.indexOf(o);

    if (index >= 0) {
      o.isDeleted = true;
      this.patient.allergies.map(obj => (o.id === obj.id) || obj);
      this.selectedAllergies = this.patient.allergies.filter(x => !x.isDeleted);
      //this.patient.allergies.splice(index, 1);
    }
  }

  addMedicine(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    if ((value || '').trim()) {
      this.patient.medicines.push(event);
    }

    if (input) {
      input.value = '';
    }

    this.medicineCtrl.setValue(null);
  }

  removeMedicine(o): void {
    const index = this.patient.medicines.indexOf(o);

    if (index >= 0) {
      o.isDeleted = true;
      this.patient.medicines.map(obj => (o.id === obj.id) || obj);
      this.selectedMedicines = this.patient.medicines.filter(x => !x.isDeleted);      
      //this.patient.medicines.splice(index, 1);
    }
  }

  addPersonalBackground(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    if ((value || '').trim()) {
      this.patient.personalBackground.push(event);
    }

    if (input) {
      input.value = '';
    }

    this.personalBackgroundCtrl.setValue(null);
  }

  removePersonalBackground(o): void {
    const index = this.patient.personalBackground.indexOf(o);

    if (index >= 0) {
      o.isDeleted = true;
      this.patient.personalBackground.map(obj => (o.id === obj.id) || obj);
      this.selectedPersonalBackgrounds = this.patient.personalBackground.filter(x => !x.isDeleted);
      //this.patient.personalBackground.splice(index, 1);
    }
  }

  addFatherBackground(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    if ((value || '').trim()) {
      this.patient.fatherBackground.push(event);
    }

    if (input) {
      input.value = '';
    }

    this.fatherBackgroundCtrl.setValue(null);
  }

  removeFatherBackground(o): void {
    const index = this.patient.fatherBackground.indexOf(o);

    if (index >= 0) {
      o.isDeleted = true;
      this.patient.fatherBackground.map(obj => (o.id === obj.id) || obj);
      this.selectedFatherBackgrounds = this.patient.fatherBackground.filter(x => !x.isDeleted);
      // this.patient.fatherBackground.splice(index, 1);
    }
  }

  addMotherBackground(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    if ((value || '').trim()) {
      this.patient.motherBackground.push(event);
    }

    if (input) {
      input.value = '';
    }

    this.motherBackgroundCtrl.setValue(null);
  }

  removeMotherBackground(o): void {
    const index = this.patient.motherBackground.indexOf(o);
    if (index >= 0) {
      o.isDeleted = true;
      this.patient.motherBackground.map(obj => (o.id === obj.id) || obj);
      this.selectedMotherBackgrounds = this.patient.motherBackground.filter(x => !x.isDeleted);
      // this.patient.motherBackground.splice(index, 1);
    }
  }

  selectedAllergie(event: MatAutocompleteSelectedEvent): void {
    if (this.patient.allergies.indexOf(event.option.value) === -1 && !this.patient.allergies.isDeleted) {
      this.patient.allergies.push(event.option.value);
    }
    this.allergieInput.nativeElement.value = '';
    this.allergiesCtrl.setValue(null);
  }

  selectedMedicine(event: MatAutocompleteSelectedEvent): void {
    if (this.patient.medicines.indexOf(event.option.value) === -1 && !this.patient.allergies.isDeleted) {
      this.patient.medicines.push(event.option.value);
    }
    this.medicineInput.nativeElement.value = '';
    this.medicineCtrl.setValue(null);
  }

  selectedPersonalBackground(event: MatAutocompleteSelectedEvent) {
    if (this.patient.personalBackground.indexOf(event.option.value) === -1) {
      this.patient.personalBackground.push(event.option.value);
    }
    this.personalBackgroundInput.nativeElement.value = '';
    this.personalBackgroundCtrl.setValue(null);
  }

  selectedFatherBackground(event: MatAutocompleteSelectedEvent) {
    if (this.patient.fatherBackground.indexOf(event.option.value) === -1) {
      this.patient.fatherBackground.push(event.option.value);
    }
    this.fatherBackgroundInput.nativeElement.value = '';
    this.fatherBackgroundCtrl.setValue(null);
  }

  selectedMotherBackground(event: MatAutocompleteSelectedEvent) {
    if (this.patient.motherBackground.indexOf(event.option.value) === -1) {
      this.patient.motherBackground.push(event.option.value);
    }
    this.motherBackgroundInput.nativeElement.value = '';
    this.motherBackgroundCtrl.setValue(null);
  }

  _filterAllergies(value: any): string[] {
    const filterValue = value.name.toLowerCase();
    return this.resources.allergies.filter(x => x.name.toLowerCase().indexOf(filterValue) === 0);
  }
  _filterMedicines(value: any): string[] {
    const filterValue = value.name.toLowerCase();
    return this.resources.medicines.filter(x => x.name.toLowerCase().indexOf(filterValue) === 0);
  }
  _filterBackgrounds(value: any): string[] {
    const filterValue = value.name.toLowerCase();
    return this.resources.backgrounds.filter(x => x.name.toLowerCase().indexOf(filterValue) === 0);
  }

  addAllergieSymptoms(a) {
    if (this.patient.allergies.indexOf(a) === -1 && !this.patient.allergies.isDeleted) {
      let patients = this.patient.allergies.filter(x => !x.isDeleted && x.name === a.name);
      if (patients.length === 0) {
        let allergie = {
          id: this.patient.allergies.id ? 0 : this.patient.allergies.id,
          patientId: this.patient.id,
          name: a.name,
          isDeleted: false
        }
        this.patient.allergies.push(allergie);
        this.selectedAllergies = this.patient.allergies.filter(x => !x.isDeleted);
      }
    }
  }

  addMedicineSymptoms(a) {
    if (this.patient.medicines.indexOf(a) === -1 && !this.patient.medicines.isDeleted) {
      let patients = this.patient.medicines.filter(x => !x.isDeleted && x.name === a.name);
      if (patients.length === 0) {
        let medicine = {
          id: this.patient.medicines.id ? 0 : this.patient.medicines.id,
          patientId: this.patient.id,
          name: a.name,
          isDeleted: false
        }

        this.patient.medicines.push(medicine);
        this.selectedMedicines = this.patient.medicines.filter(x => !x.isDeleted);
      }
    }
  }

  addPersonalBackgroundSymptoms(a) {
    if (this.patient.personalBackground.indexOf(a) === -1 && !this.patient.personalBackground.isDeleted) {
      let patients = this.patient.personalBackground.filter(x => !x.isDeleted && x.name === a.name);
      if (patients.length === 0) {
        let pBackground = {
          id: this.patient.personalBackground.id ? 0 : this.patient.personalBackground.id,
          patientId: this.patient.id,
          name: a.name,
          isDeleted: false
        }
        this.patient.personalBackground.push(pBackground);
        this.selectedPersonalBackgrounds = this.patient.personalBackground.filter(x => !x.isDeleted);
      }
    }
  }

  addFatherBackgroundSymptoms(a) {
    if (this.patient.fatherBackground.indexOf(a) === -1 && !this.patient.fatherBackground.isDeleted) {
      let patients = this.patient.fatherBackground.filter(x => !x.isDeleted && x.name === a.name);
      if (patients.length === 0) {
        let fBackground = {
          id: this.patient.fatherBackground.id ? 0 : this.patient.fatherBackground.id,
          patientId: this.patient.id,
          name: a.name
        }
        this.patient.fatherBackground.push(fBackground);
        this.selectedFatherBackgrounds = this.patient.fatherBackground.filter(x => !x.isDeleted);
      }
    }
  }

  addMotherBackgroundSymptoms(a) {
    if (this.patient.motherBackground.indexOf(a) === -1 && !this.patient.motherBackground.isDeleted) {
      let patients = this.patient.motherBackground.filter(x => !x.isDeleted && x.name === a.name);
      if (patients.length === 0) {
        let mBackground = {
          id: this.patient.motherBackground.id ? 0 : this.patient.motherBackground.id,
          patientId: this.patient.id,
          name: a.name,
          isDeleted: false
        }
        this.patient.motherBackground.push(mBackground);
        this.selectedMotherBackgrounds = this.patient.motherBackground.filter(x => !x.isDeleted);
      }
    }
  }

}
