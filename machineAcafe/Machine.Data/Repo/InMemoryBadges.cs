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

        public bool Find(string serial)
        { 
            return  (from b in badges
                     where b.Serial.StartsWith(serial)
                     select b).Count() > 0 ? true : false;
        }
    }
}
