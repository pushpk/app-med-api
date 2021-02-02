using MedAPI.Domain;
using System;

namespace MedAPI.Domain
{
    public class UserWithIdPw
    {
       
        public long id { get; set; }

        public string oldPasswordHash { get; set; }

        public string passwordHash { get; set; }

        public string token { get; set; }

    }
}