using System.Text;

namespace test.Helpers
{
    public static class PasswordCreationHelper
    {
        public static string GenerateRandomPassword()
        {
            int length = 8;
            Random random = new Random();
            string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            string specialChars = "!@#$%^*()-_=+";
            string numericChars = "0123456789";
            StringBuilder password = new StringBuilder();

            // Add at least one character from each category
            password.Append(uppercaseChars[random.Next(uppercaseChars.Length)]);
            password.Append(lowercaseChars[random.Next(lowercaseChars.Length)]);
            password.Append(specialChars[random.Next(specialChars.Length)]);
            password.Append(numericChars[random.Next(numericChars.Length)]);

            // Fill the rest of the password with random characters
            for (int i = 4; i < length; i++)
            {
                string charSet = uppercaseChars + lowercaseChars + specialChars + numericChars;
                password.Append(charSet[random.Next(charSet.Length)]);
            }

            // Shuffle the password characters
            char[] passwordArray = password.ToString().ToCharArray();
            for (int i = 0; i < passwordArray.Length; i++)
            {
                int randIndex = random.Next(i, passwordArray.Length);
                char temp = passwordArray[i];
                passwordArray[i] = passwordArray[randIndex];
                passwordArray[randIndex] = temp;
            }

            return new string(passwordArray);
        }

        public static string GeneratePassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyz0123456789@#$%!";
            StringBuilder password = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(validChars.Length);
                password.Append(validChars[index]);
            }

            return password.ToString();
        }
    }
}
