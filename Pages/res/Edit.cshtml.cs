using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using spanish_verbs.Data;
using spanish_verbs.Models;

namespace spanish_verbs.Pages.res
{
    public class EditModel : PageModel
    {
        private readonly spanish_verbs.Data.ApplicationDbContext _context;

        public EditModel(spanish_verbs.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ResultsData ResultsData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ResultsData == null)
            {
                return NotFound();
            }

            var resultsdata =  await _context.ResultsData.FirstOrDefaultAsync(m => m.Id == id);
            if (resultsdata == null)
            {
                return NotFound();
            }
            ResultsData = resultsdata;
           ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ResultsData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultsDataExists(ResultsData.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ResultsDataExists(int id)
        {
          return (_context.ResultsData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
