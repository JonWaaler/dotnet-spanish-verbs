using Microsoft.AspNetCore.Identity;

namespace spanish_verbs.Models
{
    public class ApplicationUser : IdentityUser
    {

        // Statistic collection
        public DateTime DateAccountCreated { get; set; } = DateTime.Today;

        // List of test data
        public ICollection<ResultsData> ResultsData { get; set; } = new List<ResultsData>();

        public int CurrectActiveStreak = 0; // the active days streak

    }
}
