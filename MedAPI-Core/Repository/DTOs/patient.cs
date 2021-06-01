using Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
    public class Patient
    {
        public Patient()
        {
            //this.notes = new List<Note>();
            //this.triages = new List<Triage>();
            this.allergiesList = new List<PatientAllergies>();
            this.medicinesList = new List<PatientMedicines>();
            this.personalBackgroundList = new List<PatientPersonalBackgrounds>();
            this.patientFatherbackgroundList = new List<PatientFatherbackgrounds>();
            this.patientMotherbackgroundList = new List<PatientMotherbackgrounds>();
            patientMedicPermission = new List<PatientMedicPermission>();
            user = new User();
        }

        public string alcohol { get; set; }
        public string bloodType { get; set; }
        public string race { get; set; }
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
        public List<PatientAllergies> allergiesList { get; set; }
        public string otherAllergies { get; set; }
        public List<PatientFatherbackgrounds> patientFatherbackgroundList { get; set; }
        public string otherFatherBackground { get; set; }
        public List<PatientMedicines> medicinesList { get; set; }
        public string otherMedicines { get; set; }
        public List<PatientPersonalBackgrounds> personalBackgroundList { get; set; }
        public string otherPersonalBackground { get; set; }
        public List<PatientMotherbackgrounds> patientMotherbackgroundList { get; set; }
        public string otherMotherBackground { get; set; }


        public string physicalActivity { get; set; }
        public long? residentNumber { get; set; }
        public bool sewage { get; set; }
        public bool water { get; set; }
        public long id { get; set; }
        public long userId { get; set; }
        public long departmentId { get; set; }
        //public List<Note> notes { get; set; }
        //public List<Triage> triages { get; set; }
        public User user { get; set; }
        public List<PatientMedicPermission> patientMedicPermission { get; set; }
    }
}
