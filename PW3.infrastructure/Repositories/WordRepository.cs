using Microsoft.EntityFrameworkCore;
using PW3.Application.Interfaces.Repositories;
using PW3.Domain.Models;
using PW3.infrastructure.Contexts;

namespace PW3.infrastructure.Repositories;

public class WordRepository(AppDbContext _context) : IWordRepository
{
    public async Task AddAsync(GameWord Word)
    {
        await _context.Words.AddAsync(Word);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<GameWord>> GetWordsPerGameIdAsync(int GameId, CancellationToken cancellationToken)
    {
        return await _context.Words.Where(w => w.GameId == GameId).ToListAsync();
    }
}
