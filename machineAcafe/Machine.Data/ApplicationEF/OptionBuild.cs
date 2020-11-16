using Microsoft.EntityFrameworkCore;

namespace Machine.Data.ApplicationEF
{
    public partial class AppDbContext
    {
        public class OptionBuild
        {
            public OptionBuild()
            {
                Settings = new AppConfiguration();
                OpsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                OpsBuilder.UseSqlServer(Settings.SqlConnection);

                dbOptions = OpsBuilder.Options;
            }

            public DbContextOptionsBuilder<AppDbContext> OpsBuilder { get; set; }
            public DbContextOptions<AppDbContext> dbOptions{ get; set; }
            public AppConfiguration Settings { get; set; }
        }



    }
}
