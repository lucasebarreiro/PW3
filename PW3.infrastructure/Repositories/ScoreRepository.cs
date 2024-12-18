using Microsoft.EntityFrameworkCore;
using PW3.Application.Interfaces;
using PW3.Domain.Models;
using PW3.infrastructure.Contexts;

namespace PW3.infrastructure.Repositories;

public class ScoreRepository(AppDbContext _context) : IScoreRepository
{
    public async Task AddAsync(Score score, CancellationToken cancellationToken)
    {
        await _context.Scores.AddAsync(score, cancellationToken);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Score>> GetScoresByUserIdAsync(int userId, CancellationToken cancellationToken)
    {
        return await _context.Scores.Where(s => s.UserId == userId).ToListAsync();
    }

    public async Task<IEnumerable<Score>> GetTopScoresAsync(int top, CancellationToken cancellationToken)
    {
        return await _context.Scores.OrderByDescending(s => s.Points).Take(top).ToListAsync(cancellationToken);

    }
}

