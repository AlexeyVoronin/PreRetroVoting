using System;
using System.Collections.Generic;
using System.Linq;

namespace RSC.PreRetroVoting.DataAccess.Model
{
    public sealed class RetroItem
    {
        public RetroItem()
        {
            Id = Guid.NewGuid();
        }

        public RetroItem(string description)
            : this()
        {
            Description = description;
        }

        public Guid Id { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> VoterNames
        {
            get
            {
                return _voterNames;
            }
        }

        public bool Vote(string identity)
        {
            if (!_voterNames.Contains(identity))
            {
                _voterNames.Add(identity);
                return true;
            }

            return false;
        }

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

        private readonly IList<string> _voterNames = new List<string>();

    }
}
