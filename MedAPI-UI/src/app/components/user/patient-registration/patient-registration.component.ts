import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatChipInputEvent } from '@angular/material/chips';
import { DateAdapter } from '@angular/material/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Patient } from 'src/app/models/patient.model';
import { MyDateAdapter } from 'src/app/shared/directive/date-adapter';
import { DialogTermsAndConditionsComponent } from 'src/app/shared/termsAndConditions/dialog-terms-and-conditions.component';
import { PatientService } from '../../patient/service/patient.service';

@Component({
  selector: 'app-patient-registration',
  templateUrl: './patient-registration.component.html',
  styleUrls: ['./patient-registration.component.scss'],
  providers: [{ provide: DateAdapter, useClass: MyDateAdapter }],
})
export class PatientRegistrationComponent implements OnInit {
  resources: any;
  public selectable = true;
  public removable = true;
  patient: Patient = new Patient();
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  allergiesCtrl = new FormControl();
  medicineCtrl = new FormControl();
  personalBackgroundCtrl = new FormControl();
  filteredAllergies: Observable<string[]>;
  filteredMedicines: Observable<string[]>;
  filteredPersonalBackgrounds: Observable<string[]>;
  acceptTermsAndConditions = false;
  showRequiredError = false;
  today = new Date();

  selectedAllergies = [];
  selectedMedicines = [];
  selectedPersonalBackgrounds = [];

  @ViewChild('allergieInput') allergieInput: ElementRef<HTMLInputElement>;
  @ViewChild('medicineInput') medicineInput: ElementRef<HTMLInputElement>;
  @ViewChild('personalBackgroundInput')
  personalBackgroundInput: ElementRef<HTMLInputElement>;

  constructor(
    public router: Router,
    private patientService: PatientService,
    public toastr: ToastrService,
    private dateAdapter: DateAdapter<Date>,
    public dialog: MatDialog
  ) {
    this.dateAdapter.setLocale('en-GB');
    this.patient.roleId = 4;
  }

  ngOnInit(): void {
    let resourcesPath: string = 'users/resources';

    this.patientService
      .getResources(resourcesPath)
      .then((response: any) => {
        this.patientService.resources.next(response);
      })
      .catch((error) => {
        console.log(error);
      });

    this.patientService.resources.subscribe((o) => {
      this.resources = o;
    });

    this.selectedAllergies = this.patient.allergies.filter((x) => !x.isDeleted);
  }

  submitRequest() {
    // this.submit.waiting = true;
    let currentUserEmail = localStorage.getItem('email');

    this.patientService
      .registerPatient(this.patient)
      .then((response: any) => {
        console.log(response);
        // this.submit.waiting = false;
        // this.submit.success = true;
        this.toastr.success('Paciente afiliado correctamente.');
        this.router.navigateByUrl('/login');
      })
      .catch((error) => {
        console.log(error);
        // this.submit.waiting = false;
        // this.submit.success = false;
        if (error.status === 409) {
          this.toastr.error(
            'Ya existe un usuario con el mismo correo electrónico o número de documento en el sistema.'
          );
        } else {
          this.toastr.error('Ocurrió un error al afiliar el paciente.');
        }
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

  selectedAllergie(event: MatAutocompleteSelectedEvent): void {
    if (this.patient.allergies.indexOf(event.option.value) === -1) {
      this.patient.allergies.push(event.option.value);
    }
    this.allergieInput.nativeElement.value = '';
    this.allergiesCtrl.setValue(null);
  }

  addAllergieSymptoms(a) {
    if (
      this.patient.allergies.indexOf(a) === -1 &&
      !this.patient.allergies['isDeleted']
    ) {
      let patients = this.patient.allergies.filter(
        (x) => !x.isDeleted && x.name === a.name
      );
      if (patients.length === 0) {
        let allergie = {
          id: this.patient.allergies['id'] ? 0 : this.patient.allergies['id'],
          patientId: this.patient.id,
          name: a.name,
          isDeleted: false,
        };
        this.patient.allergies.push(allergie);
        this.selectedAllergies = this.patient.allergies.filter(
          (x) => !x.isDeleted
        );
      }
    }
  }

  removeAllergie(o: any): void {
    const index = this.patient.allergies.indexOf(o);

    if (index >= 0) {
      o.isDeleted = true;
      this.patient.allergies.map((obj) => o.id === obj.id || obj);
      this.selectedAllergies = this.patient.allergies.filter(
        (x) => !x.isDeleted
      );
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
      this.patient.medicines.map((obj) => o.id === obj.id || obj);
      this.selectedMedicines = this.patient.medicines.filter(
        (x) => !x.isDeleted
      );
      //this.patient.medicines.splice(index, 1);
    }
  }

  selectedMedicine(event: MatAutocompleteSelectedEvent): void {
    if (
      this.patient.medicines.indexOf(event.option.value) === -1 &&
      !this.patient.allergies['isDeleted']
    ) {
      this.patient.medicines.push(event.option.value);
    }
    this.medicineInput.nativeElement.value = '';
    this.medicineCtrl.setValue(null);
  }

  _filterMedicines(value: any): string[] {
    const filterValue = value.name.toLowerCase();
    return this.resources.medicines.filter(
      (x) => x.name.toLowerCase().indexOf(filterValue) === 0
    );
  }

  //Personal History
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
      this.patient.personalBackground.map((obj) => o.id === obj.id || obj);
      this.selectedPersonalBackgrounds = this.patient.personalBackground.filter(
        (x) => !x.isDeleted
      );
      //this.patient.personalBackground.splice(index, 1);
    }
  }

  selectedPersonalBackground(event: MatAutocompleteSelectedEvent) {
    if (this.patient.personalBackground.indexOf(event.option.value) === -1) {
      this.patient.personalBackground.push(event.option.value);
    }
    this.personalBackgroundInput.nativeElement.value = '';
    this.personalBackgroundCtrl.setValue(null);
  }

  _filterBackgrounds(value: any): string[] {
    const filterValue = value.name.toLowerCase();
    return this.resources.backgrounds.filter(
      (x) => x.name.toLowerCase().indexOf(filterValue) === 0
    );
  }

  addPersonalBackgroundSymptoms(a) {
    if (
      this.patient.personalBackground.indexOf(a) === -1 &&
      !this.patient.personalBackground['isDeleted']
    ) {
      let patients = this.patient.personalBackground.filter(
        (x) => !x.isDeleted && x.name === a.name
      );
      if (patients.length === 0) {
        let pBackground = {
          id: this.patient.personalBackground['id']
            ? 0
            : this.patient.personalBackground['id'],
          patientId: this.patient.id,
          name: a.name,
          isDeleted: false,
        };
        this.patient.personalBackground.push(pBackground);
        this.selectedPersonalBackgrounds =
          this.patient.personalBackground.filter((x) => !x.isDeleted);
      }
    }
  }

  addMedicineSymptoms(a) {
    if (
      this.patient.medicines.indexOf(a) === -1 &&
      !this.patient.medicines['isDeleted']
    ) {
      let patients = this.patient.medicines.filter(
        (x) => !x.isDeleted && x.name === a.name
      );
      if (patients.length === 0) {
        let medicine = {
          id: this.patient.medicines['id'] ? 0 : this.patient.medicines['id'],
          patientId: this.patient.id,
          name: a.name,
          isDeleted: false,
        };

        this.patient.medicines.push(medicine);
        this.selectedMedicines = this.patient.medicines.filter(
          (x) => !x.isDeleted
        );
      }
    }
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

  openTermsAndConditions() {
    let dialogRef = this.dialog.open(DialogTermsAndConditionsComponent, {
      panelClass: 'custom-dialog',
      data: {},
      autoFocus: false,
      maxHeight: '90vh',
      maxWidth: '120vw',
    });
    dialogRef.afterClosed().subscribe((response: any) => {
      // console.log(response);
      if (response == undefined) {
        this.acceptTermsAndConditions = false;
        this.showRequiredError = true;
      } else if (response.accept == true) {
        this.acceptTermsAndConditions = true;
        this.showRequiredError = false;
      } else {
        this.acceptTermsAndConditions = false;
        this.showRequiredError = true;
      }
    });
  }
}
