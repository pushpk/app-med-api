using Repository.DTOs;
using System;

namespace Repository.DTOs
{
    public class UserWithIdPw
    {
       
        public long id { get; set; }

        public string oldPasswordHash { get; set; }

        public string passwordHash { get; set; }

        public string token { get; set; }

    }
}