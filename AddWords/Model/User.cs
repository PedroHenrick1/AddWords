using AddWords.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using System.Text.RegularExpressions;
using static BCrypt.Net.BCrypt;

namespace AddWords.Model
{
    public class User : IValidationUser
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

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
