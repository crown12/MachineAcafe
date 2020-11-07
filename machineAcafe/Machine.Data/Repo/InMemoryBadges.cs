using Machine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.Data.Repo
{
    public class InMemoryBadges : IBadge
    {
        public List<Badge> badges;
        public InMemoryBadges()
        {
            badges = new List<Badge> { 
                new Badge { Id = 1, Name = "Ali", Serial = "1234" },
                new Badge { Id = 2, Name = "David", Serial = "5678" }
            };
        }

        public Badge Find(string serial=null)
        {
            return badges.SingleOrDefault(b => b.Serial == serial);
        }
    }
}
