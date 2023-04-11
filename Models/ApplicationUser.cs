using Microsoft.AspNetCore.Identity;

namespace spanish_verbs.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ResultsData ResultsData { get; set; } = default!;

    }
}
