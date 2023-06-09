using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using spanish_verbs.Data;
using spanish_verbs.Models;

namespace spanish_verbs.Pages.Account
{
    public class ActivityModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public IList<ResultsData> resultsData;

        public ApplicationUser ApplicationUser { get; set; }

        public ActivityModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
                return;
            ApplicationUser = user;
            resultsData = await _context.ResultsData
                .Include(r => r.ApplicationUser).ToListAsync();

            await Utils.GetActiveStreak(_context, _userManager, HttpContext);
        }
    }
}
