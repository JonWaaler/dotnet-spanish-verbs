namespace spanish_verbs.Models
{
    /// <summary>
    /// Each user will retain a ResultsData object.
    /// This will store information about how the user
    /// has performed in the tests.
    /// </summary>
    public class ResultsData
    {
        public int Id { get; set; }
        public int TotalAnswered { get; set; } = 0;
        public int TotalAnsweredCorrect { get; set; } = 0;
        public int TotalTests { get; set; } = 0;
        public int TotalTestsFinished { get; set; } = 0;

        // User relation
        public string ApplicationUserId { get; set; } = default!;
        public ApplicationUser ApplicationUser { get; set; } = default!;
    }
}
