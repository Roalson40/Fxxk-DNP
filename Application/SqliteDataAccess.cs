using Domain;
using EfcDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application;

public class SqliteDataAccess : IDataAccess
{
    private readonly KindContenxt _context;

    public SqliteDataAccess(KindContenxt context)
    {
        _context = context;
    }

    public async Task<Player> CreatePlayerAsync(Player player)
    {
        try
        {
            string s1 = "basic";
            string s2 = "full";
            string s3 = "premium";
            if (player.Name.Length > 50) throw new Exception("That is too long!");
            if (player.Age < 18 || player.Age > 99) throw new Exception("That is not in compliance1");
            if (player.MembershipFee < 1000.00 || player.MembershipFee > 5000.00) throw new Exception("That is not in compliance2");
            if (!(player.MembershipType.Equals(s1) || player.MembershipType.Equals(s2) || player.MembershipType.Equals(s3)))  throw new Exception("That is not in compliance3");
            EntityEntry<Player> newPlayer = await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            return newPlayer.Entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }
    
    public async Task<ICollection<Player>> GetAllPlayersAsync()
    {
        try
        {

            ICollection<Player> players = await _context.Players.ToListAsync();

            return players;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task AddScoreToPlayerAsync(HoleScore holeScore, int playerId)
    {
        try
        {

            Player? players = await _context.Players.Include(p => p.HoleScores)
                .FirstOrDefaultAsync(p => p.PlayerId == playerId);

            List<HoleScore> scores = players!.HoleScores.ToList();

            HoleScore? holeScores = scores.FirstOrDefault(s => s.HoleId.Equals(holeScore.HoleId));

            if (holeScores == null)
            {
                players.HoleScores.Add(holeScore);
            }
            else
            {
                holeScores.NumOfStrikes = holeScore.NumOfStrikes;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }
}