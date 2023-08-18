using FilmApi.Data_Access;
using FilmApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly FilmDbContext _context;

        public MovieService(FilmDbContext context)
        {
            _context = context;

        }

        public async Task<int> AddAsync(Movie entity)
        {
            _context.Movies.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;

        }

        public async Task DeleteAsync(Movie entity)
        {
            _context.Movies.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsWithIdAsync(int id)
        {
            return (_context.Characters?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<ICollection<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task UpdateAsync(Movie entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();


        }

        public async Task<Movie> GetCharactersMovieLinkTableAsync(int id)
        {
            return await _context.Movies
                    .Include(m => m.CharacterMovie)
                    .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateCharactersInMovieAsync(Movie movie, IEnumerable<int> charactersIds) 
        {
            movie.CharacterMovie.Clear();

            foreach (var characterId in charactersIds)
            {
                var character = await _context.Characters.FindAsync(characterId);
                if (character != null)
                {
                    movie.CharacterMovie.Add(new CharacterMovie
                    {
                        Character = character,
                        Movie = movie
                    });
                }
            }

            await UpdateAsync(movie);
        }

        public async Task<IEnumerable<Character>> getAllCharactersInMovie(Movie movie)
        {
            List<Character> characters = new();

            foreach (CharacterMovie cm in movie.CharacterMovie)
            {
                var character = await _context.Characters.FindAsync(cm.CharacterId);

                if (character != null)
                {
                    characters.Add(character);
                }
            }

            return characters;
        }
    }
}
