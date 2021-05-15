//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedAPI.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class triage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public triage()
        {
            this.notes = new HashSet<note>();
        }
    
        public long id { get; set; }
        public Nullable<double> abdominalPerimeter { get; set; }
        public Nullable<double> bmi { get; set; }
        public Nullable<double> breathingRate { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public bool deleted { get; set; }
        public string deposition { get; set; }
        public Nullable<double> diastolicBloodPressure { get; set; }
        public Nullable<double> glycemia { get; set; }
        public Nullable<double> hdlCholesterol { get; set; }
        public Nullable<double> heartRate { get; set; }
        public Nullable<double> heartRisk { get; set; }
        public string hunger { get; set; }
        public Nullable<double> hypertensionRisk { get; set; }
        public Nullable<double> ldlCholesterol { get; set; }
        public string modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedDate { get; set; }
        public Nullable<double> size { get; set; }
        public string sleep { get; set; }
        public Nullable<double> systolicBloodPressure { get; set; }
        public Nullable<double> temperature { get; set; }
        public string thirst { get; set; }
        public Nullable<double> totalCholesterol { get; set; }
        public string urine { get; set; }
        public Nullable<double> weight { get; set; }
        public string weightEvolution { get; set; }
        public Nullable<long> patient_id { get; set; }
        public Nullable<long> ticket_id { get; set; }
        public string speciality { get; set; }
        public Nullable<double> saturation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<note> notes { get; set; }
        public virtual ticket ticket { get; set; }
    }
}
