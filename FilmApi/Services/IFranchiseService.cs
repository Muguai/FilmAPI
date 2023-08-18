using FilmApi.Models;

namespace FilmApi.Services
{
    public interface IFranchiseService : IRepository<Franchise>
    {
        /// <summary>
        /// Update which movies this franchise includes in the database
        /// </summary>
        /// <param name="franchise"></param>
        /// <param name="movieIds"></param>
        /// <returns></returns>
        public Task UpdateMoviesOnFranchise(Franchise franchise, IEnumerable<int> movieIds);

        /// <summary>
        /// Include List of Movies related to specified (by id) Franchise in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Franchise with list of movies</returns>
        public Task<Franchise> IncludeMovies(int id);

        /// <summary>
        /// Include Characters in Franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Franchise which include list of movies and movies which include many to many link table which include Characters</returns>
        public Task<Franchise> IncludeCharacters(int id);

        /// <summary>
        /// Get all the character accosicated with a specific franchise in the database
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns>List of Characters</returns>
        public List<Character> GetCharacterInFranchise(Franchise franchise);


    }
}
