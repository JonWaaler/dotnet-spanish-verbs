using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using spanish_verbs.Data;
using spanish_verbs.Models;

namespace spanish_verbs.Pages.res
{
    public class IndexModel : PageModel
    {
        private readonly spanish_verbs.Data.ApplicationDbContext _context;

        public IndexModel(spanish_verbs.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ResultsData> ResultsData { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ResultsData != null)
            {
                ResultsData = await _context.ResultsData
                .Include(r => r.ApplicationUser).ToListAsync();
            }
        }
    }
}
