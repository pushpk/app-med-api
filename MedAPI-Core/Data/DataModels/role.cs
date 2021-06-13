using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Data.DataModels
{
    public partial class role : IdentityRole<long>
    {
        public virtual ICollection<user> users { get; set; }
    }
}
