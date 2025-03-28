﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AddWords.Model
{
    public class Translations
    {
        [Key]
        public int IdTranslation { get; set; }
        public int WordsId { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        [JsonIgnore]
        public Words Words { get; set; }
    }
}
