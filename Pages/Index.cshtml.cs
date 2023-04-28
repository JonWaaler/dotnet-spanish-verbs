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
            //var user = await _userManager.GetUserAsync(HttpContext.User);

            //if (user == null)
            //    return;

            //Words = await _context.Words.ToListAsync();

            //await Utils.GetActiveStreak(_context, _userManager, HttpContext);
        }

        //private async Task GetActiveStreak()
        //{
        //    // Calculate Daily Active Streak
        //    var user = await _userManager.GetUserAsync(HttpContext.User);
        //    if (user == null)
        //        return;
        //    var resultsData = await _context.ResultsData
        //        .Where(e => e.ApplicationUserId == user.Id)
        //        .ToListAsync();

        //    //Console.WriteLine($"______________________________");
        //    //Console.WriteLine($"Calculating User ActiveStreak");
        //    //Console.WriteLine($"quizResCount: {resultsData.Count}");
        //    //Console.WriteLine($"______________________________");

        //    DateTime dateToday = new();
        //    dateToday = DateTime.Today;
        //    int activeStreak = 0;
        //    Console.WriteLine($"TodaysDate: {dateToday}");

        //    var lastEntryDate = resultsData[resultsData.Count - 1].DateTaken;

        //    // Check if the user has NOT taken their daily quiz
        //    if (lastEntryDate != dateToday)
        //    {
        //        // Check if last quiz matches yesterdays date
        //        if (lastEntryDate != dateToday.AddDays(-1))
        //        {
        //            activeStreak = 0;
        //        }
        //        else
        //        {
        //            // The user hasn't taken their daily test, however
        //            // the user did yesterdays
        //            dateToday = dateToday.AddDays(-1);
        //        }
        //    }

        //    // Loop assumes that you have submitted you daily quiz
        //    for (int i = resultsData.Count - 1; i >= 0; i--)
        //    {
        //        //Console.WriteLine($"___________________________");
        //        //Console.WriteLine($"Index: {i}");
        //        //Console.WriteLine($"activeStreak: {activeStreak}");

        //        if (resultsData[i].DateTaken == dateToday)
        //        {
        //            Console.WriteLine($"Date Match: Streak++");
        //            activeStreak++;
        //            dateToday = dateToday.AddDays(-1);
        //        }
        //        // Check if duplicate
        //        else if (resultsData[i].DateTaken == dateToday.AddDays(1))
        //        {
        //            Console.WriteLine($"Date Match (prevDate): Found Duplicate");

        //        }
        //        else
        //        {
        //            // We can terminate the loop because at this point the
        //            // the date stamp we are looking at is not the next day or a duplicate
        //            Console.WriteLine("Date Match FAIL, streak stop");
        //            break;
        //        }
        //    }

        //    user.CurrectActiveStreak = activeStreak;
        //    await _context.SaveChangesAsync();

        //    HttpContext.Session.SetInt32("Streak", activeStreak);
        //}
    }
}