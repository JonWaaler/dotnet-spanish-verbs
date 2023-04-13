using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using spanish_verbs.Data;
using spanish_verbs.Models;
using System;

namespace spanish_verbs.Pages.Practice
{
    public class _10VerbsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IList<Word> Words { get; set; } = default!;

        public _10VerbsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Word Word { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Words = await _context.Words.ToListAsync();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Words == null || Word == null)
            {
                return Page();
            }

            _context.Words.Add(Word);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
