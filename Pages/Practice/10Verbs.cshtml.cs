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
        /// The question information (Holds the translations)
        /// </summary>
        public Word QuestionWord { get; set; } = default!;
        public IList<Word> QuestionWords { get; set; } = default!;

        /// <summary>
        /// The answer received when the user submits their string
        /// </summary>
        [BindProperty]
        public string Answer { get; set; } = string.Empty;

        // We need to track so we know when to end the test
        // && What score the user got
        public int QuestionsAnswered = 0;
        public int QuestionsAnsweredCorrect = 0;

        // Random id of the word selected for the quiz
        private int RandomWordId;

        public async Task OnGetAsync()
        {
            Console.WriteLine($"10Verbs - ON GET");

            // Creates a new session if there is none stored already
            StartSession();

            Console.WriteLine($"GET END");

            // Collect model errors for debug
            //var errors = ModelState
            //    .Where(x => x.Value.Errors.Count > 0)
            //    .Select(x => new { x.Key, x.Value.Errors })
            //    .ToArray();

            // Serialize rand word
            //string randomWord = JsonConvert.SerializeObject(QuestionWord);
            //Console.WriteLine($"RandomWord-Serialized: {randomWord}");

            // Get session data
            //QuestionsAnswered = Convert.ToInt32(HttpContext.Session.GetInt32("QuestionsAnswered"));
            //QuestionsAnsweredCorrect = Convert.ToInt32(HttpContext.Session.GetInt32("QuestionsAnsweredCorrect"));
            //Console.WriteLine($"QuestionsAnsed: {QuestionsAnswered}");


            // Set session state
            //Request.HttpContext.Session.SetString("QuestionWord", randomWord);

            //Console.WriteLine($"RandomWord: {QuestionWord.ToEnglish}");
            //Console.WriteLine($"RandomWord: {QuestionWord.ToSpanish}");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine($"10Verbs - ON POST");

            var session = HttpContext.Session;

            // Get users session data
            var verbs = session.GetString("10Verbs");
            var questionsAnswered = session.GetInt32("10VerbsQuestionsAnswered");
            var questionsAnsweredCorrect = session.GetInt32("10VerbsQuestionsAnsweredCorrect");

            // Get the list of words the user was using
            if (verbs == null || questionsAnswered == null || questionsAnsweredCorrect == null)
                throw new Exception($"10Verbs session returned null, On answer submission.");

            // Get Quiz info
            QuestionWords = JsonConvert.DeserializeObject<List<Word>>(verbs);
            QuestionsAnswered = (int)questionsAnswered;
            QuestionsAnsweredCorrect = (int)questionsAnsweredCorrect;


            // Collect model errors for debug
            //var errors = ModelState
            //    .Where(x => x.Value.Errors.Count > 0)
            //    .Select(x => new { x.Key, x.Value.Errors })
            //    .ToArray();

            // Check if all model fields were filled in
            if (!ModelState.IsValid || _context.Words == null)
            {
                throw new Exception($"ModelState invalid");

                return Page();
            }

            // Compare the users answer to both translations (temp)
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

            session.SetInt32("10VerbsQuestionsAnswered", QuestionsAnswered);
            session.SetInt32("10VerbsQuestionsAnsweredCorrect", QuestionsAnsweredCorrect);

            return Page();
        }

        /// <summary>
        /// Starts the quiz session
        /// </summary>
        /// Quiz data
        /// - QuestionsAnswered
        /// - QuestionsAnsweredCorrect
        /// - List<Words> randomWords
        /// This data should allow score calculations, displaying 
        /// <param name=""></param>
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
                    if(verbs == null || questionsAnswered == null || questionsAnsweredCorrect == null)
                        throw new Exception($"10Verbs session returned null even though a user session was found. id:{currentUserId}");

                    // Get Quiz info
                    QuestionWords = JsonConvert.DeserializeObject<List<Word>>(verbs);
                    QuestionsAnswered = (int)questionsAnswered;
                    QuestionsAnsweredCorrect = (int)questionsAnsweredCorrect;


                    Console.WriteLine("10Verbs - Recieved Data");
                    Console.WriteLine($"Verbs: {QuestionWords}");
                    Console.WriteLine($"Answered: {QuestionsAnswered}");
                    Console.WriteLine($"Correct: {QuestionsAnsweredCorrect}");
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
                createNewSession(currentUserId);
            }
        }

        /// <summary>
        /// Create a new session for the user, this will store
        /// the state for the quiz, keeping track of the user's
        /// stats to be sent to the db on quiz completion.
        /// </summary>
        /// <param name="curUserId"></param>
        private async void createNewSession(string? curUserId)
        {
            var session = HttpContext.Session;

            // Store the user id in the session
            session.SetString("UserId", curUserId);

            // Get 10 random words
            List<Word> randomWords = await getRandomWords(10);

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
        private async Task<List<Word>> getRandomWords(int amount)
        {
            List<Word> randomWords = new List<Word>();

            // Get size of word table
            Word lastWord = await _context.Words.OrderBy(e => e.Id).LastOrDefaultAsync();
            int lastId = lastWord.Id;

            // Get words
            for (int i = 0; i < amount; i++)
            {
                // Get random word
                Random random = new Random();
                RandomWordId = random.Next(1, lastId + 1);

                // add word
                randomWords.Add(await getWord(RandomWordId));
            }

            // DEBUG: Print list of words
            var s = JsonConvert.SerializeObject(randomWords, Formatting.Indented);
            Console.WriteLine("CREATED WORDS LIST:");
            Console.WriteLine(s);

            return randomWords;
        }

        // Get a word from the database
        private async Task<Word> getWord(int id)
        {
            // Display word for the quiz
            return await _context.Words.FirstOrDefaultAsync(Words => Words.Id == id);
        }
    }
}