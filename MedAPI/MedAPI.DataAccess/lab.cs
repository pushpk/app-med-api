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
    
    public partial class lab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lab()
        {
            this.lab_upload_result = new HashSet<lab_upload_result>();
        }
    
        public long id { get; set; }
        public long user_id { get; set; }
        public string parentCompany { get; set; }
        public string labName { get; set; }
        public long ruc { get; set; }
        public bool IsFreezed { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDenied { get; set; }
    
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lab_upload_result> lab_upload_result { get; set; }
    }
}
