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

        
        public bool QuestionChecked = false;
        public bool IsCorrect = false;


        public async Task OnGetAsync()
        {
            Console.WriteLine($"10Verbs - ON GET");

            QuestionChecked = HttpContext.Session.GetInt32("10VerbsQuestionChecked") == 1;
            IsCorrect = HttpContext.Session.GetInt32("10VerbsIsCorrect") == 1;

            // Creates a new session if there is none stored already
            StartSession();
        }

        /// <summary>
        /// Connects to a link element and is show when the quiz hits
        /// the final page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGetNewQuiz()
        {
            var session = HttpContext.Session;

            Console.WriteLine("SESSION CLEARED! get");
            session.Clear();
            return RedirectToPage();
        }



        public async Task<IActionResult> OnPostAsync()
        {
            var session = HttpContext.Session;

            GetData(session);




            QuestionChecked = session.GetInt32("10VerbsQuestionChecked") == 1;
            IsCorrect = session.GetInt32("10VerbsIsCorrect") == 1;

            // On user click post button...
            // if true: question has been checked and they want the next question
            // if false: the user wants to check their answer results
            if(QuestionChecked)
            {
                // A question was answered so we can go to next question
                QuestionsAnswered++;

                // Update the session data
                session.SetInt32("10VerbsQuestionsAnswered", QuestionsAnswered);
                session.SetInt32("10VerbsQuestionsAnsweredCorrect", QuestionsAnsweredCorrect);
                session.SetInt32("10VerbsQuestionChecked", 0);
                session.SetInt32("10VerbsIsCorrect", 0);


                // Next question
                // Check if quiz complete
                if (QuestionsAnswered >= 10)
                {
                    await CompleteQuiz();
                }
            }
            else
            {
                // Check if all model fields were filled in
                if (!ModelState.IsValid || _context.Words == null)
                    Answer = "";

                // Validate answer
                // Compare the users answer to both translations (temp)
                if (QuestionWords != null && QuestionsAnswered >= 0 && QuestionsAnswered < QuestionWords.Count)
                {
                    QuestionChecked= true;

                    if (QuestionWords[QuestionsAnswered].ToEnglish == Answer || QuestionWords[QuestionsAnswered].ToSpanish == Answer)
                    {
                        QuestionsAnsweredCorrect++;
                        IsCorrect = true;
                    }
                    else
                    {
                        IsCorrect = false;
                    }

                    session.SetInt32("10VerbsQuestionChecked", QuestionChecked == true ? 1: 0);
                    session.SetInt32("10VerbsIsCorrect", IsCorrect == true ? 1: 0);
                    Console.WriteLine("Saved QuestionChecked Results");
                }
            }




            // Clears the quiz form 
            return RedirectToPage();
        }

        /// <summary>
        /// We need to get and check if there was previous quiz data,
        /// this info tells us if the user is still doing a quiz or if they are done.
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="Exception"></exception>
        private void GetData(ISession session)
        {
            // Get users session data
            var verbs = session.GetString("10Verbs");
            var questionsAnswered = session.GetInt32("10VerbsQuestionsAnswered");
            var questionsAnsweredCorrect = session.GetInt32("10VerbsQuestionsAnsweredCorrect");

            // Get the list of words the user was using
            if (verbs == null || questionsAnswered == null || questionsAnsweredCorrect == null)
                throw new Exception($"10Verbs session returned null, On answer submission.");

            // Allows Razor pages to access this information
            QuestionWords = JsonConvert.DeserializeObject<List<Word>>(verbs);
            QuestionsAnswered = (int)questionsAnswered;
            QuestionsAnsweredCorrect = (int)questionsAnsweredCorrect;
        }

        private async void NextQuestion()
        {

        }

        private async void AnswerQuestion()
        {

        }

        /// <summary>
        /// Creates a results object connected to the user and
        /// submits the object to resultsData model
        /// </summary>
        /// <returns></returns>
        private async Task CompleteQuiz()
        {
            // Create Results object to add to users resultsData list
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ResultsData resultsData = new ResultsData();
            resultsData.ApplicationUserId = user.Id;
            resultsData.ApplicationUser = user;
            resultsData.TotalAnswered = QuestionsAnswered;
            resultsData.TotalAnsweredCorrect = QuestionsAnsweredCorrect;
            resultsData.DateTaken = DateTime.Today;
            _context.ResultsData.Add(resultsData);

            // Save db changes
            await _context.SaveChangesAsync();
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
