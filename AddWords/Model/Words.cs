using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AddWords.Model
{
    public class Words
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<Translations> Translations { get; set; }

        [JsonIgnore]
        public User user { get; set; }
    }
}
