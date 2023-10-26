using System.Text;
using System.Text.Json;

namespace MyToDoList.Data;

public class ToDoList : IToDoList
{
    private readonly List<Task> _todoTasks = new List<Task>();
    private readonly List<Task> _doneTasks = new List<Task>();

    private const string _filePath = "../../../toDoList.json";

    public ToDoList() 
    {
        List<Task> allTasks = Load();

        if (allTasks != null)
        {
            foreach (var task in allTasks) 
            {
                if (task.CompletedTime != null)
                {
                    _doneTasks.Add(task);
                }
                else
                {
                    _todoTasks.Add(task);
                }
            }
        }
    }

    public void Add(string taskDescr)
    {
        _todoTasks.Add(new Task(taskDescr));
    }

    public bool Delete(int id)
    {
        if (Contains(id))
        {
            _todoTasks.RemoveAt(id);
            return true;
        }

        return false;
    }

    public void MarkAsCompleted(int id)
    {
        if (Contains(id))
        {
            var task = _todoTasks[id];
            task.Complete();
            _todoTasks.RemoveAt(id);
            _doneTasks.Add(task);
        }
    }

    public bool Contains(int id)
    {
        if (_todoTasks.Count > id && id >= 0)
        {
            var task = _todoTasks[id];

            if (task != null)
            {
                return true;
            }
        }

        return false;
    }

    public List<Task> ToDoItems()
    {
        return _todoTasks;
    }

    public List<Task> DoneItems()
    {
        return _doneTasks;
    }

    public void Save()
    {
        List<Task> allTasks = new List<Task>();

        allTasks.AddRange(_todoTasks);
        allTasks.AddRange(_doneTasks);

        File.WriteAllText(_filePath, JsonSerializer.Serialize(allTasks));
    }

    public List<Task> Load()
    {
        if (File.Exists(_filePath))
        {
            string fileContext = File.ReadAllText(_filePath);

            if (string.IsNullOrEmpty(fileContext))
            {
                return new List<Task>();
            }

            return JsonSerializer.Deserialize<List<Task>>(fileContext) ?? new List<Task>();
        }

        File.Create(_filePath);

        return new List<Task>();
    }
}
