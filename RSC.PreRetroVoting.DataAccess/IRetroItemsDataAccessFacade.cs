using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSC.PreRetroVoting.DataAccess
{
  public interface IRetroItemsDataAccessFacade
  {
    string RetroItemsStoragePath { get; }

    IRetroItemsRepository RetroItemsRepository { get; }
  }
}
