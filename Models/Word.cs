namespace spanish_verbs.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string ToEnglish { get; set; } = null!;
        public string ToSpanish { get; set; } = null!;

    }
}
