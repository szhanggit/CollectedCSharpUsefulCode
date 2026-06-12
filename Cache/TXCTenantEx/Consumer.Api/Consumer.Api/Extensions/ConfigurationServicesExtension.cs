using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Consumer.Api.Extensions
{
    public static class ConfigurationServicesExtension
    {
        public static void ConfigureDataOperations(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<IDapperOperation>(dapper => new DapperOperation());

            services.AddScoped<ITenantDbConnection, TenantDbConnection>();
            //services.Configure<ShardConfiguration>(options => configuration.GetSection("ShardConfiguration").Bind(options));
            //services.AddSingleton<ITenantShardMapHelper, TenantShardMapHelper>();

            //services.AddScoped<IDbCommand>(cmd => new SqlCommand { CommandTimeout = Convert.ToInt32(configuration.GetSection("SqlCommand:CommandTimeout").Value) });
        }
    }
}
