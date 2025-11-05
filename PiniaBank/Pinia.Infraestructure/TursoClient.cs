using System.Net.Http.Headers;
using System.Text;

namespace Pinia.Infraestructure;

public class TursoClient
{
    private readonly HttpClient _httpClient;
    private readonly string _databaseUrl;
    private readonly string _authToken;

    public TursoClient(string databaseUrl, string authToken)
    {
        _httpClient = new HttpClient();
        _databaseUrl = databaseUrl;
        _authToken = authToken;
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
    }

    public string ExecuteQuery(string query)
    {
        var requestBody = new
        {
            q = query
        };

        var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response =  _httpClient.PostAsync($"{_databaseUrl}/v1/sql", content).Result;
        response.EnsureSuccessStatusCode();

        return response.Content.ReadAsStringAsync().Result;
    }
}