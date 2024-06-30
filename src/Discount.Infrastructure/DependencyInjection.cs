using Dapr.Client;
using Discount.Core.Repositories;
using Discount.Infrastructure;
using Discount.Infrastructure.Configurations;
using Discount.Infrastructure.Helpers;
using Discount.Infrastructure.Repositories;
using Ecart.Core;
using Ecart.Core.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Discount.Infrastructure;
public static class DependencyInjection
{
    public static async Task<IServiceCollection> AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDaprConfiguration(configuration);
        services.AddSqlConfiguration(configuration);

        var daprConfig = services.BuildServiceProvider().GetRequiredService<IOptions<DaprConfig>>().Value;
        var sqlConfig = services.BuildServiceProvider().GetRequiredService<IOptions<SqlConfig>>().Value;
        var daprClient = services.BuildServiceProvider().GetRequiredService<DaprClient>();

        await daprClient.WaitForSidecarAsync();
        var secretKeys = await daprClient.GetSecretAsync(daprConfig.SecretstoreName, Constants.DatabaseCredentialsKey);
        var credentials = secretKeys[Constants.DatabaseCredentialsKey];

        var connectionString = new ConnectionStringBuilder()
            .WithServer(sqlConfig.ServerName)
            .WithPort(sqlConfig.ServerPort)
            .WithDatabase(sqlConfig.DatabaseName)
            .WithCredentials(credentials)
            .Build();

        var databaseOptions = new DatabaseOptions
        {
            ConnectionString = connectionString 
        };

        services.AddSingleton(databaseOptions);
        services.AddScoped<IDiscountRepository, DiscountRepository>();
        services
            .AddHealthChecks()
            .AddNpgSql(connectionString);

        return services;
    }
}
