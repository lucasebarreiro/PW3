namespace PW3.Application.Interfaces;

public interface IRandomWordProvider
{
    Task<IEnumerable<string>> GetWordsAsync(CancellationToken cancellationToken);
}
