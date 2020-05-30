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

  selectedDiagnosis: any;
  searchDiagnosis: string;

  selectedExam: any;
  searchExam: string;

  selectedTreatment: any;
  searchTreatment: string;

  selectedSpecialty: any;
  searchSpecialty: string;
  specialty = '';
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
      }
    };

    self.note.specialty = this.specialty.toUpperCase();
    if (this.specialty === 'cardiology') {
      self.note.physicalExamination = {
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
      };
    }
  }

  ngOnInit(): void {
    this.recordService.selectedSpecialty.subscribe((value) => {
      console.log(value);
      //this.router.navigateByUrl('/records');      
      this.specialty = value;
    });

    this.getResources();
    this.tabs = this.showTabs(this.specialty);
    console.log(this.tabs, 'self.tabs');
  }

  private showTabs(specialty: string) {
    switch (specialty) {
      case 'cardiology':
        return [
          {
            title: 'Triaje'
          },
          {
            title: 'Atención'
          },
          {
            title: 'Conclusión'
          },
          {
            title: 'Resumen'
          }
        ];
      default:
        return [
          {
            title: 'Triaje'
          },
          {
            title: 'Atención'
          },
          {
            title: 'Resumen'
          }
        ];
    }

  }

  getResources() {
    let resourcesPath: string = null;
    switch (this.specialty) {
      case 'cardiology':
        resourcesPath = '/record/resources/cardiology';
        break;
      default:
        resourcesPath = '/record/resources/note';
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
