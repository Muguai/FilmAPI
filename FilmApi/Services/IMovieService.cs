using FilmApi.Models;

namespace FilmApi.Services
{
    public interface IMovieService : IRepository<Movie>
    {
        public Task<Movie> GetCharactersMovieLinkTableAsync(int id);

        public Task UpdateCharactersInMovieAsync(Movie movie, IEnumerable<int> charactersIds);
        public Task<IEnumerable<Character>> getAllCharactersInMovie(Movie movie);


    }
}
