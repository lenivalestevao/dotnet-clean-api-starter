using System.Collections.Concurrent;
using DotnetCleanApiStarter.Models;

namespace DotnetCleanApiStarter.Repositories;

public interface ITaskRepository
{
  IEnumerable<TaskItem> GetAll();
TaskItem? GetById(Guid id);
TaskItem Add(TaskItem task);
bool Delete(Guid id);
}

/// <summary>
/// In-memory implementation so the starter runs with zero setup.
/// Swap this for an EF Core / Dapper / Mongo implementation when you're ready
/// — nothing outside this class needs to change, since consumers depend on ITaskRepository.
/// </summary>
public class InMemoryTaskRepository : ITaskRepository
{
private readonly ConcurrentDictionary<Guid, TaskItem> _tasks = new();

public IEnumerable<TaskItem> GetAll() => _tasks.Values.OrderBy(t => t.CreatedAtUtc);

public TaskItem? GetById(Guid id) => _tasks.TryGetValue(id, out var task) ? task : null;

public TaskItem Add(TaskItem task)
{
  _tasks[task.Id] = task;
return task;
}

public bool Delete(Guid id) => _tasks.TryRemove(id, out _);
}
