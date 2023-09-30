
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class GoogleSearchService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _searchEngineId;

    public GoogleSearchService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _apiKey = configuration["GoogleApiSettings:ApiKey"] ?? throw new ArgumentNullException("GoogleApiSettings:ApiKey");
        _searchEngineId = configuration["GoogleApiSettings:SearchEngineId"] ?? throw new ArgumentNullException("GoogleApiSettings:SearchEngineId");
    }

    public async Task<string> Search(string query)
    {
        string apiUrl = $"https://www.googleapis.com/customsearch/v1?key={_apiKey}&cx={_searchEngineId}&q={query}";

        var response = await _httpClient.GetStringAsync(apiUrl);

        return response;
    }
}
