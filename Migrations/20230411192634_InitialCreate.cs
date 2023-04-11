using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace spanish_verbs.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ToEnglish = table.Column<string>(type: "TEXT", nullable: false),
                    ToSpanish = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResultsData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalAnswered = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalAnsweredCorrect = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalTests = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalTestsFinished = table.Column<int>(type: "INTEGER", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultsData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultsData_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "ToEnglish", "ToSpanish" },
                values: new object[,]
                {
                    { 1, "to be", "ser" },
                    { 2, "to be", "estar" },
                    { 3, "to have", "tener" },
                    { 4, "to do", "hacer" },
                    { 5, "to go", "ir" },
                    { 6, "to want", "querer" },
                    { 7, "to say", "decir" },
                    { 8, "to see", "ver" },
                    { 9, "to know", "saber" },
                    { 10, "to be able to", "poder" },
                    { 11, "to think", "pensar" },
                    { 12, "to take", "tomar" },
                    { 13, "to want", "desear" },
                    { 14, "to come", "venir" },
                    { 15, "to put", "poner" },
                    { 16, "to speak", "hablar" },
                    { 17, "to give", "dar" },
                    { 18, "to find", "encontrar" },
                    { 19, "to tell", "contar" },
                    { 20, "to work", "trabajar" },
                    { 21, "to call", "llamar" },
                    { 22, "to try", "intentar" },
                    { 23, "to ask", "preguntar" },
                    { 24, "to need", "necesitar" },
                    { 25, "to feel", "sentir" },
                    { 26, "to become", "convertirse en" },
                    { 27, "to leave", "dejar" },
                    { 28, "to mean", "significar" },
                    { 29, "to keep", "mantener" },
                    { 30, "to start", "empezar" },
                    { 31, "to turn", "girar" },
                    { 32, "to show", "mostrar" },
                    { 33, "to offer", "ofrecer" },
                    { 34, "to read", "leer" },
                    { 35, "to include", "incluir" },
                    { 36, "to continue", "continuar" },
                    { 37, "to consider", "considerar" },
                    { 38, "to appear", "aparecer" },
                    { 39, "to add", "añadir" },
                    { 40, "to change", "cambiar" },
                    { 41, "to follow", "seguir" },
                    { 42, "to stop", "parar" },
                    { 43, "to create", "crear" },
                    { 44, "to speak", "hablar" },
                    { 45, "to allow", "permitir" },
                    { 46, "to spend", "gastar" },
                    { 47, "to open", "abrir" },
                    { 48, "to walk", "caminar" },
                    { 49, "to win", "ganar" },
                    { 50, "to understand", "entender" },
                    { 51, "to meet", "conocer" },
                    { 52, "to offer", "ofrecer" },
                    { 53, "to live", "vivir" },
                    { 54, "to wait", "esperar" },
                    { 55, "to remember", "recordar" },
                    { 56, "to arrive", "llegar" },
                    { 57, "to consider", "considerar" },
                    { 58, "to suggest", "sugerir" },
                    { 59, "to involve", "involucrar" },
                    { 60, "to need", "necesitar" },
                    { 61, "to ask", "pedir" },
                    { 62, "to stand", "estar de pie" },
                    { 63, "to lead", "liderar" },
                    { 64, "to play", "jugar" },
                    { 65, "to study", "estudiar" },
                    { 66, "to write", "escribir" },
                    { 67, "to begin", "empezar" },
                    { 68, "to believe", "creer" },
                    { 69, "to finish", "terminar" },
                    { 70, "to eat", "comer" },
                    { 71, "to drink", "beber" },
                    { 72, "to close", "cerrar" },
                    { 73, "to send", "enviar" },
                    { 74, "to pay", "pagar" },
                    { 75, "to believe", "creer" },
                    { 76, "to receive", "recibir" },
                    { 77, "to meet", "encontrar" },
                    { 78, "to remember", "recordar" },
                    { 79, "to serve", "servir" },
                    { 80, "to learn", "aprender" },
                    { 81, "to understand", "comprender" },
                    { 82, "to watch", "mirar" },
                    { 83, "to ask", "preguntar" },
                    { 84, "to work", "trabajar" },
                    { 85, "to talk", "hablar" },
                    { 86, "to travel", "viajar" },
                    { 87, "to help", "ayudar" },
                    { 88, "to play", "tocar" },
                    { 89, "to walk", "andar" },
                    { 90, "to win", "vencer" },
                    { 91, "to lose", "perder" },
                    { 92, "to remember", "acordar" },
                    { 93, "to close", "acabar" },
                    { 94, "to use", "usar" },
                    { 95, "to expect", "esperar" },
                    { 96, "to close", "cerrar" },
                    { 97, "to travel", "viajar" },
                    { 98, "to start", "empezar" },
                    { 99, "to understand", "entender" },
                    { 100, "to work", "trabajar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResultsData_ApplicationUserId",
                table: "ResultsData",
                column: "ApplicationUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ResultsData");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
