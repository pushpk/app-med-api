import { Component, OnInit } from '@angular/core';
import { NoteService } from './services/note.service';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RecordService } from '../record/services/record.service';
import { CheckEmptyUtil } from '../../shared/util/check-empty.util';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {
  patient: any;
  note: any;
  notes: any;
  selectedDiagnosis: any;
  searchDiagnosis: string;

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
    private recordService: RecordService
  ) {
    const self = this;
    self.speciality = localStorage.getItem('speciality');
    self.selectedDiagnosis = null;
    self.searchDiagnosis = '';

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
