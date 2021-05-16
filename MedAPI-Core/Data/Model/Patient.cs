using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Notes = new HashSet<Note>();
            PatientAllergies = new HashSet<PatientAllergy>();
            PatientFatherbackgrounds = new HashSet<PatientFatherbackground>();
            PatientMedicPermissions = new HashSet<PatientMedicPermission>();
            PatientMedicines = new HashSet<PatientMedicine>();
            PatientMotherbackgrounds = new HashSet<PatientMotherbackground>();
            PatientPersonalbackgrounds = new HashSet<PatientPersonalbackground>();
            PatientSymptoms = new HashSet<PatientSymptom>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string Alcohol { get; set; }
        public string BloodType { get; set; }
        public long? CigaretteNumber { get; set; }
        public string CreatedTicket { get; set; }
        public long? DormNumber { get; set; }
        public string EducationalAttainment { get; set; }
        public bool Electricity { get; set; }
        public long? FractureNumber { get; set; }
        public string FruitsVegetables { get; set; }
        public string HighGlucose { get; set; }
        public string HomeMaterial { get; set; }
        public string HomeOwnership { get; set; }
        public string HomeType { get; set; }
        public string Occupation { get; set; }
        public string OtherAllergies { get; set; }
        public string OtherFatherBackground { get; set; }
        public string OtherMedicines { get; set; }
        public string OtherMotherBackground { get; set; }
        public string OtherPersonalBackground { get; set; }
        public string PhysicalActivity { get; set; }
        public long? ResidentNumber { get; set; }
        public bool Sewage { get; set; }
        public bool Water { get; set; }
        public long DepartmentId { get; set; }
        public string Race { get; set; }

        public virtual Department Department { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<PatientAllergy> PatientAllergies { get; set; }
        public virtual ICollection<PatientFatherbackground> PatientFatherbackgrounds { get; set; }
        public virtual ICollection<PatientMedicPermission> PatientMedicPermissions { get; set; }
        public virtual ICollection<PatientMedicine> PatientMedicines { get; set; }
        public virtual ICollection<PatientMotherbackground> PatientMotherbackgrounds { get; set; }
        public virtual ICollection<PatientPersonalbackground> PatientPersonalbackgrounds { get; set; }
        public virtual ICollection<PatientSymptom> PatientSymptoms { get; set; }
    }
}
