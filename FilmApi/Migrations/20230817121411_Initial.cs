using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovie",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovie", x => new { x.CharacterId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "Picture" },
                values: new object[,]
                {
                    { 1, "Bruce Wayne", "Batman", "Male", "https://vignette.wikia.nocookie.net/legobatman/images/a/ac/Batman2_Batman.png/revision/latest?cb=20190331215239" },
                    { 2, "Harvey Dent", "Two-face", "Male", "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fimages2.fanpop.com%2Fimage%2Fphotos%2F14300000%2FTwo-Face-lego-batman-14369888-560-560.jpg&f=1&nofb=1&ipt=dcb2afdec6f6bb0cfbcf68d1b26f9128215e332e08f748bc5819e4e5c0dcb6e9&ipo=images" },
                    { 3, "Jack White", "Joker", "Male", "http://www.vignette1.wikia.nocookie.net/lego/images/8/8b/Non-Blurry_Joker.png/revision/latest?cb=20140722220222" },
                    { 4, "Darth Vader", "Anakin Skywalker", "Male", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpm1.narvii.com%2F6511%2F484805d71056e4a2444767a89136a322c5ec09cb_hq.jpg&f=1&nofb=1&ipt=18a282eda5be08037a416b9216625664f16d872b79b757ae364936c65b1d297b&ipo=images" }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Guys rich parents dies and he dresses up as a bat", "Batman" },
                    { 2, "They blow up stuff in space", "Star Wars" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "Picture", "ReleaseYear", "Title", "Trailer" },
                values: new object[,]
                {
                    { 1, "Christopher Nolan", 1, "Action,Crime,Drama", "https://upload.wikimedia.org/wikipedia/en/a/af/Batman_Begins_Poster.jpg", 2005, "Batman Begins", "https://www.youtube.com/watch?v=8TtdY3_Am7w" },
                    { 2, "Christopher Nolan", 1, "Action,Crime,Drama", "https://upload.wikimedia.org/wikipedia/en/1/1c/The_Dark_Knight_%282008_film%29.jpg", 2008, "The Dark Knight", "https://www.youtube.com/watch?v=StWZDqqBfJo" },
                    { 3, "Christopher Nolan", 1, "Action,Crime,Drama", "https://upload.wikimedia.org/wikipedia/en/8/83/Dark_knight_rises_poster.jpg", 2012, "The Dark Knight Rises", "https://www.youtube.com/watch?v=dEwUwslyaEQ" },
                    { 4, "George Lucas", 2, "Sci-fi,Adventure", "https://upload.wikimedia.org/wikipedia/en/8/87/StarWarsMoviePoster1977.jpg", 1977, "A New Hope", "https://www.youtube.com/watch?v=bx9GYhpx10Q" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_MovieId",
                table: "CharacterMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FranchiseId",
                table: "Movies",
                column: "FranchiseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovie");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Franchises");
        }
    }
}
