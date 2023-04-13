using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using spanish_verbs.Data;
using spanish_verbs.Models;

namespace spanish_verbs.Pages._100verbs
{
    public class DetailsModel : PageModel
    {
        private readonly spanish_verbs.Data.ApplicationDbContext _context;

        public DetailsModel(spanish_verbs.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Word Word { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Words == null)
            {
                return NotFound();
            }

            var word = await _context.Words.FirstOrDefaultAsync(m => m.Id == id);
            if (word == null)
            {
                return NotFound();
            }
            else 
            {
                Word = word;
            }
            return Page();
        }
    }
}
