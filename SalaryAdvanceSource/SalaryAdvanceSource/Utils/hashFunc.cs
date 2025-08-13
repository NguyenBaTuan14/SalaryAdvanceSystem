using System.Runtime.CompilerServices;

namespace SalaryAdvanceSource.utils
{
    public static class hashFunc
    {
        public static string hashString(string input)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(input);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public static DateTime GetCyrrenttime(this DateTime inputdate)
        {
            return DateTime.Now;
        }

        public static string abc(this string input)
        {
            DateTime.UtcNow.GetCyrrenttime();
            return input;
        }
    }
}
