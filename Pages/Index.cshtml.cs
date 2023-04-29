using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using spanish_verbs.Data;
using spanish_verbs.Models;
using static Azure.Core.HttpHeader;

namespace spanish_verbs.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public int DailyActiveStreak { get; set; } = 0;
        public ApplicationUser applicationUser { get; set; } = default!;
        public IList<Word> Words { get; set; } = default!;

        public IndexModel(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            ILogger<IndexModel> logger)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Words = await _context.Words.ToListAsync();
        }
    }
}