using AddWords.Services;
using System.ComponentModel.DataAnnotations.Schema;
using static BCrypt.Net.BCrypt;

namespace AddWords.Model
{
    [Table("users")]
    public class User : IHashedPassword
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Senha")]
        public string Senha { get; set; }

        private int Factor = 12;

        public string HashedPassword(string password)
        {
            var hash = HashPassword(password, Factor);
            return hash;
        }
    }
}
