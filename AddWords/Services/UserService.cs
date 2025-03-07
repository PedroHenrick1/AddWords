using System.Text.RegularExpressions;
using AddWords.Infraestrutura;
using static BCrypt.Net.BCrypt;

namespace AddWords.Services
{
    public class UserService : IValidationUser
    {
        private int Factor = 12;

        public string HashedPassword(string password)
        {
            var hash = HashPassword(password, Factor);
            return hash;
        }

        public bool ValidateEmail(string email)
        {
            Regex strModelo = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            Match match = strModelo.Match(email);

            if (match.Success)
            {
                return true;
            }

            return false;
        }
    }
}
