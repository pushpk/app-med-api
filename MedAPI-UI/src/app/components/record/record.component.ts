import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { RecordService } from './services/record.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Router, ActivatedRoute } from '@angular/router';
import { CheckEmptyUtil } from '../../shared/util/check-empty.util';
import { NoteDetail } from '../../models/noteDetail.model';
import { Patient } from '../../models/patient.model';
import { Triage } from '../../models/triage.model';
import { Cardiovascularnote } from '../../models/cardiovascularnote.model';
import { NoteDiagnosis } from '../../models/noteDiagnosis.model';
import { Lists } from '../../models/lists.model';
import { NoteExams } from '../../models/noteExams.model';
import { NoteSymptom } from '../../models/noteSymptom.model';
import { NoteTreatment } from '../../models/noteTreatment.model';
import { NoteInterconsultation } from '../../models/noteInterconsultation.model';
import { NoteReferrals } from '../../models/noteReferrals.model';
import { AllergiesList } from '../../models/allergiesList.model';
import { MedicinesList } from '../../models/medicinesList.model';
import { PatientFatherbackgroundList } from '../../models/patientFatherbackgroundList.model';
import { PatientMotherbackgroundList } from '../../models/patientMotherbackgroundList.model';
import { PersonalBackgroundList } from '../../models/personalBackgroundList.model';
import { CardiovascularSymptoms } from '../../models/cardiovascularSymptoms.model';
import { jsPDF } from "jspdf";
import 'jspdf-autotable';
import { CommonService } from 'src/app/services/common.service';
import { LabUploadResult } from 'src/app/models/labUploadResult';
import { ToastrService } from 'ngx-toastr';


export enum TicketStatus {
  REGISTERED = 0,
  STARTED = 1,
  FINISHED = 2
}

export interface PastAttentions {
  id: number;
  description: any;
  specialty: any;
  date: string;
  action: string;
}



@Component({
  selector: 'app-record',
  templateUrl: './record.component.html',
  styleUrls: ['./record.component.scss']
})
export class RecordComponent implements OnInit {
  notes: NoteDetail[];
  patient: Patient = new Patient();
  formData: FormData = new FormData();  
  labUploadResult: LabUploadResult = new LabUploadResult();
  ticket: any;
  ticketNumber: string;
  documentNumber: string;
  isUploadFormShow : boolean = false;

  askTicket: boolean;
  waitingTicket: boolean;
  askDocumentNumber: boolean;
  askPatientRegistration: boolean;
  showRecord: boolean;

  displayedColumns: string[] = ['id', 'description', 'specialty', 'date', 'action'];
  dataSource: any;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  selectedSpeciality: any = '';

  specialities = [{ value: 'GENERAL', name: 'Medicina General', id: 1 },
  { value: 'CARDIOLOGY', name: 'Cardiología', id: 2 },
  { value: 'PEDIATRY', name: 'Pediatría', id: 3 },
  { value: 'TRAUMATOLOGY', name: 'Traumatología', id: 4 }];

  isUserAdmin : boolean = false;
  isUserLabPerson: boolean = false;
  uploadedFile: any;
  labId: number;
  uploadResultsByLab =  new MatTableDataSource<LabUploadResult>([]);
  displayedColumnsUpload: string[] = ['user_id', 'fileName', 'dateUploaded', 'comments','action'];

  constructor(private recordService: RecordService, public router: Router, private changeDetectorRefs: ChangeDetectorRef, 
    private commonService : CommonService, private activatedRouter: ActivatedRoute, public toastr: ToastrService) { }

  ngOnInit(): void {

    
    this.askTicket = false;
    this.waitingTicket = false;
    this.askDocumentNumber = true; // false;
    this.askPatientRegistration = false;
    this.showRecord = false;

    this.ticketNumber = '';
    //this.ticket.status   = TicketStatus.REGISTERED;
    this.documentNumber = '';

    //this.patient = {};

    var docNumber = this.activatedRouter.snapshot.paramMap.get("id");

    if(docNumber)
    {
      this.documentNumber = docNumber;
      this.searchDocumentNumber();
    }

    this.isUserAdmin = localStorage.getItem('role') !== 'patient' &&  localStorage.getItem('role') !== 'lab' ;
    this.isUserLabPerson = localStorage.getItem('role') === 'lab';

    if(this.isUserLabPerson)
    {
      this.labId = Number(localStorage.getItem('loggedInID'));

          this.recordService.getUploadResultByLabID(this.labId).then((response : LabUploadResult[]) => {

            this.uploadResultsByLab.data = response;


          }).catch((error : any) => {
             console.log(error);
          });
    }
    
  }

  toggleUploadCard(){
    this.isUploadFormShow = !this.isUploadFormShow;
  }

  downloadAttentionPdf(note: NoteDetail) {
    this.commonService.generatePDF(this.patient,note,"Attention");
  }

  downloadPrescription(note: NoteDetail){

    this.commonService.generatePDF(this.patient, note, "Prescription");
  }

  downloadInter(note: NoteDetail){

    console.log(this.patient)
    this.commonService.generatePDF(this.patient, note, "Interconsultation");
  }

  downloadTestResult(id: number){

    console.log(id);
    this.recordService.downloadTestResult(id).subscribe(res => {
      const data = new Blob([res], { type: 'text/plain;charset=utf-8' });
     saveAs(data, 'text.docx');
     console.log(data);
   });
  }
 

  csvInputChange(fileInputEvent: any) {
    this.labUploadResult.file = fileInputEvent.target.files[0];
    this.formData.set('uploadFile', fileInputEvent.target.files[0]);  
  }

  submitUploadResult(){
    this.labUploadResult.user_id = this.patient.userId;

    if(this.labUploadResult.comments != null && this.labUploadResult.comments != ''){

      if(this.isUserAdmin)
      {
      this.labUploadResult.medicId = Number(localStorage.getItem('loggedInID'));
      }
      else if(this.isUserLabPerson)
      {
        this.labUploadResult.labId = Number(localStorage.getItem('loggedInID'));
      }

       this.recordService.uploadResult(this.labUploadResult.file, this.labUploadResult).subscribe((response: any) => {
      
        if(this.isUserLabPerson)
        {
          this.recordService.getUploadResultByLabID(this.labUploadResult.labId).then((response : LabUploadResult[]) => {
            this.uploadResultsByLab.data = response;
          }).catch((error : any) => {
            console.log(error);
          });
        }
        else{
          this.recordService.getUploadResultByLabID(this.patient.userId).then((response : LabUploadResult[]) => {
            this.uploadResultsByLab.data = response;
          }).catch((error : any) => {
            console.log(error);
          });
        }

      this.toastr.success('Médica registrada con éxito.');
      
    },(error) => {
       console.log(error);
        
        this.toastr.error('Se produjo un error al crear medic.');
       });

    // .catch((error) => {
    //   console.log(error);
      
    //   this.toastr.error('Se produjo un error al crear medic.');
    // });

  }
  }

  searchTicket() {
    this.askTicket = true;
    this.askDocumentNumber = false;
    this.askPatientRegistration = false;
    this.showRecord = false;

    if (!this.ticketNumber) {
      return;
    }

    let self = this;

    self.waitingTicket = true;
    this.recordService.getPatientsByTicketNumber(this.ticketNumber).then((response: any) => {



      this.setPatientDetails(response);

      //localStorage.setItem('patient', response.patient);
      //localStorage.setItem('notes', response.notes);
      //self.patient = response.patient;
      //self.patient.notes = response.notes;
      self.ticket = response.ticket;
      self.ticket.status = TicketStatus[<string>response.ticket.status];
      self.recordService.patientId.next(self.patient.id);
      if (typeof self.patient.notes !== 'undefined' && self.patient.notes !== null) {
        this.dataSource = new MatTableDataSource<PastAttentions>(self.patient.notes);
        this.dataSource.paginator = this.paginator;

      }
      self.showRecord = true;
      self.waitingTicket = false;

     

    }).catch(() => {
      self.askDocumentNumber = true;
      self.waitingTicket = false;
    });
  }


  searchDocumentNumber() {
    this.askTicket = false; // true;
    this.askDocumentNumber = true;
    this.askPatientRegistration = false;
    this.showRecord = false;
    this.ticketNumber = '000-000000';
    localStorage.setItem('notes', '');
    localStorage.setItem('patient', '');
    if (!this.documentNumber) {
      return;
    }

    let self = this;

    self.waitingTicket = true;
    this.recordService.getPatientsByDocNumber(this.documentNumber).then((response: any) => {

      console.log("---");
      console.log(response);
      console.log("---");
      this.setPatientDetails(response);
      //localStorage.setItem('patient', JSON.stringify(response.patient));
      //if (CheckEmptyUtil.isNotEmptyObject(response.notes)) {
      //  localStorage.setItem('notes', JSON.stringify(response.notes));
      //}
      //self.patient = response.patient;
      //self.patient.notes = response.notes;
      this.dataSource = [];
      if (typeof self.patient.notes !== 'undefined' && self.patient.notes !== null) {
        this.dataSource = new MatTableDataSource<PastAttentions>(self.patient.notes);
        this.dataSource.paginator = this.paginator;
        this.changeDetectorRefs.detectChanges();
      }
      self.ticket = {
        ticket: self.ticketNumber,
        status: TicketStatus.REGISTERED
      };

      self.showRecord = true;
      self.waitingTicket = false;

      if(!this.isUserLabPerson)
      {
       this.recordService.getUploadResultByPatientID(this.patient.userId).then((response : LabUploadResult[]) => {
        this.uploadResultsByLab.data = response;
      }).catch((error : any) => {
         console.log(error);
      });
    }


    }).catch(() => {
      localStorage.removeItem('notes');
      localStorage.removeItem('patient');
      self.askPatientRegistration = true;
      self.waitingTicket = false;
    });
  }

  onSpecialityChange(event: any) {
    if (CheckEmptyUtil.isNotEmptyObject(event)) {
      this.selectedSpeciality = event.value.toLowerCase();
      localStorage.setItem('speciality', this.selectedSpeciality);
      this.recordService.selectedSpecialty.next(this.selectedSpeciality);
      //this.notes = [];
      //this.patient = null;
      //this.searchDocumentNumber();
    } else {
      localStorage.setItem('speciality', '');
      this.selectedSpeciality = '';
      this.recordService.selectedSpecialty.next('');
    }
  }

  navigateToNotes() {
    let routerPath = '/records/notes/new';
    switch (this.selectedSpeciality) {
      case 'general':
        routerPath = routerPath + '/general';
        break;
      case 'cardiology':
        routerPath = routerPath + '/cardiology';
        break;
      case 'pediatry':
        routerPath = routerPath + '/pediatry';
        break;
      case 'traumatology':
        routerPath = routerPath + '/traumatology';
        break;
      default:
        routerPath = '/records/notes/new';
        localStorage.setItem('speciality', '');
        break;
    }
    localStorage.setItem('notes', '');
    this.router.navigateByUrl(routerPath);
  }
  navigateToPatient() {
    let routerPath = '/patients/new';
    if (CheckEmptyUtil.isNotEmptyObject(this.patient)) {
      routerPath = '/patients/' + this.patient.id;
    }
    this.router.navigateByUrl(routerPath);
  }

  setNoteDetails(noteDetails: any) {
    if (noteDetails && noteDetails.length > 0) {
      this.notes = [];
      try {
        noteDetails.forEach((note: any) => {
          let notes = new NoteDetail();
          notes.id = note.id;
          notes.patientId = note.patientId;
          notes.ticketId = note.ticketId;
          notes.medicId = note.medicId;
          notes.triageId = note.triageId;
          notes.age = note.age;
          notes.completed = note.completed;
          notes.control = note.control;
          notes.specialty = note.specialty;
          notes.selectedSpecialty = note.specialty;
          notes.stage = note.stage;
          notes.registrationDate = note.createdDate;
          notes.symptoms = this.setSymptoms(note);
          if (CheckEmptyUtil.isNotEmpty(note.physicalExam)) {
            notes.physicalExam.text = note.physicalExam;
          }
          notes.diagnosis = this.setDignosis(note);
          notes.exams = this.setExams(note);
          notes.treatments = this.setTreatments(note);
          notes.interconsultation = this.setInterconsultation(note);
          notes.referrals = this.setReferrals(note);
          notes.triage = this.setTriageDetails(note);
          if (CheckEmptyUtil.isNotEmptyObject(note.cardiovascularNote)) {
            notes.otherSymptoms = note.cardiovascularNote.otherSymptoms;
          }
          notes.cardiovascularSymptoms = this.setCardioSympotms(note);
          notes.cardiovascularNote = this.setCardiovascularnote(note);
          this.notes.push(notes);
        });
        localStorage.setItem('notes', JSON.stringify(this.notes));
        this.patient.notes = this.notes;
      } catch (e) {
        console.log(e, 'error');
      }
    }
  }
  setReferrals(note) {
    try {
      let referral = new NoteReferrals();
      if (note.noteReferrals && note.noteReferrals.length > 0) {
        note.noteReferrals.forEach((x: any) => {
          referral.list.push({ name: x.specialty });
        })
      }
      return referral;
    } catch (e) {
      console.log(e);
    }
  };
  setInterconsultation(note) {
    try {
      let interConsultant = new NoteInterconsultation();
      if (note.noteReferrals && note.noteReferrals.length > 0) {
        note.noteReferrals.forEach((x: any) => {
          interConsultant.reason = x.reason;
          interConsultant.list.push(x);
        })
      }
      return interConsultant;
    } catch (e) {
      console.log(e);
    }
  }
  setTreatments(note) {
    try {
      let treatment = new NoteTreatment();
      treatment.other = note.treatment;
      if (note.noteMedicines) {
        note.noteMedicines.forEach((x: any) => {
          let list = new Lists();
          list.id = x.medicineId;
          x.medicineList.filter(y => y.id === x.medicineId).map((m) => {
            list.deleted = m.deleted;
            list.concentration = m.concentration;
            list.form = m.form;
            list.fractions = m.fractions;
            list.healthRegistration = m.healthRegistration;
            list.name = m.name;
            list.owner = m.owner;
            list.presentation = m.presentation;
          });
          list.indications = x.indication;
          treatment.list.push(list);
        })
      }
      return treatment;
    } catch (e) {
      console.log(e, 'error');
    }
  };
  setSymptoms(note) {
    try {
      let symptom = new NoteSymptom();
      if (CheckEmptyUtil.isNotEmptyObject(note)) {
        symptom.description = note.symptom;
        symptom.duration = note.sicknessTime;
        symptom.durationUnit = note.sicknessUnit;
        symptom.background = note.story;
      }
      return symptom;
    } catch (e) {
      console.log(e, 'error');
    }
  };

  setExams(note) {
    try {
      let exam = new NoteExams();
      exam.observations = note.exam;
      if (note.noteExams) {
        note.noteExams.forEach((x: any) => {
          let list = new Lists();
          list.id = x.examId;
          if (x.examList.length > 0) {
            list.deleted = x.examList[0].deleted;
            list.type = x.examList.type;
          }
          x.examList.filter(y => y.id === x.examId).map((m) => {
            list.name = m.name
          });
          exam.list.push(list);
        })
      }
      return exam;
    } catch (e) {
      console.log(e, 'error');
    }
  };

  setDignosis(note) {
    try {
      let dignosis = new NoteDiagnosis();
      dignosis.observations = note.diagnosis;
      if (note.noteDiagnosis) {
        note.noteDiagnosis.forEach((x: any) => {
          let list = new Lists();
          list.id = x.diagnosisId;
          x.diagnosisList.filter(y => y.id === x.diagnosisId).map((m) => {
            list.name = m.name;
            list.code = m.code;
            list.title = m.title;
            list.chapterId = m.chapterId;
            list.chapter = m.chapter;
          });
          list.deleted = x.deleted;
          list.type = x.diagnosisType;
          dignosis.list.push(list);
        })
      }
      return dignosis;
    } catch (e) {
      console.log(e, 'error');
    }
  }
  setCardiovascularnote(note) {
    try {

      let cardiovascularNote = new Cardiovascularnote()
      if (CheckEmptyUtil.isNotEmptyObject(note.cardiovascularNote)) {
        cardiovascularNote.skin.capillaryRefillLLM = note.cardiovascularNote.capillaryRefillLLM;
        cardiovascularNote.skin.capillaryRefillLRM = note.cardiovascularNote.capillaryRefillLRM;
        cardiovascularNote.skin.trophicChanges = note.cardiovascularNote.trophicChanges;
        cardiovascularNote.skin.edemaAnkle = note.cardiovascularNote.edemaAnkle;
        cardiovascularNote.skin.edemaGeneralized = note.cardiovascularNote.edemaGeneralized;
        cardiovascularNote.skin.edemaLowerMember = note.cardiovascularNote.edemaLowerMembers;
        cardiovascularNote.pulses.pulsesLLM = note.cardiovascularNote.pulsesLLM;
        cardiovascularNote.pulses.pulsesLRM = note.cardiovascularNote.pulsesLRM;
        cardiovascularNote.respiratorySystem.vesicularWhisperL = note.cardiovascularNote.vesicularWhisperL;
        cardiovascularNote.respiratorySystem.vesicularWhisperR = note.cardiovascularNote.vesicularWhisperR;
        cardiovascularNote.cardiovascularSystem.radialPulsesL = note.cardiovascularNote.radialPulsesL;
        cardiovascularNote.cardiovascularSystem.radialPulsesR = note.cardiovascularNote.radialPulsesR;
        cardiovascularNote.cardiovascularSystem.pedalPulsesL = note.cardiovascularNote.pedalPulsesL;
        cardiovascularNote.cardiovascularSystem.pedalPulsesR = note.cardiovascularNote.pedalPulsesR;
        cardiovascularNote.cardiovascularSystem.cardiacPressureRhythm = note.cardiovascularNote.cardiacPressureRhythm;
        cardiovascularNote.cardiovascularSystem.cardiacPressureIntensity = note.cardiovascularNote.cardiacPressureIntensity;
        cardiovascularNote.murmurs.murmurs = note.cardiovascularNote.murmurs;
        cardiovascularNote.gastrointestinalSemiology.gastrointestinalSemiology = note.cardiovascularNote.gastrointestinalSemiology;
      }
      return cardiovascularNote;

    } catch (e) {
      console.log(e, 'error');
    }
  }
  setTriageDetails(note) {
    try {
      let triage = new Triage()
      if (CheckEmptyUtil.isNotEmptyObject(note.triage)) {
        triage.triageId = note.triageId;
        triage.biologicalFunctions.deposition = note.triage.deposition;
        triage.biologicalFunctions.hunger = note.triage.hunger;
        triage.biologicalFunctions.sleep = note.triage.sleep;
        triage.biologicalFunctions.thirst = note.triage.thirst;
        triage.biologicalFunctions.urine = note.triage.urine;
        triage.biologicalFunctions.weightEvolution = note.triage.weightEvolution;
        triage.vitalFunctions.systolic = note.triage.systolicBloodPressure;
        triage.vitalFunctions.diastolic = note.triage.diastolicBloodPressure;
        triage.vitalFunctions.heartRate = note.triage.heartRate;
        triage.vitalFunctions.respiratoryRate = note.triage.breathingRate;
        triage.vitalFunctions.temperature = note.triage.temperature;
        triage.vitalFunctions.waistCircumference = note.triage.abdominalPerimeter;
        triage.vitalFunctions.height = note.triage.size;
        triage.vitalFunctions.weight = note.triage.weight;
        triage.vitalFunctions.bmi = note.triage.bmi;
        triage.vitalFunctions.cardiovascularRiskFramingham = note.triage.cardiovascularRiskFramingham;
        triage.vitalFunctions.cardiovascularRiskReynolds = note.triage.cardiovascularRiskReynolds;
        triage.vitalFunctions.hypertensionRisk = note.triage.hypertensionRisk;
        triage.vitalFunctions.diabetesRisk = note.triage.diabetesRisk;
        triage.vitalFunctions.fractureRisk = note.triage.fractureRisk;
        triage.others.totalCholesterol = note.triage.totalCholesterol;
        triage.others.ldlCholesterol = note.triage.ldlCholesterol;
        triage.others.hdlCholesterol = note.triage.hdlCholesterol;
        triage.others.glycemia = note.triage.glycemia;
        triage.others.glycatedHemoglobin = note.triage.glycatedHemoglobin;
        triage.others.urineAlbumin = note.triage.urineAlbumin;
        triage.others.creatinineClearance = note.triage.creatinineClearance;
      }
      return triage;

    } catch (e) {
      console.log(e, 'error');
    }
  }
  setPatientDetails(data) {
    try {
      if (CheckEmptyUtil.isNotEmpty(data)) {
        this.recordService.passwordHash.subscribe((val) => {
          if (CheckEmptyUtil.isNotEmpty(val)) {
            this.patient.passwordHash = val;
          }
        });
        let patientDetails = data.patient;
        this.patient.id = patientDetails.id;
        this.patient.userId = patientDetails.userId;
        this.patient.name = patientDetails.user.firstName;
        this.patient.lastnameFather = patientDetails.user.lastNameFather;
        this.patient.lastnameMother = patientDetails.user.lastNameMother;

        this.patient.documentType = patientDetails.user.documentType;
        this.patient.documentNumber = patientDetails.user.documentNumber;
        this.patient.birthday = patientDetails.user.birthday;
        this.patient.sex = patientDetails.user.sex;
        this.patient.maritalStatus = patientDetails.user.maritalStatus;
        this.patient.province = String(patientDetails.user.provinceId);
        this.patient.district = String(patientDetails.user.districtId);
        this.patient.department = String(patientDetails.user.departmentId);
        this.patient.country = String(patientDetails.user.countryId);
        this.patient.address = patientDetails.user.address;
        if (CheckEmptyUtil.isNotEmpty(patientDetails.user.organDonor)) {
          this.patient.isDonor = patientDetails.user.organDonor;
        } else {
          this.patient.isDonor = false;
        }
        this.patient.email = patientDetails.user.email;
        this.patient.phone = patientDetails.user.cellphone;

        this.patient.educationalAttainment = patientDetails.educationalAttainment;
        this.patient.occupation = patientDetails.occupation;
        this.patient.bloodType = patientDetails.bloodType;
        this.patient.alcoholConsumption = patientDetails.alcohol;
        this.patient.physicalActivity = patientDetails.physicalActivity;
        this.patient.fvConsumption = patientDetails.fruitsVegetables;
        this.patient.cigarettes = patientDetails.cigaretteNumber;
        this.patient.dormNumber = patientDetails.dormNumber;
        this.patient.fractureNumber = patientDetails.fractureNumber;
        this.patient.highGlucose = patientDetails.highGlucose;
        this.patient.home.rooms = patientDetails.residentNumber;
        this.patient.home.population = '';
        this.patient.home.type = patientDetails.homeType;
        this.patient.home.ownership = patientDetails.homeOwnership;
        this.patient.home.material = patientDetails.homeMaterial;
        this.patient.home.electricity = patientDetails.electricity;
        this.patient.home.water = patientDetails.water;
        this.patient.home.sewage = patientDetails.sewage;
        this.patient.otherAllergies = patientDetails.otherAllergies;
        this.patient.otherMedicines = patientDetails.otherMedicines;
        this.patient.otherPersonalBackground = patientDetails.otherPersonalBackground;
        this.patient.otherFatherBackground = patientDetails.otherFatherBackground;
        this.patient.otherMotherBackground = patientDetails.otherMotherBackground;
        this.patient.passwordHash = patientDetails.user.passwordHash;
        this.patient.allergies = this.setAllergiesList(patientDetails);
        this.patient.medicines = this.setMedicinesList(patientDetails);
        this.patient.personalBackground = this.setPatientPersonalbackgroundList(patientDetails);
        this.patient.fatherBackground = this.setPatientFatherbackgroundList(patientDetails);
        this.patient.motherBackground = this.setPatientMotherbackgroundList(patientDetails);
        localStorage.setItem('patient', JSON.stringify(this.patient));
        let noteDetails = data.notes;
        if (noteDetails && noteDetails.length > 0) {
          this.setNoteDetails(noteDetails);
        } else {
          let notes = new NoteDetail();
          notes.patientId = patientDetails.id;
          notes.userId = patientDetails.userId;
          localStorage.setItem('notes', JSON.stringify(notes));
        }
      }
    } catch (e) {
      console.log(e, 'error');
    }
  }

  setAllergiesList(patientDetails) {
    try {
      if (CheckEmptyUtil.isNotEmpty(patientDetails)) {
        let allergies = [];
        if (patientDetails) {
          patientDetails.allergiesList.forEach((x: any) => {
            if (patientDetails.id === x.patientId && !x.isDeleted) {
              let allergy = new AllergiesList();
              allergy.id = x.id,
              allergy.patientId = x.patientId,
              allergy.name = x.allergies,
              allergy.isDeleted = x.isDeleted
              allergies.push(allergy);
            }
          })
        }
        return allergies;
      }
    } catch (e) {
      console.log(e, 'error');
    }
  }

  setMedicinesList(patientDetails) {
    try {
      if (CheckEmptyUtil.isNotEmpty(patientDetails)) {
        let medicines = [];
        if (patientDetails) {
          patientDetails.medicinesList.forEach((x: any) => {
            if (patientDetails.id === x.patientId && !x.isDeleted) {
              let medicine = new MedicinesList();
              medicine.id = x.id,

              medicine.patientId = x.patientId,
              medicine.name = x.medicines,
              medicine.isDeleted = x.isDeleted

              medicines.push(medicine);
            }
          })
        }
        return medicines;
      }
    } catch (e) {
      console.log(e, 'error');
    }
  }

  setPatientFatherbackgroundList(patientDetails) {
    console.log(JSON.stringify(patientDetails));
    try {
      if (CheckEmptyUtil.isNotEmpty(patientDetails)) {
        let fBackgrounds = [];
        if (patientDetails) {
          patientDetails.patientFatherbackgroundList.forEach((x: any) => {
            if (patientDetails.id === x.patientId && !x.isDeleted) {
              let fBackground = new PatientFatherbackgroundList();
              fBackground.id = x.id,

              fBackground.patientId = x.patientId,
              fBackground.name = x.fatherBackgrounds,
              fBackground.isDeleted = x.isDeleted

              fBackgrounds.push(fBackground);
            }
          })
        }
        return fBackgrounds;
      }
    } catch (e) {
      console.log(e, 'error');
    }
  }

  setPatientMotherbackgroundList(patientDetails) {
    try {
      if (CheckEmptyUtil.isNotEmpty(patientDetails)) {
        let mBackgrounds = [];
        if (patientDetails) {
          patientDetails.patientMotherbackgroundList.forEach((x: any) => {
            if (patientDetails.id === x.patientId && !x.isDeleted) {
              let mBackground = new PatientMotherbackgroundList();
              mBackground.id = x.id,

              mBackground.patientId = x.patientId,
              mBackground.name = x.motherBackgrounds,
              mBackground.isDeleted = x.isDeleted

              mBackgrounds.push(mBackground);
            }
          })
        }
        return mBackgrounds;
      }
    } catch (e) {
      console.log(e, 'error');
    }
  }

  setPatientPersonalbackgroundList(patientDetails) {
    try {
      if (CheckEmptyUtil.isNotEmpty(patientDetails)) {
        let pBackgrounds = [];
        if (patientDetails) {
          patientDetails.personalBackgroundList.forEach((x: any) => {
            if (patientDetails.id === x.patientId && !x.isDeleted) {
              let pBackground = new PersonalBackgroundList();
              pBackground.id = x.id,
              pBackground.patientId = x.patientId,
              pBackground.name = x.personalBackgrounds,
              pBackground.isDeleted = x.isDeleted
              pBackgrounds.push(pBackground);
            }
          })
        }
        return pBackgrounds;
      }
    } catch (e) {
      console.log(e, 'error');
    }
  }

  setCardioSympotms(notes) {
    try {
      if (CheckEmptyUtil.isNotEmpty(notes)) {
        let cardiovascularSymptoms = [], cardiovascularNoteId = 0;
        if (CheckEmptyUtil.isNotEmptyObject(notes.cardiovascularNote)) {
          cardiovascularNoteId = notes.cardiovascularNote.id;
        }
        if (notes) {
          notes.cardiovascularSymptoms.forEach((x: any) => {
            if (cardiovascularNoteId === x.cardiovascularNoteId) {
              let cardiovascularSymptom = new CardiovascularSymptoms();
              cardiovascularSymptom.id = x.id,
                cardiovascularSymptom.cardiovascularNoteId = x.cardiovascularNoteId,
                cardiovascularSymptom.cardiovascularSymptoms = x.cardiovascularSymptoms
              cardiovascularSymptoms.push(cardiovascularSymptom);
            }
          })
        }
        return cardiovascularSymptoms;
      }
    } catch (e) {
      console.log(e, 'error');
    }
  }

  selectedNotes(notes) {
    let speciality = notes.specialty.toLowerCase();
    //localStorage.setItem('selectNotes', notes);
    localStorage.setItem('speciality', speciality);
    let routerPath = '/records/notes/' + notes.id;
    switch (speciality) {
      case 'general':
        routerPath = routerPath + '/general';
        break;
      case 'cardiology':
        routerPath = routerPath + '/cardiology';
        break;
      case 'pediatry':
        routerPath = routerPath + '/pediatry';
        break;
      case 'traumatology':
        routerPath = routerPath + '/traumatology';
        break;
      default:
        routerPath = routerPath + '/general';
        break;
    }
    this.recordService.selectedSpecialty.next(speciality);
    this.router.navigateByUrl(routerPath);
  }
}
