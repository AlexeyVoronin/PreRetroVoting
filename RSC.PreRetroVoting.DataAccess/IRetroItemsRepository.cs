using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSC.PreRetroVoting.DataAccess
{
  public interface IRetroItemsRepository
  {
    IEnumerable<RetroItem> GetRetroItems();

    void AddRetroItem(RetroItem itemDescription);
  }
}
