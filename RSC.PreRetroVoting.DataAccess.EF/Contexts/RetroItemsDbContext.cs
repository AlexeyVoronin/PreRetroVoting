using System.Data.Entity;
using RSC.PreRetroVoting.DataAccess.Model;

namespace RSC.PreRetroVoting.DataAccess.EF.Contexts
{
  internal class RetroItemsDbContext : DbContext
  {
    public DbSet<RetroItem> RetroItems { get; set; }
  }
}
