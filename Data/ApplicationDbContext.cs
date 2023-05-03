using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using spanish_verbs.Models;
namespace spanish_verbs.Data;


public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>()
                .HasMany(e => e.ResultsData)
                .WithOne(e => e.ApplicationUser)
                .HasForeignKey(e => e.ApplicationUserId)
                .IsRequired();

        builder.Entity<Word>().HasData(infinitive_verbs);

        
    }

    public DbSet<ApplicationUser> ApplicationUser { get; set; } = default!;
    public DbSet<ResultsData> ResultsData { get; set; } = default!;
    public DbSet<Word> Words { get; set; } = default!;

    //private static ResultsData[] fake_entries = new ResultsData[]
    //{
    //    new ResultsData { }
    //};

    /// <summary>
    /// 100 Infinitive verbs
    /// </summary>
    private static Word[] infinitive_verbs = new Word[]
    {
           new Word {Id = 1, ToEnglish = "to be", ToSpanish = "ser" },
           new Word { Id = 2, ToEnglish = "to be", ToSpanish = "estar" },
           new Word { Id = 3, ToEnglish = "to have", ToSpanish = "tener" },
           new Word { Id = 4, ToEnglish = "to do", ToSpanish = "hacer" },
           new Word { Id = 5, ToEnglish = "to go", ToSpanish = "ir" },
           new Word { Id = 6, ToEnglish = "to want", ToSpanish = "querer" },
           new Word { Id = 7, ToEnglish = "to say", ToSpanish = "decir" },
           new Word { Id = 8, ToEnglish = "to see", ToSpanish = "ver" },
           new Word { Id = 9, ToEnglish = "to know", ToSpanish = "saber" },
           new Word { Id = 10, ToEnglish = "to be able to", ToSpanish = "poder" },
           new Word { Id = 11, ToEnglish = "to think", ToSpanish = "pensar" },
           new Word { Id = 12, ToEnglish = "to take", ToSpanish = "tomar" },
           new Word { Id = 13, ToEnglish = "to want", ToSpanish = "desear" },
           new Word { Id = 14, ToEnglish = "to come", ToSpanish = "venir" },
           new Word { Id = 15, ToEnglish = "to put", ToSpanish = "poner" },
           new Word { Id = 16, ToEnglish = "to speak", ToSpanish = "hablar" },
           new Word { Id = 17, ToEnglish = "to give", ToSpanish = "dar" },
           new Word { Id = 18, ToEnglish = "to find", ToSpanish = "encontrar" },
           new Word { Id = 19, ToEnglish = "to tell", ToSpanish = "contar" },
           new Word { Id = 20, ToEnglish = "to work", ToSpanish = "trabajar" },
           new Word { Id = 21, ToEnglish = "to call", ToSpanish = "llamar" },
           new Word { Id = 22, ToEnglish = "to try", ToSpanish = "intentar" },
           new Word { Id = 23, ToEnglish = "to ask", ToSpanish = "preguntar" },
           new Word { Id = 24, ToEnglish = "to need", ToSpanish = "necesitar" },
           new Word { Id = 25, ToEnglish = "to feel", ToSpanish = "sentir" },
           new Word { Id = 26, ToEnglish = "to become", ToSpanish = "convertirse en" },
           new Word { Id = 27, ToEnglish = "to leave", ToSpanish = "dejar" },
           new Word { Id = 28, ToEnglish = "to mean", ToSpanish = "significar" },
           new Word { Id = 29, ToEnglish = "to keep", ToSpanish = "mantener" },
           new Word { Id = 30, ToEnglish = "to start", ToSpanish = "empezar" },
           new Word { Id = 31, ToEnglish = "to turn", ToSpanish = "girar" },
           new Word { Id = 32, ToEnglish = "to show", ToSpanish = "mostrar" },
           new Word { Id = 33, ToEnglish = "to offer", ToSpanish = "ofrecer" },
           new Word { Id = 34, ToEnglish = "to read", ToSpanish = "leer" },
           new Word { Id = 35, ToEnglish = "to include", ToSpanish = "incluir" },
           new Word { Id = 36, ToEnglish = "to continue", ToSpanish = "continuar" },
           new Word { Id = 37, ToEnglish = "to consider", ToSpanish = "considerar" },
           new Word { Id = 38, ToEnglish = "to appear", ToSpanish = "aparecer" },
           new Word { Id = 39, ToEnglish = "to add", ToSpanish = "añadir" },
           new Word { Id = 40, ToEnglish = "to change", ToSpanish = "cambiar" },
           new Word { Id = 41, ToEnglish = "to follow", ToSpanish = "seguir" },
           new Word { Id = 42, ToEnglish = "to stop", ToSpanish = "parar" },
           new Word { Id = 43, ToEnglish = "to create", ToSpanish = "crear" },
           new Word { Id = 44, ToEnglish = "to speak", ToSpanish = "hablar" },
           new Word { Id = 45, ToEnglish = "to allow", ToSpanish = "permitir" },
           new Word { Id = 46, ToEnglish = "to spend", ToSpanish = "gastar" },
           new Word { Id = 47, ToEnglish = "to open", ToSpanish = "abrir" },
           new Word { Id = 48, ToEnglish = "to walk", ToSpanish = "caminar" },
           new Word { Id = 49, ToEnglish = "to win", ToSpanish = "ganar" },
           new Word { Id = 50, ToEnglish = "to understand", ToSpanish = "entender" },
           new Word { Id = 51, ToEnglish = "to meet", ToSpanish = "conocer" },
           new Word { Id = 52, ToEnglish = "to offer", ToSpanish = "ofrecer" },
           new Word { Id = 53, ToEnglish = "to live", ToSpanish = "vivir" },
           new Word { Id = 54, ToEnglish = "to wait", ToSpanish = "esperar" },
           new Word { Id = 55, ToEnglish = "to remember", ToSpanish = "recordar" },
           new Word { Id = 56, ToEnglish = "to arrive", ToSpanish = "llegar" },
           new Word { Id = 57, ToEnglish = "to consider", ToSpanish = "considerar" },
           new Word { Id = 58, ToEnglish = "to suggest", ToSpanish = "sugerir" },
           new Word { Id = 59, ToEnglish = "to involve", ToSpanish = "involucrar" },
           new Word { Id = 60, ToEnglish = "to need", ToSpanish = "necesitar" },
           new Word { Id = 61, ToEnglish = "to ask", ToSpanish = "pedir" },
           new Word { Id = 62, ToEnglish = "to stand", ToSpanish = "estar de pie" },
           new Word { Id = 63, ToEnglish = "to lead", ToSpanish = "liderar" },
           new Word { Id = 64, ToEnglish = "to play", ToSpanish = "jugar" },
           new Word { Id = 65, ToEnglish = "to study", ToSpanish = "estudiar" },
           new Word { Id = 66, ToEnglish = "to write", ToSpanish = "escribir" },
           new Word { Id = 67, ToEnglish = "to begin", ToSpanish = "empezar" },
           new Word { Id = 68, ToEnglish = "to believe", ToSpanish = "creer" },
           new Word { Id = 69, ToEnglish = "to finish", ToSpanish = "terminar" },
           new Word { Id = 70, ToEnglish = "to eat", ToSpanish = "comer" },
           new Word { Id = 71, ToEnglish = "to drink", ToSpanish = "beber" },
           new Word { Id = 72, ToEnglish = "to close", ToSpanish = "cerrar" },
           new Word { Id = 73, ToEnglish = "to send", ToSpanish = "enviar" },
           new Word { Id = 74, ToEnglish = "to pay", ToSpanish = "pagar" },
           new Word { Id = 75, ToEnglish = "to believe", ToSpanish = "creer" },
           new Word { Id = 76, ToEnglish = "to receive", ToSpanish = "recibir" },
           new Word { Id = 77, ToEnglish = "to meet", ToSpanish = "encontrar" },
           new Word { Id = 78, ToEnglish = "to remember", ToSpanish = "recordar" },
           new Word { Id = 79, ToEnglish = "to serve", ToSpanish = "servir" },
           new Word { Id = 80, ToEnglish = "to learn", ToSpanish = "aprender" },
           new Word { Id = 81, ToEnglish = "to understand", ToSpanish = "comprender" },
           new Word { Id = 82, ToEnglish = "to watch", ToSpanish = "mirar" },
           new Word { Id = 83, ToEnglish = "to ask", ToSpanish = "preguntar" },
           new Word { Id = 84, ToEnglish = "to work", ToSpanish = "trabajar" },
           new Word { Id = 85, ToEnglish = "to talk", ToSpanish = "hablar" },
           new Word { Id = 86, ToEnglish = "to travel", ToSpanish = "viajar" },
           new Word { Id = 87, ToEnglish = "to help", ToSpanish = "ayudar" },
           new Word { Id = 88, ToEnglish = "to play", ToSpanish = "tocar" },
           new Word { Id = 89, ToEnglish = "to walk", ToSpanish = "andar" },
           new Word { Id = 90, ToEnglish = "to win", ToSpanish = "vencer" },
           new Word { Id = 91, ToEnglish = "to lose", ToSpanish = "perder" },
           new Word { Id = 92, ToEnglish = "to remember", ToSpanish = "acordar" },
           new Word { Id = 93, ToEnglish = "to close", ToSpanish = "acabar" },
           new Word { Id = 94, ToEnglish = "to use", ToSpanish = "usar" },
           new Word { Id = 95, ToEnglish = "to expect", ToSpanish = "esperar" },
           new Word { Id = 96, ToEnglish = "to close", ToSpanish = "cerrar" },
           new Word { Id = 97, ToEnglish = "to travel", ToSpanish = "viajar" },
           new Word { Id = 98, ToEnglish = "to start", ToSpanish = "empezar" },
           new Word { Id = 99, ToEnglish = "to understand", ToSpanish = "entender" },
           new Word { Id = 100, ToEnglish = "to work", ToSpanish = "trabajar" }
    };
}

