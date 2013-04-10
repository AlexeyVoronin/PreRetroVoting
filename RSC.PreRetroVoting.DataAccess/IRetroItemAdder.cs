using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSC.PreRetroVoting.DataAccess
{
  public interface IRetroItemAdder
  {
    void AddRetroItem(string itemDescription);
  }
}
