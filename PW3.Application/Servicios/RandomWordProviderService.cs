using PW3.Application.Interfaces;

namespace PW3.Application.Servicios
{
    public class RandomWordProviderService(HttpClient _httpClient) : IRandomWordProviderService
    {
        public async Task<string> GetWordsAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetStringAsync("https://clientes.api.greenborn.com.ar/public-random-word", cancellationToken);
            if (string.IsNullOrEmpty(response))
            {
                throw new ArgumentException("No se pudo obtener una palabra de la API.");
            }

            return response;
        }
    }
}
