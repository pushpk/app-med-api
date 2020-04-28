using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using static MedAPI.Infrastructure.Common;

namespace MedAPI.Service
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository noteRepository;
        private readonly ITriageRepository triageRepository;
        private readonly ITicketRepository ticketRepository;
        public NoteService(INoteRepository noteRepository, ITriageRepository triageRepository, ITicketRepository ticketRepository)
        {
            this.noteRepository = noteRepository;
            this.ticketRepository = ticketRepository;
            this.triageRepository = triageRepository;
        }

        public bool DeleteNoteById(long id)
        {
            return noteRepository.DeleteNoteById(id);
        }

        public List<Note> GetAllNote()
        {
            return noteRepository.GetAllNote();
        }

        public Note GetNoteById(long id)
        {
            return noteRepository.GetNoteById(id);
        }

        public Note SaveNote(Note mNote)
        {
            var ticket = ticketRepository.SaveTicket(mNote.Ticket);
            if (ticket.id > 0)
            {
                mNote.TicketId = ticket.id;
                mNote.Triage.TicketId = ticket.id;
            }
            var triage = triageRepository.SaveTriage(mNote.Triage);
            if (triage.Id > 0)
            {
                mNote.TriageId = triage.Id;
            }

            return noteRepository.SaveNote(mNote);
        }
        public Triage TriageSave(Triage triage)
        {
            return triageRepository.SaveTriage(triage);
        }
        public NoteResources GetResources()
        {
            NoteResources mNoteResourcesList = new NoteResources();

            mNoteResourcesList.hunger = Enum.GetValues(typeof(Hunger))
                            .Cast<Hunger>()
                            .Select(d => new ObjectNode() { Id = (int)d, Name = d.ToString() })
                            .ToList();

            mNoteResourcesList.thirst = Enum.GetValues(typeof(Thirst))
                            .Cast<Thirst>()
                            .Select(d => new ObjectNode() { Id = (int)d, Name = d.ToString() })
                            .ToList();

            mNoteResourcesList.sleeps = Enum.GetValues(typeof(Sleep))
                          .Cast<Sleep>()
                          .Select(d => new ObjectNode() { Id = (int)d, Name = d.ToString() })
                          .ToList();

            mNoteResourcesList.urines = Enum.GetValues(typeof(Urine))
                          .Cast<Urine>()
                          .Select(d => new ObjectNode() { Id = (int)d, Name = d.ToString() })
                          .ToList();

            mNoteResourcesList.weightEvolutions = Enum.GetValues(typeof(WeightEvolution))
                         .Cast<WeightEvolution>()
                         .Select(d => new ObjectNode() { Id = (int)d, Name = d.ToString() })
                         .ToList();

            mNoteResourcesList.depositions = Enum.GetValues(typeof(Deposition))
                        .Cast<Deposition>()
                        .Select(d => new ObjectNode() { Id = (int)d, Name = d.ToString() })
                        .ToList();

            mNoteResourcesList.cardiovascularSymptom = Enum.GetValues(typeof(CardiovascularSymptom))
                        .Cast<CardiovascularSymptom>()
                        .Select(d => new ObjectNode() { Id = (int)d, Name = d.ToString() })
                        .ToList();


            mNoteResourcesList.medicines = Enum.GetValues(typeof(Infrastructure.Common.Medicine))
                        .Cast<Infrastructure.Common.Medicine>()
                        .Select(d => new ObjectNode() { Id = (int)d, Name = d.ToString() })
                        .ToList();

            mNoteResourcesList.backgrounds = Enum.GetValues(typeof(Infrastructure.Common.Background))
                      .Cast<Infrastructure.Common.Background>()
                      .Select(d => new ObjectNode() { Id = (int)d, Name = d.ToString() })
                      .ToList();

            mNoteResourcesList.physicalActivities = Enum.GetValues(typeof(Infrastructure.Common.PhysicalActivity))
                      .Cast<Infrastructure.Common.PhysicalActivity>()
                      .Select(d => new ObjectNode() { Id = (int)d, Name = d.ToString() })
                      .ToList();
            mNoteResourcesList.sexes = Enum.GetValues(typeof(Infrastructure.Common.Sex))
            .Cast<Infrastructure.Common.Sex>()
            .Select(d => new ObjectNode() { Id = (int)d, Name = d.ToString() })
            .ToList();

            return mNoteResourcesList;
        }

    }
}
