using System.Net.Http.Json;
using System.Text.Json;
using Client.HttpClientServices.ClientInterface;
using Domain;

namespace Client.HttpClientServices.ClientServices;

public class PlayerHttpServices : IPlayerHttpServices
{
    private readonly HttpClient _client;

    public PlayerHttpServices(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<Player> CreateAsync(Player player)
    {
        HttpResponseMessage response = await _client.PostAsJsonAsync("/Player", player);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Player p  = JsonSerializer.Deserialize<Player>(result, new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        })!;
        return p;
    }
    
    public async Task<ICollection<Player>> GetAllAsync()
    {
        HttpResponseMessage response = await _client.GetAsync("/Player");

        string result = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        ICollection<Player> players = JsonSerializer.Deserialize<ICollection<Player>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

        return players;
    }

    public async Task AddScoreToPlayerAsync(HoleScore holeScore, int playerId)
    {
        HttpResponseMessage response = await _client.PostAsJsonAsync($"/Player/{playerId}", holeScore);
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
    }
}