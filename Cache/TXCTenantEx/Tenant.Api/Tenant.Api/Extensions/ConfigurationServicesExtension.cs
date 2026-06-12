using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Data.SqlClient;
using TXC.Common.Data;

namespace Tenant.Api.Extensions
{
    public static class ConfigurationServicesExtension
    {
        public static void ConfigureDataOperations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDapperOperation>(dapper => new DapperOperation());
            services.AddScoped<IDbConnection>(db => new SqlConnection(configuration.GetSection("Tenant-ConnectionString:DefaultConnection").Value));
            //services.AddScoped<IDbConnection, SqlConnection>();
            services.AddScoped<IDbCommand>(cmd => new SqlCommand { CommandTimeout = Convert.ToInt32(configuration.GetSection("SqlCommand:CommandTimeout").Value) });
        }
    }
}
