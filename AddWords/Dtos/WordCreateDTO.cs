namespace AddWords.Dtos
{
    public class WordCreateDTO
    {
        public string Name { get; set; }
        public List<TranslationCreateDTO> Translation { get; set; }
    }
}
