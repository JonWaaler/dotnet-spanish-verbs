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
    public class DetailsModel : PageModel
    {
        private readonly spanish_verbs.Data.ApplicationDbContext _context;

        public DetailsModel(spanish_verbs.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public ResultsData ResultsData { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ResultsData == null)
            {
                return NotFound();
            }

            var resultsdata = await _context.ResultsData.FirstOrDefaultAsync(m => m.Id == id);
            if (resultsdata == null)
            {
                return NotFound();
            }
            else 
            {
                ResultsData = resultsdata;
            }
            return Page();
        }
    }
}
