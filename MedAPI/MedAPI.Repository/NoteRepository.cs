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
                return (from nt in context.notes
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
                            physicalExam = nt.physicalExam,
                            secondOpinion = nt.secondOpinion,
                            sicknessTime = nt.sicknessTime,
                            sicknessUnit = nt.sicknessUnit,
                            specialty = nt.specialty,
                            stage = nt.stage,
                            story = nt.story,
                            symptom = nt.symptom,
                            treatment = nt.treatment,
                            controlNoteId = nt.controlNote_id,
                            establishmentId = nt.establishment_id,
                            medicId = nt.medic_id,
                            patientId = nt.patient_id,
                            ticketId = nt.ticket_id,
                            triageId = nt.triage_id,
                            noteDiagnosis = ((from x in context.notediagnosis
                                              where x.deleted != true && x.note_id == nt.id
                                              select new NoteDiagnosi()
                                              {
                                                  noteId = x.note_id,
                                                  diagnosisId = x.diagnosis_id,
                                                  diagnosisType = x.diagnosisType
                                              }).ToList()),
                            noteExams = ((from x in context.noteexams
                                         where x.deleted != true && x.note_id == nt.id
                                         select new NoteExam()
                                         {
                                             noteId = x.note_id,
                                             examId = x.exam_id,
                                             observation = x.observation,
                                             specification = x.specification,
                                             status = x.status
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
                                              medicineId = x.medicine_id
                                          }).ToList()),
                            noteReferrals = ((from x in context.notereferrals
                                              where x.deleted != true && x.note_id == nt.id
                                              select new NoteReferral()
                                              {
                                                  noteId = x.note_id,
                                                  reason = x.reason,
                                                  specialty = x.specialty
                                              }).ToList())
                        }).ToList();
                //triage = ((from x in context.triages
                //           where x.deleted != true && x.patient_id == id
                //           select new Domain.Triage()
                //           {
                //               abdominalPerimeter = x.abdominalPerimeter,
                //               bmi = x.bmi,
                //               breathingRate = x.breathingRate,
                //               deposition = x.deposition,
                //               diastolicBloodPressure = x.diastolicBloodPressure,
                //               glycemia = x.glycemia,
                //               hdlCholesterol = x.hdlCholesterol,
                //               heartRate = x.heartRate,
                //               heartRisk = x.heartRisk,
                //               hunger = x.hunger,
                //               hypertensionRisk = x.hypertensionRisk,
                //               ldlCholesterol = x.ldlCholesterol,
                //               size = x.size,
                //               sleep = x.sleep,
                //               systolicBloodPressure = x.systolicBloodPressure,
                //               temperature = x.temperature,
                //               thirst = x.thirst,
                //               totalCholesterol = x.totalCholesterol,
                //               urine = x.urine,
                //               weight = x.weight,
                //               weightEvolution = x.weightEvolution,
                //               patientId = x.patient_id,
                //               ticketId = x.ticket_id
                //           }).ToList())
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
                            controlNoteId = nt.controlNote_id,
                            establishmentId = nt.establishment_id,
                            medicId = nt.medic_id,
                            patientId = nt.patient_id,
                            ticketId = nt.ticket_id,
                            triageId = nt.triage_id
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
                       controlNoteId = x.controlNote_id,
                       establishmentId = x.establishment_id,
                       medicId = x.medic_id,
                       patientId = x.patient_id,
                       ticketId = x.ticket_id,
                       triageId = x.triage_id
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
                efNotes.age = mNote.age;
                efNotes.completed = mNote.completed;
                efNotes.control = mNote.control;
                efNotes.controlNote_id = mNote.controlNoteId;
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
                        var efDignosos = context.notediagnosis.Where(m => m.id == diagnosis.id).FirstOrDefault();
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
                        var efExams = context.noteexams.Where(m => m.id == exam.id).FirstOrDefault();
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
                        var efMedications = context.notemedicines.Where(m => m.id == medication.id).FirstOrDefault();
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
                        var efReferrals = context.notereferrals.Where(m => m.id == referral.id).FirstOrDefault();
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
                    }
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
