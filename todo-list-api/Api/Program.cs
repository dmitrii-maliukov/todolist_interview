using TodoList.Core.Abstractions;
using TodoList.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// standard .net services
builder.Services.AddLogging();
builder.Services.AddHttpLogging();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();

builder.Services.AddTransient<ITodoListService, TodoListService>();

var app = builder.Build();

app.UseHttpLogging();
app.UseHealthChecks("/health");

app.MapControllers();

// TODO: open this only for dev
app.MapOpenApi();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

app.Run();
