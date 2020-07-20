using MedAPI.Domain;
using MedAPI.Infrastructure;
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

        public List<Note> GetAllNoteByPatient(int id)
        {
            return noteRepository.GetAllNoteByPatient(id);

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
            var ticket = ticketRepository.SaveTicket(mNote.ticket);
            if (ticket.id > 0)
            {
                mNote.ticketId = ticket.id;
                mNote.triage.ticketId = ticket.id;
            }
            var triage = triageRepository.SaveTriage(mNote.triage);
            if (triage.id > 0)
            {
                mNote.triageId = triage.id;
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

            mNoteResourcesList.hungers = Enum.GetValues(typeof(Hunger))
                            .Cast<Hunger>()
                            .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                            .ToList();

            mNoteResourcesList.thirsts = Enum.GetValues(typeof(Thirst))
                            .Cast<Thirst>()
                            .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                            .ToList();

            mNoteResourcesList.sleeps = Enum.GetValues(typeof(Sleep))
                          .Cast<Sleep>()
                          .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                          .ToList();

            mNoteResourcesList.urines = Enum.GetValues(typeof(Urine))
                          .Cast<Urine>()
                          .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                          .ToList();

            mNoteResourcesList.weightEvolutions = Enum.GetValues(typeof(WeightEvolution))
                         .Cast<WeightEvolution>()
                         .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                         .ToList();

            mNoteResourcesList.depositions = Enum.GetValues(typeof(Deposition))
                        .Cast<Deposition>()
                        .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                        .ToList();

            mNoteResourcesList.cardiovascularSymptom = Enum.GetValues(typeof(CardiovascularSymptom))
                        .Cast<CardiovascularSymptom>()
                        .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                        .ToList();


            mNoteResourcesList.medicines = Enum.GetValues(typeof(Infrastructure.Common.Medicine))
                        .Cast<Infrastructure.Common.Medicine>()
                        .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                        .ToList();

            mNoteResourcesList.backgrounds = Enum.GetValues(typeof(Infrastructure.Common.Background))
                      .Cast<Infrastructure.Common.Background>()
                      .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                      .ToList();

            mNoteResourcesList.physicalActivities = Enum.GetValues(typeof(Infrastructure.Common.PhysicalActivity))
                      .Cast<Infrastructure.Common.PhysicalActivity>()
                      .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                      .ToList();
            mNoteResourcesList.sexes = Enum.GetValues(typeof(Infrastructure.Common.Sex))
            .Cast<Infrastructure.Common.Sex>()
            .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
            .ToList();

            return mNoteResourcesList;
        }
      
        public bool SaveDiagnosisList(List<NoteDiagnosi> diagnosi)
        {
            return noteRepository.SaveDiagnosisList(diagnosi);
        }
        public bool SaveExamsList(List<NoteExam> exams)
        {
            return noteRepository.SaveExamsList(exams);
        }
        public bool SaveMedicationsList(List<NoteMedicine> mMedications)
        {
            return noteRepository.SaveMedicationsList(mMedications);
        }
        public bool SaveReferralsList(List<NoteReferral> mReferrals)
        {
            return noteRepository.SaveReferralsList(mReferrals);
        }
    }
}
