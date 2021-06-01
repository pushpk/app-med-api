using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class note
    {
        public note()
        {
            cardiovascularnotes = new HashSet<cardiovascularnote>();
            notediagnoses = new HashSet<notediagnosis>();
            noteexams = new HashSet<noteexam>();
            notemedicines = new HashSet<notemedicine>();
            notereferrals = new HashSet<notereferral>();
        }

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
        public long? user_id { get; set; }
        public long? establishment_id { get; set; }
        public long? medic_id { get; set; }
        public long patient_id { get; set; }
        public long? ticket_id { get; set; }
        public long? triage_id { get; set; }
        public string status { get; set; }
        public string category { get; set; }
        public int? attached_attention { get; set; }
        public string prognosis { get; set; }
        public string notes { get; set; }
        public bool? isSignatureDraw { get; set; }
        public string signatuteText { get; set; }
        public byte[] signatuteDraw { get; set; }

        public virtual establishment establishment { get; set; }
        public virtual medic medic { get; set; }
        public virtual patient patient { get; set; }
        public virtual ticket ticket { get; set; }
        public virtual triage triage { get; set; }
        public virtual user user { get; set; }
        public virtual ICollection<cardiovascularnote> cardiovascularnotes { get; set; }
        public virtual ICollection<notediagnosis> notediagnoses { get; set; }
        public virtual ICollection<noteexam> noteexams { get; set; }
        public virtual ICollection<notemedicine> notemedicines { get; set; }
        public virtual ICollection<notereferral> notereferrals { get; set; }
    }
}
