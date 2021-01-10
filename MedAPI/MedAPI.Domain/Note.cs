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
            this.noteList = new List<Note>();
            this.noteDiagnosis = new List<NoteDiagnosi>();
            this.noteExams = new List<NoteExam>();
            this.noteMedicines = new List<NoteMedicine>();
            this.noteReferrals = new List<NoteReferral>();
            //this.NoteDiagnosis1 = new List<NoteDiagnosi>();
            //this.NoteExams1 = new List<NoteExam>();
            //this.NoteMedicines1 = new List<NoteMedicine>();
            //this.NoteReferrals1 = new List<NoteReferral>();
            //this.medic = new medic();
            this.cardiovascularNote = new CardiovascularNote();
            this.cardiovascularSymptoms = new List<CardiovascularSymptoms>();
            this.establishment = new Establishment();
            this.triage = new Triage();
            this.ticket = new Ticket();

        }

        public string status { get; set; }

        public string category { get; set; }

        public int attached_attention { get; set; }

        public string prognosis { get; set; }
        public string notes { get; set; }

        public long id { get; set; }
        public string age { get; set; }
        public bool completed { get; set; }
        public bool control { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public bool deleted { get; set; }
        public string diagnosis { get; set; }
        public string exam { get; set; }
        public string modifiedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public string physicalExam { get; set; }
        public string secondOpinion { get; set; }
        public long? sicknessTime { get; set; }
        public string sicknessUnit { get; set; }
        public string specialty { get; set; }
        public long? stage { get; set; }
        public string story { get; set; }
        public string symptom { get; set; }
        public string treatment { get; set; }
        public long? userId { get; set; }
        public long? establishmentId { get; set; }
        public long? medicId { get; set; }
        public long patientId { get; set; }
        public long? ticketId { get; set; }
        public long? triageId { get; set; }


        //public virtual cardiovascularnote cardiovascularnote { get; set; }
        //public virtual establishment establishment { get; set; }
        public ICollection<Note> noteList { get; set; }
        //public virtual medic medic { get; set; }
        //public virtual note note2 { get; set; }
        //public virtual patient patient { get; set; }
        //public virtual triage triage { get; set; }
        //public virtual ticket ticket { get; set; }
        //public ICollection<Note> note { get; set; }
        public CardiovascularNote cardiovascularNote { get; set; }
        public Establishment establishment { get; set; }
        public ICollection<NoteDiagnosi> noteDiagnosis { get; set; }
        public ICollection<NoteExam> noteExams { get; set; }
        public ICollection<NoteMedicine> noteMedicines { get; set; }
        public ICollection<NoteReferral> noteReferrals { get; set; }
        public ICollection<CardiovascularSymptoms> cardiovascularSymptoms { get; set; }
        //public ICollection<NoteDiagnosi> NoteDiagnosis1 { get; set; }
        //public ICollection<NoteExam> NoteExams1 { get; set; }
        //public ICollection<NoteMedicine> NoteMedicines1 { get; set; }
        //public ICollection<NoteReferral> NoteReferrals1 { get; set; }

        public Triage triage { get; set; }
        public Ticket ticket { get; set; }
        public bool? isSignatureDraw { get; set; }
        public string signatuteText { get; set; }
        public byte[] signatuteDraw { get; set; }
    }

}
