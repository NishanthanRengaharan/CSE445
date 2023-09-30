using System;
using System.Net.Http;
using System.Threading.Tasks;


    public class GoogleMapsService
{

    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public GoogleMapsService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _apiKey = configuration["GoogleApiSettings:PlacesApiKey"] ?? throw new ArgumentNullException("GoogleApiSettings:PlacesApiKey");

    }

    public async Task<string> SearchPlaces(string query)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://maps.googleapis.com/maps/api/place/textsearch/json?query={query}&key={_apiKey}";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return result;
                    }
                    else
                    {
                        throw new Exception($"Error: {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Internal server error: {ex.Message}");
            }
        }
    }
