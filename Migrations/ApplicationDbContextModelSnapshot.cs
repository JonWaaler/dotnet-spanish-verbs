﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using spanish_verbs.Data;

#nullable disable

namespace spanish_verbs.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("spanish_verbs.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateAccountCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("spanish_verbs.Models.ResultsData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalAnswered")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalAnsweredCorrect")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ResultsData");
                });

            modelBuilder.Entity("spanish_verbs.Models.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ToEnglish")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ToSpanish")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Words");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ToEnglish = "to be",
                            ToSpanish = "ser"
                        },
                        new
                        {
                            Id = 2,
                            ToEnglish = "to be",
                            ToSpanish = "estar"
                        },
                        new
                        {
                            Id = 3,
                            ToEnglish = "to have",
                            ToSpanish = "tener"
                        },
                        new
                        {
                            Id = 4,
                            ToEnglish = "to do",
                            ToSpanish = "hacer"
                        },
                        new
                        {
                            Id = 5,
                            ToEnglish = "to go",
                            ToSpanish = "ir"
                        },
                        new
                        {
                            Id = 6,
                            ToEnglish = "to want",
                            ToSpanish = "querer"
                        },
                        new
                        {
                            Id = 7,
                            ToEnglish = "to say",
                            ToSpanish = "decir"
                        },
                        new
                        {
                            Id = 8,
                            ToEnglish = "to see",
                            ToSpanish = "ver"
                        },
                        new
                        {
                            Id = 9,
                            ToEnglish = "to know",
                            ToSpanish = "saber"
                        },
                        new
                        {
                            Id = 10,
                            ToEnglish = "to be able to",
                            ToSpanish = "poder"
                        },
                        new
                        {
                            Id = 11,
                            ToEnglish = "to think",
                            ToSpanish = "pensar"
                        },
                        new
                        {
                            Id = 12,
                            ToEnglish = "to take",
                            ToSpanish = "tomar"
                        },
                        new
                        {
                            Id = 13,
                            ToEnglish = "to want",
                            ToSpanish = "desear"
                        },
                        new
                        {
                            Id = 14,
                            ToEnglish = "to come",
                            ToSpanish = "venir"
                        },
                        new
                        {
                            Id = 15,
                            ToEnglish = "to put",
                            ToSpanish = "poner"
                        },
                        new
                        {
                            Id = 16,
                            ToEnglish = "to speak",
                            ToSpanish = "hablar"
                        },
                        new
                        {
                            Id = 17,
                            ToEnglish = "to give",
                            ToSpanish = "dar"
                        },
                        new
                        {
                            Id = 18,
                            ToEnglish = "to find",
                            ToSpanish = "encontrar"
                        },
                        new
                        {
                            Id = 19,
                            ToEnglish = "to tell",
                            ToSpanish = "contar"
                        },
                        new
                        {
                            Id = 20,
                            ToEnglish = "to work",
                            ToSpanish = "trabajar"
                        },
                        new
                        {
                            Id = 21,
                            ToEnglish = "to call",
                            ToSpanish = "llamar"
                        },
                        new
                        {
                            Id = 22,
                            ToEnglish = "to try",
                            ToSpanish = "intentar"
                        },
                        new
                        {
                            Id = 23,
                            ToEnglish = "to ask",
                            ToSpanish = "preguntar"
                        },
                        new
                        {
                            Id = 24,
                            ToEnglish = "to need",
                            ToSpanish = "necesitar"
                        },
                        new
                        {
                            Id = 25,
                            ToEnglish = "to feel",
                            ToSpanish = "sentir"
                        },
                        new
                        {
                            Id = 26,
                            ToEnglish = "to become",
                            ToSpanish = "convertirse en"
                        },
                        new
                        {
                            Id = 27,
                            ToEnglish = "to leave",
                            ToSpanish = "dejar"
                        },
                        new
                        {
                            Id = 28,
                            ToEnglish = "to mean",
                            ToSpanish = "significar"
                        },
                        new
                        {
                            Id = 29,
                            ToEnglish = "to keep",
                            ToSpanish = "mantener"
                        },
                        new
                        {
                            Id = 30,
                            ToEnglish = "to start",
                            ToSpanish = "empezar"
                        },
                        new
                        {
                            Id = 31,
                            ToEnglish = "to turn",
                            ToSpanish = "girar"
                        },
                        new
                        {
                            Id = 32,
                            ToEnglish = "to show",
                            ToSpanish = "mostrar"
                        },
                        new
                        {
                            Id = 33,
                            ToEnglish = "to offer",
                            ToSpanish = "ofrecer"
                        },
                        new
                        {
                            Id = 34,
                            ToEnglish = "to read",
                            ToSpanish = "leer"
                        },
                        new
                        {
                            Id = 35,
                            ToEnglish = "to include",
                            ToSpanish = "incluir"
                        },
                        new
                        {
                            Id = 36,
                            ToEnglish = "to continue",
                            ToSpanish = "continuar"
                        },
                        new
                        {
                            Id = 37,
                            ToEnglish = "to consider",
                            ToSpanish = "considerar"
                        },
                        new
                        {
                            Id = 38,
                            ToEnglish = "to appear",
                            ToSpanish = "aparecer"
                        },
                        new
                        {
                            Id = 39,
                            ToEnglish = "to add",
                            ToSpanish = "añadir"
                        },
                        new
                        {
                            Id = 40,
                            ToEnglish = "to change",
                            ToSpanish = "cambiar"
                        },
                        new
                        {
                            Id = 41,
                            ToEnglish = "to follow",
                            ToSpanish = "seguir"
                        },
                        new
                        {
                            Id = 42,
                            ToEnglish = "to stop",
                            ToSpanish = "parar"
                        },
                        new
                        {
                            Id = 43,
                            ToEnglish = "to create",
                            ToSpanish = "crear"
                        },
                        new
                        {
                            Id = 44,
                            ToEnglish = "to speak",
                            ToSpanish = "hablar"
                        },
                        new
                        {
                            Id = 45,
                            ToEnglish = "to allow",
                            ToSpanish = "permitir"
                        },
                        new
                        {
                            Id = 46,
                            ToEnglish = "to spend",
                            ToSpanish = "gastar"
                        },
                        new
                        {
                            Id = 47,
                            ToEnglish = "to open",
                            ToSpanish = "abrir"
                        },
                        new
                        {
                            Id = 48,
                            ToEnglish = "to walk",
                            ToSpanish = "caminar"
                        },
                        new
                        {
                            Id = 49,
                            ToEnglish = "to win",
                            ToSpanish = "ganar"
                        },
                        new
                        {
                            Id = 50,
                            ToEnglish = "to understand",
                            ToSpanish = "entender"
                        },
                        new
                        {
                            Id = 51,
                            ToEnglish = "to meet",
                            ToSpanish = "conocer"
                        },
                        new
                        {
                            Id = 52,
                            ToEnglish = "to offer",
                            ToSpanish = "ofrecer"
                        },
                        new
                        {
                            Id = 53,
                            ToEnglish = "to live",
                            ToSpanish = "vivir"
                        },
                        new
                        {
                            Id = 54,
                            ToEnglish = "to wait",
                            ToSpanish = "esperar"
                        },
                        new
                        {
                            Id = 55,
                            ToEnglish = "to remember",
                            ToSpanish = "recordar"
                        },
                        new
                        {
                            Id = 56,
                            ToEnglish = "to arrive",
                            ToSpanish = "llegar"
                        },
                        new
                        {
                            Id = 57,
                            ToEnglish = "to consider",
                            ToSpanish = "considerar"
                        },
                        new
                        {
                            Id = 58,
                            ToEnglish = "to suggest",
                            ToSpanish = "sugerir"
                        },
                        new
                        {
                            Id = 59,
                            ToEnglish = "to involve",
                            ToSpanish = "involucrar"
                        },
                        new
                        {
                            Id = 60,
                            ToEnglish = "to need",
                            ToSpanish = "necesitar"
                        },
                        new
                        {
                            Id = 61,
                            ToEnglish = "to ask",
                            ToSpanish = "pedir"
                        },
                        new
                        {
                            Id = 62,
                            ToEnglish = "to stand",
                            ToSpanish = "estar de pie"
                        },
                        new
                        {
                            Id = 63,
                            ToEnglish = "to lead",
                            ToSpanish = "liderar"
                        },
                        new
                        {
                            Id = 64,
                            ToEnglish = "to play",
                            ToSpanish = "jugar"
                        },
                        new
                        {
                            Id = 65,
                            ToEnglish = "to study",
                            ToSpanish = "estudiar"
                        },
                        new
                        {
                            Id = 66,
                            ToEnglish = "to write",
                            ToSpanish = "escribir"
                        },
                        new
                        {
                            Id = 67,
                            ToEnglish = "to begin",
                            ToSpanish = "empezar"
                        },
                        new
                        {
                            Id = 68,
                            ToEnglish = "to believe",
                            ToSpanish = "creer"
                        },
                        new
                        {
                            Id = 69,
                            ToEnglish = "to finish",
                            ToSpanish = "terminar"
                        },
                        new
                        {
                            Id = 70,
                            ToEnglish = "to eat",
                            ToSpanish = "comer"
                        },
                        new
                        {
                            Id = 71,
                            ToEnglish = "to drink",
                            ToSpanish = "beber"
                        },
                        new
                        {
                            Id = 72,
                            ToEnglish = "to close",
                            ToSpanish = "cerrar"
                        },
                        new
                        {
                            Id = 73,
                            ToEnglish = "to send",
                            ToSpanish = "enviar"
                        },
                        new
                        {
                            Id = 74,
                            ToEnglish = "to pay",
                            ToSpanish = "pagar"
                        },
                        new
                        {
                            Id = 75,
                            ToEnglish = "to believe",
                            ToSpanish = "creer"
                        },
                        new
                        {
                            Id = 76,
                            ToEnglish = "to receive",
                            ToSpanish = "recibir"
                        },
                        new
                        {
                            Id = 77,
                            ToEnglish = "to meet",
                            ToSpanish = "encontrar"
                        },
                        new
                        {
                            Id = 78,
                            ToEnglish = "to remember",
                            ToSpanish = "recordar"
                        },
                        new
                        {
                            Id = 79,
                            ToEnglish = "to serve",
                            ToSpanish = "servir"
                        },
                        new
                        {
                            Id = 80,
                            ToEnglish = "to learn",
                            ToSpanish = "aprender"
                        },
                        new
                        {
                            Id = 81,
                            ToEnglish = "to understand",
                            ToSpanish = "comprender"
                        },
                        new
                        {
                            Id = 82,
                            ToEnglish = "to watch",
                            ToSpanish = "mirar"
                        },
                        new
                        {
                            Id = 83,
                            ToEnglish = "to ask",
                            ToSpanish = "preguntar"
                        },
                        new
                        {
                            Id = 84,
                            ToEnglish = "to work",
                            ToSpanish = "trabajar"
                        },
                        new
                        {
                            Id = 85,
                            ToEnglish = "to talk",
                            ToSpanish = "hablar"
                        },
                        new
                        {
                            Id = 86,
                            ToEnglish = "to travel",
                            ToSpanish = "viajar"
                        },
                        new
                        {
                            Id = 87,
                            ToEnglish = "to help",
                            ToSpanish = "ayudar"
                        },
                        new
                        {
                            Id = 88,
                            ToEnglish = "to play",
                            ToSpanish = "tocar"
                        },
                        new
                        {
                            Id = 89,
                            ToEnglish = "to walk",
                            ToSpanish = "andar"
                        },
                        new
                        {
                            Id = 90,
                            ToEnglish = "to win",
                            ToSpanish = "vencer"
                        },
                        new
                        {
                            Id = 91,
                            ToEnglish = "to lose",
                            ToSpanish = "perder"
                        },
                        new
                        {
                            Id = 92,
                            ToEnglish = "to remember",
                            ToSpanish = "acordar"
                        },
                        new
                        {
                            Id = 93,
                            ToEnglish = "to close",
                            ToSpanish = "acabar"
                        },
                        new
                        {
                            Id = 94,
                            ToEnglish = "to use",
                            ToSpanish = "usar"
                        },
                        new
                        {
                            Id = 95,
                            ToEnglish = "to expect",
                            ToSpanish = "esperar"
                        },
                        new
                        {
                            Id = 96,
                            ToEnglish = "to close",
                            ToSpanish = "cerrar"
                        },
                        new
                        {
                            Id = 97,
                            ToEnglish = "to travel",
                            ToSpanish = "viajar"
                        },
                        new
                        {
                            Id = 98,
                            ToEnglish = "to start",
                            ToSpanish = "empezar"
                        },
                        new
                        {
                            Id = 99,
                            ToEnglish = "to understand",
                            ToSpanish = "entender"
                        },
                        new
                        {
                            Id = 100,
                            ToEnglish = "to work",
                            ToSpanish = "trabajar"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("spanish_verbs.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("spanish_verbs.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("spanish_verbs.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("spanish_verbs.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("spanish_verbs.Models.ResultsData", b =>
                {
                    b.HasOne("spanish_verbs.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("ResultsData")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("spanish_verbs.Models.ApplicationUser", b =>
                {
                    b.Navigation("ResultsData");
                });
#pragma warning restore 612, 618
        }
    }
}
