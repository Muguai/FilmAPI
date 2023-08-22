using FilmApi.Models;

namespace FilmApi.Services
{
    public interface ICharacterService : IRepository<Character>
    {
        /// <summary>
        /// Include CharacterMovie ManyToMany Link table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Character object with included CharacterMovie link table</returns>
        public Task<Character> IncludeCharacterMovieAsync(int id);

        /// <summary>
        /// Delete CharacterMovie ManyToMany Link table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteCharacterMovieAsync(int id);
    }
}
