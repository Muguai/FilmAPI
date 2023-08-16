using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmApi.Migrations
{
    public partial class AddMockData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "Picture" },
                values: new object[,]
                {
                    { 1, "Bruce Wayne", "Batman", "Male", "https://vignette.wikia.nocookie.net/legobatman/images/a/ac/Batman2_Batman.png/revision/latest?cb=20190331215239"},
                    { 2, "Harvey Dent", "Two-face", "Male", "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fimages2.fanpop.com%2Fimage%2Fphotos%2F14300000%2FTwo-Face-lego-batman-14369888-560-560.jpg&f=1&nofb=1&ipt=dcb2afdec6f6bb0cfbcf68d1b26f9128215e332e08f748bc5819e4e5c0dcb6e9&ipo=images" },
                    { 3, "Jack White", "Joker", "Male", "http://www.vignette1.wikia.nocookie.net/lego/images/8/8b/Non-Blurry_Joker.png/revision/latest?cb=20140722220222"},
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
                    { 2, "Christopher Nolan", 1, "Action,Crime,Drama", "https://upload.wikimedia.org/wikipedia/en/1/1c/The_Dark_Knight_%282008_film%29.jpg", 2008, "The Dark Knight", "https://www.youtube.com/watch?v=StWZDqqBfJo"},
                    { 3, "Christopher Nolan", 1, "Action,Crime,Drama", "https://upload.wikimedia.org/wikipedia/en/8/83/Dark_knight_rises_poster.jpg", 2012, "The Dark Knight Rises", "https://www.youtube.com/watch?v=dEwUwslyaEQ"},
                    { 4, "George Lucas", 2, "Sci-fi,Adventure", "https://upload.wikimedia.org/wikipedia/en/8/87/StarWarsMoviePoster1977.jpg", 1977, "A New Hope", "https://www.youtube.com/watch?v=bx9GYhpx10Q" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
