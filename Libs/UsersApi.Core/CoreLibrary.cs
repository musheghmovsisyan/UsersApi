using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsersApi.Core.Application.Services;
using UsersApi.Core.Contracts.Services;

namespace UsersApi.Core;

public static class CoreLibrary
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IAuthorizationService, AuthorizationService>();

        return services;
    }
}