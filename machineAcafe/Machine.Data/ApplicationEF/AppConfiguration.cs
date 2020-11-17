using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Machine.Data.ApplicationEF
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            //var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var path = Path.Combine(@"E:\users\Exam\machineAcafe\machineAcafe", "appsettings.json");
            configBuilder.AddJsonFile(path, false);

            var root = configBuilder.Build();
            var appSetting = root.GetSection("ConnectionStrings:MachineCafe");

            SqlConnection = appSetting.Value;
        }

        public string SqlConnection { get; set; }
    }
}
