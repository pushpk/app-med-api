namespace Services.Helpers
{
    public class HashPasswordHelper
    {
        private static string GetRandomSalt()
        {
            return "";
           // return BCrypt.Net.BCrypt.GenerateSalt();
        }

        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                //var defaultPassword = "$2a$10$yYVYoz8rpthvx1Qh5wydxu0IGslC13Ul.lxWvOgKLcu4fTTC04ohu";
                //return BCrypt.Net.BCrypt.HashPassword(defaultPassword);
            }
            return "";
            //return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static string HashToken(System.Guid token)
        {
            return "";
            //return BCrypt.Net.BCrypt.HashString(token.ToString());
        }

        public static bool ValidatePassword(string password, string correctHash)
        {
            return true;
            //return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }

    }
}
