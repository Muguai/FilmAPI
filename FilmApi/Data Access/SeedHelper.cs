using FilmApi.Models;

namespace FilmApi.Data_Access
{
    public class SeedHelper
    {
        public static List<Movie> GetMovies()
        {
            List<Movie> newMovie = new() {
                new Movie() { Id = 1, Title = "Batman Begins", Genre = "Action,Crime,Drama", ReleaseYear = 2005, Director = "Christopher Nolan", Picture="https://upload.wikimedia.org/wikipedia/en/a/af/Batman_Begins_Poster.jpg", Trailer = "https://www.youtube.com/watch?v=8TtdY3_Am7w", FranchiseId = 1 },
                new Movie() { Id = 2, Title = "The Dark Knight", Genre = "Action,Crime,Drama", ReleaseYear = 2008, Director = "Christopher Nolan", Picture = "https://upload.wikimedia.org/wikipedia/en/1/1c/The_Dark_Knight_%282008_film%29.jpg", Trailer = "https://www.youtube.com/watch?v=StWZDqqBfJo", FranchiseId = 1  },
                new Movie() { Id = 3, Title = "The Dark Knight Rises", Genre = "Action,Crime,Drama", ReleaseYear = 2012, Director = "Christopher Nolan", Picture = "https://upload.wikimedia.org/wikipedia/en/8/83/Dark_knight_rises_poster.jpg", Trailer = "https://www.youtube.com/watch?v=dEwUwslyaEQ", FranchiseId = 1 },
                new Movie() { Id = 4, Title = "A New Hope", Genre = "Sci-fi,Adventure", ReleaseYear = 1977, Director = "George Lucas", Picture = "https://upload.wikimedia.org/wikipedia/en/8/87/StarWarsMoviePoster1977.jpg", Trailer="https://www.youtube.com/watch?v=bx9GYhpx10Q",  FranchiseId = 2  },
            };

            return newMovie;
        }

        public static List<Character> GetCharacters()
        {
            List<Character> newCharacters = new() {
                new Character() { Id = 1, FullName = "Batman", Alias = "Bruce Wayne", Gender = "Male", Picture = "https://vignette.wikia.nocookie.net/legobatman/images/a/ac/Batman2_Batman.png/revision/latest?cb=20190331215239"},
                new Character() { Id = 2, FullName = "Two-face", Alias = "Harvey Dent", Gender = "Male", Picture = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fimages2.fanpop.com%2Fimage%2Fphotos%2F14300000%2FTwo-Face-lego-batman-14369888-560-560.jpg&f=1&nofb=1&ipt=dcb2afdec6f6bb0cfbcf68d1b26f9128215e332e08f748bc5819e4e5c0dcb6e9&ipo=images"},
                new Character() { Id = 3, FullName = "Joker", Alias = "Jack White", Gender = "Male", Picture = "http://www.vignette1.wikia.nocookie.net/lego/images/8/8b/Non-Blurry_Joker.png/revision/latest?cb=20140722220222"},
                new Character() { Id = 4, FullName = "Anakin Skywalker", Alias = "Darth Vader", Gender = "Male", Picture = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpm1.narvii.com%2F6511%2F484805d71056e4a2444767a89136a322c5ec09cb_hq.jpg&f=1&nofb=1&ipt=18a282eda5be08037a416b9216625664f16d872b79b757ae364936c65b1d297b&ipo=images"},
            };

            return newCharacters;
        }

        public static List<Franchise> GetFranchises()
        {
            List<Franchise> newFranchise = new() {
                new Franchise() { Id = 1, Name = "Batman", Description = "Guys rich parents dies and he dresses up as a bat"},
                new Franchise() {Id = 2, Name = "Star Wars", Description = "They blow up stuff in space"},
            };


            return newFranchise;
        }

    }
}
