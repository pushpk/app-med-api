﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Helpers
{
    public class HashPasswordHelperRepo
    {
        public static bool ValidatePassword(string password, string correctHash)
        {
            return true;
            //return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}
