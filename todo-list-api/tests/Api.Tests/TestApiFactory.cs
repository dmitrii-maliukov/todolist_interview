using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Core.Abstractions;

namespace Api.Tests;

internal class TestApiFactory : WebApplicationFactory<Program>
{
    public Mock<ITodoListService> TodoListServiceMock = new Mock<ITodoListService>();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddTransient<ITodoListService>((x) => TodoListServiceMock.Object);
        });
    }

}