using Microsoft.EntityFrameworkCore;
using FilmApi.Data_Access;
using FilmApi.Models;

namespace FilmApi.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly FilmDbContext _context;

        public CharacterService(FilmDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Character entity)
        {
            _context.Characters.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;

        }

        public async Task DeleteAsync(Character entity)
        {
            _context.Characters.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCharacterMovieAsync(int id)
        {
            var movieCharacters = _context.CharacterMovie.Where(cm => cm.MovieId == id);
            _context.CharacterMovie.RemoveRange(movieCharacters);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsWithIdAsync(int id)
        {
            return (_context.Characters?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<ICollection<Character>> GetAllAsync()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character> GetByIdAsync(int id)
        {
            return await _context.Characters.FindAsync(id);
        }


        public async Task<Character> IncludeCharacterMovieAsync(int id)
        {
            return await _context.Characters
                    .Include(m => m.CharacterMovie)
                    .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Character entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
