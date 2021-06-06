﻿using Data.DataModels; using Repository.DTOs;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly registroclinicocoreContext context;
        public TicketRepository(registroclinicocoreContext context)
        {
            this.context = context;

        }
        public Note getByTicket(string serie, string nroTicket)
        {
            //var bytes = BitConverter.GetBytes(false);
          
                return (from n in context.notes
                        join t in context.tickets on n.ticket.id equals t.id
                        where t.serie == serie && t.nroTicket == nroTicket &&
                        n.deleted != false && t.deleted != false
                        select new Note
                        {
                            age = n.age,
                            completed = n.completed,
                            control = n.control,
                            userId = n.user_id,
                            createdBy = n.createdBy,
                            createdDate = n.createdDate,
                            diagnosis = n.diagnosis,
                            deleted = n.deleted,
                            establishmentId = n.establishment_id,
                            exam = n.exam,
                            id = n.id,
                            medicId = n.medic_id,
                            modifiedBy = n.modifiedBy,
                            modifiedDate = n.modifiedDate,
                            physicalExam = n.physicalExam,
                            patientId = n.patient_id,
                            sicknessTime = n.sicknessTime,
                            sicknessUnit = n.sicknessUnit,
                            triageId = n.triage_id,
                            isSignatureDraw = n.isSignatureDraw,
                            signatuteText = n.signatuteText,
                            signatuteDraw = n.signatuteDraw,
                            treatment = n.treatment,
                            ticketId = n.ticket_id,
                            symptom = n.symptom,
                            story = n.story,
                            stage = n.stage,
                            specialty = n.specialty,
                            secondOpinion = n.secondOpinion,
                            //patient = n.patient,
                            //note2 = n.note2,
                            //medic = n.medic,
                            //ticket = n.ticket
                        }).FirstOrDefault();
            
        }

        public List<Note> getByPatient(long? patientId = 0)
        {
            //var bytes = BitConverter.GetBytes(false);
            //var bytesComplete = BitConverter.GetBytes(true);
            
                return (from n in context.notes
                        where n.deleted != false && n.patient_id == patientId && n.completed == true
                        select new Note()
                        {
                            age = n.age,
                            completed = n.completed,
                            control = n.control,
                            userId = n.user_id,
                            createdBy = n.createdBy,
                            createdDate = n.createdDate,
                            diagnosis = n.diagnosis,
                            deleted = n.deleted,
                            establishmentId = n.establishment_id,
                            exam = n.exam,
                            id = n.id,
                            medicId = n.medic_id,
                            modifiedBy = n.modifiedBy,
                            modifiedDate = n.modifiedDate,
                            physicalExam = n.physicalExam,
                            patientId = n.patient_id,
                            isSignatureDraw = n.isSignatureDraw,
                            signatuteText = n.signatuteText,
                            signatuteDraw = n.signatuteDraw,
                            sicknessTime = n.sicknessTime,
                            sicknessUnit = n.sicknessUnit,
                            triageId = n.triage_id,
                            treatment = n.treatment,
                            ticketId = n.ticket_id,
                            symptom = n.symptom,
                            story = n.story,
                            stage = n.stage,
                            specialty = n.specialty,
                            secondOpinion = n.secondOpinion,
                            //patient = n.patient,
                            //note2 = n.note2,
                            //medic = n.medic,
                            //ticket = n.ticket
                        }).ToList();
            
        }

        public Ticket SaveTicket(Ticket mTicket)
        {
            
                var efTicket = context.tickets.Where(m => m.id == mTicket.id).FirstOrDefault();
                if (efTicket == null)
                {
                    efTicket = new ticket();
                    efTicket.deleted = false;// BitConverter.GetBytes(false);
                    context.tickets.Add(efTicket);
                }                
                efTicket.closed = mTicket.closed;
                efTicket.status = mTicket.status;
                efTicket.serie = mTicket.serie;
                efTicket.nroTicket = mTicket.nroTicket;
                context.SaveChanges();


               mTicket.id = efTicket.id;
            
            return mTicket;
        }
    }
}

