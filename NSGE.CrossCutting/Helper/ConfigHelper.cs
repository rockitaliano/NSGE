using Microsoft.Extensions.Configuration;

namespace NSGE.CrosCutting.Helper
{
    public class ConfigHelper
    {
        private static readonly IConfiguration Configuration;

        static ConfigHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public static int CacheExpiracao
        {
            get
            {
                return Convert.ToInt32(Configuration["Config:Cache:Expiracao:Minutos"]);
            }
        }

        public static bool ModeDebug
        {
            get
            {
                return Convert.ToBoolean(Configuration["Config:Debug"]);
            }
        }
    }
}