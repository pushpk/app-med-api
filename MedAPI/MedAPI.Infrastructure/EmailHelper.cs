﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Infrastructure
{
    public class EmailHelper
    {
        public enum EmailPurpose
        {
            EmailVerification,
            ForgotPassword,
            ApproveAccount,
            DenyAccount,
            PatientNotification
        }
    }
}
