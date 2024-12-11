using PW3.Application.Interfaces;
using System.Text.Json;

namespace PW3.Application.Servicios
{
    public class RandomWordProviderService(HttpClient _httpClient) : IRandomWordProvider
    {
        public async Task<IEnumerable<string>> GetWordsAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync("https://clientes.api.greenborn.com.ar/public-random-word", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error al obtener palabras: {response.StatusCode}");
            }
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<IEnumerable<string>>(content) ?? new List<string>();
        }
    }
}
