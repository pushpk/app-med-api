﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAPI.models
{
    public class Diagnosis
    {
        public long diagnosisId { get; set; }
        public List[] list { get; set; }
        public string observations { get; set; }
    }
}