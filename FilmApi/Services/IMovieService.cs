using FilmApi.Models;

namespace FilmApi.Services
{
    public interface IMovieService : IRepository<Movie>
    {
        /// <summary>
        /// Includes CharacterMovie link table that relates to a specified (by id) movie in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Movie with link table</returns>
        public Task<Movie> IncludeCharacterMovieAsync(int id);

        /// <summary>
        /// Updates characters related to movie
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="charactersIds"></param>
        /// <returns></returns>
        public Task UpdateCharactersInMovieAsync(Movie movie, IEnumerable<int> charactersIds);
        
        /// <summary>
        /// Gets all the characters related to movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>List of Characters</returns>
        public Task<IEnumerable<Character>> getAllCharactersInMovieAsync(Movie movie);


    }
}
