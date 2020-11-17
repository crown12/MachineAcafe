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

            var path = Directory.GetCurrentDirectory();
            var rootProject = Directory.GetParent(path) + "\\machineAcafe";
            
            var pathMain = Path.Combine(rootProject, "appsettings.json");
           
           
            configBuilder.AddJsonFile(pathMain, false);

            var root = configBuilder.Build();
            var appSetting = root.GetSection("ConnectionStrings:MachineCafe");

            SqlConnection = appSetting.Value;
        }

        public string SqlConnection { get; set; }
    }
}
