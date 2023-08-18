using FilmApi.Data_Access;
using FilmApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly FilmDbContext _context;

        public FranchiseService(FilmDbContext context) 
        {
            _context = context;

        }

        public async Task<int> AddAsync(Franchise entity)
        {
            _context.Franchises.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;

        }

        public async Task DeleteAsync(Franchise entity)
        {
            _context.Franchises.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsWithIdAsync(int id)
        {
            return (_context.Characters?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<ICollection<Franchise>> GetAllAsync()
        {
            return await _context.Franchises.ToListAsync();
        }

        public async Task<Franchise> GetByIdAsync(int id)
        {
            return await _context.Franchises.FindAsync(id);
        }

        public async Task UpdateAsync(Franchise entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();


        }

        public async Task<Franchise> IncludeMovies(int id)
        {
            return await _context.Franchises
                    .Include(m => m.movies)
                    .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Franchise> IncludeCharacters(int id)
        {
           return await _context.Franchises
                .Include(f => f.movies)
                    .ThenInclude(m => m.CharacterMovie)
                        .ThenInclude(cm => cm.Character)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public List<Character> GetCharacterInFranchise(Franchise franchise)
        {
            var franchiseCharacters = new List<Character>();

            foreach (var movie in franchise.movies)
            {
                foreach (var characterMovie in movie.CharacterMovie)
                {
                    if (!franchiseCharacters.Contains(characterMovie.Character))
                    {
                        franchiseCharacters.Add(characterMovie.Character);
                    }
                }
            }

            return franchiseCharacters;
        }


        public async Task UpdateMoviesOnFranchise(Franchise franchise, IEnumerable<int> movieIds)
        {
            List<Movie> movies = new();

            foreach (int movieId in movieIds)
            {
                var movie = await _context.Movies.FindAsync(movieId);

                if (movie == null)
                {
                    throw new KeyNotFoundException($"Movie with id ${movieId} not found!");
                }

                movies.Add(movie);
            }

            franchise.movies = movies;

            await UpdateAsync(franchise);
        }

    }
}
