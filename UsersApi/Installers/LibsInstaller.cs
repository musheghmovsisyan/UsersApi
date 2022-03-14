using UsersApi.Core.Contracts.Container;
using UsersApi.Infrastructure;

namespace UsersApi.Installers;

public class LibsInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterInfrastructerServices(configuration);
    }
}