namespace DotnetCleanApiStarter.Models;

/// <summary>
/// Sample domain entity used by the starter's demo endpoints.
/// Replace or extend this with your own models.
/// </summary>
public class TaskItem
{
public Guid Id { get; init; } = Guid.NewGuid();

public required string Title { get; set; }

public bool IsDone { get; set; }

public DateTime CreatedAtUtc { get; init; } = DateTime.UtcNow;
}
