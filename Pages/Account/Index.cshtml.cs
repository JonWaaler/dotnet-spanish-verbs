using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using spanish_verbs.Data;
using spanish_verbs.Models;

namespace spanish_verbs.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ApplicationUser ApplicationUser { get; private set; } = default!;

        public IndexModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var session = HttpContext.Session;
            var user = await _userManager.GetUserAsync(User);

            if(user == null)
            {
                return RedirectToPage("/index");
            }
            ApplicationUser = user;
            Console.WriteLine("Got users data");
            Console.WriteLine("Got users data");
            Console.WriteLine("Got users data");
            Console.WriteLine("Got users data");
            Console.WriteLine("Got users data");
            return Page();
        }
    }
}
