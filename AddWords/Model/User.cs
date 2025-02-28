using System.ComponentModel.DataAnnotations.Schema;

namespace AddWords.Model
{
    [Table("users")]
    public class User
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Senha")]
        public string Senha { get; set; }

    }
}
