using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TodoList.EntityFrameworkRepository;

public static class ServiceConfig
{
    public static void AddEntityFramework(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TodoListDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("Default")));
    }
}