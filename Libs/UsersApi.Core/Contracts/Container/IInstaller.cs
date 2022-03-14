using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UsersApi.Core.Contracts.Container;

public interface IInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}