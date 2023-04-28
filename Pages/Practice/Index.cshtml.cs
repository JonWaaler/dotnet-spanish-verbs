using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using spanish_verbs.Data;
using spanish_verbs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace spanish_verbs.Pages._100verbs
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly spanish_verbs.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public IndexModel(spanish_verbs.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Word> Word { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Words != null)
            {
                Word = await _context.Words.ToListAsync();
            }

            HttpContext.Session.Clear();

            //await Utils.GetActiveStreak(_context, _userManager, HttpContext);
        }
        /*
        private async Task GetActiveStreak()
        {
            // Calculate Daily Active Streak
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
                return;
            var resultsData = await _context.ResultsData
                .Where(e => e.ApplicationUserId == user.Id)
                .ToListAsync();

            Console.WriteLine($"______________________________");
            Console.WriteLine($"Calculating User ActiveStreak");
            Console.WriteLine($"quizResCount: {resultsData.Count}");
            //Console.WriteLine($"______________________________");

            DateTime dateToday = new();
            dateToday = DateTime.Today;
            int activeStreak = 0;
            Console.WriteLine($"TodaysDate: {dateToday}");

            // Loop through data
            for (int i = resultsData.Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"___________________________");
                Console.WriteLine($"Index: {i}");
                Console.WriteLine($"activeStreak: {activeStreak}");

                if (resultsData[i].DateTaken == dateToday)
                {
                    Console.WriteLine($"Date Match: Streak++");
                    activeStreak++;
                    dateToday = dateToday.AddDays(-1);
                }
                // Check if duplicate
                else if (resultsData[i].DateTaken == dateToday.AddDays(1))
                {
                    Console.WriteLine($"Date Match (prevDate): Found Duplicate");

                }
                else
                {
                    // We can terminate the loop because at this point the
                    // the date stamp we are looking at is not the next day or a duplicate
                    Console.WriteLine("Date Match FAIL, streak stop");
                    break;
                }
            }

            user.CurrectActiveStreak = activeStreak;
            await _context.SaveChangesAsync();

            HttpContext.Session.SetInt32("Streak", activeStreak);
        }
        */
    }
}
