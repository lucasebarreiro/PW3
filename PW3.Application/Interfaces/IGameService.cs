﻿using PW3.Application.DTOs;

namespace PW3.Application.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<string>> GetRandomWordsAsync(CancellationToken cancellationToken);
        Task RegisterScoreAsync(ScoreDto scoreDto, CancellationToken cancellationToken);
    }
}
