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
    
    public partial class patient_symptoms
    {
        public long id { get; set; }
        public long patient_id { get; set; }
        public Nullable<long> symptoms_id { get; set; }
        public string custom_symptom { get; set; }
    
        public virtual patient patient { get; set; }
        public virtual symptom symptom { get; set; }
    }
}
