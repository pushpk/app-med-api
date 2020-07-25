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
      console.log(this.resources, 'this.resources');
      this.filteredAllergies = this.allergiesCtrl.valueChanges.pipe(
        delay(1000),
        startWith(null),
        map((data: string | null) => data ? this._filterAllergies(data) : this.resources.allergies));

      this.filteredMedicines = this.medicineCtrl.valueChanges.pipe(
        delay(1000),
        startWith(null),
        map((data: string | null) => data ? this._filterMedicines(data) : this.resources.medicines));

      this.filteredPersonalBackgrounds = this.personalBackgroundCtrl.valueChanges.pipe(
        delay(1000),
        startWith(null),
        map((data: string | null) => data ? this._filterBackgrounds(data) : this.resources.backgrounds));

      this.filteredFatherBackgrounds = this.fatherBackgroundCtrl.valueChanges.pipe(
        delay(1000),
        startWith(null),
        map((data: string | null) => data ? this._filterBackgrounds(data) : this.resources.backgrounds));

      this.filteredMotherBackgrounds = this.motherBackgroundCtrl.valueChanges.pipe(
        delay(1000),
        startWith(null),
        map((data: string | null) => data ? this._filterBackgrounds(data) : this.resources.backgrounds));
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

  removeAllergie(o: string): void {
    const index = this.patient.allergies.indexOf(o);

    if (index >= 0) {
      this.patient.allergies.splice(index, 1);
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

  removeMedicine(o: string): void {
    const index = this.patient.medicines.indexOf(o);

    if (index >= 0) {
      this.patient.medicines.splice(index, 1);
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

  removePersonalBackground(o: string): void {
    const index = this.patient.personalBackground.indexOf(o);

    if (index >= 0) {
      this.patient.personalBackground.splice(index, 1);
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

    this.personalBackgroundCtrl.setValue(null);
  }

  removeFatherBackground(o: string): void {
    const index = this.patient.fatherBackground.indexOf(o);

    if (index >= 0) {
      this.patient.fatherBackground.splice(index, 1);
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

    this.personalBackgroundCtrl.setValue(null);
  }

  removeMotherBackground(o: string): void {
    const index = this.patient.motherBackground.indexOf(o);

    if (index >= 0) {
      this.patient.motherBackground.splice(index, 1);
    }
  }

  selectedAllergie(event: MatAutocompleteSelectedEvent): void {
    if (this.patient.allergies.indexOf(event.option.value) === -1) {
      this.patient.allergies.push(event.option.value);
    }
    this.allergieInput.nativeElement.value = '';
    this.allergiesCtrl.setValue(null);
  }

  selectedMedicine(event: MatAutocompleteSelectedEvent): void {
    if (this.patient.medicines.indexOf(event.option.value) === -1) {
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
    if (this.patient.allergies.indexOf(a) === -1) {
      this.patient.allergies.push(a);
    }
  }

  addMedicineSymptoms(a) {
    if (this.patient.medicines.indexOf(a) === -1) {
      this.patient.medicines.push(a);
    }
  }

  addPersonalBackgroundSymptoms(a) {
    if (this.patient.personalBackground.indexOf(a) === -1) {
      this.patient.personalBackground.push(a);
    }
  }

  addFatherBackgroundSymptoms(a) {
    if (this.patient.fatherBackground.indexOf(a) === -1) {
      this.patient.fatherBackground.push(a);
    }
  }

  addMotherBackgroundSymptoms(a) {
    if (this.patient.motherBackground.indexOf(a) === -1) {
      this.patient.motherBackground.push(a);
    }
  }

}
