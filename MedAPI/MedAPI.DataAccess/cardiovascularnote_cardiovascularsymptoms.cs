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
    
    public partial class cardiovascularnote_cardiovascularsymptoms
    {
        public long id { get; set; }
        public long cardiovascularNote_id { get; set; }
        public string cardiovascularSymptoms { get; set; }
        public bool isDelete { get; set; }
    
        public virtual cardiovascularnote cardiovascularnote { get; set; }
    }
}
