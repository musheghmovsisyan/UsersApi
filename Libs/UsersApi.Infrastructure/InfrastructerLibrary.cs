using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsersApi.Core;
using UsersApi.Core.Contracts.Common;
using UsersApi.Core.Contracts.Repositories;
using UsersApi.Infrastructure.Data;
using UsersApi.Infrastructure.Repositories;

namespace UsersApi.Infrastructure;

public static class InfrastructerLibrary
{
    public static IServiceCollection RegisterInfrastructerServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<UsersApiDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(DbConnections.UsersConnectionString)));

        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IUserSessionRepository, UserSessionRepository>();

        services.RegisterApplicationServices(configuration);

        return services;
    }
}