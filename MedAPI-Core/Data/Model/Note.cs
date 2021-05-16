using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Note
    {
        public Note()
        {
            Cardiovascularnotes = new HashSet<Cardiovascularnote>();
            Notediagnoses = new HashSet<Notediagnosis>();
            Noteexams = new HashSet<Noteexam>();
            Notemedicines = new HashSet<Notemedicine>();
            Notereferrals = new HashSet<Notereferral>();
        }

        public long Id { get; set; }
        public string Age { get; set; }
        public bool Completed { get; set; }
        public bool Control { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool Deleted { get; set; }
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
        public long? UserId { get; set; }
        public long? EstablishmentId { get; set; }
        public long? MedicId { get; set; }
        public long PatientId { get; set; }
        public long? TicketId { get; set; }
        public long? TriageId { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public int? AttachedAttention { get; set; }
        public string Prognosis { get; set; }
        public string Notes { get; set; }
        public bool? IsSignatureDraw { get; set; }
        public string SignatuteText { get; set; }
        public byte[] SignatuteDraw { get; set; }

        public virtual Establishment Establishment { get; set; }
        public virtual Medic Medic { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual Triage Triage { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Cardiovascularnote> Cardiovascularnotes { get; set; }
        public virtual ICollection<Notediagnosis> Notediagnoses { get; set; }
        public virtual ICollection<Noteexam> Noteexams { get; set; }
        public virtual ICollection<Notemedicine> Notemedicines { get; set; }
        public virtual ICollection<Notereferral> Notereferrals { get; set; }
    }
}
