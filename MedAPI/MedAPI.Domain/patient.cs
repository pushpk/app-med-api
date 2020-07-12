using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
    public class Patient
    {
        public Patient()
        {
            //this.notes = new List<Note>();
            //this.triages = new List<Triage>();
            user = new User();
        }

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
        public long id { get; set; }

        //public List<Note> notes { get; set; }
        //public List<Triage> triages { get; set; }

        public Domain.User user { get; set; }
    }
}
