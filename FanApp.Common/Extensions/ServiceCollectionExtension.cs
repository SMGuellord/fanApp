using FanApp.Common.Database;
using FanApp.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FanApp.Common.Services
{
    public static class ServiceCollectionExtension 
    {
        public static IServiceCollection AddFanAppSqlConnection(this IServiceCollection services)
        {
            //services.AddDbContext<FanAppContext>(
            //    options => options.UseSqlServer("name=ConnectionStrings:Default", contextBuilder =>
            //    contextBuilder.MigrationsAssembly("FanApp"))
            //    );
            services.AddOptions<ConnectionDetails>().BindConfiguration("Referrence_db");
            services.AddDbContext<FanAppContext>((provider, option) =>
            {
                var connectionDetails = provider.GetRequiredService<IOptions<ConnectionDetails>>();
                option.UseSqlServer(BuildConnectionDetails(connectionDetails.Value),
                    ops => ops.MigrationsAssembly("FanApp"));
            });
            return services;
        }

        private static string BuildConnectionDetails(ConnectionDetails connectionsDetails)
        {
            return @$"Server=tcp:{connectionsDetails.Server},1433;Initial Catalog={connectionsDetails.Database_Name};
                    Persist Security Info=False;User ID={connectionsDetails.User};Password={connectionsDetails.Password};
                    MultipleActiveResultSets=False; Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        }
    }
}
