
namespace MyToDoList.Data;

public class Task
{
    public string Description { get; }
    public DateTime CreatedTime { get; }

    public DateTime? CompletedTime { get; private set; }

    //public Task(string description)
    //{
    //    Description = description;
    //    CreatedTime = DateTime.Now;
    //}

    public Task(string description, DateTime createdTime, DateTime completedTime)
    {
        Description = description;
        CreatedTime = createdTime;
        CompletedTime = completedTime;
    }

    public Task(string description)
    {
        Description = description;
        CreatedTime = DateTime.Now;
    }

    public void Complete()
    {
        CompletedTime = DateTime.Now;
    }
}
