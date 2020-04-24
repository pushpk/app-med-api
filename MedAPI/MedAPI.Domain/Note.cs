using MedAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class Note
    {
        public Note()
        {
            this.Note1 = new List<Note>();
            this.NoteDiagnosis = new List<NoteDiagnosi>();
            this.NoteExams = new List<NoteExam>();
            this.NoteMedicines = new List<NoteMedicine>();
            this.NoteReferrals = new List<NoteReferral>();
            this.NoteDiagnosis1 = new List<NoteDiagnosi>();
            this.NoteExams1 = new List<NoteExam>();
            this.NoteMedicines1 = new List<NoteMedicine>();
            this.NoteReferrals1 = new List<NoteReferral>();
            cardiovascularnote = new cardiovascularnote();
            establishment = new establishment();
            medic = new medic();
            Triage = new Triage();
            Ticket = new Ticket();

        }

        public long Id { get; set; }
        public string Age { get; set; }
        public byte[] Completed { get; set; }
        public byte[] Control { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public byte[] Deleted { get; set; }
        public string Diagnosis { get; set; }
        public string Exam { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string PhysicalExam { get; set; }
        public string SecondOpinion { get; set; }
        public long? SicknessTime { get; set; }
        public string SicknessUnit { get; set; }
        public string Specialty { get; set; }
        public long? Stage { get; set; }
        public string Story { get; set; }
        public string Symptom { get; set; }
        public string Treatment { get; set; }
        public long? ControlNoteId { get; set; }
        public long? EstablishmentId { get; set; }
        public long? MedicId { get; set; }
        public long PatientId { get; set; }
        public long? TicketId { get; set; }
        public long? TriageId { get; set; }


        public virtual cardiovascularnote cardiovascularnote { get; set; }
        public virtual establishment establishment { get; set; }
        public virtual medic medic { get; set; }
        public virtual note note2 { get; set; }
        //public virtual patient patient { get; set; }
        //public virtual triage triage { get; set; }
        public virtual ticket ticket { get; set; }
        public ICollection<Note> Note1 { get; set; }
        public ICollection<NoteDiagnosi> NoteDiagnosis { get; set; }
        public ICollection<NoteExam> NoteExams { get; set; }
        public ICollection<NoteMedicine> NoteMedicines { get; set; }
        public ICollection<NoteReferral> NoteReferrals { get; set; }
        public ICollection<NoteDiagnosi> NoteDiagnosis1 { get; set; }
        public ICollection<NoteExam> NoteExams1 { get; set; }
        public ICollection<NoteMedicine> NoteMedicines1 { get; set; }
        public ICollection<NoteReferral> NoteReferrals1 { get; set; }

        public Triage Triage { get; set; }
        public  Ticket Ticket { get; set; }
    }
}
