using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Core.Abstractions;

namespace TodoList.EntityFrameworkRepository;

public static class ServiceConfig
{
    public static void AddEntityFramework(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IRepository, EntityFrameworkRepository>();
        AddDbContext(services, configuration);
    }

    public static void AddEntityFrameworkForDecoration(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<EntityFrameworkRepository>();
        AddDbContext(services, configuration);
    }

    private static void AddDbContext(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TodoListDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("Default")));
    }
}