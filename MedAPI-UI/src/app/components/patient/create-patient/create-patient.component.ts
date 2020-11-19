import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { PatientService } from '../service/patient.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router, NavigationStart } from '@angular/router';
import { CheckEmptyUtil } from '../../../shared/util/check-empty.util';
import { RecordService } from '../../record/services/record.service';
import { Patient } from '../../../models/patient.model';
import { Home } from '../../../models/home.model';
import { UserAuthService } from 'src/app/auth/user-auth.service';

@Component({
  selector: 'app-create-patient',
  templateUrl: './create-patient.component.html',
  styleUrls: ['./create-patient.component.scss']
})
export class CreatePatientComponent implements OnInit {
  tabs: Array<{ title: string; value: string; }>;
  index = new FormControl(0);
  patient: Patient = new Patient();
  isEditable: boolean;
  // patient = {
  //  id: 0,
  //  name: '',
  //  lastnameFather: '',
  //  lastnameMother: '',
  //  country: '',
  //  documentType: '',
  //  documentNumber: '',
  //  birthday: '',
  //  sex: '',
  //  maritalStatus: '',
  //  department: '',
  //  province: '',
  //  district: '',
  //  address: '',
  //  isDonor: false,
  //  email: '',
  //  phone: '',
  //  race: '',
  //  educationalAttainment: '',
  //  occupation: '',
  //  bloodType: '',
  //  alcoholConsumption: '',
  //  physicalActivity: '',
  //  fvConsumption: '',
  //  home: {
  //    rooms: '',
  //    population: '',
  //    type: '',
  //    ownership: '',
  //    material: '',
  //    electricity: false,
  //    water: false,
  //    sewage: false
  //  },
  //  allergies: [],
  //  otherAllergies: '',
  //  medicines: [],
  //  otherMedicines: '',
  //  personalBackground: [],
  //  otherPersonalBackground: '',
  //  fatherBackground: [],
  //  otherFatherBackground: '',
  //  motherBackground: [],
  //  otherMotherBackground: '',
  //  passwordHash: '',
  //  cigarettes: '',
  //  dormNumber: '',
  //  fractureNumber: '',
  //  createdTicket: '',
  //  highGlucose: ''
  // };
  docNumber: string;
  resources = null;
  submit = {
    waiting: false,
    success: false
  };
  constructor(public route: ActivatedRoute, public router: Router,
              private recordService: RecordService, private patientService: PatientService,
              public toastr: ToastrService, private authService: UserAuthService) {

    if (this.route.snapshot.queryParamMap.get('docNumber')){
      this.docNumber = this.route.snapshot.queryParamMap.get('docNumber');
    }
    // router.events.subscribe((val) => {
    //  if (val instanceof NavigationStart) {
    //    if (val.url.includes('patients/new')) {
    //      localStorage.setItem('patient', '');
    //    }
    //  }
    // });
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
    this.isEditable = (this.patient.userId > 0 && this.patient.userId === this.authService.getUserId()) ? true : false;

    this.tabs = [{
      title: 'Información General',
      value: 'form_1'
    }, {
      title: 'Información Adicional',
      value: 'form_2'
    }, {
      title: 'Antecedentes',
      value: 'form_3'
    }, {
      title: 'Información de Vivienda',
      value: 'form_4'
    }, {
      title: 'Resumen',
      value: 'form_5'
    }];

    this.getResources();

  }

  setPatientDetails(patientData) {
    if (CheckEmptyUtil.isNotEmpty(patientData)) {
      this.recordService.passwordHash.subscribe((val) => {
        this.patient.passwordHash = val;
      });
      const patientDetails = JSON.parse(patientData);
      // console.log(patientDetails, 'patientDetails');
      this.patient = patientDetails;
      // this.patient.id = patientDetails.id;
      // this.patient.userId = patientDetails.userId;
      // this.patient.name = patientDetails.user.firstName;
      // this.patient.lastnameFather = patientDetails.user.lastNameFather;
      // this.patient.lastnameMother = patientDetails.user.lastNameMother;
      // this.patient.country = patientDetails.user.countryId;
      // this.patient.documentType = patientDetails.user.documentType;
      // this.patient.documentNumber = patientDetails.user.documentNumber;
      // this.patient.birthday = patientDetails.user.birthday;
      // this.patient.sex = patientDetails.user.sex;
      // this.patient.maritalStatus = patientDetails.user.maritalStatus;
      // this.patient.maritalStatus = patientDetails.user.maritalStatus;
      // this.patient.province = patientDetails.user.district;
      // this.patient.district = patientDetails.user.districtId;
      // this.patient.address = patientDetails.user.address;
      // if (CheckEmptyUtil.isNotEmpty(patientDetails.user.organDonor)) {
      //   this.patient.isDonor = patientDetails.user.organDonor;
      // } else {
      //  this.patient.isDonor = false;
      // }
      // this.patient.email = patientDetails.user.email;
      // this.patient.phone = patientDetails.user.cellphone;

      // this.patient.educationalAttainment = patientDetails.educationalAttainment;
      // this.patient.occupation = patientDetails.occupation;
      // this.patient.bloodType = patientDetails.bloodType;
      // this.patient.alcoholConsumption = patientDetails.alcohol;
      // this.patient.physicalActivity = patientDetails.physicalActivity;
      // this.patient.fvConsumption = patientDetails.fruitsVegetables;
      // this.patient.cigarettes = patientDetails.cigaretteNumber;
      // this.patient.dormNumber = patientDetails.dormNumber;
      // this.patient.fractureNumber = patientDetails.fractureNumber;
      // this.patient.highGlucose = patientDetails.highGlucose;
      // this.patient.home.rooms = patientDetails.residentNumber;
      // this.patient.home.population = '';
      // this.patient.home.type = patientDetails.homeType;
      // this.patient.home.ownership = patientDetails.homeOwnership;
      // this.patient.home.material = patientDetails.homeMaterial;
      // this.patient.home.electricity = patientDetails.electricity;
      // this.patient.home.water = patientDetails.water;
      // this.patient.home.sewage = patientDetails.sewage;
      // this.patient.otherAllergies = patientDetails.otherAllergies;
      // this.patient.otherMedicines = patientDetails.otherMedicines;
      // this.patient.otherPersonalBackground = patientDetails.otherPersonalBackground;
      // this.patient.otherFatherBackground = patientDetails.otherFatherBackground;
      // this.patient.otherMotherBackground = patientDetails.otherMotherBackground;
      // this.patient.passwordHash = patientDetails.user.passwordHash;

    }
  }

  getResources() {
    let resourcesPath: string = 'users/resources';

    this.patientService.getResources(resourcesPath).then((response: any) => {
      this.patientService.resources.next(response);
    }).catch((error) => {
      console.log(error);
    });
  }

  submitRequest = function () {

    this.submit.waiting = true;
    let currentUserEmail = localStorage.getItem('email');
    this.patientService.save(this.patient, currentUserEmail).then((response: any) => {
      // console.log(response);
      this.submit.waiting = false;
      this.submit.success = true;
      this.toastr.success('Paciente afiliado correctamente.');
      this.router.navigateByUrl('/records');
    }).catch((error) => {
      console.log(error);
      this.submit.waiting = false;
      this.submit.success = false;
      this.toastr.error('Ocurrió un error al afiliar el paciente.');
    });
  }
}
