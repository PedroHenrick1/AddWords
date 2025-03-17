using System.ComponentModel.DataAnnotations;

namespace AddWords.Model
{
    public class Words
    {
        [Key]
        public int IdWord { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<Translations> Translation { get; set; }

        public User user { get; set; }
    }
}
