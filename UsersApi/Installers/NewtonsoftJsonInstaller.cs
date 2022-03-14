using Newtonsoft.Json;
using UsersApi.Core.Contracts.Container;

namespace UsersApi.Installers;

public class NewtonsoftJsonInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        var jsSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.None,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
        };

        services.AddSingleton(jsSettings);
    }
}