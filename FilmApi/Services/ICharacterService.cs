using FilmApi.Models;

namespace FilmApi.Services
{
    public interface ICharacterService : IRepository<Character>
    {

        public Task<Character> IncludeCharacterMovieAsync(int id);

        public Task DeleteCharacterMovieAsync(int id);
    }
}
