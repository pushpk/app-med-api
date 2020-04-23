using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Repository
{
    public class NoteRepository : INoteRepository
    {
        public bool DeleteNoteById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efNote = context.notes.Where(m => m.id == id).FirstOrDefault();
                if (efNote != null)
                {
                    efNote.deleted = BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }

        public List<Note> GetAllNote()
        {
            var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from nt in context.notes
                        where nt.deleted != bytes
                        select new Note()
                        {
                            Id = nt.id,
                            Age = nt.age,
                            Completed = nt.completed,
                            Control = nt.control,
                            Diagnosis = nt.diagnosis,
                            Exam = nt.exam,
                            ModifiedBy = nt.modifiedBy,
                            PhysicalExam = nt.physicalExam,
                            SecondOpinion = nt.secondOpinion,
                            SicknessTime = nt.sicknessTime,
                            SicknessUnit = nt.sicknessUnit,
                            Specialty = nt.specialty,
                            Stage = nt.stage,
                            Story = nt.story,
                            Symptom = nt.symptom,
                            Treatment = nt.treatment,
                            ControlNoteId = nt.controlNote_id,
                            EstablishmentId = nt.establishment_id,
                            MedicId = nt.medic_id,
                            PatientId = nt.patient_id,
                            TicketId = nt.ticket_id,
                            TriageId = nt.triage_id
                        }).ToList();
            }
        }

        public Note GetNoteById(long id)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return context.notes.Where(x => x.id == id)
                   .Select(x => new Note()
                   {
                       Id = x.id,
                       Age = x.age,
                       Completed = x.completed,
                       Control = x.control,
                       Diagnosis = x.diagnosis,
                       Exam = x.exam,
                       ModifiedBy = x.modifiedBy,
                       PhysicalExam = x.physicalExam,
                       SecondOpinion = x.secondOpinion,
                       SicknessTime = x.sicknessTime,
                       SicknessUnit = x.sicknessUnit,
                       Specialty = x.specialty,
                       Stage = x.stage,
                       Story = x.story,
                       Symptom = x.symptom,
                       Treatment = x.treatment,
                       ControlNoteId = x.controlNote_id,
                       EstablishmentId = x.establishment_id,
                       MedicId = x.medic_id,
                       PatientId = x.patient_id,
                       TicketId = x.ticket_id,
                       TriageId = x.triage_id
                   }).FirstOrDefault();
            }
        }
    }
}
