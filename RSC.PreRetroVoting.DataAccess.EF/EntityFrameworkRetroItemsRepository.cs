using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSC.PreRetroVoting.DataAccess.Model;
using RSC.PreRetroVoting.DataAccess.EF.Contexts;

namespace RSC.PreRetroVoting.DataAccess.EF
{
  public class EntityFrameworkRetroItemsRepository : IRetroItemsRepository, IDisposable
  {
    public EntityFrameworkRetroItemsRepository()
    {
      _dbContext = new RetroItemsDbContext();
      _dbContext.Database.Initialize(false);
    }

    public IEnumerable<RetroItem> GetRetroItems()
    {
      return _dbContext.RetroItems.ToList();
    }

    public void AddRetroItem(RetroItem item)
    {
      _dbContext.RetroItems.Add(item);
      _dbContext.SaveChanges();
    }

    public void Vote(Guid retroIteId, string voter)
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {
      _dbContext.Dispose();
    }

    private RetroItemsDbContext _dbContext;
  }
}
