using TodoList.Api.Validations;
using TodoList.Core.Abstractions;
using TodoList.Core.Services;
using TodoList.EntityFrameworkRepository;
using FluentValidation;
using FluentValidation.AspNetCore;
using TodoList.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// standard .net services
builder.Services.AddLogging();
builder.Services.AddHttpLogging();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();

// validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTodoListRequestValidator>();

builder.Services.AddTransient<IRepository, EntityFrameworkRepository>();
builder.Services.AddTransient<ITodoListService, TodoListService>();

// adding EF Core
ServiceConfig.AddEntityFramework(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionsMiddleware>();
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
