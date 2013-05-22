using System;
using System.Collections.Generic;
using System.Linq;
using RSC.PreRetroVoting.DataAccess.EF.Contexts;
using RSC.PreRetroVoting.DataAccess.Model;

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
        var retroItem = _dbContext.RetroItems.First(item => item.Id == retroIteId);
        retroItem.Vote(voter);
        _dbContext.SaveChanges();
    }

    public void Dispose()
    {
      _dbContext.Dispose();
    }

    private readonly RetroItemsDbContext _dbContext;
  }
}
