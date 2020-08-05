using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
    public class Triage
    {
        public Triage()
        {
            //notes = new List<Note>();
        }

        public long id { get; set; }
        public double? abdominalPerimeter { get; set; }
        public double? bmi { get; set; }
        public double? breathingRate { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public bool deleted { get; set; }
        public string deposition { get; set; }
        public double? diastolicBloodPressure { get; set; }
        public double? glycemia { get; set; }
        public double? hdlCholesterol { get; set; }
        public double? heartRate { get; set; }
        public double? heartRisk { get; set; }
        public string hunger { get; set; }
        public double? hypertensionRisk { get; set; }
        public double? ldlCholesterol { get; set; }
        public string modifiedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public double? size { get; set; }
        public string sleep { get; set; }
        public double? systolicBloodPressure { get; set; }
        public double? temperature { get; set; }
        public string thirst { get; set; }
        public double? totalCholesterol { get; set; }
        public string urine { get; set; }
        public double? weight { get; set; }
        public string weightEvolution { get; set; }
        public long? patientId { get; set; }
        public long? ticketId { get; set; }

        public static implicit operator Triage(List<Triage> v)
        {
            throw new NotImplementedException();
        }

        //public List<Note> notes { get; set; }
    }
}
