using System.ComponentModel.DataAnnotations;

namespace AddWords.Model
{
    public class Translations
    {
        [Key]
        public int IdTranslation { get; set; }
        public int WordsId { get; set; }
        public string Name { get; set; }
        public Words Words { get; set; }
    }
}
