namespace PW3.Application.Interfaces;

public interface IRandomWordProviderService
{
    Task<string> GetWordsAsync(CancellationToken cancellationToken);
}
