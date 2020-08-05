import { NoteSymptom } from './noteSymptom.model';
import { NoteDiagnosis } from './noteDiagnosis.model';
import { NoteExams } from './noteExams.model';
import { PhysicalExam } from './physicalexam.model';
import { NoteTreatment } from './noteTreatment.model';
import { NoteInterconsultation } from './noteInterconsultation.model';
import { NoteReferrals } from './noteReferrals.model';
import { Triage } from './triage.model';
import { Todo } from './todo.model';
import { Cardiovascularnote } from './cardiovascularnote.model';

export class NoteDetail {
  id = 0;
  ticketId = 0;
  registrationDate = '';
  patientId = 0;
  userId = 0;
  age = 0;
  symptoms: NoteSymptom = new NoteSymptom();
  physicalExam: PhysicalExam = new PhysicalExam();
  diagnosis: NoteDiagnosis = new NoteDiagnosis();
  exams: NoteExams = new NoteExams();
  treatments: NoteTreatment = new NoteTreatment();
  interconsultation: NoteInterconsultation = new NoteInterconsultation();
  referrals: NoteReferrals = new NoteReferrals();
  triage: Triage = new Triage();
  todo: Todo = new Todo();
  otherSymptoms = '';
  selectedSpecialty = '';
  specialty = '';
  cardiovascularNote: Cardiovascularnote = new Cardiovascularnote();
  secondOpinion = null;
  completed = true;
  control = '';
  stage = 0;
  deleted = false;
  medicId = null;
  triageId = 0;
}
