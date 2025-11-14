using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoList.Core.Abstractions;

namespace TodoList.MemoryCacheRepository;

public static class ServiceConfig
{
    public static void AddCachedEntityFramework(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMemoryCache();

        EntityFrameworkRepository.ServiceConfig
            .AddEntityFrameworkForDecoration(services, configuration);
        services.AddTransient<IRepository>(sp =>
            new CachedEfRepository(
                sp.GetRequiredService<EntityFrameworkRepository.EntityFrameworkRepository>(),
                sp.GetRequiredService<IMemoryCache>(),
                sp.GetRequiredService<ILogger<CachedEfRepository>>()));
    }
}