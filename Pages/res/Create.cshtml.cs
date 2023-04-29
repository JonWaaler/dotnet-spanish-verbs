using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using spanish_verbs.Data;
using spanish_verbs.Models;

namespace spanish_verbs.Pages.res
{
    public class CreateModel : PageModel
    {
        private readonly spanish_verbs.Data.ApplicationDbContext _context;

        public CreateModel(spanish_verbs.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ResultsData ResultsData { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ResultsData == null || ResultsData == null)
            {
                return Page();
            }

            _context.ResultsData.Add(ResultsData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
