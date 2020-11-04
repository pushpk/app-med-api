using MedAPI.DataAccess;
using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Repository
{
    public class NoteRepository : INoteRepository


    {

        public List<Note> GetAllNoteByPatient(int id)
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var notes = (from nt in context.notes
                             where nt.deleted != true && nt.patient_id == id
                             select new Note()
                             {
                                 id = nt.id,
                                 age = nt.age,
                                 completed = nt.completed,
                                 control = nt.control,
                                 diagnosis = nt.diagnosis,
                                 exam = nt.exam,
                                 modifiedBy = nt.modifiedBy,
                                 modifiedDate = nt.modifiedDate,
                                 createdDate = nt.createdDate,
                                 createdBy = nt.createdBy,
                                 deleted = nt.deleted,
                                 physicalExam = nt.physicalExam,
                                 secondOpinion = nt.secondOpinion,
                                 sicknessTime = nt.sicknessTime,
                                 sicknessUnit = nt.sicknessUnit,
                                 specialty = nt.specialty,
                                 stage = nt.stage,
                                 story = nt.story,
                                 symptom = nt.symptom,
                                 treatment = nt.treatment,
                                 userId = nt.user_id,
                                 establishmentId = nt.establishment_id,
                                 medicId = nt.medic_id,
                                 patientId = nt.patient_id,
                                 ticketId = nt.ticket_id,
                                 triageId = nt.triage_id,
                                 status = nt.status,
                                 attached_attention = nt.attached_attention.HasValue ? nt.attached_attention.Value : 0,
                                 category = nt.category,
                                 noteDiagnosis = ((from x in context.notediagnosis
                                                   where x.deleted != true && x.note_id == nt.id
                                                   select new NoteDiagnosi()
                                                   {
                                                       id = x.id,
                                                       noteId = x.note_id,
                                                       diagnosisId = x.diagnosis_id,
                                                       diagnosisType = x.diagnosisType,
                                                       diagnosisList = (from y in context.diagnosis
                                                                        where y.id == x.diagnosis_id
                                                                        select new Diagnosis
                                                                        {
                                                                            id = y.id,
                                                                            code = y.code,
                                                                            deleted = y.deleted,
                                                                            title = y.title,
                                                                            chapterId = y.chapter_id
                                                                        }).ToList()
                                                   }).ToList()),
                                 noteExams = ((from x in context.noteexams
                                               where x.deleted != true && x.note_id == nt.id
                                               select new NoteExam()
                                               {
                                                   noteId = x.note_id,
                                                   examId = x.exam_id,
                                                   observation = x.observation,
                                                   specification = x.specification,
                                                   status = x.status,
                                                   examList = (from y in context.exams
                                                               where y.id == x.exam_id
                                                               select new Exam
                                                               {
                                                                   id = y.id,
                                                                   name = y.name,
                                                                   deleted = y.deleted,
                                                                   type = y.type
                                                               }).ToList()
                                               }).ToList()),
                                 noteMedicines = ((from x in context.notemedicines
                                                   where x.deleted != true && x.note_id == nt.id
                                                   select new NoteMedicine()
                                                   {
                                                       noteId = x.note_id,
                                                       durationTime = x.durationTime,
                                                       durationUnit = x.durationUnit,
                                                       frequencyTime = x.frequencyTime,
                                                       indication = x.indication,
                                                       medicineId = x.medicine_id,
                                                       medicineList = (from y in context.medicines
                                                                       where y.id == x.medicine_id
                                                                       select new Medicine
                                                                       {
                                                                           id = y.id,
                                                                           concentration = y.concentration,
                                                                           deleted = y.deleted,
                                                                           form = y.form,
                                                                           fractions = y.fractions,
                                                                           healthRegistration = y.healthRegistration,
                                                                           name = y.name,
                                                                           owner = y.owner,
                                                                           presentation = y.presentation
                                                                       }).ToList()
                                                   }).ToList()),
                                 noteReferrals = ((from x in context.notereferrals
                                                   where x.deleted != true && x.note_id == nt.id
                                                   select new NoteReferral()
                                                   {
                                                       noteId = x.note_id,
                                                       reason = x.reason,
                                                       specialty = x.specialty
                                                   }).ToList()),
                                 triage = (from x in context.triages
                                           where x.deleted != true && x.patient_id == nt.patient_id && x.id == nt.triage_id
                                           select new Triage()
                                           {
                                               id = x.id,
                                               abdominalPerimeter = x.abdominalPerimeter,
                                               bmi = x.bmi,
                                               breathingRate = x.breathingRate,
                                               createdBy = x.createdBy,
                                               createdDate = x.createdDate,
                                               deleted = x.deleted,
                                               deposition = x.deposition,
                                               diastolicBloodPressure = x.diastolicBloodPressure,
                                               specialities = x.speciality,
                                               glycemia = x.glycemia,
                                               hdlCholesterol = x.hdlCholesterol,
                                               heartRate = x.heartRate,
                                               heartRisk = x.heartRisk,
                                               hunger = x.hunger,
                                               hypertensionRisk = x.hypertensionRisk,
                                               ldlCholesterol = x.ldlCholesterol,
                                               size = x.size,
                                               sleep = x.sleep,
                                               systolicBloodPressure = x.systolicBloodPressure,
                                               temperature = x.temperature,
                                               thirst = x.thirst,
                                               totalCholesterol = x.totalCholesterol,
                                               urine = x.urine,
                                               weight = x.weight,
                                               weightEvolution = x.weightEvolution,
                                               patientId = x.patient_id,
                                               ticketId = x.ticket_id
                                           }).FirstOrDefault(),
                                 cardiovascularNote = (from x in context.cardiovascularnotes
                                                       where x.note_id == nt.id
                                                       select new CardiovascularNote()
                                                       {
                                                           id = x.id,
                                                           auscultationSite = x.auscultationSite,
                                                           capillaryRefillLLM = x.capillaryRefillLLM,
                                                           capillaryRefillLRM = x.capillaryRefillLRM,
                                                           cardiacPressureIntensity = x.cardiacPressureIntensity,
                                                           cardiacPressureRhythm = x.cardiacPressureRhythm,
                                                           diastolicPhase = x.diastolicPhase,
                                                           edemaAnkle = x.edemaAnkle,
                                                           edemaGeneralized = x.edemaGeneralized,
                                                           edemaLowerMembers = x.edemaLowerMembers,
                                                           fourthNoise = x.fourthNoise,
                                                           gastrointestinalSemiology = x.gastrointestinalSemiology,
                                                           murmurs = x.murmurs,
                                                           neckRadiation = x.neckRadiation,
                                                           otherSymptoms = x.otherSymptoms,
                                                           pedalPulsesL = x.pedalPulsesL,
                                                           pedalPulsesR = x.pedalPulsesR,
                                                           pulsesLLM = x.pulsesLLM,
                                                           pulsesLRM = x.pulsesLRM,
                                                           radialPulsesL = x.radialPulsesL,
                                                           radialPulsesR = x.radialPulsesR,
                                                           systolicPhase = x.systolicPhase,
                                                           thirdNoise = x.thirdNoise,
                                                           trophicChanges = x.trophicChanges,
                                                           vesicularWhisperL = x.vesicularWhisperL,
                                                           vesicularWhisperR = x.vesicularWhisperR,
                                                           noteId = x.note_id
                                                       }).FirstOrDefault(),
                                 cardiovascularSymptoms = ((from x in context.cardiovascularnote_cardiovascularsymptoms
                                                            where x.cardiovascularNote_id == (context.cardiovascularnotes.Where(y => y.note_id == nt.id).FirstOrDefault().id)
                                                            select new CardiovascularSymptoms()
                                                            {
                                                                id = x.id,
                                                                cardiovascularNoteId = x.cardiovascularNote_id,
                                                                cardiovascularSymptoms = x.cardiovascularSymptoms
                                                            }).ToList())
                             }).ToList();

                return notes;
            }
        }
        public bool DeleteNoteById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efNote = context.notes.Where(m => m.id == id).FirstOrDefault();
                if (efNote != null)
                {
                    efNote.deleted = true;// BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }

        public List<Note> GetAllNote()
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from nt in context.notes
                        where nt.deleted != true
                        select new Note()
                        {
                            id = nt.id,
                            age = nt.age,
                            completed = nt.completed,
                            control = nt.control,
                            diagnosis = nt.diagnosis,
                            exam = nt.exam,
                            modifiedBy = nt.modifiedBy,
                            physicalExam = nt.physicalExam,
                            secondOpinion = nt.secondOpinion,
                            sicknessTime = nt.sicknessTime,
                            sicknessUnit = nt.sicknessUnit,
                            specialty = nt.specialty,
                            stage = nt.stage,
                            story = nt.story,
                            symptom = nt.symptom,
                            treatment = nt.treatment,
                            userId = nt.user_id,
                            establishmentId = nt.establishment_id,
                            medicId = nt.medic_id,
                            patientId = nt.patient_id,
                            ticketId = nt.ticket_id,
                            triageId = nt.triage_id,
                            status = nt.status,
                            attached_attention = nt.attached_attention.HasValue ? nt.attached_attention.Value : 0,
                            category = nt.category
                        }).ToList();
            }
        }

        public Note GetNoteById(long id)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.notes.Where(x => x.id == id)
                   .Select(x => new Note()
                   {
                       id = x.id,
                       age = x.age,
                       completed = x.completed,
                       control = x.control,
                       diagnosis = x.diagnosis,
                       exam = x.exam,
                       modifiedBy = x.modifiedBy,
                       physicalExam = x.physicalExam,
                       secondOpinion = x.secondOpinion,
                       sicknessTime = x.sicknessTime,
                       sicknessUnit = x.sicknessUnit,
                       specialty = x.specialty,
                       stage = x.stage,
                       story = x.story,
                       symptom = x.symptom,
                       treatment = x.treatment,
                       userId = x.user_id,
                       establishmentId = x.establishment_id,
                       medicId = x.medic_id,
                       patientId = x.patient_id,
                       ticketId = x.ticket_id,
                       triageId = x.triage_id,
                       status = x.status,
                       attached_attention = x.attached_attention.HasValue? x.attached_attention.Value : 0,
                       category = x.category
                   }).FirstOrDefault();
            }
        }

        public Note SaveNote(Note mNote)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efNotes = context.notes.Where(m => m.id == mNote.id).FirstOrDefault();
                if (efNotes == null)
                {
                    efNotes = new DataAccess.note();
                    efNotes.deleted = false;// BitConverter.GetBytes(false);
                    efNotes.createdDate = DateTime.UtcNow;
                    context.notes.Add(efNotes);
                }

                efNotes.status = "open";
                efNotes.category = mNote.category;
                efNotes.attached_attention = mNote.attached_attention;


                efNotes.age = mNote.age;
                efNotes.completed = mNote.completed;
                efNotes.control = mNote.control;
                efNotes.createdBy = mNote.createdBy;
                efNotes.diagnosis = mNote.diagnosis;
                efNotes.establishment_id = mNote.establishmentId;
                efNotes.exam = mNote.exam;
                efNotes.medic_id = mNote.medicId;
                efNotes.modifiedBy = mNote.modifiedBy;
                efNotes.modifiedDate = mNote.modifiedDate;
                efNotes.patient_id = mNote.patientId;
                efNotes.physicalExam = mNote.physicalExam;
                efNotes.secondOpinion = mNote.secondOpinion;
                efNotes.sicknessTime = mNote.sicknessTime;
                efNotes.sicknessUnit = mNote.sicknessUnit;
                efNotes.secondOpinion = mNote.secondOpinion;
                efNotes.specialty = mNote.specialty;
                efNotes.stage = mNote.stage;
                efNotes.story = mNote.story;
                efNotes.symptom = mNote.symptom;
                efNotes.ticket_id = mNote.ticketId;
                efNotes.treatment = mNote.treatment;
                efNotes.triage_id = mNote.triageId;
                context.SaveChanges();
                mNote.id = efNotes.id;
            }
            return mNote;
        }
        public bool SaveDiagnosisList(List<NoteDiagnosi> mDiagnosis)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                try
                {
                    foreach (var diagnosis in mDiagnosis)
                    {
                        var efDignosos = context.notediagnosis.Where(m => m.diagnosis_id == diagnosis.diagnosisId && m.note_id == diagnosis.noteId).FirstOrDefault();
                        if (efDignosos == null)
                        {
                            efDignosos = new DataAccess.notediagnosi();
                            efDignosos.deleted = false;// BitConverter.GetBytes(false);   
                            context.notediagnosis.Add(efDignosos);
                        }
                        efDignosos.diagnosisType = diagnosis.diagnosisType;
                        efDignosos.diagnosis_id = diagnosis.diagnosisId;
                        efDignosos.note_id = diagnosis.noteId;
                        context.SaveChanges();
                        diagnosis.id = efDignosos.id;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        public bool SaveExamsList(List<NoteExam> mExams)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                try
                {
                    foreach (var exam in mExams)
                    {
                        var efExams = context.noteexams.Where(m => m.exam_id == exam.examId && m.note_id == exam.noteId).FirstOrDefault();
                        if (efExams == null)
                        {
                            efExams = new DataAccess.noteexam();
                            efExams.deleted = false;// BitConverter.GetBytes(false);   
                            context.noteexams.Add(efExams);
                        }
                        efExams.observation = exam.observation;
                        efExams.exam_id = exam.examId;
                        efExams.note_id = exam.noteId;
                        context.SaveChanges();
                        exam.id = efExams.id;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public bool SaveMedicationsList(List<NoteMedicine> mMedications)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                try
                {
                    foreach (var medication in mMedications)
                    {
                        var efMedications = context.notemedicines.Where(m => m.medicine_id == medication.medicineId && m.note_id == medication.noteId).FirstOrDefault();
                        if (efMedications == null)
                        {
                            efMedications = new DataAccess.notemedicine();
                            efMedications.deleted = false;// BitConverter.GetBytes(false);   
                            context.notemedicines.Add(efMedications);
                        }
                        efMedications.durationTime = medication.durationTime;
                        efMedications.durationUnit = medication.durationUnit;
                        efMedications.frequencyTime = medication.frequencyTime;
                        efMedications.frequencyUnit = medication.frequencyUnit;
                        efMedications.indication = medication.indication;
                        efMedications.medicine_id = medication.medicineId;
                        efMedications.note_id = medication.noteId;
                        context.SaveChanges();
                        medication.id = efMedications.id;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool SaveReferralsList(List<NoteReferral> mReferrals)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                try
                {
                    foreach (var referral in mReferrals)
                    {
                        var efReferrals = context.notereferrals.Where(m => m.note_id == referral.noteId).FirstOrDefault();
                        if (efReferrals == null)
                        {
                            efReferrals = new DataAccess.notereferral();
                            efReferrals.deleted = false;// BitConverter.GetBytes(false);   
                            context.notereferrals.Add(efReferrals);
                        }
                        efReferrals.reason = referral.reason;
                        efReferrals.specialty = referral.specialty;
                        efReferrals.note_id = referral.noteId;
                        context.SaveChanges();
                        referral.id = efReferrals.id;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool CloseAttention(long id)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                try
                {
                    var attention = context.notes.FirstOrDefault(m => m.id == id);
                    if (attention == null)
                    {
                        return false;
                    }
                    attention.status = "close";
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }
    }
}
