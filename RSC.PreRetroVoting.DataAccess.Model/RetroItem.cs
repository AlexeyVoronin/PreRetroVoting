using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSC.PreRetroVoting.DataAccess.Model
{
  public sealed class RetroItem
  {
    public Guid Id { get; set; }

    public string Description { get; set; }

    public string[] VoterNames { get; set; }

    public override bool Equals(object obj)
    {
      var retroItem = obj as RetroItem;
      if (retroItem == null)
        return false;

      var voterNamesAreEqual = VoterNames == retroItem.VoterNames;
      if (!voterNamesAreEqual && VoterNames != null && retroItem.VoterNames != null)
        voterNamesAreEqual = VoterNames.SequenceEqual(retroItem.VoterNames);
      
      return Description == retroItem.Description && voterNamesAreEqual;
    }

    public override int GetHashCode()
    {
      if (Description == null)
        return 0;

      return Description.GetHashCode();
    }

    public override string ToString()
    {
      return Description;
    }
  }
}
