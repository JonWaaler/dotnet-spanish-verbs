namespace spanish_verbs.Models
{
    /// <summary>
    /// Eact test will end and fill out and submit a ResultsData object
    /// </summary>
    public class ResultsData
    {
        public int Id { get; set; }
        public int TotalAnswered { get; set; } = 0;
        public int TotalAnsweredCorrect { get; set; } = 0;

        public DateTime DateTaken { get; set; } = default!;

        // The user who owns these stats
        public string ApplicationUserId { get; set; } = default!;
        public ApplicationUser ApplicationUser { get; set; } = default!;

        //public ResultsData()
        //{
        //    DateTaken = DateTime.Today;
        //}
    }
}
