namespace MedAPI.Infrastructure
{
    public class HashPasswordHelper
    {
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }

        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                var defaultPassword = "$2a$10$embGpT0ph3zWV7qhw553s.BHFbUGFbuBKCt2BJ2CwkdXRNEJIcoJu";
                return BCrypt.Net.BCrypt.HashPassword(defaultPassword);
            }
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }

    }
}
