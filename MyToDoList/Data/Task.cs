
using System.Text.Json.Serialization;

namespace MyToDoList.Data;

public class Task
{
    public string Description { get; }
    public DateTime CreatedTime { get; }

    public DateTime? CompletedTime { get; private set; }

    public Task(string description) : this(description, DateTime.Now, null) { }

    [JsonConstructor]
    public Task(string description, DateTime createdTime, DateTime? completedTime)
    {
        Description = description;
        CreatedTime = createdTime;
        CompletedTime = completedTime;
    }

    public void Complete()
    {
        CompletedTime = DateTime.Now;
    }
}
