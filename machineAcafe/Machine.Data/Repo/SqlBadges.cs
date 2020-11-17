using Machine.Core.Entities;
using Machine.Data.ApplicationEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Data.Repo
{
    public class SqlBadges : IBadge
    {
        private readonly AppDbContext context;
        
        public SqlBadges(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Badge> Find(string serial)
        {
            
            return await context.badges?.SingleOrDefaultAsync(b => b.Serial.Equals(serial));
        }
    }
}
