using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using spanish_verbs.Data;
using spanish_verbs.Models;

namespace spanish_verbs
{
    public static class Utils
    {
        /// <summary>
        /// Takes a list of items and shuffles it using the
        /// Fisher-Yates algorithm
        /// </summary>
        /// <param name="list">List you want to randomize</param>
        public static void Shuffle(List<string> list)
        {
            Random rng = new Random();

            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                string temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        public static async Task GetActiveStreak(ApplicationDbContext _context, UserManager<ApplicationUser> _userManager, HttpContext _httpContext)
        {
            // Calculate Daily Active Streak
            var user = await _userManager.GetUserAsync(_httpContext.User);
            if (user == null)
                return;
            
            var resultsData = await _context.ResultsData
                .Where(e => e.ApplicationUserId == user.Id)
                .ToListAsync();


            if(resultsData.Count <= 0)
            {
                if(user != null)
                {
                    user.CurrectActiveStreak = 0;
                    await _context.SaveChangesAsync();
                }
                    
                _httpContext.Session.SetInt32("Streak", 0);

                return;
            }

            DateTime dateToday = new();
            dateToday = DateTime.Today;
            int activeStreak = 0;
            Console.WriteLine($"TodaysDate: {dateToday}");

            var lastEntryDate = resultsData[resultsData.Count - 1].DateTaken;

            // Check if the user has NOT taken their daily quiz
            if (lastEntryDate.Date != dateToday.Date)
            {
                // Check if last quiz matches yesterdays date
                var yesterdayDate = dateToday.AddDays(-1);
                if (lastEntryDate.Date == yesterdayDate.Date)
                {
                    dateToday = dateToday.AddDays(-1);
                }
                else
                {
                    activeStreak = 0;
                }
            }

            // Loop assumes that you have submitted you daily quiz
            for (int i = resultsData.Count - 1; i >= 0; i--)
            {
                if (resultsData[i].DateTaken.Date == dateToday.Date)
                {
                    Console.WriteLine($"Date Match: Streak++");
                    activeStreak++;
                    dateToday = dateToday.AddDays(-1);
                }
                // Check if duplicate
                else if (resultsData[i].DateTaken.Date == dateToday.AddDays(1).Date)
                {
                    Console.WriteLine($"Date Match (prevDate): Found Duplicate");
                }
                else
                {
                    break;
                }
            }

            user.CurrectActiveStreak = activeStreak;
            await _context.SaveChangesAsync();

            _httpContext.Session.SetInt32("Streak", activeStreak);
        }
    }
}
