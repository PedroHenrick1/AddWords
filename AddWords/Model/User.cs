using AddWords.Infraestrutura;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace AddWords.Model
{
    public class User
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
