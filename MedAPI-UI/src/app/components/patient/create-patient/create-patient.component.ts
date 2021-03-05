import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserAuthService } from 'src/app/auth/user-auth.service';
import { Patient } from '../../../models/patient.model';
import { CheckEmptyUtil } from '../../../shared/util/check-empty.util';
import { RecordService } from '../../record/services/record.service';
import { PatientService } from '../service/patient.service';

@Component({
  selector: 'app-create-patient',
  templateUrl: './create-patient.component.html',
  styleUrls: ['./create-patient.component.scss'],
})
export class CreatePatientComponent implements OnInit {
  tabs: Array<{ title: string; value: string }>;
  index = new FormControl(0);
  patient: Patient = new Patient();
  isEditable: boolean;

  docNumber: string;
  resources = null;
  submit = {
    waiting: false,
    success: false,
  };
  constructor(
    public route: ActivatedRoute,
    public router: Router,
    private recordService: RecordService,
    private patientService: PatientService,
    public toastr: ToastrService,
    private authService: UserAuthService
  ) {
    if (this.route.snapshot.queryParamMap.get('docNumber')) {
      this.docNumber = this.route.snapshot.queryParamMap.get('docNumber');
    }
  }

  ngOnInit(): void {
    let patientId = this.route.snapshot.paramMap.get('id');

    if (CheckEmptyUtil.isNotEmpty(patientId)) {
      let patientData = localStorage.getItem('patient');
      this.setPatientDetails(patientData);
    }

    // this.isEditable = (this.patient.userId === 0 ||
    //   (this.patient.userId > 0 && this.patient.userId ===
    //     this.authService.getUserId())) ? true : false;
    this.isEditable =
      this.patient.userId > 0 &&
      this.patient.userId === this.authService.getUserId()
        ? true
        : false;

    this.tabs = [
      {
        title: 'Información General',
        value: 'form_1',
      },
      {
        title: 'Información Adicional',
        value: 'form_2',
      },
      {
        title: 'Antecedentes',
        value: 'form_3',
      },
      {
        title: 'Información de Vivienda',
        value: 'form_4',
      },
      {
        title: 'Resumen',
        value: 'form_5',
      },
    ];

    this.getResources();
  }

  setPatientDetails(patientData) {
    if (CheckEmptyUtil.isNotEmpty(patientData)) {
      this.recordService.passwordHash.subscribe((val) => {
        this.patient.passwordHash = val;
      });
      const patientDetails = JSON.parse(patientData);
      this.patient = patientDetails;
    }
  }

  getResources() {
    let resourcesPath: string = 'users/resources';

    this.patientService
      .getResources(resourcesPath)
      .then((response: any) => {
        this.patientService.resources.next(response);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  submitRequest = function () {
    this.submit.waiting = true;
    let currentUserEmail = localStorage.getItem('email');
    let currentUserId = localStorage.getItem('IoggedInID');

    console.log(this.patient);

    this.patient.IsEdit = true;
    this.patientService
      .save(this.patient, currentUserEmail)
      .then((response: any) => {
        // console.log(response);
        this.submit.waiting = false;
        this.submit.success = true;
        this.toastr.success('Paciente afiliado correctamente.');
        this.router.navigateByUrl('/records/' + this.docNumber);
      })
      .catch((error) => {
        console.log(error);
        this.submit.waiting = false;
        this.submit.success = false;
        this.toastr.error('Ocurrió un error al afiliar el paciente.');
      });
  };
}
