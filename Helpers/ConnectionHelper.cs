using System.IO;
using Microsoft.Extensions.Configuration;

namespace TodoApi1.Helpers
{
    public static class ConnectionHelper
    {
        public static string GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            return config.GetConnectionString("ConnApi");
        }
    }
}
