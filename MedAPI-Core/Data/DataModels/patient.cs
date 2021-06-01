using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class patient
    {
        public patient()
        {
            notes = new HashSet<note>();
            patient_allergies = new HashSet<patient_allergy>();
            patient_fatherbackgrounds = new HashSet<patient_fatherbackground>();
            patient_medic_permissions = new HashSet<patient_medic_permission>();
            patient_medicines = new HashSet<patient_medicine>();
            patient_motherbackgrounds = new HashSet<patient_motherbackground>();
            patient_personalbackgrounds = new HashSet<patient_personalbackground>();
            patient_symptoms = new HashSet<patient_symptom>();
        }

        public long id { get; set; }
        public long user_id { get; set; }
        public string alcohol { get; set; }
        public string bloodType { get; set; }
        public long? cigaretteNumber { get; set; }
        public string createdTicket { get; set; }
        public long? dormNumber { get; set; }
        public string educationalAttainment { get; set; }
        public bool electricity { get; set; }
        public long? fractureNumber { get; set; }
        public string fruitsVegetables { get; set; }
        public string highGlucose { get; set; }
        public string homeMaterial { get; set; }
        public string homeOwnership { get; set; }
        public string homeType { get; set; }
        public string occupation { get; set; }
        public string otherAllergies { get; set; }
        public string otherFatherBackground { get; set; }
        public string otherMedicines { get; set; }
        public string otherMotherBackground { get; set; }
        public string otherPersonalBackground { get; set; }
        public string physicalActivity { get; set; }
        public long? residentNumber { get; set; }
        public bool sewage { get; set; }
        public bool water { get; set; }
        public long departmentId { get; set; }
        public string race { get; set; }

        public virtual department department { get; set; }
        public virtual user user { get; set; }
        public virtual ICollection<note> notes { get; set; }
        public virtual ICollection<patient_allergy> patient_allergies { get; set; }
        public virtual ICollection<patient_fatherbackground> patient_fatherbackgrounds { get; set; }
        public virtual ICollection<patient_medic_permission> patient_medic_permissions { get; set; }
        public virtual ICollection<patient_medicine> patient_medicines { get; set; }
        public virtual ICollection<patient_motherbackground> patient_motherbackgrounds { get; set; }
        public virtual ICollection<patient_personalbackground> patient_personalbackgrounds { get; set; }
        public virtual ICollection<patient_symptom> patient_symptoms { get; set; }
    }
}
