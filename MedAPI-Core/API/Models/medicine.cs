﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Medicine
    {
        public long medicineId { get; set; }
        public long id { get; set; }
        public string name { get; set; }
        public bool isDeleted { get; set; }
    }
}