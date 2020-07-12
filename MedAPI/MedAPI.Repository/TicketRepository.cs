using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Repository
{
    public class TicketRepository : ITicketRepository
    {
        public Note getByTicket(string serie, string nroTicket)
        {
            //var bytes = BitConverter.GetBytes(false);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from n in context.notes
                        join t in context.tickets on n.ticket.id equals t.id
                        where t.serie == serie && t.nroTicket == nroTicket &&
                        n.deleted != false && t.deleted != false
                        select new Domain.Note
                        {
                            Age = n.age,
                            Completed = n.completed,
                            Control = n.control,
                            ControlNoteId = n.controlNote_id,
                            CreatedBy = n.createdBy,
                            CreatedDate = n.createdDate,
                            Diagnosis = n.diagnosis,
                            Deleted = n.deleted,
                            EstablishmentId = n.establishment_id,
                            Exam = n.exam,
                            Id = n.id,
                            MedicId = n.medic_id,
                            ModifiedBy = n.modifiedBy,
                            ModifiedDate = n.modifiedDate,
                            PhysicalExam = n.physicalExam,
                            PatientId = n.patient_id,
                            SicknessTime = n.sicknessTime,
                            SicknessUnit = n.sicknessUnit,
                            TriageId = n.triage_id,
                            Treatment = n.treatment,
                            TicketId = n.ticket_id,
                            Symptom = n.symptom,
                            Story = n.story,
                            Stage = n.stage,
                            Specialty = n.specialty,
                            SecondOpinion = n.secondOpinion,
                            //patient = n.patient,
                            note2 = n.note2,
                            medic = n.medic,
                            ticket = n.ticket
                        }).FirstOrDefault();
            }
        }

        public List<Note> getByPatient(long patientId)
        {
            //var bytes = BitConverter.GetBytes(false);
            //var bytesComplete = BitConverter.GetBytes(true);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from n in context.notes
                        where n.deleted != false && n.patient_id == patientId && n.completed == true
                        select new Note()
                        {
                            Age = n.age,
                            Completed = n.completed,
                            Control = n.control,
                            ControlNoteId = n.controlNote_id,
                            CreatedBy = n.createdBy,
                            CreatedDate = n.createdDate,
                            Diagnosis = n.diagnosis,
                            Deleted = n.deleted,
                            EstablishmentId = n.establishment_id,
                            Exam = n.exam,
                            Id = n.id,
                            MedicId = n.medic_id,
                            ModifiedBy = n.modifiedBy,
                            ModifiedDate = n.modifiedDate,
                            PhysicalExam = n.physicalExam,
                            PatientId = n.patient_id,
                            SicknessTime = n.sicknessTime,
                            SicknessUnit = n.sicknessUnit,
                            TriageId = n.triage_id,
                            Treatment = n.treatment,
                            TicketId = n.ticket_id,
                            Symptom = n.symptom,
                            Story = n.story,
                            Stage = n.stage,
                            Specialty = n.specialty,
                            SecondOpinion = n.secondOpinion,
                            //patient = n.patient,
                            note2 = n.note2,
                            medic = n.medic,
                            ticket = n.ticket
                        }).ToList();
            }
        }

        public Ticket SaveTicket(Ticket mTicket)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efTicket = context.tickets.Where(m => m.id == mTicket.id).FirstOrDefault();
                if (efTicket == null)
                {
                    efTicket = new DataAccess.ticket();
                    efTicket.deleted = false;// BitConverter.GetBytes(false);
                    context.tickets.Add(efTicket);
                }
                efTicket.closed = mTicket.closed;
                efTicket.status = mTicket.status;
                efTicket.serie = mTicket.serie;
                efTicket.nroTicket = mTicket.nroTicket;
                context.SaveChanges();
                mTicket.id= efTicket.id;
            }
            return mTicket;
        }
    }
}

