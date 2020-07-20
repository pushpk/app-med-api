using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAPI.models
{
    public class VitalFunctions
    {
        public double diastolic { get; set; }
        public double bmi { get; set; }
        public double cardiovascularRiskFramingham { get; set; }
        public double cardiovascularRiskReynolds { get; set; }
        public double hypertensionRisk { get; set; }
        public double diabetesRisk { get; set; }
        public double fractureRisk { get; set; }
        public double cardiovascularAge { get; set; }
        public double systolic { get; set; }
        public double heartRate { get; set; }
        public double respiratoryRate { get; set; }
        public double temperature { get; set; }
        public double waistCircumference { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
    }
}