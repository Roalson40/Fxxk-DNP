using Domain;

namespace Client.HttpClientServices.ClientInterface;

public interface IPlayerHttpServices
{
    Task<Player> CreateAsync(Player player);
    
    Task<ICollection<Player>> GetAllAsync();

    Task AddScoreToPlayerAsync( HoleScore holeScore, int playerId);
}