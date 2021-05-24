﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Note
    {
        public long id { get; set; }
        public long patientId { get; set; }
        public long ticketId { get; set; }
        public long triageId { get; set; }
        public long medicId { get; set; }
        public long userId { get; set; }
        public Symptoms symptoms { get; set; }
        public PhysicalExam physicalExam { get; set; }
        public Diagnosis diagnosis { get; set; }
        public Exams exams { get; set; }
        public Treatments treatments { get; set; }
        public Interconsultations interconsultation { get; set; }
        public Referrals referrals { get; set; }
        public Triage triage { get; set; }
        public Todo todo { get; set; }
        public string otherSymptoms { get; set; }
        public string selectedSpecialty { get; set; }
        public string specialty { get; set; }
        public CardiovascularNote cardiovascularNote { get; set; }
        public List<CardiovascularSymptoms> cardiovascularSymptoms { get; set; }


        public Nullable<bool> isSignatureDraw { get; set; }
        public string signatuteText { get; set; }
        public byte[] signatuteDraw { get; set; }

        public string status { get; set; }

        

        public string category { get; set; }

        public int attached_attention { get; set; }

        public string prognosis { get; set; }
        public string notes { get; set; }

    }
}