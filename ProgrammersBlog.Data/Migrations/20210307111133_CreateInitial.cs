using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammersBlog.Data.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    About = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    YoutubeLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TwitterLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InstagramLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FacebookLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LinkedInLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GitHubLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WebsiteLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    CommentsCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5526), "Latest Information on C# Programming Language", true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5536), "C#", "C# Blog Category" },
                    { 2, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5553), "Latest Information on C++ Programming Language", true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5555), "C++", "C++ Blog Category" },
                    { 3, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5558), "Latest Information on JavaScript Programming Language", true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5560), "JavaScript", "JavaScript Blog Category" },
                    { 4, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5563), "Latest Information on TypeScript Programming Language", true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5564), "Typescript", "Typescript Blog Category" },
                    { 5, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5568), "Latest Information on Java Programming Language", true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5569), "Java", "Java Blog Category" },
                    { 6, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5573), "Latest Information on Python Programming Language", true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5574), "Python", "Python Blog Category" },
                    { 7, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5577), "Latest Information on Php Programming Language", true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5578), "Php", "Php Blog Category" },
                    { 8, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5582), "Latest Information on Kotlin Programming Language", true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5583), "Kotlin", "Kotlin Blog Category" },
                    { 9, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5587), "Latest Information on Swift Programming Language", true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5588), "Swift", "Swift Blog Category" },
                    { 10, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5591), "Latest Information on Ruby Programming Language", true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 593, DateTimeKind.Local).AddTicks(5592), "Ruby", "Ruby Blog Category" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 14, "f4181588-8f05-409b-932a-2097f37f6ebf", "Role.Read", "ROLE.READ" },
                    { 15, "7042ea94-f77a-44fa-9aae-80360b8f14d8", "Role.Update", "ROLE.UPDATE" },
                    { 16, "3d7c3852-d1ad-4836-9911-b2cb2f203c07", "Role.Delete", "ROLE.DELETE" },
                    { 17, "dae15af3-3e2f-4ff3-b7ce-6763723ef9d7", "Comment.Create", "COMMENT.CREATE" },
                    { 22, "f988f4ca-389f-40c7-bc9a-8989324f3cd2", "SuperAdmin", "SUPERADMIN" },
                    { 19, "73d0ab37-0ce6-4e9c-9126-88c7a5e573a7", "Comment.Update", "COMMENT.UPDATE" },
                    { 20, "0a2ec5ce-9dde-4f8c-97c1-d4e69e749c1f", "Comment.Delete", "COMMENT.DELETE" },
                    { 21, "73d4be3b-58ec-4cc2-b2e6-7dd45f7e2775", "AdminArea.Home.Read", "ADMINAREA.HOME.READ" },
                    { 13, "94b8fa69-a6e4-4091-89eb-70cd6f2c2b75", "Role.Create", "ROLE.CREATE" },
                    { 18, "191796d5-654a-4522-a82f-acf8096d883a", "Comment.Read", "COMMENT.READ" },
                    { 12, "22dd7bc7-d33a-48a2-b065-66265d9d6238", "User.Delete", "USER.DELETE" },
                    { 7, "ab78a0c4-6658-40f0-ad5a-44d0e7af44b9", "Article.Update", "ARTICLE.UPDATE" },
                    { 10, "286ed258-0c51-4ef5-a51e-6167d458e53d", "User.Read", "USER.READ" },
                    { 9, "a5bec9e6-634e-433d-ab1f-85a0496309a3", "User.Create", "USER.CREATE" },
                    { 8, "7a3b71c7-0444-417f-a18b-41f7ea4042b0", "Article.Delete", "ARTICLE.DELETE" },
                    { 6, "6dad468b-3598-49a2-80f5-715d1a6cd319", "Article.Read", "ARTICLE.READ" },
                    { 5, "fcf3c320-c44e-4b81-8e26-00f9ea23c60d", "Article.Create", "ARTICLE.CREATE" },
                    { 4, "e8613d35-034c-4665-8ccf-d4383752e924", "Category.Delete", "CATEGORY.DELETE" },
                    { 3, "909d50ec-5a05-4d00-806d-6ee399e0a5ba", "Category.Update", "CATEGORY.UPDATE" },
                    { 2, "a79bb721-733a-447a-ac32-3f3fc4671d05", "Category.Read", "CATEGORY.READ" },
                    { 1, "a3b30097-207f-460d-9459-0b26c36537e9", "Category.Create", "CATEGORY.CREATE" },
                    { 11, "5b9e3396-a6a4-4c48-89be-5ac6d273d594", "User.Update", "USER.UPDATE" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookLink", "FirstName", "GitHubLink", "InstagramLink", "LastName", "LinkedInLink", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwitterLink", "TwoFactorEnabled", "UserName", "WebsiteLink", "YoutubeLink" },
                values: new object[,]
                {
                    { 1, "Admin User of ProgrammersBlog", 0, "b1ec5c4b-5dda-4a2e-a9f0-75821eb8dd83", "mahdiguliyev@gmail.com", true, "https://facebook.com/mahdiguliyev", "Mahdi", "https://github.com/mahdiguliyev", "https://instagram.com/mahdiguliyev", "Guliyev", "https://linkedin.com/mahdiguliyev", false, null, "MAHDIGULIYEV@GMAIL.COM", "MAHDIGULIYEV", "AQAAAAEAACcQAAAAEDeUT4Gj4bHRrcB7AvrVL0z9UDWGyTpjKlecLoUDcXFrMZ5SX3R8JuyAyMn5TXRC+g==", "+905555555555", true, "/userImages/defaultUser.png", "be972f14-9ba0-4503-820c-a66db28876b1", "https://twitter.com/mahdiguliyev", false, "mahdiguliyev", "https://programmersblog.com/", "https://youtube.com/mahdiguliyev" },
                    { 2, "Editor User of ProgrammersBlog", 0, "0b969737-89fe-4a8a-a056-2677867f9652", "guliyevsadiq@gmail.com", true, "https://facebook.com/guliyevsadiq", "Sadiq", "https://github.com/guliyevsadiq", "https://instagram.com/guliyevsadiq", "Guliyev", "https://linkedin.com/guliyevsadiq", false, null, "GULIYEVSADIQ@GMAIL.COM", "GULIYEVSADIQ", "AQAAAAEAACcQAAAAEApMoZ4VN+2vN706vtCs24pufT2vHZkeIGG1G/FTG5Rb6+nAt9rASXrTGTKfCC5BVA==", "+905555555555", true, "/userImages/defaultUser.png", "cca7756d-680e-4ff9-9e34-6f3588524700", "https://twitter.com/guliyevsadiq", false, "guliyevsadiq", "https://programmersblog.com/", "https://youtube.com/guliyevsadiq" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentsCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { 1, 1, 0, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(828), new DateTime(2021, 3, 7, 15, 11, 32, 589, DateTimeKind.Local).AddTicks(9344), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(1582), "C# 9.0 ve .NET 5 Updates", "Guliyev Mahdi", "C# 9.0 ve .NET 5 Updates", "C#, C# 9, .NET5, .NET Framework, .NET Core", "postImages/defaultThumbnail.jpg", "C# 9.0 ve .NET 5 Updates", 1, 100 },
                    { 10, 10, 0, "Esistono innumerevoli variazioni dei passaggi del Lorem Ipsum, ma la maggior parte hanno subito delle variazioni del tempo, a causa dell’inserimento di passaggi ironici, o di sequenze casuali di caratteri palesemente poco verosimili. Se si decide di utilizzare un passaggio del Lorem Ipsum, è bene essere certi che non contenga nulla di imbarazzante. In genere, i generatori di testo segnaposto disponibili su internet tendono a ripetere paragrafi predefiniti, rendendo questo il primo vero generatore automatico su intenet. Infatti utilizza un dizionario di oltre 200 vocaboli latini, combinati con un insieme di modelli di strutture di periodi, per generare passaggi di testo verosimili. Il testo così generato è sempre privo di ripetizioni, parole imbarazzanti o fuori luogo ecc.", "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3405), new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3404), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3406), "Ruby", "Guliyev Mahdi", "Ruby, Ruby on Rails Web Programming, AirBnb Klon", "Ruby on Rails, Ruby, Web Programming, AirBnb", "postImages/defaultThumbnail.jpg", "Ruby on Rails for AirBnb Klon Coding", 1, 26777 },
                    { 8, 8, 0, "Plusieurs variations de Lorem Ipsum peuvent être trouvées ici ou là, mais la majeure partie d'entre elles a été altérée par l'addition d'humour ou de mots aléatoires qui ne ressemblent pas une seconde à du texte standard. Si vous voulez utiliser un passage du Lorem Ipsum, vous devez être sûr qu'il n'y a rien d'embarrassant caché dans le texte. Tous les générateurs de Lorem Ipsum sur Internet tendent à reproduire le même extrait sans fin, ce qui fait de lipsum.com le seul vrai générateur de Lorem Ipsum. Iil utilise un dictionnaire de plus de 200 mots latins, en combinaison de plusieurs structures de phrases, pour générer un Lorem Ipsum irréprochable. Le Lorem Ipsum ainsi obtenu ne contient aucune répétition, ni ne contient des mots farfelus, ou des touches d'humour.", "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3394), new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3392), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3395), "Kotlin", "Guliyev Mahdi", "Kotlin for Mobile Programming Step by Step A-Z", "kotlin, android, mobile, programming", "postImages/defaultThumbnail.jpg", "Kotlin for Mobile Programming", 1, 750 },
                    { 7, 7, 0, "Contrairement à une opinion répandue, le Lorem Ipsum n'est pas simplement du texte aléatoire. Il trouve ses racines dans une oeuvre de la littérature latine classique datant de 45 av. J.-C., le rendant vieux de 2000 ans. Un professeur du Hampden-Sydney College, en Virginie, s'est intéressé à un des mots latins les plus obscurs, consectetur, extrait d'un passage du Lorem Ipsum, et en étudiant tous les usages de ce mot dans la littérature classique, découvrit la source incontestable du Lorem Ipsum. Il provient en fait des sections 1.10.32 et 1.10.33 du 0De Finibus Bonorum et Malorum' (Des Suprêmes Biens et des Suprêmes Maux) de Cicéron. Cet ouvrage, très populaire pendant la Renaissance, est un traité sur la théorie de l'éthique. Les premières lignes du Lorem Ipsum, 'Lorem ipsum dolor sit amet...'', proviennent de la section 1.10.32", "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3388), new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3386), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3389), "PHP", "Guliyev Mahdi", "Php - Creating API Guide", "php, laravel, api, oop", "postImages/defaultThumbnail.jpg", "Php Laravel Getting Started Guide | API", 1, 4818 },
                    { 6, 6, 0, "Le Lorem Ipsum est simplement du faux texte employé dans la composition et la mise en page avant impression. Le Lorem Ipsum est le faux texte standard de l'imprimerie depuis les années 1500, quand un imprimeur anonyme assembla ensemble des morceaux de texte pour réaliser un livre spécimen de polices de texte. Il n'a pas fait que survivre cinq siècles, mais s'est aussi adapté à la bureautique informatique, sans que son contenu n'en soit modifié. Il a été popularisé dans les années 1960 grâce à la vente de feuilles Letraset contenant des passages du Lorem Ipsum, et, plus récemment, par son inclusion dans des applications de mise en page de texte, comme Aldus PageMaker.", "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3382), new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3380), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3383), "Python", "Guliyev Mahdi", "Data Analytics with Python", "Python, How is Data Mining Done?", "postImages/defaultThumbnail.jpg", "Data Analytics with Python | 2021", 1, 9999 },
                    { 9, 9, 0, "Al contrario di quanto si pensi, Lorem Ipsum non è semplicemente una sequenza casuale di caratteri. Risale ad un classico della letteratura latina del 45 AC, cosa che lo rende vecchio di 2000 anni. Richard McClintock, professore di latino al Hampden-Sydney College in Virginia, ha ricercato una delle più oscure parole latine, consectetur, da un passaggio del Lorem Ipsum e ha scoperto tra i vari testi in cui è citata, la fonte da cui è tratto il testo, le sezioni 1.10.32 and 1.10.33 del 'de Finibus Bonorum et Malorum' di Cicerone. Questo testo è un trattato su teorie di etica, molto popolare nel Rinascimento. La prima riga del Lorem Ipsum, 'Lorem ipsum dolor sit amet..'', è tratta da un passaggio della sezione 1.10.32.", "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3399), new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3398), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3400), "Swift", "Guliyev Mahdi", "Swift for IOS Programming Step by Step A-Z", "IOS, android, mobile, programming", "postImages/defaultThumbnail.jpg", "Swift for IOS Programming", 1, 14900 },
                    { 4, 4, 0, "É um facto estabelecido de que um leitor é distraído pelo conteúdo legível de uma página quando analisa a sua mancha gráfica. Logo, o uso de Lorem Ipsum leva a uma distribuição mais ou menos normal de letras, ao contrário do uso de 'Conteúdo aqui,conteúdo aqui'', tornando-o texto legível. Muitas ferramentas de publicação electrónica e editores de páginas web usam actualmente o Lorem Ipsum como o modelo de texto usado por omissão, e uma pesquisa por 'lorem ipsum' irá encontrar muitos websites ainda na sua infância. Várias versões têm evoluído ao longo dos anos, por vezes por acidente, por vezes propositadamente (como no caso do humor).", "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3366), new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3364), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3367), "Typescript 4.1 Updates", "Guliyev Mahdi", "Typescript 4.1, Typescript, TYPESCRIPT 2021", "Typescript 4.1 Updates", "postImages/defaultThumbnail.jpg", "Typescript 4.1", 1, 666 },
                    { 3, 3, 0, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.", "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3358), new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3357), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3360), "JavaScript ES2019 and ES2020 Updates", "Guliyev Mahdi", "JavaScript ES2019 ve ES2020 Updates", "JavaScript ES2019 ve ES2020 Updates", "postImages/defaultThumbnail.jpg", "JavaScript ES2019 and ES2020 Updates", 1, 12 },
                    { 2, 2, 0, "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3351), new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3349), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3352), "C++ 11 ve 19 Updates", "Guliyev Mahdi", "C++ 11 ve 19 Updates", "C++ 11 ve 19 Updates", "postImages/defaultThumbnail.jpg", "C++ 11 ve 19 Updates", 1, 295 },
                    { 5, 5, 0, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.", "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3375), new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3373), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 590, DateTimeKind.Local).AddTicks(3376), "JAVA", "Guliyev Mahdi", "Java, Android, Mobile, Kotlin, Mobile Development", "Java, Mobil, Kotlin, Android, IOS, SWIFT", "postImages/defaultThumbnail.jpg", "Java and Android's Future | 2021", 1, 3225 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 3, 2 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 4, 2 },
                    { 17, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 19, 1 },
                    { 18, 2 },
                    { 19, 2 },
                    { 5, 2 },
                    { 18, 1 },
                    { 13, 1 },
                    { 16, 1 },
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 20, 2 },
                    { 14, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 15, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 17, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 21, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[,]
                {
                    { 1, 1, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9396), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9563), "C# Article Comment", "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır." },
                    { 2, 2, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9577), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9578), "C++ Article Comment", "Lorem Ipsum jest tekstem stosowanym jako przykładowy wypełniacz w przemyśle poligraficznym. Został po raz pierwszy użyty w XV w. przez nieznanego drukarza do wypełnienia tekstem próbnej książki. Pięć wieków później zaczął być używany przemyśle elektronicznym, pozostając praktycznie niezmienionym. Spopularyzował się w latach 60. XX w. wraz z publikacją arkuszy Letrasetu, zawierających fragmenty Lorem Ipsum, a ostatnio z zawierającym różne wersje Lorem Ipsum oprogramowaniem przeznaczonym do realizacji druków na komputerach osobistych, jak Aldus PageMaker" },
                    { 3, 3, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9582), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9583), "JavaScript Article Comment", "Ang Lorem Ipsum ay ginagamit na modelo ng industriya ng pagpriprint at pagtytypeset. Ang Lorem Ipsum ang naging regular na modelo simula pa noong 1500s, noong may isang di kilalang manlilimbag and kumuha ng galley ng type at ginulo ang pagkaka-ayos nito upang makagawa ng libro ng mga type specimen. Nalagpasan nito hindi lang limang siglo, kundi nalagpasan din nito ang paglaganap ng electronic typesetting at nanatiling parehas. Sumikat ito noong 1960s kasabay ng pag labas ng Letraset sheets na mayroong mga talata ng Lorem Ipsum, at kamakailan lang sa mga desktop publishing software tulad ng Aldus Pagemaker ginamit ang mga bersyon ng Lorem Ipsum." },
                    { 4, 4, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9587), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9588), "Typescript Article Comment", "Lorem Ipsum er rett og slett dummytekst fra og for trykkeindustrien. Lorem Ipsum har vært bransjens standard for dummytekst helt siden 1500-tallet, da en ukjent boktrykker stokket en mengde bokstaver for å lage et prøveeksemplar av en bok. Lorem Ipsum har tålt tidens tann usedvanlig godt, og har i tillegg til å bestå gjennom fem århundrer også tålt spranget over til elektronisk typografi uten vesentlige endringer. Lorem Ipsum ble gjort allment kjent i 1960-årene ved lanseringen av Letraset-ark med avsnitt fra Lorem Ipsum, og senere med sideombrekkingsprogrammet Aldus PageMaker som tok i bruk nettopp Lorem Ipsum for dummytekst." },
                    { 5, 5, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9591), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9593), "Java Article Comment", "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum." },
                    { 6, 6, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9596), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9597), "Python Article Comment", "Lorem Ipsum je jednostavno probni tekst koji se koristi u tiskarskoj i slovoslagarskoj industriji. Lorem Ipsum postoji kao industrijski standard još od 16-og stoljeća, kada je nepoznati tiskar uzeo tiskarsku galiju slova i posložio ih da bi napravio knjigu s uzorkom tiska. Taj je tekst ne samo preživio pet stoljeća, već se i vinuo u svijet elektronskog slovoslagarstva, ostajući u suštini nepromijenjen. Postao je popularan tijekom 1960-ih s pojavom Letraset listova s odlomcima Lorem Ipsum-a, a u skorije vrijeme sa software-om za stolno izdavaštvo kao što je Aldus PageMaker koji također sadrži varijante Lorem Ipsum-a." },
                    { 7, 7, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9601), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9602), "Php Article Comment", "Lorem Ipsum – tas ir teksta salikums, kuru izmanto poligrāfijā un maketēšanas darbos. Lorem Ipsum ir kļuvis par vispārpieņemtu teksta aizvietotāju kopš 16. gadsimta sākuma. Tajā laikā kāds nezināms iespiedējs izveidoja teksta fragmentu, lai nodrukātu grāmatu ar burtu paraugiem. Tas ir ne tikai pārdzīvojis piecus gadsimtus, bet bez ievērojamām izmaiņām saglabājies arī mūsdienās, pārejot uz datorizētu teksta apstrādi. Tā popularizēšanai 60-tajos gados kalpoja Letraset burtu paraugu publicēšana ar Lorem Ipsum teksta fragmentiem un, nesenā pagātnē, tādas maketēšanas programmas kā Aldus PageMaker, kuras šablonu paraugos ir izmantots Lorem Ipsum teksts." },
                    { 8, 8, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9606), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9607), "Kotlin Article Comment", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)." },
                    { 9, 9, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9610), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9611), "Swift Article Comment", "هنالك العديد من الأنواع المتوفرة لنصوص لوريم إيبسوم، ولكن الغالبية تم تعديلها بشكل ما عبر إدخال بعض النوادر أو الكلمات العشوائية إلى النص. إن كنت تريد أن تستخدم نص لوريم إيبسوم ما، عليك أن تتحقق أولاً أن ليس هناك أي كلمات أو عبارات محرجة أو غير لائقة مخبأة في هذا النص. بينما تعمل جميع مولّدات نصوص لوريم إيبسوم على الإنترنت على إعادة تكرار مقاطع من نص لوريم إيبسوم نفسه عدة مرات بما تتطلبه الحاجة، يقوم مولّدنا هذا باستخدام كلمات من قاموس يحوي على أكثر من 200 كلمة لا تينية، مضاف إليها مجموعة من الجمل النموذجية، لتكوين نص لوريم إيبسوم ذو شكل منطقي قريب إلى النص الحقيقي. وبالتالي يكون النص الناتح خالي من التكرار، أو أي كلمات أو عبارات غير لائقة أو ما شابه. وهذا ما يجعله أول مولّد نص لوريم إيبسوم حقيقي على الإنترنت." },
                    { 10, 10, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9615), true, false, "InitialCreate", new DateTime(2021, 3, 7, 15, 11, 32, 595, DateTimeKind.Local).AddTicks(9616), "Ruby Article Comment", "Lorem Ipsum，也称乱数假文或者哑元文本， 是印刷及排版领域所常用的虚拟文字。由于曾经一台匿名的打印机刻意打乱了一盒印刷字体从而造出一本字体样品书，Lorem Ipsum从西元15世纪起就被作为此领域的标准文本使用。它不仅延续了五个世纪，还通过了电子排版的挑战，其雏形却依然保存至今。在1960年代，”Leatraset”公司发布了印刷着Lorem Ipsum段落的纸张，从而广泛普及了它的使用。最近，计算机桌面出版软件”Aldus PageMaker”也通过同样的方式使Lorem Ipsum落入大众的视野。" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
