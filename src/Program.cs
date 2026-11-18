using DotnetCleanApiStarter.Middleware;
using DotnetCleanApiStarter.Models;
using DotnetCleanApiStarter.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}

var tasks = app.MapGroup("/api/tasks").WithTags("Tasks");

tasks.MapGet("/", (ITaskRepository repo) => Results.Ok(repo.GetAll()));

tasks.MapGet("/{id:guid}", (Guid id, ITaskRepository repo) =>
  repo.GetById(id) is { } task ? Results.Ok(task) : Results.NotFound());

tasks.MapPost("/", (CreateTaskRequest request, ITaskRepository repo) =>
  {
  var task = repo.Add(new TaskItem { Title = request.Title });
return Results.Created($"/api/tasks/{task.Id}", task);
});

tasks.MapDelete("/{id:guid}", (Guid id, ITaskRepository repo) =>
  repo.Delete(id) ? Results.NoContent() : Results.NotFound());

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();

public record CreateTaskRequest(string Title);
