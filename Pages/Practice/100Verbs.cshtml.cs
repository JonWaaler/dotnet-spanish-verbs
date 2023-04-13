using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using spanish_verbs.Data;
using spanish_verbs.Models;
using System;

namespace spanish_verbs.Pages.Practice
{
    public class _100VerbsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IList<Word> Words { get; set; } = default!;

        public _100VerbsModel(ApplicationDbContext context
            )
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Words = await _context.Words.ToListAsync();
        }
    }
}
