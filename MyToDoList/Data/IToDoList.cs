namespace MyToDoList.Data;

public interface IToDoList
{
    void Add(string task);

    bool Delete(int id);

    void MarkAsCompleted(int id);

    List<Task> ToDoItems();

    List<Task> DoneItems();

    bool Contains(int id);
}
