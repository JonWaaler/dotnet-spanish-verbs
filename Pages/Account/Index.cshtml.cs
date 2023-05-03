using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using spanish_verbs.Data;
using spanish_verbs.Models;

namespace spanish_verbs.Pages.Account
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ApplicationUser ApplicationUser { get; private set; } = default!;
        public IList<ResultsData> Results { get; private set; }

        public IndexModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            //var session = HttpContext.Session;
            var user = await _userManager.GetUserAsync(User);
            var resultsData = await _context.ResultsData
                .Include(r => r.ApplicationUser).ToListAsync();

            if (user == null)
                return RedirectToPage("/index");

            ApplicationUser = user;

            if(resultsData == null)
                return RedirectToPage("/index");

            Results = resultsData;

            //await Utils.GetActiveStreak(_context, _userManager, HttpContext);


            return Page();
        }
    }
}
