using Microsoft.AspNetCore.Identity;

namespace spanish_verbs.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ResultsData ResultsData { get; set; } = default!;

        // Statistic collection
        public DateTime DateJoined { get; set; } = DateTime.Now;
        public List<DateTime> DaysActive { get; set; } = default!;
        public int CurrectActiveStreak = 0; // the active days streak
    }
}
