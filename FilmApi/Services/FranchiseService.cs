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
    }
}
