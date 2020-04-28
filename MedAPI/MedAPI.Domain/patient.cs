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
            this.Notes = new List<Note>();
            this.Triages = new List<Triage>();
            User = new User();
        }

        public string Alcohol { get; set; }
        public string BloodType { get; set; }
        public long? CigaretteNumber { get; set; }
        public string CreatedTicket { get; set; }
        public long? DormNumber { get; set; }
        public string EducationalAttainment { get; set; }
        public byte[] Electricity { get; set; }
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
        public byte[] Sewage { get; set; }
        public byte[] Water { get; set; }
        public long Id { get; set; }

        public List<Note> Notes { get; set; }
        public List<Triage> Triages { get; set; }

        public Domain.User User { get; set; }
    }
}
