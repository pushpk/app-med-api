import { Component, OnInit } from '@angular/core';
import { NoteService } from './services/note.service';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RecordService } from '../record/services/record.service';
import { CheckEmptyUtil } from '../../shared/util/check-empty.util';
import {
  CardiovascularFraminghamIndicator, CardiovascularRiskReynoldsIndicator,
  HypertensionIndicator, DiabetesIndicator,
  FractureIndicator, CardiovascularAgeIndicator
} from './indicators/indicators';
import { MatDialog } from '@angular/material/dialog';
import { DialogDiagnosisComponent } from './dialog-diagnosis/dialog-diagnosis.component';
import { ResourcesService } from '../../services/resources.service';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {
  patient: any;
  note: any;
  notes: any;
  selectedExam: any;
  searchExam: string;

  selectedTreatment: any;
  searchTreatment: string;

  selectedSpecialty: any;
  searchSpecialty: string;
  speciality = '';
  index = new FormControl(0);
  submit = {
    waiting: false,
    success: false
  };

  tabs: Array<{ title: string; }>;

  constructor(private noteService: NoteService,
    public route: ActivatedRoute,
    public router: Router,
    private recordService: RecordService,
    public dialog: MatDialog,
    public resourcesService: ResourcesService
  ) {
    const self = this;
    self.speciality = localStorage.getItem('speciality');
    //self.selectedDiagnosis = null;
    //self.searchDiagnosis = '';

    self.selectedTreatment = null;
    self.searchTreatment = '';

    self.selectedExam = null;
    self.searchExam = '';

    self.selectedSpecialty = null;
    self.searchSpecialty = '';

    self.note = {
      //patient: patient.id,
      //ticket: ticket,
      symptoms: {
        list: [],
        description: '',
        duration: '',
        durationUnit: '',
        background: ''
      },
      physicalExam: {
        text: ''
      },
      diagnosis: {
        list: [],
        observations: ''
      },
      exams: {
        list: [],
        observations: ''
      },
      treatments: {
        list: [],
        other: ''
      },
      interconsultation: {
        list: [],
        reason: ''
      },
      referrals: {
        list: []
      },
      triage: {
        biologicalFunctions: {
          sleep: 'NORMAL',
          hunger: 'NORMAL',
          thirst: 'NORMAL',
          urine: 'NORMAL',
          deposition: 'NORMAL',
          weightEvolution: 'NORMAL'
        },
        vitalFunctions: {
          systolic: '',
          diastolic: '',
          heartRate: '',
          respiratoryRate: '',
          temperature: '',
          waistCircumference: '',
          height: '',
          weight: '',
          bmi: '',
          cardiovascularRiskFramingham: '',
          cardiovascularRiskReynolds: '',
          hypertensionRisk: '',
          diabetesRisk: '',
          fractureRisk: '',
          cardiovascularAge: ''
        },
        others: {
          totalCholesterol: '',
          ldlCholesterol: '',
          hdlCholesterol: '',
          glycemia: '',
          glycatedHemoglobin: '',
          urineAlbumin: '',
          creatinineClearance: ''

        }
      },
      todo: {
        HSCRP: [],
        HDL: [],
        TCH: []
      },
      otherSymptoms: '',
      selectedSpecialty: this.speciality,
      specialty: this.speciality.toUpperCase(),
      physicalExamination: {
        skin: {
          capillaryRefillLLM: 'NORMAL',
          capillaryRefillLRM: 'NORMAL'
        },
        pulses: {
          pulsesLLM: 'NORMAL',
          pulsesLRM: 'NORMAL'
        },
        respiratorySystem: {
          vesicularWhisperL: 'NORMAL',
          vesicularWhisperR: 'NORMAL'
        },
        cardiovascularSystem: {
          radialPulsesL: 'NORMAL',
          radialPulsesR: 'NORMAL',
          pedalPulsesL: 'NORMAL',
          pedalPulsesR: 'NORMAL',
          cardiacPressureRhythm: 'NORMAL',
          cardiacPressureIntensity: 'NORMAL'
        },
        murmurs: {
          murmurs: false
        },
        gastrointestinalSemiology: {
          gastrointestinalSemiology: 'NORMAL'
        }
      }
    };
  }

  ngOnInit(): void {
    this.patient = JSON.parse(localStorage.getItem('patient'));
    this.notes = localStorage.getItem('notes');
    console.log(this.notes);
    console.log(this.patient);
    this.recordService.selectedSpecialty.subscribe((value) => {
      console.log(value);
      //this.router.navigateByUrl('/records');      
      this.speciality = value;
    });

    this.getResources();
    this.tabs = this.showTabs(this.speciality);

  }

  private showTabs(speciality: string) {
    switch (speciality) {
      case 'cardiology':
        return [
          {
            title: 'Triaje',
            isCardiology: true
          },
          {
            title: 'Atención',
            isCardiology: true
          },
          {
            title: 'Conclusión',
            isCardiology: true
          },
          {
            title: 'Resumen',
            isCardiology: true
          }
        ];
      default:
        return [
          {
            title: 'Triaje',
            isCardiology: false
          },
          {
            title: 'Atención',
            isCardiology: false
          },
          {
            title: 'Resumen',
            isCardiology: false
          }
        ];
    }

  }

  getResources() {
    let resourcesPath: string = null;
    switch (this.speciality) {
      case 'cardiology':
        resourcesPath = 'record/resources/cardiology';
        break;
      default:
        resourcesPath = 'record/resources/note';
        break;
    }
    this.noteService.getResources(resourcesPath).then((response: any) => {
      this.noteService.resources.next(response);
    }).catch((error) => {
      console.log(error);
    });
  }

  handleComputedFieldsChange(note: any) {
    this.note = note;
    let vf = note.triage.vitalFunctions;

    /* bmi */
    if (vf.weight > 0 && vf.height > 0) {
      vf.bmi = Number((vf.weight / Math.pow(vf.height, 2)).toFixed(2));
    } else {
      vf.bmi = null;
    }

    console.log(vf.bmi);
    /* cardiovascular desease risk */
    let cigarettes = false;
    let medicines_ANTIHIPERTENSIVOS = false;
    let personalBackground_DIABETES = false;
    let personalBackground_GLUCOSA_ELEVADA = false;

    let fatherBackground_ENFERMEDAD_CARDIOVASCULAR = false;
    let motherBackground_ENFERMEDAD_CARDIOVASCULAR = false;

    let fatherBackground_HIPERTENSION = false;
    let motherBackground_HIPERTENSION = false;
    let personalBackground_HIPERTENSION = false;

    let fatherBackground_DIABETES = false;
    let motherBackground_DIABETES = false;
    let physicalActivity = false;
    let fvConsumption = false;
    if (CheckEmptyUtil.isNotEmptyObject(this.patient)) {
      if (typeof this.patient.physicalActivity !== 'undefined') {
        physicalActivity = (this.patient.physicalActivity !== 'NINGUNA');
      }

      if (typeof this.patient.fvConsumption !== 'undefined') {
        fvConsumption = (this.patient.fvConsumption === 'DAILY');
      }
      if (typeof this.patient.cigarettes !== 'undefined') {
        cigarettes = (this.patient.cigarettes > 0);
      }
      if (typeof this.patient.medicines !== 'undefined') {
        medicines_ANTIHIPERTENSIVOS = (this.patient.medicines.indexOf('ANTIHIPERTENSIVOS') !== -1);
      }
      if (typeof this.patient.personalBackground !== 'undefined') {
        personalBackground_DIABETES = (this.patient.personalBackground.indexOf('DIABETES_MELITUS_') !== -1);
        personalBackground_HIPERTENSION = (this.patient.personalBackground.indexOf('HIPERTENSION') !== -1);
        personalBackground_GLUCOSA_ELEVADA = (this.patient.personalBackground.indexOf('GLUCOSA_ELEVADA') !== -1);
      }
      if (typeof this.patient.fatherBackground !== 'undefined') {
        fatherBackground_ENFERMEDAD_CARDIOVASCULAR = (this.patient.fatherBackground.indexOf('ENFERMEDAD_CARDIOVASCULAR') !== -1);
        fatherBackground_HIPERTENSION = (this.patient.fatherBackground.indexOf('HIPERTENSION') !== -1);
        fatherBackground_DIABETES = (this.patient.fatherBackground.indexOf('DIABETES_MELITUS_') !== -1);
      }

      if (typeof this.patient.motherBackground !== 'undefined') {
        motherBackground_ENFERMEDAD_CARDIOVASCULAR = (this.patient.motherBackground.indexOf('ENFERMEDAD_CARDIOVASCULAR') !== -1);
        motherBackground_HIPERTENSION = (this.patient.motherBackground.indexOf('HIPERTENSION') !== -1);
        motherBackground_DIABETES = (this.patient.motherBackground.indexOf('DIABETES_MELITUS_') !== -1);
      }
    }

    vf.cardiovascularRiskFramingham = new CardiovascularFraminghamIndicator().get(
      this.patient.sex,
      this.patient.age,
      vf.systolic,
      cigarettes,
      medicines_ANTIHIPERTENSIVOS,
      vf.bmi,
      personalBackground_DIABETES);

    const cardiovascularRiskFramingham = (vf.cardiovascularRiskFramingham !== undefined) ? vf.cardiovascularRiskFramingham : 0;
    vf.cardiovascularRiskFramingham = Number((100 * cardiovascularRiskFramingham).toFixed(2));

    /* Cardiovascular Risk Reynolds */

    vf.cardiovascularRiskReynolds = new CardiovascularRiskReynoldsIndicator().get(
      this.patient.age,
      vf.systolic,
      cigarettes,
      8, // TODO HSCRP
      45, // TODO HDL
      180, // TODO TCH
      personalBackground_DIABETES,
      (
        fatherBackground_ENFERMEDAD_CARDIOVASCULAR ||
        motherBackground_ENFERMEDAD_CARDIOVASCULAR
      )
    );
    const cardiovascularRiskReynolds = (vf.cardiovascularRiskReynolds !== undefined) ? vf.cardiovascularRiskReynolds : 0;
    vf.cardiovascularRiskReynolds = Number((100 * cardiovascularRiskReynolds).toFixed(2));

    /* hypertension risk */
    vf.hypertensionRisk = new HypertensionIndicator().get(
      this.patient.sex,
      this.patient.age,
      vf.systolic,
      vf.diastolic,
      cigarettes,
      (
        (fatherBackground_HIPERTENSION ? 0 : 1) +
        (motherBackground_HIPERTENSION ? 0 : 1)
      ),
      vf.bmi,
      personalBackground_HIPERTENSION);
    const hypertensionRisk = (vf.hypertensionRisk !== undefined) ? vf.hypertensionRisk : 0;
    vf.hypertensionRisk = Number((100 * hypertensionRisk).toFixed(2));

    /* diabetes risk */
    vf.diabetesRisk = new DiabetesIndicator().get(
      this.patient.sex,
      this.patient.age,
      vf.waistCircumference,
      physicalActivity,
      fvConsumption,
      personalBackground_GLUCOSA_ELEVADA,
      medicines_ANTIHIPERTENSIVOS,
      vf.bmi,
      (
        fatherBackground_DIABETES ||
        motherBackground_DIABETES
      ),
      personalBackground_DIABETES);
    const diabetesRisk = (vf.diabetesRisk !== undefined) ? vf.diabetesRisk : 0;
    vf.diabetesRisk = Number((100 * diabetesRisk).toFixed(2));

    /* fracture risk */
    vf.fractureRisk = new FractureIndicator().get(
      this.patient.age,
      vf.weight,
      0, // TODO
      0 // TODO
    );
    const fractureRisk = (vf.fractureRisk !== undefined) ? vf.fractureRisk : 0;
    vf.fractureRisk = Number((100 * vf.fractureRisk).toFixed(2));

    /* cardiovascular age */
    vf.cardiovascularAge = new CardiovascularAgeIndicator().get(
      this.patient.sex,
      this.patient.age,
      vf.systolic,
      cigarettes,
      medicines_ANTIHIPERTENSIVOS,
      45, // TODO HDL
      180, // TODO TCH
      personalBackground_DIABETES
    );
    vf.cardiovascularAge = Number((vf.cardiovascularAge !== undefined) ? vf.cardiovascularAge.toFixed(0) : 0);

    this.note.triage.vitalFunctions = vf;
  }

  handleDiagnosisChange(search: any) {
    this.queryDiagnosis(search);
  }

  addSymptom(a) {
    var index = this.note.symptoms.list.indexOf(a);
    if (index === -1) {
      this.note.symptoms.list.push(a);
    }
  }

  ///* diagnosis */

  //queryDiagnosis(query: string) {
  //  if (!query || query.length < 3) {
  //    return [];
  //  }

  //  this.resourcesService.search(query, '/admin/diagnosis').toPromise()
  //    .then((response) => {
  //      this.note.diagnosis.list = response;
  //      this.noteService.diagnosisList.emit(this.note.diagnosis.list);
  //      console.log(this.note.diagnosis, 'this.note.diagnosis');
  //    }).catch((error) => {
  //      console.log(error);
  //    });
  //}

  submitRequest() {

    let self = this;

    self.submit.waiting = true;

    this.noteService.save(this.note).then((response: any) => {
      console.log(response);
      //self.$state.go('record.index');
      //self.Toast.display('Atención guardada satisfactoriamente.');
      self.submit.waiting = false;
      self.submit.success = true;
      self.note.id = response.id;
    }).catch((errors: any) => {
      console.log(errors);
      //self.Toast.display('Ocurrió un error al guardar la atención.');
      self.submit.waiting = false;
      self.submit.success = false;
    });
  }
}
