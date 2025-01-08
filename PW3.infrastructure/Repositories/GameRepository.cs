using Microsoft.EntityFrameworkCore;
using PW3.Application.Interfaces.Repositories;
using PW3.Domain.Models;
using PW3.infrastructure.Contexts;

namespace PW3.infrastructure.Repositories
{

    public class GameRepository(AppDbContext _context) : IGameRepository
    {
        public async Task AddAsync(Game Game, CancellationToken cancellationToken)
        {
            await _context.Games.AddAsync(Game);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Game>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Games.Include(g => g.Words).FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _context.Games.ToListAsync();
        }
    }

}