using PW3.Application.DTOs;
using PW3.Domain.Models;

namespace PW3.Application.Interfaces
{
    public class GameService(IRandomWordProvider randomWordProvider, IScoreRepository scoreRepository) : IGameService
    {
        private readonly IRandomWordProvider _randomWordProvider = randomWordProvider;
        private readonly IScoreRepository _scoreRepository = scoreRepository;

        public async Task<IEnumerable<string>> GetRandomWordsAsync(CancellationToken cancellationToken)
        {

            return await _randomWordProvider.GetWordsAsync(cancellationToken);
        }


        public async Task RegisterScoreAsync(ScoreDto scoreDto, CancellationToken cancellationToken)
        {

            var score = new Score
            {
                UserId = scoreDto.UserId,
                Points = scoreDto.Points,
                Timestamp = DateTime.UtcNow
            };


            await _scoreRepository.AddAsync(score, cancellationToken);
        }
    }
}
