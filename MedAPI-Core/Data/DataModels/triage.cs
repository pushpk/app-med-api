using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class triage
    {
        public triage()
        {
            notes = new HashSet<note>();
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
        public long? patient_id { get; set; }
        public long? ticket_id { get; set; }
        public string speciality { get; set; }
        public double? saturation { get; set; }

        public virtual ticket ticket { get; set; }
        public virtual ICollection<note> notes { get; set; }
    }
}
