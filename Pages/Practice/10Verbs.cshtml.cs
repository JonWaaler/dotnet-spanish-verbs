using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using spanish_verbs.Data;
using spanish_verbs.Models;
using System;
using System.Diagnostics;
using System.Security.Claims;


// DEBUG MODEL
//var errors = ModelState
//    .Where(x => x.Value.Errors.Count > 0)
//    .Select(x => new { x.Key, x.Value.Errors })
//    .ToArray();
namespace spanish_verbs.Pages.Practice
{
    public class _10VerbsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public _10VerbsModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// A list of words with spanish and english translations. It's
        /// used in quizes where the razor page with cycle between the words to conduct a test
        /// </summary>
        public IList<Word> QuestionWords { get; set; } = default!;


        /// <summary>
        /// The answer received when the user submits their string
        /// </summary>
        [BindProperty]
        public string Answer { get; set; } = string.Empty;

        /// <summary>
        /// Amount of questions the user has answered
        /// </summary>
        public int QuestionsAnswered = 0;

        /// <summary>
        /// Amount of questions the user has answererd correct
        /// </summary>
        public int QuestionsAnsweredCorrect = 0;


        public async Task OnGetAsync()
        {
            Console.WriteLine($"10Verbs - ON GET");

            // Creates a new session if there is none stored already
            StartSession();


        }

        

        public async Task<IActionResult> OnPostAsync()
        {
            var session = HttpContext.Session;

            //Console.WriteLine($"10Verbs - ON POST");
            if (Answer == "Complete")
            {


                session.Clear();
                return RedirectToPage();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("___________________________");
                Console.WriteLine("QUIZ IN PROGRESS");
                Console.WriteLine("___________________________");

                // Get users session data
                var verbs = session.GetString("10Verbs");
                var questionsAnswered = session.GetInt32("10VerbsQuestionsAnswered");
                var questionsAnsweredCorrect = session.GetInt32("10VerbsQuestionsAnsweredCorrect");

                // Get the list of words the user was using
                if (verbs == null || questionsAnswered == null || questionsAnsweredCorrect == null)
                    throw new Exception($"10Verbs session returned null, On answer submission.");

                // Get Quiz info
                if (verbs != null)
                    QuestionWords = JsonConvert.DeserializeObject<List<Word>>(verbs);
                QuestionsAnswered = (int)questionsAnswered;
                QuestionsAnsweredCorrect = (int)questionsAnsweredCorrect;


                // Check if all model fields were filled in
                if (!ModelState.IsValid || _context.Words == null)
                {
                    throw new Exception($"ModelState invalid");

                    //return Page();
                }

                // Compare the users answer to both translations (temp)
                if (QuestionWords != null)
                    if (QuestionWords[QuestionsAnswered].ToEnglish == Answer || QuestionWords[QuestionsAnswered].ToSpanish == Answer)
                    {
                        Console.WriteLine($"Answer is Correct!");
                        QuestionsAnsweredCorrect++;

                    }
                    else
                    {
                        Console.WriteLine($"Wrong Answer");
                    }

                // A question was answered so we can go to next question
                QuestionsAnswered++;

                // Update the session data
                session.SetInt32("10VerbsQuestionsAnswered", QuestionsAnswered);
                session.SetInt32("10VerbsQuestionsAnsweredCorrect", QuestionsAnsweredCorrect);

                // Check if quiz complete
                if(QuestionsAnswered >= 10)
                {
                    //Console.WriteLine("");
                    //Console.WriteLine("");
                    //Console.WriteLine("___________________________");
                    //Console.WriteLine("QUIZ COMPLETED");
                    //Console.WriteLine("___________________________");

                    // Create Results object to add to users resultsData list
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    ResultsData resultsData = new ResultsData();
                    resultsData.ApplicationUserId = user.Id;
                    resultsData.ApplicationUser = user;
                    resultsData.TotalAnswered = QuestionsAnswered;
                    resultsData.TotalAnsweredCorrect = QuestionsAnsweredCorrect;
                    resultsData.DateTaken = DateTime.Today;
                    _context.ResultsData.Add(resultsData);

                    // Update Current active streak
                    //user.CurrectActiveStreak = user.CurrectActiveStreak + 1;

                    // Save db changes
                    await _context.SaveChangesAsync();

                    // DEBUG
                    //Console.WriteLine($"_________________________");
                    //Console.WriteLine($"RESULTS DATA SUBMITTED:");
                    //Console.WriteLine($"ApplicationUser: {user.Email}");
                    //Console.WriteLine($"TotalAnswered: {QuestionsAnswered}");
                    //Console.WriteLine($"TotalCorrect: {QuestionsAnsweredCorrect}");
                    //Console.WriteLine($"--------------------------");
                    //Console.WriteLine("");
                    //Console.WriteLine("");
                }


                // Clears the quiz form 
                return RedirectToPage();
                //return Page();
            }

        }


        /// <summary>
        /// Starts the quiz session
        /// Quiz data
        /// - QuestionsAnswered
        /// - QuestionsAnsweredCorrect
        /// - List<Words> randomWords
        /// This data should allow score calculations, displaying 
        /// </summary>
        private async void StartSession()
        {
            var session = HttpContext.Session;

            // get the UserId from the session
            var storedUserId = session.GetString("UserId");

            // get the current user's id
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var currentUserId = user.Id;

            // DEBUG USER SESSION
            //Console.WriteLine($"--User Information--");
            //Console.WriteLine($"StoredUserId: {storedUserId}");
            //Console.WriteLine($"CurrentUserId: {currentUserId}");

            // Check if there's a session already stored by using the UserId
            if (storedUserId != null)
            {
                // Check if the storedUserId we found matches the user currently logged in
                if (currentUserId == storedUserId)
                {
                    // Get users session data
                    var verbs = session.GetString("10Verbs");
                    var questionsAnswered = session.GetInt32("10VerbsQuestionsAnswered");
                    var questionsAnsweredCorrect = session.GetInt32("10VerbsQuestionsAnsweredCorrect");

                    // Get the list of words the user was using
                    if (verbs == null || questionsAnswered == null || questionsAnsweredCorrect == null)
                        throw new Exception($"10Verbs session returned null even though a user session was found. id:{currentUserId}");

                    // Get Quiz info
                    if(verbs != null)
                        QuestionWords = JsonConvert.DeserializeObject<List<Word>>(verbs);
                    QuestionsAnswered = (int)questionsAnswered;
                    QuestionsAnsweredCorrect = (int)questionsAnsweredCorrect;

                    // DEBUG
                    //Console.WriteLine("___________________________");
                    //Console.WriteLine("-----10Verbs Start-----");
                    //Console.WriteLine($"Verbs: {QuestionWords.Count}");
                    //Console.WriteLine($"Answered: {QuestionsAnswered}");
                    //Console.WriteLine($"Correct: {QuestionsAnsweredCorrect}");
                    //Console.WriteLine("___________________________");

                }
                else
                {
                    // UserId doesn't match session, clear the session, retry
                    Console.WriteLine($"CurrentUserId: {currentUserId}, doesn't match sessionStoreUserId: {storedUserId}");
                    session.Clear();
                    StartSession();
                }
            }
            // Else no session found so we will create a new session
            else
            {
                // Creates a new session save based on the userId
                CreateNewSession(currentUserId);
            }
        }

        /// <summary>
        /// Create a new session for the user, this will store
        /// the state for the quiz, keeping track of the user's
        /// stats to be sent to the db on quiz completion.
        /// </summary>
        /// <param name="curUserId">The user logged in</param>
        private async void CreateNewSession(string? curUserId)
        {
            var session = HttpContext.Session;

            // Store the user id in the session
            session.SetString("UserId", curUserId);

            // Get 10 random words
            List<Word> randomWords = await GetRandomWords(10);

            // Store words in the new session
            session.SetString("10Verbs", JsonConvert.SerializeObject(randomWords));
            session.SetInt32("10VerbsQuestionsAnswered", 0);
            session.SetInt32("10VerbsQuestionsAnsweredCorrect", 0);

            QuestionWords = randomWords;
            QuestionsAnswered = 0;
            QuestionsAnsweredCorrect = 0;
        }

        /// <summary>
        /// Generates random numbers and uses them to get a random word from the database
        /// </summary>
        /// <param name="amount">the amount of words in the list being returned</param>
        /// <returns>list of Words</returns>
        private async Task<List<Word>> GetRandomWords(int amount)
        {
            List<Word> randomWords = new();

            // Get size of word table
            Word lastWord = await _context.Words.OrderBy(e => e.Id).LastOrDefaultAsync();
            if (lastWord == null)
            {
                return new List<Word>();
            }
            int lastId = lastWord.Id;

            // Get words
            for (int i = 0; i < amount; i++)
            {
                // Get random word
                Random random = new();
                var randomWordId = random.Next(1, lastId + 1);

                // add word
                randomWords.Add(await GetWord(randomWordId));
            }

            // DEBUG: Print list of words
            //var s = JsonConvert.SerializeObject(randomWords, Formatting.Indented);
            //Console.WriteLine("CREATED WORDS LIST:");
            //Console.WriteLine(s);

            return randomWords;
        }

        // Get a word from the database
        private async Task<Word> GetWord(int id)
        {
            // Display word for the quiz
            return await _context.Words.FirstOrDefaultAsync(Words => Words.Id == id);
        }
    }
}
