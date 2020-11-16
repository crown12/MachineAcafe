using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machine.Data.ApplicationEF
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var appConfig = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            opsBuilder.UseSqlServer(appConfig.SqlConnection);

            return new AppDbContext(opsBuilder.Options);
        }
    }
}
