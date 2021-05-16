﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Triage
    {
        public Triage()
        {
            Notes = new HashSet<Note>();
        }

        public long Id { get; set; }
        public double? AbdominalPerimeter { get; set; }
        public double? Bmi { get; set; }
        public double? BreathingRate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool Deleted { get; set; }
        public string Deposition { get; set; }
        public double? DiastolicBloodPressure { get; set; }
        public double? Glycemia { get; set; }
        public double? HdlCholesterol { get; set; }
        public double? HeartRate { get; set; }
        public double? HeartRisk { get; set; }
        public string Hunger { get; set; }
        public double? HypertensionRisk { get; set; }
        public double? LdlCholesterol { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public double? Size { get; set; }
        public string Sleep { get; set; }
        public double? SystolicBloodPressure { get; set; }
        public double? Temperature { get; set; }
        public string Thirst { get; set; }
        public double? TotalCholesterol { get; set; }
        public string Urine { get; set; }
        public double? Weight { get; set; }
        public string WeightEvolution { get; set; }
        public long? PatientId { get; set; }
        public long? TicketId { get; set; }
        public string Speciality { get; set; }
        public double? Saturation { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
