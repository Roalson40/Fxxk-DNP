using Domain;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class KindContenxt : DbContext
{
    public DbSet<Player> Players { get; set; }
    
    public DbSet<HoleScore> HoleScores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source =../EfcDataAccess/Player.db");
    }
}