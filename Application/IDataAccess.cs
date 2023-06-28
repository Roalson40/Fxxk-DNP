using Domain;

namespace Application;

public interface IDataAccess
{
    Task<Player> CreatePlayerAsync(Player player);

    Task<ICollection<Player>> GetAllPlayersAsync();

    Task AddScoreToPlayerAsync(HoleScore holeScore, int playerId);
}