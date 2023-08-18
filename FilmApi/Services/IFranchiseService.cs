using FilmApi.Models;

namespace FilmApi.Services
{
    public interface IFranchiseService : IRepository<Franchise>
    {
        public Task UpdateMoviesOnFranchise(Franchise franchise, IEnumerable<int> movieIds);

        public Task<Franchise> IncludeMovies(int id);

        public Task<Franchise> IncludeCharacters(int id);

        public List<Character> GetCharacterInFranchise(Franchise franchise);


    }
}
