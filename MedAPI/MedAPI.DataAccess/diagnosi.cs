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
    
    public partial class diagnosi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public diagnosi()
        {
            this.notediagnosis = new HashSet<notediagnosi>();
        }
    
        public long id { get; set; }
        public string code { get; set; }
        public byte[] deleted { get; set; }
        public string title { get; set; }
        public long chapter_id { get; set; }
    
        public virtual chapter chapter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notediagnosi> notediagnosis { get; set; }
    }
}
